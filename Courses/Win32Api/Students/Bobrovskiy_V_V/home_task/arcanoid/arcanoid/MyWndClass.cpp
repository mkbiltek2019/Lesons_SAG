#include "MyWndClass.h"
//----------------------
int MyWndClass::x=10;
int MyWndClass::y=10;
int MyWndClass::xv=1;
int MyWndClass::yv=1;
int MyWndClass::radius=10;
COLORREF MyWndClass::FontColor=RGB(200,160,255);
//----------------------
static int border = 0;
static int mousex = 0;
static int mousey = 0;
static int Score = 0;
const int scoreadd = 5;
static int maxscore = 50;
static int Life = 3;
static int Level =1;
bool gameOver = false;
//----------------------
void MyWndClass::DrawCircle(const HDC hDC,const int x, const int y){
	::Ellipse(hDC,x-radius,y-radius,x+radius,y+radius);
}
//----------------------
void MyWndClass::SetXY(const HWND hWnd){
	RECT r; 
	::GetClientRect(hWnd,&r);
	r.right = r.right-170;
	//-----------------------
		 x += xv;
		 y += yv;
	    //----- left border--
		 if ((x-radius) < (r.left)){
			 x =radius;
		  xv = -xv;
		 }
		//------top border --
		 if ((y-radius) <( r.top)){
			 y =radius;
		  yv = -yv;
		 }
		//-----right border--
		 if ((x+radius) >= r.right){
		  x = r.right-radius;
		  xv = -xv;
		 }

		//-----bottom border--
		 if ((y+radius) > r.bottom-border){
		  y = r.bottom-border-radius;
		  yv = -yv;
		 }	
	    //--------------------
};
//----------------------

