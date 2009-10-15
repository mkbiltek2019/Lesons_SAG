#ifndef _MY_WND_CLASS_
#define _MY_WND_CLASS_
//----------------------
#include "windows.h"
#include <string>
#include <wingdi.h>
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
	void DrawRomb(HWND hWnd);
	void DrawLines(HWND hWnd);
	void randXY(POINT &a1,POINT &a2, const int max);
	const POINT randxy(const int max);
	void DrawRectangles(HWND hWnd);
	//-----
	void circleDiagram(HWND hWnd);
	//---
	void CreateWndClass();
	int CreateWnd();
	//---
	
public:
	MyWndClass();
	MyWndClass(HINSTANCE hInstance);		
	int Run();
};
//---
typedef MyWndClass* pMyWndClass;
//----------------------
#endif