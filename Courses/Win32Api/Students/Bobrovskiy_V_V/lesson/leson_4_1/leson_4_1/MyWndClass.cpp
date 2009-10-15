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
void MyWndClass::randXY(POINT &a1,POINT &a2, const int max) {
	a1.x = rand()%max;
	a1.y = rand()%max;
	a2.x = rand()%max;
	a2.y = rand()%max;
}
//----------------------
const POINT MyWndClass::randxy(const int max){
	POINT p;
	p.x = rand()%max;
	p.y = rand()%max;
	return p;
};
//----------------------
void MyWndClass::DrawLines(HWND hWnd){
		RECT rect;
		HDC hDC = GetDC(hWnd);
		::GetClientRect(hWnd,&rect);
		//-----------
		int max = rect.right;
		//-----------
		POINT a1,a2;
		for(int i=0; i<2000; ++i){						
			HPEN hPen = ::CreatePen(PS_DOT|PS_GEOMETRIC|PS_ENDCAP_ROUND, 0, RGB(rand()%255,rand()%255,rand()%255));
			::SelectObject(hDC,hPen);
			//randXY(a1,a2,max);			
			  a1 = randxy(max);			
			::MoveToEx(hDC,a1.x,a1.y,0);
			  a2 = randxy(max);
			::LineTo(hDC,a2.x,a2.y);
			::DeleteObject(hPen);			
		}		
};
//----------------------
void MyWndClass::DrawRomb(HWND hWnd) {
		//=========== cool romb ========================
		RECT rect;
		POINT center;
		HDC hDC = GetDC(hWnd);
		::GetClientRect(hWnd,&rect);
		//-----------
		center.x = (rect.right + rect.left)/2;
		center.y = (rect.top + rect.bottom)/2;
		//-----------
		//for(int i=0; i<2000; ++i){
		int hstep = 50;//+i*5;  //cool
		int vstep = 50;// +i*5; //cool
		POINT a1,a2,a3,a4;
		a1 = a2 = a3 = a4 = center;
		//--------------------------------------
		HPEN hPen = ::CreatePen(PS_SOLID, 0, RGB(0,255,255));
		::SelectObject(hDC,hPen);

		::SetPixel(hDC,center.x,center.y,RGB(0,0,0));
		a1.x = a1.x - hstep;
		a2.y = a2.y - vstep;
		a3.x = a3.x + hstep;
		a4.y = a4.y + vstep;
		//-----
		::MoveToEx(hDC,a1.x,a1.y,0);
		::LineTo(hDC,a2.x,a2.y);
		
		::MoveToEx(hDC,a2.x,a2.y,0);
		::LineTo(hDC,a3.x,a3.y);
		
		::MoveToEx(hDC,a3.x,a3.y,0);
		::LineTo(hDC,a4.x,a4.y);
		
		::MoveToEx(hDC,a4.x,a4.y,0);
		::LineTo(hDC,a1.x,a1.y);
		::DeleteObject(hPen);
		//}
		//----- draw diagonals -----
		hPen = ::CreatePen(PS_DASHDOT, 1, RGB(255,0,0));
		::SelectObject(hDC,hPen);
		
		::MoveToEx(hDC,a1.x,a1.y,0);
		::LineTo(hDC,a3.x,a3.y);
		
		::MoveToEx(hDC,a2.x,a2.y,0);
		::LineTo(hDC,a4.x,a4.y);

		::ReleaseDC(hWnd,hDC);
		::DeleteObject(hPen);
		//====================================
		////-------- static romb ---
		//::MoveToEx(hDC,75,50,0);
		//::SetPixel(hDC,75,50,RGB(0,0,0));
		////----------------------
		//::MoveToEx(hDC,50,50,0);
		////--
		//::LineTo(hDC,75,25);
		//::MoveToEx(hDC,75,25,0);
		////--
		//::LineTo(hDC,100,50);
		//::MoveToEx(hDC,100,50,0);
		////--
		//::LineTo(hDC,75,75);
		//::MoveToEx(hDC,75,75,0);
		////--
		//::LineTo(hDC,50,50);
		////------------------------
};
//----------------------
void MyWndClass::DrawRectangles(HWND hWnd){
	RECT rect;
	HDC hDC = GetDC(hWnd);
	::GetClientRect(hWnd,&rect);
	int arr[10] = { LTGRAY_BRUSH, GRAY_BRUSH, DKGRAY_BRUSH,        
		BLACK_BRUSH,       NULL_BRUSH, HOLLOW_BRUSH,        
		WHITE_PEN,         BLACK_PEN,           
		NULL_PEN,          OEM_FIXED_FONT };
	for(int i=0 ; i<9; ++i) {
		HBRUSH hBr = (HBRUSH)::GetStockObject(arr[i]);
		::SelectObject(hDC,hBr);
		::Rectangle(hDC,10+i*30,10+i*30,40+i*30,40+i*30);
		::DeleteObject(hBr);		
	}
};
//---------------------
void MyWndClass::circleDiagram(HWND hWnd){
	RECT rect;
	HDC hDC = GetDC(hWnd);
	::GetClientRect(hWnd,&rect);
	/*int arr[10] = { LTGRAY_BRUSH, GRAY_BRUSH, DKGRAY_BRUSH,        
		BLACK_BRUSH,       NULL_BRUSH, HOLLOW_BRUSH,        
		WHITE_PEN,         BLACK_PEN,           
		NULL_PEN,          OEM_FIXED_FONT };*/
	//for(int i=0 ; i<2; ++i) {
		HBRUSH hBr = (HBRUSH)::GetStockObject(GRAY_BRUSH);
		::SelectObject(hDC,hBr);
		::Pie(hDC,10,10,50,50,0,0,100,0);
		::DeleteObject(hBr);	

		hBr = (HBRUSH)::GetStockObject(BLACK_BRUSH);
		::SelectObject(hDC,hBr);
		::Pie(hDC,10,10,50,50,0,0,250,150);
		::DeleteObject(hBr);

		hBr = (HBRUSH)::GetStockObject(LTGRAY_BRUSH);
		::SelectObject(hDC,hBr);
		::Pie(hDC,10,10,50,50,0,0,60,290);
		::DeleteObject(hBr);
	//}

};
//----------------------
LRESULT MyWndClass::WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
	PAINTSTRUCT ps;
	RECT rect;

	switch(uMsg) {
	case WM_PAINT: {
		::BeginPaint(hWnd, &ps);
		HDC hDC = GetDC(hWnd);
		::GetClientRect(hWnd,&rect);
		//-- rainbow pixel output
	/*	int max = 255;	
		  ::SetPixel(hDC,100,100,RGB(max,0,0));
		  ::SetPixel(hDC,200,100,RGB(max,max,0));
		  ::SetPixel(hDC,300,100,RGB(max,max,max));
		  ::SetPixel(hDC,400,100,RGB(max,0,max));
		  ::SetPixel(hDC,500,100,RGB(0,max,0));
		  ::SetPixel(hDC,550,100,RGB(max,0,0));
		  ::SetPixel(hDC,560,100,RGB(0,0,max));
		  ::SetPixel(hDC,570,100,RGB(0,max,max));
	*/		
		//-- output screen resolution 	
		/*char bf1[120];
		char bf2[15];	
		  ::lstrcat(bf1,"Screen resolution: (");
		int horz = GetDeviceCaps(hDC, HORZRES);
		  itoa(horz,bf2,10);
		  ::lstrcat(bf1,bf2);
		int vert = GetDeviceCaps(hDC, VERTRES);
			  itoa(vert,bf2,10);
		  ::lstrcat(bf1," , ");
		  ::lstrcat(bf1,bf2);		
		  ::lstrcat(bf1,")");
		::DrawText(hDC,bf1,-1,&rect,DT_CENTER|DT_VCENTER);	*/
		//--- Draw rect --------
		//DrawRomb(hWnd);	
		//DrawLines(hWnd);
		//DrawRectangles(hWnd);
		circleDiagram(hWnd);
		//-----------------------
		::ReleaseDC(hWnd,hDC);
		::EndPaint(hWnd, &ps);
		
	   }
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	};
	return 0;
};
//---------------------
void MyWndClass::CreateWndClass() {
	this->szClassName="MyClassTimer";
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
	hMainWnd=CreateWindow(this->szClassName.c_str(), "Hallo man ", WS_OVERLAPPEDWINDOW,
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