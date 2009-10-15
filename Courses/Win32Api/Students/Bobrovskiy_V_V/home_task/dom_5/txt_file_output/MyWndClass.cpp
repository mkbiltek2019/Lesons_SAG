#include "MyWndClass.h"
//----------------------
MyWndClass::MyWndClass() {	
	SetWindowLong( hMainWnd, GWL_USERDATA, (LONG)this);
	SetWindowLong( hMainWnd, GWL_WNDPROC, (LONG)WndProcStub); 
};
//----------------------
MyWndClass::MyWndClass(HINSTANCE hInstancem):hInstance(hInstancem) {
	SetWindowLong( hMainWnd, GWL_USERDATA, (LONG)this);
	SetWindowLong( hMainWnd, GWL_WNDPROC, (LONG)WndProcStub);	
};
//----------------------
LRESULT CALLBACK MyWndClass::WndProcStub(HWND hWnd,UINT msg,WPARAM wParam,LPARAM lParam) {
	pMyWndClass pThis = (pMyWndClass)GetWindowLong(hWnd, GWL_USERDATA);
	return pThis->WndProc(hWnd, msg, wParam, lParam);
};
//----------------------
LRESULT MyWndClass::WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
	PAINTSTRUCT ps;
	RECT rect;
	::GetClientRect(hWnd,&rect);
	static CTxtFileLoader txtFile;
	static bool up = true;
	HDC hDC;
	TEXTMETRIC tm;
	int cxClient=0, cyClient=0;
	static int xInc, yInc;	
	//-------------
	switch(uMsg) {
//-------------1-----------------
	case WM_CREATE:{
		hDC = GetDC(hWnd);
		GetTextMetrics(hDC, &tm);
		txtFile.Initialize(&tm); 
		ReleaseDC(hWnd, hDC);
	}break;
//------------2-------------------
	case WM_VSCROLL:
		switch(LOWORD(wParam)) {
		case SB_LINEUP:
			yInc = -1;
			break;

		case SB_LINEDOWN:
			yInc = 1;
			break;

		case SB_PAGEUP:
			yInc = -(int)txtFile.vsi.nPage;
			break;

		case SB_PAGEDOWN:
			yInc = (int)txtFile.vsi.nPage;
			break;

		case SB_THUMBTRACK:
			yInc = HIWORD(wParam) - txtFile.vsi.nPos;
			break;

		default:
			yInc = 0;
		}
		txtFile.UpdateVscroll(hWnd, yInc);	
		break;
//------------3-------------------
	case WM_HSCROLL:{
		switch(LOWORD(wParam)) {
		case SB_LINELEFT:
			xInc = -1;
			break;

		case SB_LINERIGHT:
			xInc = 1;
			break;

		case SB_PAGELEFT:
			xInc = -0.8 * (int)txtFile.hsi.nPage;
			break;

		case SB_PAGERIGHT:
			xInc = 0.8 * (int)txtFile.hsi.nPage;
			break;

		case SB_THUMBTRACK:
			xInc = HIWORD(wParam) - txtFile.hsi.nPos;
			break;

		default:
			xInc = 0;
		}
		txtFile.UpdateHscroll(hWnd, xInc);		
	}break;
//-------------4-----------------
	case WM_SETFOCUS:{
		if(up){
		 txtFile.LoadNextPage();
		 txtFile.LoadPrevPage();	
		 ::InvalidateRect(hWnd,&rect,false);
		}else {
		    txtFile.LoadPrevPage();
			txtFile.LoadNextPage();			
			::InvalidateRect(hWnd,&rect,false);
		}
		}break;
//------------5-----------------
	case WM_SIZE:{		
		hDC = GetDC(hWnd);
		cxClient = LOWORD(lParam);
		cyClient = HIWORD(lParam);
		if (cxClient > 0)
			txtFile.ScrollSettings(hWnd, cxClient, cyClient);
		ReleaseDC(hWnd, hDC);
				
		}break;
//-----------6--------------------
	case WM_KEYDOWN:{
		if(wParam==VK_PRIOR){
			txtFile.LoadPrevPage();				
			up = true;
			::InvalidateRect(hWnd,&rect,false);
		}
		else if(wParam==VK_NEXT) {
			up = false;
			txtFile.LoadNextPage();				
			::InvalidateRect(hWnd,&rect,false);
		}
	  }break;
//-----------7--------------------
	case WM_PAINT: {
		::BeginPaint(hWnd, &ps);
	   	if(up){
		    txtFile.DrawPageText(hWnd);
		}else {
		 	txtFile.DrawPageText(hWnd);	
		}		
		::EndPaint(hWnd, &ps);
		}
	break;
//---------------8-----------------
	case WM_MOUSEWHEEL:{
	   if (((short) HIWORD(wParam))<0) {
                yInc = (int)txtFile.vsi.nPage;
				SendMessage (hWnd,WM_PAINT,0,0); 
         } else {
                 yInc = -(int)txtFile.vsi.nPage;
				SendMessage (hWnd,WM_PAINT,0,0);  
         }	
	   txtFile.UpdateVscroll(hWnd, yInc);	
	}break;
//--------------------------------
	case WM_DESTROY:
		PostQuitMessage(0);
	break;
//--------------------------------
	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	};
	return 0;
};
//---------------------
void MyWndClass::CreateWndClass() {
	this->szClassName="MyTxtViewer";
	//--
	wc.cbSize = sizeof(wc);
	wc.style = CS_HREDRAW | CS_VREDRAW;
	wc.lpfnWndProc = WndProcStub;
	wc.cbClsExtra = 0;
	wc.cbWndExtra=0;
	wc.hInstance = this->hInstance;
	wc.hIcon = LoadIcon(NULL,IDI_EXCLAMATION);
	wc.hCursor = LoadCursor(NULL,IDC_HAND);	
	wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	wc.lpszMenuName = NULL;
	wc.lpszClassName = szClassName.c_str();
	wc.hIconSm = LoadIcon(NULL, IDI_EXCLAMATION);
};
//---
int MyWndClass::CreateWnd(){
	if(!RegisterClassEx(&this->wc)){
		throw "Error can't register window class";		
	};
	//--
	hMainWnd=CreateWindow(this->szClassName.c_str(), "Simple text viewer ", WS_TILEDWINDOW | WS_VSCROLL | WS_HSCROLL,
		100, 100, 700, 700,(HWND)NULL,
		(HMENU)NULL, (HINSTANCE)this->hInstance, NULL);
	//--
	if(!hMainWnd){
		throw "Cant create main window";		
	};
	return 0;
};
//---
int MyWndClass::Run() {
	//--
	CreateWndClass();
	//--
	CreateWnd();
	//--
	ShowWindow(hMainWnd, SW_SHOWNORMAL);
	//--
	while(GetMessage(&msg, NULL, 0, 0)) {
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	};
	return msg.wParam;
};
//---