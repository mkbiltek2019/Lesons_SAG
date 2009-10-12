#ifndef _MY_WND_CLASS_
#define _MY_WND_CLASS_
//----------------------
#include "windows.h"
#include <string>
#include "time.h"
#include "math.h"
//---
class MyWndClass{
private:
	HWND hMainWnd;
	MSG msg;
	UINT umsg;
	WNDCLASSEX wc;
	HINSTANCE hInstance;
	std::string szClassName;
	static int x;
	static int y;
	static MOUSEHOOKSTRUCT* mstruct;
	//--------
	static LRESULT CALLBACK WndProc(const HWND hWnd,const UINT uMsg,const WPARAM wParam,const LPARAM lParam);
	static void random_window_pos(const HWND hWnd,const LPARAM lParam);
	//---------
	void CreateWndClass();
	int CreateWnd();
public:
	MyWndClass(){};
	MyWndClass(const HINSTANCE hInstance);		
	int Run();
};
//----------------------
#endif