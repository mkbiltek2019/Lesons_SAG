#include "MyWndClass.h"
//----------------------
MyWndClass::MyWndClass() {	
};
//----------------------
MyWndClass::MyWndClass(HINSTANCE hInstancem):hInstance(hInstancem) {
};
//----------------------
LRESULT CALLBACK MyWndClass::WndProcStub(HWND hWnd,UINT msg,WPARAM wParam,LPARAM lParam) {
	pMyWndClass pThis = (pMyWndClass)GetWindowLong(hWnd, GWL_USERDATA);
	return pThis->WndProc(hWnd, msg, wParam, lParam);
};
//----------------------
LRESULT MyWndClass::WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
	PAINTSTRUCT ps;

	
	static int x= 0,y = 0,zDelta = 0 ;
	static HDC hDC=NULL;
	static BOOL track = false;

	switch(uMsg) {
	//---------
	/*case WM_LBUTTONDOWN: {
		::MessageBox(hWnd,"Left mouse button clicked ","Mouse",0);	   
	}break;*/
	//---------
	//case WM_LBUTTONUP: {
	//	::MessageBox(hWnd,"UP mouse button clicked ","Mouse",0);		   
	//}break;
	//-------
	/*case WM_LBUTTONDBLCLK : {
		::MessageBox(hWnd,"Double mouse button clicked ","Mouse",0);				   
	}break;*/
	//-------
	case WM_CREATE : {
		hDC = ::GetDC(hWnd);	
		x = LOWORD(lParam); 
		y = HIWORD(lParam);
		::MoveToEx(hDC,x,y,0);	
	}break;
	//---------
	case WM_LBUTTONDOWN: {
		track = true; 
			x = LOWORD(lParam); 
			y = HIWORD(lParam);
			::MoveToEx(hDC,x,y,0);			   
	}break;
	//----------
	case WM_LBUTTONUP: {
		track = false; 			
			//::MoveToEx(hDC,x,y,0);			   
	}break;	
	//----------
	case WM_MOUSEHWHEEL : {		
			zDelta =(short) HIWORD(wParam);
			char buf[10];
			 std::string str;
			 str.append(itoa(zDelta,buf,10));
			 ::SetWindowText(hWnd,str.c_str());
			 //::TextOut(hDC,20,20,str.c_str(),lstrlen(str.c_str()));

	} break;
	//----------
	case WM_MOUSEMOVE : {
		if(track) {		 
		//---------------------
		//RECT rect;
		//::GetClientRect(hWnd,&rect);
		////-----
		//LOGBRUSH logBrush;
		//logBrush.lbStyle = 0;
		//logBrush.lbColor = RGB(255, 255, 255);
		//logBrush.lbHatch = HS_CROSS;

		////-----
		//HBRUSH br = ::CreateBrushIndirect(&logBrush);
		//::SelectObject(hDC,br);
		//::FillRect(hDC,&rect,br);
		//::DeleteObject(br);
		//	 ::InvalidateRect(hWnd,&rect,false);
		//	track = true; 
		//-------------
			//x = LOWORD(lParam); 
			//y = HIWORD(lParam);
			////--------
			//char buf[10];
			// std::string str;
			// str.append(itoa(x,buf,10));
			// str.append(" , ");
			// str.append(itoa(y,buf,10));
			////--------
			// ::TextOut(hDC,x,y-15,str.c_str(),lstrlen(str.c_str()));
			::LineTo(hDC,x,y);
			// RECT rect;
			 /*rect.bottom = y+20;
			 rect.right = x+20;
			 rect.left = x-20;
			 rect.top = y-20;*/
			 //---			
		}

	}break;
	//----------
	case WM_DESTROY:
		::DeleteDC(hDC);
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	};
	return 0;
};
//---------------------

//---------------------
void MyWndClass::CreateWndClass() {
	this->szClassName="MyClassTimer";
	//--
	wc.cbSize = sizeof(wc);
	wc.style = CS_HREDRAW | CS_VREDRAW | CS_DBLCLKS; // CS_DBLCLKS this parameter used for catching double mouse click 
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
	hMainWnd=CreateWindow(this->szClassName.c_str(), "Hallo man ", WS_OVERLAPPED,
		CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT,(HWND)NULL,
		(HMENU)NULL, (HINSTANCE)this->hInstance, NULL);
	
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