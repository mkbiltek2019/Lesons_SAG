#include <windows.h>
#include <math.h>
#include <tchar.h>
#include "CMyWindow.h"
#include "resource.h"

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
VOID CALLBACK TimerProc( HWND hWnd, UINT uMsg, UINT_PTR idEvent, DWORD dwTime);
void DrawBall(HWND hWnd);
char szSoundName[] = "MY_SOUND"; 
HINSTANCE hInst;
HRGN hRgn;
int xb = 3;
int yb = 3;
int radius = 10;
int x = 10;
int y = 10;
int score = 0;
int out = 0;
int border = 0;
static int mousex = 0;
static int mousey = 0;
COLORREF BackgroundColor = RGB(0, 130, 0);
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	MSG msg;
	CMyWindow mainWnd("Теннис", hInstance, nCmdShow, WndProc);	

	while (GetMessage(&msg, NULL, 0, 0))  {
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return msg.wParam;
}

void DrawBall(HWND hWnd)
{
	     HDC hDC = GetDC(hWnd); 
		 RECT rect; 
		 GetClientRect(hWnd,&rect);
	     HPEN hPen = CreatePen(PS_SOLID, 2, RGB(0, 0, 0));
		 HBRUSH hBrush = CreateSolidBrush(BackgroundColor);
		 HBRUSH hBackgroundBrush = CreateSolidBrush(RGB(255, 255, 255));
		 HRGN hRgn = CreateRectRgn(x-radius-abs(xb),y-radius-abs(yb),x+radius+abs(xb),y+radius+abs(yb));
		
		 HPEN hOldPen = (HPEN)SelectObject (hDC, hPen);
         HBRUSH hOldBrush = (HBRUSH)SelectObject (hDC, hBrush);
		 HBRUSH hOldBackgroundBrush = (HBRUSH)SelectObject (hDC, hBackgroundBrush);
	     HRGN hOldRgn=(HRGN)SelectObject (hDC, hRgn);
		
		 FillRgn(hDC, hRgn, hOldBackgroundBrush);	
         
		 x += xb;
		 y += yb;
	  
		 if ((x - radius) < (rect.left))
		 {
			 x = radius;
		     xb = -xb;
			 PlaySound (szSoundName, hInst, SND_RESOURCE | SND_ASYNC);
		 }
		
		 if ((y - radius) <( rect.top))
		 {
			 y = radius;
		     yb = -yb;
			 PlaySound (szSoundName, hInst, SND_RESOURCE | SND_ASYNC);
		 }
		
		 if (( x+ radius) >= rect.right)
		 {
			  x = rect.right-radius;
			  xb = -xb;
			  PlaySound (szSoundName, hInst, SND_RESOURCE | SND_ASYNC);
		 }

		
		 if ((y + radius) > rect.bottom-border)
		 {
			  y = rect.bottom-border-radius;
			  yb = -yb;
			  PlaySound (szSoundName, hInst, SND_RESOURCE | SND_ASYNC);
		 }	
	    

         
		 Ellipse(hDC, x-radius, y-radius, x+radius, y+radius);

		 SelectObject(hDC, hOldRgn);	
		 SelectObject(hDC, hOldBackgroundBrush);	
		 SelectObject(hDC, hOldPen);		
		 SelectObject(hDC, hOldBrush);

		 DeleteObject(hRgn);
		 DeleteObject(hBackgroundBrush);
		 DeleteObject(hBrush);
		 DeleteObject(hPen);

		 ReleaseDC(hWnd, hDC);
		 InvalidateRect(hWnd, &rect, false);
}
VOID CALLBACK TimerProc( HWND hWnd, UINT uMsg, UINT_PTR idEvent, DWORD dwTime)
{
	DrawBall(hWnd);
    
	if(((mousex - 30) < x)&&((mousex + 30) > x)&&(y > 570)&&(y < 590))
	{
		border = 62;
		score += 1;
	} 
	else/* if(y == 590)*/
	{
		border = 0;
		out += 1;
	}
	/*TCHAR s[25];
		wsprintf(s,_T(" Очки = %d Ауты = %d"), score, out);
		SetWindowText(hWnd, s);*/
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC;
	PAINTSTRUCT ps;
	RECT rect;
	int userReply;
	HBRUSH hBrush;
	HBRUSH hOldBrush;
	HBRUSH hBackgroundBrush;
	HBRUSH hOldBackgroundBrush;
	HPEN hPen;
	HPEN hOldPen;
	HRGN hRgn;
	HRGN hOldRgn;
	TCHAR str[50];
	HINSTANCE hInst;
	HICON hIcon;
	HICON hIconSm;

	switch (uMsg)
	{
	case WM_CREATE:
		hDC = GetDC(hWnd);
		SetTimer(hWnd, 1, 1, TimerProc);
		SetClassLong(hWnd,GCL_HBRBACKGROUND,(LONG)CreateSolidBrush(BackgroundColor));
		hInst = GetModuleHandle(NULL);
		hIcon = LoadIcon(hInst, MAKEINTRESOURCE(IDI_ICON1));
		hIconSm = (HICON)LoadImage(hInst,MAKEINTRESOURCE(IDI_ICON1),IMAGE_ICON, 16, 16, LR_DEFAULTCOLOR);
		SetClassLong(hWnd, GCL_HICON, (LONG)hIcon);
		SetClassLong(hWnd, GCL_HICONSM, (LONG)hIcon);
		break;
	case WM_TIMER:
		TCHAR s[25];
		wsprintf(s,_T(" Очки = %d Ауты = %d"), score, out);
		SetWindowText(hWnd, s);
		break;
	case WM_PAINT:
		hDC = BeginPaint(hWnd, &ps);

		GetClientRect(hWnd, &rect);
		
		EndPaint(hWnd, &ps);
		break;
	case WM_MOUSEMOVE:
		//wsprintf(str, TEXT("X=%d  Y=%d"), LOWORD(lParam), HIWORD(lParam)); // текущие координаты курсора мыши
		//SetWindowText(hWnd, str);	// строка выводится в заголовок окна
		hDC = GetDC(hWnd);
        mousex = LOWORD(lParam);
		mousey = HIWORD(lParam);
		rect.left = mousex-80;
		rect.top = 640-15;
		rect.right = mousex+80;
		rect.bottom = 640+5;
		hPen = CreatePen(PS_SOLID, 1, RGB(0, 0, 0));
		hBrush = CreateSolidBrush(BackgroundColor);
		hBackgroundBrush = CreateSolidBrush(RGB(255, 0, 0));
		hRgn = CreateRectRgn(mousex-80, 600-15, mousex+80, 600+5);
        hOldPen = (HPEN)SelectObject(hDC, hPen);
        hOldBrush = (HBRUSH)SelectObject(hDC, hBrush);
		hOldBackgroundBrush = (HBRUSH)SelectObject(hDC, hBackgroundBrush);
		hOldRgn = (HRGN)SelectObject(hDC, hRgn);
		FillRgn(hDC, hRgn, hOldBackgroundBrush);
		if(mousex > 940) mousex = 930;
		if(mousex < 10) mousex = 10;
		Rectangle(hDC, mousex-30, 600-15, mousex+30, 600);
		SelectObject(hDC, hOldRgn);
		SelectObject(hDC, hOldBackgroundBrush);
		SelectObject(hDC, hOldPen);
		SelectObject(hDC, hOldBrush);
		DeleteObject(hRgn);
		DeleteObject(hBackgroundBrush);
		DeleteObject(hBrush);
		DeleteObject(hPen);
        ReleaseDC(hWnd, hDC);
		InvalidateRect(hWnd, &rect, false);
        break;
	case WM_CLOSE:
		userReply = MessageBox(hWnd, "А вы уверены в своем желании закрыть приложение?",
			"", MB_YESNO | MB_ICONQUESTION);
		if (IDYES == userReply)
			DestroyWindow(hWnd);
		break;

    case WM_DESTROY:
		KillTimer(hWnd, 1);
		PostQuitMessage(0);
		break;

	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}

	return 0;
}

