#include <windows.h>
#include <stdio.h>
#include "CMyWindow.h"
#include "resource.h"

char szSoundName[] = "MY_SOUND";

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	MSG msg;
	CMyWindow mainWnd("Uraine today", hInstance, nCmdShow, WndProc, NULL, 400, 250, 400, 300);	

	while (GetMessage(&msg, NULL, 0, 0))  {
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return msg.wParam;
}

HRGN hRgn;

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC;
	PAINTSTRUCT ps;
	RECT rect;
	int userReply;
	HINSTANCE hInst;
	HICON hIcon;
	HICON hIconSm;
	static HBITMAP hBmpUkraineFlag;
    HDC hMemDC;
	static BITMAP bm;

	switch (uMsg)
	{
	case WM_CREATE:
        hInst = GetModuleHandle(NULL);
		hIcon = LoadIcon(hInst, MAKEINTRESOURCE(IDI_ICON1));
		hIconSm = (HICON)LoadImage(hInst,MAKEINTRESOURCE(IDI_ICON1),IMAGE_ICON, 16, 16, LR_DEFAULTCOLOR);
		SetClassLong(hWnd, GCL_HICON, (LONG)hIcon);
		SetClassLong(hWnd, GCL_HICONSM, (LONG)hIcon);
		hBmpUkraineFlag = LoadBitmap(hInst, MAKEINTRESOURCE(IDB_BITMAP1));
		GetObject(hBmpUkraineFlag, sizeof(bm),(LPSTR)&bm);

		PlaySound ("MY_SOUND", hInst, SND_RESOURCE | SND_ASYNC);
		/*ShellExecute(hWnd, "open", "Himn.mp3", NULL, NULL, SW_SHOW);*/
		break;
	case WM_PAINT:
		hDC = BeginPaint(hWnd, &ps);

		GetClientRect(hWnd, &rect);
		DrawText(hDC, "Здравствуй, World!", -1, &rect,
			DT_SINGLELINE | DT_CENTER | DT_VCENTER );
		hMemDC = CreateCompatibleDC(hDC);
		SelectObject(hMemDC, hBmpUkraineFlag);
		BitBlt(hDC, 0, 0, bm.bmWidth, bm.bmHeight, hMemDC, 0, 0, SRCCOPY);
		DeleteDC(hMemDC);

		EndPaint(hWnd, &ps);
		break;

	case WM_CLOSE:
		userReply = MessageBox(hWnd, "А вы уверены в своем желании закрыть приложение?",
			"", MB_YESNO | MB_ICONQUESTION);
		if (IDYES == userReply)
			DestroyWindow(hWnd);
		break;

    case WM_DESTROY:
		PostQuitMessage(0);
		break;

	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}

	return 0;
}