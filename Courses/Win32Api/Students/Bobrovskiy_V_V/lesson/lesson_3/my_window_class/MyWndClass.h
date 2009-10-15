#ifndef _MY_WND_CLASS_
#define _MY_WND_CLASS_
//----------------------
#include "windows.h"
#include <string>
//---
//LRESULT CALLBACK WndProc(HWND ,UINT ,WPARAM ,LPARAM );
class MyWndClass{
private:
	HWND hMainWnd;
	MSG msg;
	UINT umsg;
	WNDCLASSEX wc;
	HINSTANCE hInstance;
	std::string szClassName;
	//--------
	void SetWndClass();
	static LRESULT CALLBACK WndProc(HWND hWnd,UINT uMsg,WPARAM wParam,LPARAM lParam);
	int CreateWnd();
	//-------
public:
	MyWndClass(){};
	/* need to declare window procedure as static method of class */	
	MyWndClass(HINSTANCE hInstance);		
	int Run();
};
//----------------------
#endif