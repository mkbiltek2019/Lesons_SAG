//-- simple game arcanoid using GDI writen under pure WIN32API using c++ 
//--
#ifndef _MY_WND_CLASS_
#define _MY_WND_CLASS_
//----------------------
#include "windows.h"
#include <string>
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
	//--------
	static COLORREF FontColor;
	static int x;
	static int y;
	static int xv;
	static int yv;
	static int radius;
	static void SetXY(const HWND hWnd);
	static void DrawCircle(const HDC hDC,const int x, const int y);
	static VOID CALLBACK TimerProc(const HWND hWnd,const UINT uMsg,const UINT_PTR idEvent,const  DWORD dwTime);
	static void  MoveCircle(const HWND hWnd);
	//----
	static LRESULT CALLBACK WndProc(const HWND ,const UINT ,const WPARAM ,const LPARAM );	
	//--------
	static const LOGFONT DefineFont(const HWND hWnd, const int heigth,const int width);
	static void drawGameData(const HWND hWnd);
	void CreateWndClass();
	int CreateWnd();
public:
	MyWndClass(){};
	MyWndClass( const HINSTANCE hInstance);		
	int Run();	
};
//----------------------
#endif