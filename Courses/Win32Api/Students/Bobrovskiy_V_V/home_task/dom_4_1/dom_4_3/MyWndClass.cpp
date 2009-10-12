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
//========================================
void MyWndClass::drawXOY(HWND hWnd) {
/// draw axis
	HDC hDC = ::GetDC(hWnd);
	RECT rect;
	::GetClientRect(hWnd,&rect);
	const int left_margin = 40;
	const int bottom_margin = 60;
	const int right_margin = 40;
	//---
	const int top_margin = 40;
	const int leftv_margin = 60;
	const int bottomv_margin = 20;
	//---
	HPEN hPen = ::CreatePen(0,2,RGB(0,0,0));
	::SelectObject(hDC,hPen);
	//--x-	
	::MoveToEx(hDC,left_margin,rect.right-bottom_margin,0);
	::LineTo(hDC,rect.right-right_margin,rect.right-bottom_margin);
	::TextOut(hDC,rect.right-right_margin - 20,rect.right-bottom_margin+5,"тис.грн.",strlen("тис.грн."));
	//--y-
	::MoveToEx(hDC,leftv_margin,top_margin,0);
	::LineTo(hDC,leftv_margin,rect.bottom-bottomv_margin);	
	::TextOut(hDC,leftv_margin -60,top_margin,"млн.чол.",strlen("млн.чол."));
	//---
	::DeleteObject(hPen);
	::ReleaseDC(hWnd,hDC);
};
int MyWndClass::leftv_margin = 0;
void MyWndClass::drawBar(HWND hWnd,const int barWidth, const int barHeight,const COLORREF color,const char* text) {
/// draw column on axis
	HDC hDC = ::GetDC(hWnd);
	RECT rect;
	::GetClientRect(hWnd,&rect);
	//---
	const int bottom_margin = 41;
	leftv_margin = leftv_margin + 65;	 
	//---
	HBRUSH hOld, hNew;	 
    hNew = CreateSolidBrush (color);         
    hOld = (HBRUSH)SelectObject(hDC,hNew);
	//---
	::TextOut(hDC,leftv_margin, rect.bottom - bottom_margin - barHeight - 20,text,lstrlen(text));

	::Rectangle(hDC,leftv_margin, rect.bottom - bottom_margin - barHeight, leftv_margin + barWidth, rect.bottom - bottom_margin); 
	//---
	leftv_margin += (barWidth/3);
	//---
	 SelectObject(hDC,hOld);   
    ::ReleaseDC(hWnd,hDC);
    ::DeleteObject(hNew);		
};
//========================================
LRESULT MyWndClass::WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
	PAINTSTRUCT ps;
	RECT rect;
		
	switch(uMsg) {
	case WM_PAINT: {
		::BeginPaint(hWnd, &ps);
		//-----------------------
				drawXOY(hWnd);
				drawBar(hWnd, 40, 350, RGB(200,45,45), "7 млн. чол.");
				drawBar(hWnd, 40, 250, RGB(180,40,40), "5 млн.  чол.");
				drawBar(hWnd, 40, 150, RGB(160,35,35), "3 млн.  чол.");
				drawBar(hWnd, 40, 125, RGB(140,30,30), "2.5 млн.  чол.");
				drawBar(hWnd, 40, 100, RGB(120,25,25), "2 млн.  чол.");
				drawBar(hWnd, 40, 50, RGB(100,20,20), "1 млн.  чол.");
				leftv_margin = 0;
		//-----------------------
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
	hMainWnd=CreateWindow(this->szClassName.c_str(), "Hallo man ", WS_OVERLAPPEDWINDOW|WS_EX_TOOLWINDOW,
		100, 100, 600, 600,(HWND)NULL,
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