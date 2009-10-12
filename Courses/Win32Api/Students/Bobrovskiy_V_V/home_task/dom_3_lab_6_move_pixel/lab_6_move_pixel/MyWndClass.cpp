#include "MyWndClass.h"
//----------------------
int MyWndClass::x=10;
int MyWndClass::y=10;
int MyWndClass::xv=1;
int MyWndClass::yv=1;
int MyWndClass::radius=10;
COLORREF MyWndClass::FontColor=RGB(200,160,255);
//----------------------
//HFONT CreateMyFont ()
//{
//  // Создаем фонт 
//  CFont Font;
//  Font.CreateFont(
//   12,                        // nHeight
//   0,                         // nWidth
//   0,                         // nEscapement
//   0,                         // nOrientation
//   FW_NORMAL,                 // nWeight
//   FALSE,                     // bItalic
//   FALSE,                     // bUnderline
//   0,                         // cStrikeOut
//   ANSI_CHARSET,              // nCharSet
//   OUT_DEFAULT_PRECIS,        // nOutPrecision
//   CLIP_DEFAULT_PRECIS,       // nClipPrecision
//   DEFAULT_QUALITY,           // nQuality
//   DEFAULT_PITCH | FF_SWISS,  // nPitchAndFamily
//   "Arial"));                 // lpszFacename
//
//  // Возвращаем хэндл HFONT созданного шрифта
//  // По выходу из функции объект Font удалится, 
//  // в то время как хэндл созданного фонта уже будет 
//  // отсоединен от него, и с успехом будет возвращен
//  // из функции
//  return (HFONT)Font.Detach();
//}
//----------------------
void MyWndClass::DrawCircle(const HDC hDC,const int x, const int y){
	::Ellipse(hDC,x-radius,y-radius,x+radius,y+radius);
}
//----------------------
void MyWndClass::SetXY(const HWND hWnd){
	RECT r; 
	::GetClientRect(hWnd,&r);
	//-----------------------
		 x += xv;
		 y += yv;
		 if ((x-radius) < (r.left)){
			 x =radius;
		  xv = -xv;
		 }
		//-------
		 if ((y-radius) <( r.top)){
			 y =radius;
		  yv = -yv;
		 }
		//-------
		 if ((x+radius) >= r.right){
		  x = r.right-radius;
		  xv = -xv;
		 }
		//-------
		 if ((y+radius) > r.bottom){
		  y = r.bottom-radius;
		  yv = -yv;
		 }		
};
//----------------------
void  MyWndClass::MoveCircle(const HWND hWnd){
//-------------------------------------	
		HDC hDC=GetDC(hWnd); 
		RECT rect; 
		GetClientRect(hWnd,&rect);
		//---------------------------
		 HPEN hPen = CreatePen(PS_SOLID, 2, RGB(0,255, 0));
		 HBRUSH hBrush = CreateSolidBrush(FontColor);
		 HBRUSH hFontBrush=::CreateSolidBrush(RGB(255,0,0));
		 HRGN hrgn=::CreateRectRgn(x-radius-::abs(xv),y-radius-::abs(yv),x+radius+::abs(xv),y+radius+::abs(yv));
		//---------------------------
		 HPEN hOldPen = (HPEN)SelectObject (hDC, hPen);
         HBRUSH hOldBrush = (HBRUSH)SelectObject (hDC, hBrush);
		 HBRUSH hOldFontBrush = (HBRUSH)SelectObject (hDC, hFontBrush);
	     HRGN hOldrgn=(HRGN)SelectObject (hDC, hrgn);
		//--------------------------	
		 ::FillRgn(hDC,hrgn,hOldFontBrush);// FillRect(hDC,&rect,hOldFontBrush);	
		//---------------------------
		 SetXY(hWnd);
		 DrawCircle(hDC,x,y);		 
		//---------------------------
		SelectObject(hDC, hOldrgn);	
		SelectObject(hDC, hOldFontBrush);	
		SelectObject(hDC, hOldPen);		
		SelectObject(hDC, hOldBrush);
		//---------------------------
		DeleteObject(hrgn);
		DeleteObject(hFontBrush);
		DeleteObject(hBrush);
		DeleteObject(hPen);
		//---------------------------
		::ReleaseDC(hWnd,hDC);
		//::DeleteDC(hDC);
		::InvalidateRect(hWnd,&rect,false);
};
//----------------------
VOID CALLBACK MyWndClass::TimerProc(const HWND hWnd,const UINT uMsg,const UINT_PTR idEvent,const DWORD dwTime){
	MoveCircle(hWnd);	
};
//----------------------
LRESULT CALLBACK MyWndClass::WndProc(const HWND hWnd,const UINT uMsg,const WPARAM wParam,const LPARAM lParam){
	//----
	switch(uMsg){
	case WM_CREATE:
		SetTimer(hWnd, 1,1,TimerProc );
		SetClassLong(hWnd,GCL_HBRBACKGROUND,(LONG)CreateSolidBrush(FontColor));	
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
MyWndClass::MyWndClass(const HINSTANCE hInstancem):hInstance(hInstancem){
};
//----
void MyWndClass::CreateWndClass(){
	this->szClassName="MyClass";
	//----
	wc.cbSize=sizeof(wc);
	wc.style=CS_OWNDC;
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
	if(!RegisterClassEx(&this->wc)){
		MessageBox(NULL,"Error cant register class","Hallo ",MB_OK);
		return 0;
	};
	//---
	hMainWnd=CreateWindow(this->szClassName.c_str(),"Hallo man ",/*WS_EX_PALETTEWINDOW|*/WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT ,CW_USEDEFAULT ,CW_USEDEFAULT ,CW_USEDEFAULT ,(HWND)NULL,
		(HMENU)NULL,(HINSTANCE)this->hInstance,NULL);
	
	if(!hMainWnd){
		MessageBox(NULL,"Cant create main window","Hallo ",MB_OK);
		return 0;
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