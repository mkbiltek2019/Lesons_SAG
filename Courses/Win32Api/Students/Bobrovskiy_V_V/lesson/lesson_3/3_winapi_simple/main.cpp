#include <windows.h>
/*
To compile this progect need change solution:
1_example->Properties->Character Set: Not Set or Use Multi-Byte Character Set 
*/
//--
LRESULT CALLBACK WndProc(HWND ,UINT ,WPARAM ,LPARAM );

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,LPSTR lpCmdLine,int nCmdShow)
{
	HWND hMainWnd=NULL;
	char szClassName[]="MyClass";
	MSG msg;
	WNDCLASSEX wc;
	//----
	wc.cbSize=sizeof(wc);
	wc.style=CS_HREDRAW | CS_VREDRAW;
	wc.lpfnWndProc=WndProc;
	wc.cbClsExtra=0;
	wc.cbWndExtra=0;
	wc.hInstance=hInstance;
	wc.hIcon=LoadIcon(NULL,IDI_APPLICATION);
	wc.hCursor=LoadCursor(NULL,IDC_ARROW);
	wc.hbrBackground=(HBRUSH)GetStockObject(WHITE_BRUSH);
	wc.lpszMenuName=NULL;
	wc.lpszClassName=szClassName;
	wc.hIconSm =LoadIcon(NULL,IDI_APPLICATION);
	//---
	if(!RegisterClassEx(&wc)){
		MessageBox(NULL,"Error cant register class...","Hallo ",MB_OK);
		return 0;
	};
	//---
	hMainWnd=CreateWindow(szClassName,"Hallo man ",WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT,0,CW_USEDEFAULT,0,(HWND)NULL,
		(HMENU)NULL,(HINSTANCE)hInstance,NULL);
	if(!hMainWnd){
		MessageBox(NULL,"Can't create main window...","Hallo ",MB_OK);
		return 0;
	};
  //----
	ShowWindow(hMainWnd,nCmdShow);
	//---
	while(GetMessage(&msg,NULL,0,0)){
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	};
	return msg.wParam;
}
//--
LRESULT CALLBACK WndProc(HWND hWnd,UINT uMsg,WPARAM wParam,LPARAM lParam){
	HDC hDC;
	PAINTSTRUCT ps;
	RECT rect;
	//----
	switch(uMsg){
	case WM_PAINT:
		hDC=BeginPaint(hWnd,&ps);
		GetClientRect(hWnd,&rect);
		DrawText(hDC,"Hallo ",-1,&rect,DT_SINGLELINE|DT_CENTER|DT_VCENTER);
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
