#ifndef _MY_WND_CLASS_
#define _MY_WND_CLASS_
//----------------------
#include "windows.h"
#include <string>
#include <wingdi.h>
#include "math.h"
//----------------------
class MyWndClass{
private:
	HWND hMainWnd;
	MSG msg;
	UINT umsg;
	WNDCLASSEX wc;
	HINSTANCE hInstance;
	std::string szClassName;
	//here using the stub function mechanizm to avoid static variables and function in WndProc.
	static LRESULT CALLBACK WndProcStub(HWND hwnd,UINT msg,WPARAM wParam,LPARAM lParam);
	LRESULT WndProc(HWND hwnd,UINT msg,WPARAM wParam,LPARAM lParam);
	//---
	MyWndClass();
	void CreateWndClass();
	int CreateWnd();
	//---
	void drawXOY(HWND hWnd);
	void drawBar(HWND hWnd,const int barWidth, const int barHeight,const COLORREF color,const char* text);
	//---
	static int leftv_margin;
public:	
	MyWndClass(HINSTANCE hInstance);		
	int Run();
};
//---
typedef MyWndClass* pMyWndClass;
//----------------------
#endif