const LOGFONT MyWndClass::DefineFont(const HWND hWnd, const int heigth,const int width){
///------
	LOGFONT tmpFont;
	
    tmpFont.lfHeight = heigth;
    tmpFont.lfWidth =width;
    tmpFont.lfEscapement =0;
    tmpFont.lfOrientation =0;
    tmpFont.lfWeight = FW_NORMAL;
    tmpFont.lfItalic = false;
    tmpFont.lfUnderline = false;
    tmpFont.lfStrikeOut = false;
    tmpFont.lfCharSet = RUSSIAN_CHARSET;
    tmpFont.lfOutPrecision = OUT_DEFAULT_PRECIS;
    tmpFont.lfClipPrecision  = CLIP_DEFAULT_PRECIS;
    tmpFont.lfQuality = CLEARTYPE_QUALITY;
    tmpFont.lfPitchAndFamily = DEFAULT_PITCH;
	lstrcpy(tmpFont.lfFaceName,"Times");

	return tmpFont;
};
//----------------------
void MyWndClass::drawGameData(const HWND hWnd){
	int startPos = 10;
	HDC hDC = ::GetDC(hWnd);
	RECT rect;
	rect.left = 636;
	rect.top = 0;
	rect.right = 800;
	rect.bottom = 600;
	//------
	 ::MoveToEx(hDC,635,0,0);
		::LineTo(hDC,635,600);
	HBRUSH hBrush = CreateSolidBrush(RGB(210,181,194));
	::FillRect(hDC,&rect,hBrush);
	::DeleteObject(hBrush);
	::SetTextColor(hDC,RGB(164,38,50));
	::SetBkColor(hDC,RGB(210,181,194));
	::SetBkMode(hDC,TRANSPARENT);
	//---------
	LOGFONT logFont = DefineFont(hWnd,16,8);
	HFONT hFon = ::CreateFontIndirect(&logFont);
	HFONT oldFont = (HFONT)::SelectObject(hDC,hFon);			
	//---	
	std::string sp,lev,score,len,life;
	//---
	char buf[10];
	sp.append("Speed: ");
	sp.append(itoa(Level,buf,10));
	::TextOut(hDC, 635+5, startPos, sp.c_str(), sp.length());
	//---
	startPos+=40;
	lev.append("Level: ");
	lev.append(itoa(Level,buf,10));
	::TextOut(hDC, 635+5, startPos, lev.c_str(), lev.length());
	//---
	startPos+=40;
	score.append("Score: ");
	score.append(itoa(Score,buf,10));
	::TextOut(hDC, 635+5, startPos, score.c_str(), score.length());
	//---
	startPos+=40;
	life.append("Life: ");
	life.append(itoa(Life,buf,10));
	::TextOut(hDC, 635+5, startPos, life.c_str(), life.length());
	//---
	::SelectObject(hDC,oldFont);
	::DeleteObject(hFon);
	::InvalidateRect(hWnd,&rect,false);
	::ReleaseDC(hWnd,hDC);	
};
//----------------------
void  MyWndClass::MoveCircle(const HWND hWnd){
//-------------------------------------	
		HDC hDC=GetDC(hWnd); 
		RECT rect; 
		GetClientRect(hWnd,&rect);
		 ::MoveToEx(hDC,635,0,0);
		::LineTo(hDC,635,600);
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
		 ::FillRgn(hDC,hrgn,hOldFontBrush);	
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
		::InvalidateRect(hWnd,&rect,false);
};
//----------------------
VOID CALLBACK MyWndClass::TimerProc(const HWND hWnd,const UINT uMsg,const UINT_PTR idEvent,const DWORD dwTime){
	MoveCircle(hWnd);
	static bool once = true;
	//--------------
	if(((mousex-30)<x)&&((mousex+30)>x)&&(y>470)&&(y<510)) {
		border = 100;
		Score += scoreadd;
		if(Score>maxscore) {
			maxscore+=maxscore;
			++Level;
			++xv; ++yv;
		}
	} else if(y==520){
		border = 0;
		if(once){
		 --Life; once=false;
		}else {
			once=true;
		}		
		 if(Life==0) {
			gameOver = true;
		 }
	} else {
		border = 0;
		if(Life==0) {
			gameOver = true;
		 }
	}
	//--------------
	drawGameData(hWnd);
};
//----------------------
LRESULT CALLBACK MyWndClass::WndProc(const HWND hWnd,const UINT uMsg,const WPARAM wParam,const LPARAM lParam){
	//----
	static HDC hDC=NULL;
	static BOOL track = false;
	//----
	switch(uMsg){
	//-------
	case WM_CREATE:{
		hDC = ::GetDC(hWnd);
		SetTimer(hWnd, 1,1,TimerProc );
		SetClassLong(hWnd,GCL_HBRBACKGROUND,(LONG)CreateSolidBrush(FontColor));	
		
	}break;
	//-------
	case WM_MOUSEMOVE :{		
		//------draw rectangle--------
		HDC hDC=GetDC(hWnd); 
		RECT rect;
		//----------
		 ::MoveToEx(hDC,635,0,0);
		::LineTo(hDC,635,600);
		//----------
		 mousex = LOWORD(lParam); 
		 mousey = HIWORD(lParam);
		//----------
		 rect.left = mousex-80;
		 rect.top = 500-13;		
		 rect.right = mousex+80;
		 rect.bottom = 500+3;
		//---------------------------
		 HPEN hPen = CreatePen(PS_SOLID, 1, RGB(0,255, 0));
		 HBRUSH hBrush = CreateSolidBrush(FontColor);
		 HBRUSH hFontBrush=::CreateSolidBrush(RGB(255,0,0));
		 HRGN hrgn=::CreateRectRgn(mousex-80,500-13,mousex+80,500+3);
		//---------------------------
		 HPEN hOldPen = (HPEN)SelectObject (hDC, hPen);
         HBRUSH hOldBrush = (HBRUSH)SelectObject (hDC, hBrush);
		 HBRUSH hOldFontBrush = (HBRUSH)SelectObject (hDC, hFontBrush);
	     HRGN hOldrgn=(HRGN)SelectObject (hDC, hrgn);
		//--------------------------	
		 ::FillRgn(hDC,hrgn,hOldFontBrush);	
		//---------------------------			
		 if(mousex>600) mousex=600;
		 if(mousex<50) mousex=30;
		
		 ::Rectangle(hDC,mousex-30,500-10,mousex+30,500);
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
		::InvalidateRect(hWnd,&rect,false);
		//--------	
		if(gameOver) {
			::KillTimer(hWnd,1);
			//-------------------
			HDC hDC = ::GetDC(hWnd);
			 LOGFONT logFont = DefineFont(hWnd,80,40);
			  HFONT hFon = ::CreateFontIndirect(&logFont);
			   HFONT oldFont = (HFONT)::SelectObject(hDC,hFon);
			::SetTextColor(hDC,RGB(255,0,0));
		     ::TextOut(hDC, 80, 250, "Game Over", strlen("Game Over"));
			::SelectObject(hDC,oldFont);
			::DeleteObject(hFon);
		   ::ReleaseDC(hWnd,hDC);
			//-------------------
			 Sleep(5000);			  
			PostQuitMessage(0);
		}
	} break;
	//-------
	case WM_DESTROY:{
		::KillTimer(hWnd,1);
		PostQuitMessage(0);
	} break;
	
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
	wc.style=CS_VREDRAW|CS_HREDRAW;
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
		100 ,100 ,800 ,600 ,(HWND)NULL,
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