#ifndef _MY_WND_CLASS_
#define _MY_WND_CLASS_
//----------------------
#include "windows.h"
#include <string>
#include "time.h"
//---
LRESULT CALLBACK WndProc(HWND ,UINT ,WPARAM ,LPARAM );
class MyWndClass{
private:
	HWND hMainWnd;
	MSG msg;
	UINT umsg;
	WNDCLASSEX wc;
	HINSTANCE hInstance;
	std::string szClassName;
	static RECT rc;
	static HRGN hRng;
	//--------
	static LRESULT CALLBACK WndProc(HWND hWnd,UINT uMsg,WPARAM wParam,LPARAM lParam);
	static VOID CALLBACK TimerProc(HWND hwnd, UINT uMsg, UINT_PTR idEvent, DWORD dwTime);
	//---------
	static void make_window_transparent(const HWND hWnd,const BYTE transparency,const COLORREF rgb);
	static void draw_timer(const HWND hWnd);
	static void on_wm_create(const HWND hWnd);
	//---------
	void CreateWndClass();
	int CreateWnd();
public:
	MyWndClass(){};
	MyWndClass(HINSTANCE hInstance);		
	int Run();
};
//----------------------
#endif