#include "MyWndClass.h"
//----------------------
MyWndClass::MyWndClass() {
	SetWindowLong( hMainWnd, GWL_USERDATA, (LONG)this);
	SetWindowLong( hMainWnd, GWL_WNDPROC, (LONG)WndProcStub);
};
//----------------------
LRESULT CALLBACK MyWndClass::WndProcStub(HWND hWnd,UINT msg,WPARAM wParam,LPARAM lParam) {
	pMyWndClass pThis = (pMyWndClass)GetWindowLong(hWnd, GWL_USERDATA);
	return pThis->WndProc(hWnd, msg, wParam, lParam);
};
//----------------------
LRESULT MyWndClass::WndProc(HWND hWnd,UINT uMsg,WPARAM wParam,LPARAM lParam){
	pMyWndClass pThis = (pMyWndClass)GetWindowLong(hWnd, GWL_USERDATA);
	PAINTSTRUCT ps;
	RECT rect;
	switch(uMsg){
	case WM_PAINT:{
			::BeginPaint(hWnd, &ps);
		    ::GetClientRect(hWnd,&rect);
			HDC hDC = ::GetDC(hWnd);
		//-------------1---------		
				ANSI_Tabbed_Out(hWnd);
		//---------------------------
			
		::ReleaseDC(hWnd,hDC);
		//----------------------
		::EndPaint(hWnd, &ps);	  
		}break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd,uMsg,wParam,lParam);
	};
	return 0;
};
//---------------------
void MyWndClass::ANSI_Tabbed_Out(HWND hWnd){
	RECT rect;
	::GetClientRect(hWnd,&rect);
	HDC hDC = ::GetDC(hWnd);
	//---------------
	POINT center;
	center.x = (rect.left+rect.right)/2;
	center.y = (rect.bottom+rect.top)/2;
	//---
	int x=10, y=10;
	char k=0;
	//--------------
	const int n=16;
	const int m=33;
	char** lines = new char*[n];
	for(int i=0; i<n; ++i)
		lines[i] = new char[m];
	//--------------
	for(int i=0; i<n; ++i)
		for(int j=0; j<m; ++j)
		lines[i][j]=' ';
	//--------------
	for(int i=0; i<n; ++i){
		for(int j=0; j<m; ++j){
			if(j%2!=0){
				if((int(k)>=0)&&(int(k)<32))
					lines[i][j]='o';
				else lines[i][j]=k;
			 ++k;
			}else{
				lines[i][j]='\t';
			}
		}
		lines[i][m-1]='\0';
	}
	//---
	int tabstop[m];
	for(int i=0; i<m; ++i){
		tabstop[i] =30;//horizontal_tab
	}
	//---
	int vert_tab=10;
	for ( int i=0; i<n; ++i){
		//y +=(vert_tab+ HIWORD(TabbedTextOut(hDC, x, y, lines[i], strlen(lines[i]), sizeof(tabstop) / sizeof(tabstop[0]), tabstop, x)));
		y +=(vert_tab+ HIWORD(TabbedTextOut(hDC, x, y, lines[i], strlen(lines[i]),1, tabstop,x)));
	}
		//---
	for(int i=0; i<n; ++i)
		delete[] lines[i];
	delete[] lines;
	//---------------------------------------------
	::ReleaseDC(hWnd,hDC);
	//::InvalidateRect(hWnd,&rect,false);
};
//-----------------------
//---------------------
MyWndClass::MyWndClass(HINSTANCE hInstancem):hInstance(hInstancem){
};
//----
void MyWndClass::CreateWndClass(){
	this->szClassName="MyClassTimer";
	//----
	wc.cbSize=sizeof(wc);
	wc.style=CS_HREDRAW | CS_VREDRAW;

	wc.lpfnWndProc=WndProcStub;
	wc.cbClsExtra=0;
	wc.cbWndExtra=0;
	wc.hInstance=this->hInstance;
	wc.hIcon=LoadIcon(NULL,IDI_EXCLAMATION);

	wc.hCursor=LoadCursor(NULL,IDC_HAND);
	
	wc.hbrBackground=(HBRUSH)GetStockObject(WHITE_BRUSH);

	wc.lpszMenuName=NULL;
	wc.lpszClassName=szClassName.c_str();
	wc.hIconSm =LoadIcon(NULL,IDI_EXCLAMATION);
};
//---
int MyWndClass::CreateWnd(){
	if(!RegisterClassEx(&this->wc)){
		throw "Error can't register window class";		
	};
	//---
	hMainWnd=CreateWindow(this->szClassName.c_str(),"Hallo man ",WS_OVERLAPPED,
		100,100,600,600,(HWND)NULL,
		(HMENU)NULL,(HINSTANCE)this->hInstance,NULL);
	
	if(!hMainWnd){
		throw "Cant create main window";		
	};
	return 0;
};
//---
int MyWndClass::Run(){
	//---
	CreateWndClass();
	//--
	CreateWnd();
	//--
	ShowWindow(hMainWnd,SW_SHOWNORMAL);
	//---
	while(GetMessage(&msg,NULL,0,0)){
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	};
	return msg.wParam;
};
//---