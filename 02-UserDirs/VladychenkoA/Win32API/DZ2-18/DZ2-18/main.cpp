#include <windows.h>
#include <string>
using namespace std;

#include "CMyWindow.h"
#include "resource.h"

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
BOOL CALLBACK AboutDlgProc(HWND, UINT,WPARAM, LPARAM);

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	MSG msg;
	CMyWindow mainWnd("Текстовый редактор", hInstance, nCmdShow, WndProc,MAKEINTRESOURCE(IDR_MENU1));	

	while (GetMessage(&msg, NULL, 0, 0))  {
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return msg.wParam;
}


LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC;
	PAINTSTRUCT ps;
	TEXTMETRIC  tm;
	HICON hIcon;
	HICON hIconSm;
	HINSTANCE hInst;
	int userReply;

	static string text;
	string symb;

	static int cxChar, cyChar, cxClient, cyClient;
	static int nCharPerLine, nClientLines;
	static int xCaret = 0, yCaret = 0;
	int curIndex;
	int nLines;    
	int nTailChar; 
	int x, y, i;

	switch (uMsg) {

	case WM_CREATE :
		hInst = GetModuleHandle(NULL);
        hIcon = LoadIcon(hInst, MAKEINTRESOURCE(IDI_ICON1));
		hIconSm = (HICON)LoadImage(hInst,MAKEINTRESOURCE(IDI_ICON1),IMAGE_ICON, 16, 16, LR_DEFAULTCOLOR);
		SetClassLong(hWnd, GCL_HICON, (LONG)hIcon);
		SetClassLong(hWnd, GCL_HICONSM, (LONG)hIcon);

		hDC = GetDC(hWnd);
		SelectObject(hDC, GetStockObject(SYSTEM_FIXED_FONT));
		GetTextMetrics(hDC, &tm);
		cxChar = tm.tmAveCharWidth;
		cyChar = tm.tmHeight;
		ReleaseDC(hWnd, hDC);
		break;
		case WM_COMMAND:
         {
              switch(LOWORD(wParam))
			  {
				  case ID_40007: 
				      DialogBox(GetModuleHandle(NULL), MAKEINTRESOURCE(IDD_DIALOG1), hWnd, AboutDlgProc);
				      break;
			      case ID_40005:
					  SendMessage(hWnd, WM_DESTROY, 0, 0);
					  break;
			  }
		 }
		 break;

	case WM_SIZE :
		
		cxClient = LOWORD(lParam);
		cyClient = HIWORD(lParam);
		
		nCharPerLine = max(1, cxClient / cxChar);
		nClientLines = max(1, cyClient / cyChar);

		if (hWnd == GetFocus())
			SetCaretPos(xCaret * cxChar, yCaret * cyChar);
		break;

	case WM_SETFOCUS :
		
		CreateCaret(hWnd, NULL, 0, cyChar);               // 1
		SetCaretPos(xCaret * cxChar, yCaret * cyChar);
		ShowCaret(hWnd);
		break;

	case WM_KILLFOCUS :
		
		HideCaret(hWnd);
		DestroyCaret();
		break;

	case WM_KEYDOWN:
		nLines = text.size() / nCharPerLine;
		nTailChar = text.size() % nCharPerLine;

		switch (wParam) {
		case VK_HOME:   xCaret = 0;
						break;
		case VK_END:    if (yCaret == nLines)
							xCaret = nTailChar;
						else
							xCaret = nCharPerLine - 1;
						break;
		case VK_PRIOR:  yCaret = 0;
						break;
		case VK_NEXT:   yCaret = nLines;
						xCaret = nTailChar;
						break;
		case VK_LEFT:   xCaret = max(xCaret - 1, 0);
						break;
		case VK_RIGHT:  xCaret = min(xCaret + 1, nCharPerLine - 1);
						if ((yCaret == nLines) && (xCaret > nTailChar))
							xCaret = nTailChar;
						break;
		case VK_UP:     yCaret = max(yCaret - 1, 0);
						break;
		case VK_DOWN:   yCaret = min(yCaret + 1, nLines);
						if ((yCaret == nLines) && (xCaret > nTailChar))
							xCaret = nTailChar;
						break;
		case VK_DELETE: curIndex = yCaret * nCharPerLine + xCaret;
						if (curIndex < text.size()) {
							text.erase(curIndex, 1);
							InvalidateRect(hWnd, NULL, TRUE);
						}
						break;
		}

		SetCaretPos(xCaret * cxChar, yCaret * cyChar);
		break;

	case WM_CHAR :
	switch (wParam) {
		case '\b':              
			if (xCaret > 0) {
				xCaret--;
				SendMessage(hWnd, WM_KEYDOWN, VK_DELETE, 1);
			}
			break;

		case '\t':              
			do { SendMessage(hWnd, WM_CHAR, ' ', 1L); }
			while (xCaret % 8 != 0);
			break;

		case '\r': case '\n':   

			for (i = 0; i < nCharPerLine - xCaret; ++i)
				text += ' ';
			xCaret = 0;
			if (++yCaret == nClientLines) {
				MessageBox(hWnd, "Нет места в окне", "Error", MB_OK);
				yCaret--;
			}
			break;

		default:               

			curIndex = yCaret * nCharPerLine + xCaret;
			if (curIndex == text.size())
				text += (char)wParam;
			else {
				symb = (char)wParam;			
				text.insert(curIndex, symb);
			}

			InvalidateRect(hWnd, NULL, TRUE);

			if (++xCaret == nCharPerLine) {
				xCaret = 0;
				if (++yCaret == nClientLines) {
					MessageBox(hWnd, "Нет места в окне", "Error", MB_OK);
					yCaret--;
				}
			}
			break;
		}

		SetCaretPos(xCaret * cxChar, yCaret * cyChar);
		break;

	case WM_PAINT :
		hDC = BeginPaint(hWnd, &ps);
		SelectObject(hDC, GetStockObject(SYSTEM_FIXED_FONT));

		if (text.size()) {
			nLines = text.size() / nCharPerLine;
			nTailChar = text.size() % nCharPerLine;
			for (y = 0; y < nLines; ++y)
				TextOut(hDC, 0, y*cyChar, text.c_str() + y*nCharPerLine, nCharPerLine);
			TextOut(hDC, 0, y*cyChar, text.c_str() + y*nCharPerLine, nTailChar);
		}

		EndPaint(hWnd, &ps);
		break;
		case WM_CLOSE:
		userReply = MessageBox(hWnd, "А вы уверены в своем желании закрыть приложение?",
			"", MB_YESNO | MB_ICONQUESTION);
		if (IDYES == userReply)
			DestroyWindow(hWnd);
		break;

	case WM_DESTROY :
		PostQuitMessage(0);
		break;

	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}
	return 0;
}
BOOL CALLBACK AboutDlgProc(HWND hDlg, UINT uMsg,WPARAM wParam, LPARAM lParam)
{
	 switch (uMsg)
	 {
		case WM_INITDIALOG:
			 return true;
		case WM_COMMAND:
			switch (LOWORD(wParam))
			{
			case IDOK:
			case IDCANCEL:
				EndDialog(hDlg, 0);
				return true;
			}
			break;
	 }
 return false;
}