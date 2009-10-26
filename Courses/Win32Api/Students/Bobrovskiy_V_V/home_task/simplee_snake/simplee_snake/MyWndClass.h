//--------------------
/// Some simple game Snake  
/// for grafic output using double buffering
//---------------------
#ifndef _MY_WND_CLASS_
#define _MY_WND_CLASS_
//----------------------
#include "windows.h"
#include <string>
#include "BackBuffer.h" 
#include "Vec2.h" 
//---
class MyWndClass{
private:
	HWND hMainWnd;
	MSG msg;
	UINT umsg;
	WNDCLASSEX wc;
	HINSTANCE hInstance;
	std::string szClassName;
	//---
	static LRESULT CALLBACK WndProcStub(HWND hwnd,UINT msg,WPARAM wParam,LPARAM lParam);
	LRESULT WndProc(HWND hwnd,UINT msg,WPARAM wParam,LPARAM lParam);
	//---
	void CreateWndClass();
	int CreateWnd();
	bool AppLoadIcon(const HWND hWnd);
	//---
	void create_Grid();
	void loadMap();
	void drawGrid(const HWND hWnd);
	//---
	int  Runn(const HWND hWnd); 	
	//---
	void drawGameData(const HWND hWnd);
	const LOGFONT DefineFont(const HWND hWnd, const int heigth,const int width);
	//---
public:
	MyWndClass();
	MyWndClass(HINSTANCE hInstance);		
	int Run();
};
typedef MyWndClass* pMyWndClass;

//----------------------
#endif