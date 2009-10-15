#include "MyWndClass.h"
#include "atltime.h"
#include "math.h"

//----------------------
//- need to declare window procedure as static method of class 
LRESULT CALLBACK MyWndClass::WndProc(HWND hWnd,UINT uMsg,WPARAM wParam,LPARAM lParam){
//----------	
	HDC hDC;
	PAINTSTRUCT ps;
	RECT rect;
	//----
	switch(uMsg){
	case WM_CREATE:
		SetClassLong(hWnd,GCL_HBRBACKGROUND,(LONG)CreateSolidBrush(RGB(200,160,255)));	
			break;
	case WM_PAINT:
		hDC=BeginPaint(hWnd,&ps);
		//GetClientRect(hWnd,&rect);
		for(int i=0; i<3000000; ++i)
			::SetPixel(hDC, 20+i, 20,RGB(255,0,0)); 
		//Red
		::Ellipse(hDC, 50, 50, 100, 100);
		
		EndPaint(hWnd,&ps);
		break;	
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd,uMsg,wParam,lParam);
	};
	return 0;
};
//---------------------
MyWndClass::MyWndClass(HINSTANCE hInstancem):hInstance(hInstancem){
};
//----
void MyWndClass::SetWndClass(){
	this->szClassName="MyClass";
	//----
	wc.cbSize=sizeof(wc);
	wc.style=CS_HREDRAW | CS_VREDRAW;
	
	wc.lpfnWndProc=WndProc;
	wc.cbClsExtra=0;
	wc.cbWndExtra=0;
	wc.hInstance=this->hInstance;
	wc.hIcon=LoadIcon(NULL,IDI_EXCLAMATION);
	
	wc.hCursor=LoadCursor(NULL,IDC_HAND);
		
	wc.hbrBackground=(HBRUSH)GetStockObject(LTGRAY_BRUSH);
	
	wc.lpszMenuName=NULL;
	wc.lpszClassName=szClassName.c_str();
	wc.hIconSm =LoadIcon(NULL,IDI_EXCLAMATION);
};
//---
int MyWndClass::CreateWnd(){
	//---	
	if(!RegisterClassEx(&this->wc)){
		throw("Error while register WndClass..");		
	};
	//---
	hMainWnd=CreateWindow(this->szClassName.c_str(),"Hallo man ",/*WS_EX_PALETTEWINDOW|*/WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT,0,CW_USEDEFAULT,0,(HWND)NULL,
		(HMENU)NULL,(HINSTANCE)this->hInstance,NULL);
	
	if(!hMainWnd){
		throw("Error while create window..");		
	};	
	//---
	return 0;
};
//---
int MyWndClass::Run(){
//--
	SetWndClass();
	//--
	CreateWnd();
	//--
	ShowWindow(hMainWnd,SW_SHOWNORMAL/*|SW_SHOWMAXIMIZED*/);	
	//---
	while(GetMessage(&msg,NULL,0,0)){
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	};
	return msg.wParam;
};
//---