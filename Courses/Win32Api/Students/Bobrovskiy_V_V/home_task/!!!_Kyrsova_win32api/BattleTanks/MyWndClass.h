#ifndef _MY_WND_CLASS_
#define _MY_WND_CLASS_
//----------------------
//---------------------------
#include "Sprite.h" 
#include "BackBuffer.h" 
#include <windows.h>
#include <string> 
#include <list> 
#include <vector>
#include "matrix.h"
#include <fstream>
#include <mmsystem.h>
#include "CTank.h"
#include "CDirection.h"
#include "CBullet.h"
using namespace std; 
//---------------------------
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
	//---
	
public:
	MyWndClass();
	MyWndClass(HINSTANCE hInstance);		
	int Run();
	//--------
	void create_Grid();
	void loadMap();
	int Runn();
	void DrawFramesPerSecond(float deltaTime); 
};
typedef MyWndClass* pMyWndClass;
//----------------------
#endif