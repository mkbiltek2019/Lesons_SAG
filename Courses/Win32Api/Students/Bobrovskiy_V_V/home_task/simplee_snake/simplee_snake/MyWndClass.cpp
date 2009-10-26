#include "MyWndClass.h"
#include "math.h"
#include "matrix.h"
#include <fstream>
//-----------global variable-----------
const UINT_PTR ID_TIMER = 1;
static int Speed = 200;
static int curSpeed = 1;
static int Level = 1;
static int Score = 0;
static int maxlevel = 50;
const int scoreup =5;
static int Life = 3;
bool gameOver = false;
//----
BackBuffer* gBackBuffer = 0;  

const int gClientWidth  = 600; 
const int gClientHeight = 600;  

const int gWindowWidth  = gClientWidth + 150; 
const int gWindowHeight = gClientHeight + 25; 

 RECT gMapRect = {0, 0, 600, 600};
//----------------------------------
 HPEN snakePen = NULL;  

 Vec2 snakeDir(0.0f, 0.f); 

 std::vector<POINT> snake; 
//----------------------
static int dir = 1;
const int n=30;
const int m=30;
const int margin = 20;
std::vector<POINT> grid;
matrix<int> map(n,m);
//----------------------
void MyWndClass::create_Grid(){
//----------------------
	std::ofstream write("grid.dat");

	int x = margin/2;
	 int y = margin/2;
	  POINT p;
	
	for(int i=0; i<n; ++i) {
		for(int j=0; j<m; ++j) {
			p.x=x; p.y=y;
			 write<<p.x<<" "<<p.y<<" ";
			  grid.push_back( p );
			x=x+margin;
		}
		write<<"\n";
		 x=margin/2;
	    y=y+margin;	
	};

	write.close();
};
//----------------------
void MyWndClass::loadMap(){
	std::ifstream read("map.dat");
	int buf=0;
		for(int i=0; i<n; ++i) {
		for(int j=0; j<m; ++j) {
			read>>buf;
			map[i][j] = buf;
		}
		}
	read.close();
};
//----------------------
void MyWndClass::drawGrid(const HWND hWnd){
	HDC hDC = ::GetDC(hWnd);
	RECT rect;
	::GetClientRect(hWnd,&rect);
	const int margin = 20;	
	//---
	HPEN hPen = ::CreatePen(2,1,RGB(167,175,158));
	::SelectObject(hDC,hPen);
	//--x-	
	for(int i=0; i<=rect.right; i+=margin){
	::MoveToEx(hDC,i,0,0);
	::LineTo(hDC,i,rect.bottom);	
	}	
	//--y-
	for(int j=0; j<=rect.bottom; j+=margin){
	::MoveToEx(hDC,0,j,0);
	::LineTo(hDC,rect.right,j);	
	}
	//---
	::DeleteObject(hPen);
	::ReleaseDC(hWnd,hDC);	
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
	rect.left = gClientWidth;
	rect.top = 0;
	rect.right = gWindowWidth;
	rect.bottom = gWindowHeight;
	//------
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
	sp.append(itoa(curSpeed,buf,10));
	::TextOut(hDC, gClientWidth+5, startPos, sp.c_str(), sp.length());
	//---
	startPos+=40;
	lev.append("Level: ");
	lev.append(itoa(Level,buf,10));
	::TextOut(hDC, gClientWidth+5, startPos, lev.c_str(), lev.length());
	//---
	startPos+=40;
	score.append("Score: ");
	score.append(itoa(Score,buf,10));
	::TextOut(hDC, gClientWidth+5, startPos, score.c_str(), score.length());
	//---
	startPos+=40;
	len.append("Snake length: ");
	len.append(itoa(snake.size(),buf,10));
	::TextOut(hDC, gClientWidth+5, startPos, len.c_str(), len.length());
	//---
	startPos+=40;
	life.append("Life: ");
	life.append(itoa(Life,buf,10));
	::TextOut(hDC, gClientWidth+5, startPos, life.c_str(), life.length());
	//---
	::SelectObject(hDC,oldFont);
	::DeleteObject(hFon);
	::InvalidateRect(hWnd,&rect,false);
	::ReleaseDC(hWnd,hDC);	
};
//----------------------
MyWndClass::MyWndClass() {
	SetWindowLong( hMainWnd, GWL_USERDATA, (LONG)this);
	SetWindowLong( hMainWnd, GWL_WNDPROC, (LONG)WndProcStub);
};
//---------------------
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
LRESULT MyWndClass::WndProc(HWND hWnd,UINT uMsg,WPARAM wParam,LPARAM lParam){
  LOGPEN lp; 
	
  switch(uMsg){ 
   //------------1---------
   case WM_CREATE:{  
   // Create the tank's gun pen. 
	::SetTimer(hWnd,ID_TIMER,Speed,NULL);
   //------init snake----
	POINT p; 
	   p.x =10; p.y = 10;
	   snake.push_back(p);
	   p.x =30; p.y = 10;
	   snake.push_back(p);
	   p.x =30; p.y = 10;
	   snake.push_back(p);
	//---------
	lp.lopnColor   = RGB(10, 150, 15); 
    lp.lopnStyle   = PS_SOLID; 
    lp.lopnWidth.x = 15; 
    lp.lopnWidth.y = 15; 
     snakePen = CreatePenIndirect(&lp); 
	 create_Grid();
	 loadMap();	
   // Create the backbuffer. 
    gBackBuffer = new BackBuffer(hWnd, gClientWidth, gClientHeight); 
    }break;
	//---------2----------
   case WM_KEYDOWN: {
	   int count=0;
		for(int i=0; i<n; ++i) {
			for(int j=0; j<m; ++j) {
				if(map[i][j] == 1){
					++count;
				}
			}
		}
		if(count==0) {
			int nn = rand()%n;
			int mm = rand()%m;
			 if(map[nn][mm]==2) nn = rand()%n;
			
			if((nn==n)) --nn;
				if((mm==m)) --mm;
				
			map[nn][mm]=1;
		}
	    switch(wParam) { 		  
		case VK_UP: {			
			  if(dir == 2);
                else dir = 1;
					}break;
		case VK_DOWN: {
			 if(dir == 1);
                else dir = 2;
					  }break;
		case VK_LEFT: {	
			 if(dir == 4);
                else dir = 3;
			 }break;
		case VK_RIGHT: {
			if(dir == 3);
                else dir = 4;
		}break;
	   }		 
   }break;
  //-------3----------
   case WM_TIMER: {	   
	   if(gameOver) {
		   HDC hDC = ::GetDC(hWnd);
			LOGFONT logFont = DefineFont(hWnd,80,40);
			HFONT hFon = ::CreateFontIndirect(&logFont);
			HFONT oldFont = (HFONT)::SelectObject(hDC,hFon);
			::SetTextColor(hDC,RGB(255,0,0));
		     ::TextOut(hDC, 30, 250, "Game Over", strlen("Game Over"));
			::SelectObject(hDC,oldFont);
			::DeleteObject(hFon);
		   ::ReleaseDC(hWnd,hDC);
		 ::KillTimer(hWnd,ID_TIMER);
	     DeleteObject(snakePen); 
		 delete gBackBuffer;
		 Sleep(6000);
		 PostQuitMessage(0); 
	   }
		Runn(hWnd);
		drawGameData(hWnd);		 
   }break;
  //-------4----------
   case WM_DESTROY:{
	   ::KillTimer(hWnd,ID_TIMER);
	     DeleteObject(snakePen); 
		 delete gBackBuffer;
		 PostQuitMessage(0); 
	}break;
  //----	
   default: {
	   return DefWindowProc(hWnd,uMsg,wParam,lParam);
	}
	};
	return 0;
};
//---------------------
//---
bool MyWndClass::AppLoadIcon(const HWND hWnd){
	HANDLE  hMainIcon  = ::LoadImage(0,"Games.ico",IMAGE_ICON,32,32,LR_LOADFROMFILE);
	if(!hMainWnd){
		throw "Can't load application icon";		
	}else {
      SetClassLong( hMainWnd , GCL_HICON - 20 , (long)hMainIcon );  
      SetClassLong( hMainWnd , GCL_HICON , (long)hMainIcon );  
	  return true;
	}
	//--------
	SetWindowLong( hMainWnd, GWL_USERDATA, (LONG)this);
	SetWindowLong( hMainWnd, GWL_WNDPROC, (LONG)WndProcStub);
	//--------
	return false;
};
//---
void MyWndClass::CreateWndClass(){
	this->szClassName="MyClassSnake";
	//----
	wc.cbSize=sizeof(wc);
	wc.style=CS_HREDRAW | CS_VREDRAW | CS_OWNDC;

	wc.lpfnWndProc=WndProcStub;
	wc.cbClsExtra=0;
	wc.cbWndExtra=0;
	wc.hInstance=this->hInstance;
	wc.hIcon=LoadIcon(NULL,IDI_EXCLAMATION);

	wc.hCursor=LoadCursor(NULL,IDC_NO);
	
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
	hMainWnd=CreateWindow(this->szClassName.c_str()," Simplee Snake ",WS_EX_PALETTEWINDOW|WS_SYSMENU,
		100, 100, gWindowWidth, gWindowHeight,(HWND)NULL,
		(HMENU)NULL,(HINSTANCE)this->hInstance,NULL);
	
	if(!hMainWnd){
		throw "Cant create main window";		
	};

	AppLoadIcon(hMainWnd);
	
	return 0;
};
//---
int MyWndClass::Run(){
	//---
	CreateWndClass();
	//--
	CreateWnd();
	//--
	ShowWindow(hMainWnd,SW_NORMAL);
	//---
	while(GetMessage(&msg,NULL,0,0)){
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	};
	return msg.wParam;
};
//---------------------------------------
int  MyWndClass::Runn(const HWND hWnd){
///----------
   MSG msg; 
   ZeroMemory(&msg, sizeof(MSG)); 
   //----
   if(PeekMessage(&msg, 0, 0, 0, PM_QS_POSTMESSAGE))   { 
	   TranslateMessage(&msg); 
	   DispatchMessage(&msg); 
   }  else   {   
    
		 HDC bbDC = gBackBuffer->getDC(); 
		//------------set font color---------------------	
		 HBRUSH oldBrush = (HBRUSH)SelectObject(bbDC, GetStockObject(LTGRAY_BRUSH));// CreateSolidBrush(RGB(155,230,153));
		 Rectangle(bbDC, 0, 0, gClientWidth, gClientHeight); 
		//----------create map------------
		 HBRUSH Br1 = CreateSolidBrush(RGB(25,160,10)); 
		 HBRUSH Br2 = CreateSolidBrush(RGB(160,25,10)); 
		 int k=0;
		 int food_size = 7;
		 int wallSize = 7;
		 for(int i=0; i<n; ++i) {
			for(int j=0; j<m; ++j) {
				if(map[i][j]==1) {
				  SelectObject(bbDC, Br1); 
				   Rectangle(bbDC,  (int)grid[k].x - food_size,   (int)grid[k].y - food_size,   (int)grid[k].x + food_size, (int)grid[k].y + food_size); 
				} else if(map[i][j]==2) {
				  SelectObject(bbDC, Br2); 
				   Rectangle(bbDC,  (int)grid[k].x - wallSize,   (int)grid[k].y - wallSize,   (int)grid[k].x + wallSize, (int)grid[k].y + wallSize); 
				}
				++k;
			}
		 }
		 ::DeleteObject(Br1); 
		 ::DeleteObject(Br2);
		 //------------draw grid--------------------
		 RECT rect;
		::GetClientRect(hWnd,&rect);
		const int margin = 20;	
		//---
		HPEN gPen = ::CreatePen(0,1,RGB(123,100,100));
		HPEN oldPe = (HPEN)SelectObject(bbDC, gPen); 
		 //--x-	
		for(int i=0; i<=rect.right; i+=margin){
		 ::MoveToEx(bbDC,i,0,0);
		 ::LineTo(bbDC,i,rect.bottom);	
		}	
		//--y-
		for(int j=0; j<=rect.bottom; j+=margin){
		::MoveToEx(bbDC,0,j,0);
		::LineTo(bbDC,rect.right,j);	
		}
		//--------
		 SelectObject(bbDC, oldPe); 
		 ::DeleteObject(gPen);  
		 ::DeleteObject(oldPe);	
		  ::ReleaseDC(hWnd,bbDC);
		 //---------draw snake-------------	 
		 HPEN oldPen = (HPEN)SelectObject(bbDC, snakePen); 
		 for(int i=0; i<snake.size(); ++i) {
		   MoveToEx(bbDC, (int)snake[i].x, (int)snake[i].y, 0);  
		   LineTo(bbDC, (int)(snake[i].x ), (int)(snake[i].y ));		
		 }
	  //------------eat food, change score, speed, life , game over---
		 k=0;
		for(int i=0; i<n; ++i) {
			for(int j=0; j<m; ++j) {
				if(map[i][j] == 1){
					if((snake[0].x == grid[k].x)&&(snake[0].y == grid[k].y)) {
						Score +=scoreup;
						 map[i][j] = 0;
						//------snake grow---------
						POINT p; 
						 p.x =snake[snake.size()-1].x; 
						  p.y = snake[snake.size()-1].x;
					    snake.push_back(p);
						//---------------
						if(Score>maxlevel){
						//------------
							int nn = rand()%n;
							int mm = rand()%m;
							if(map[nn][mm]==1) nn = rand()%n;
							
							if((nn==n)) --nn;
								if((mm==m)) --mm;
								
							map[nn][mm]=2;
						//------------
							maxlevel+=50;
							if(Speed>0){
								Speed-=20;
								for(int i=0; i<(snake.size()/3); ++i)
								snake.pop_back();
								++curSpeed;
							} else Speed = 200;
						}

					}
				}
				if(map[i][j] == 2){
					if((snake[0].x == grid[k].x)&&(snake[0].y == grid[k].y)) {
						if(Life>0) {
							Life -= 1;	
							snake.clear();
							   POINT p;
							   p.x =10; p.y = 10;
							   snake.push_back(p);
							   p.x =30; p.y = 10;
							   snake.push_back(p);
							   p.x =30; p.y = 10;
							   snake.push_back(p);
							Sleep(4000);
						}					
						else gameOver = true;
					}
				}
				++k;
			}
		}		
	  //----------change snake direction -----------------------
		 if(dir == 1) {
			 for(int i=snake.size()-1; i>=1; --i) {
					 snake[i].x = snake[i-1].x;
					 snake[i].y = snake[i-1].y; 
				 }
					 snake[0].y -= margin;
					 //snake[0].x = snake[0].x;
					 
			 if(snake[0].y < 0) snake[0].y = gClientHeight - margin/2;				 
			 if(snake[0].y > gClientHeight) snake[0].y = margin/2;	
		 }  
		 if(dir == 2) {
			for(int i=snake.size()-1; i>=1; --i) {
					 snake[i].x = snake[i-1].x;
					 snake[i].y = snake[i-1].y; 
				 }
					 snake[0].y += margin;
					 //snake[0].x =  snake[0].x;
					 
			if(snake[0].y < 0) snake[0].y = gClientHeight - margin/2;
			if(snake[0].y > gClientHeight) snake[0].y = margin/2;
		 } 
		 if(dir ==3) {
			for(int i=snake.size()-1; i>=1; --i) {
					 snake[i].x = snake[i-1].x;
					 snake[i].y = snake[i-1].y; 
				 }
					 snake[0].x -= margin;
					 //snake[0].y =  snake[0].y;
					 
			if(snake[0].x < 0) snake[0].x = gClientWidth - margin/2;
			if(snake[0].x > gClientWidth) snake[0].x = margin/2;
		 }  
		 if(dir == 4){
			for(int i=snake.size()-1; i>=1; --i) {
					 snake[i].x = snake[i-1].x;
					 snake[i].y = snake[i-1].y; 
				 }
					 snake[0].x += margin;
					 //snake[0].y =  snake[0].y;
					 
			if(snake[0].x < 0) snake[0].x = gClientWidth - margin/2;
			if(snake[0].x > gClientWidth) snake[0].x = margin/2;
		 }
		 //--------------------------------------------------------
		 SelectObject(bbDC, oldPen);  
		 SelectObject(bbDC, oldBrush);  
		 ::DeleteObject(oldPen);
		 ::DeleteObject(oldBrush);
		//-----------
		 gBackBuffer->present();      
		//-----------	
	
    } ///peekmessage end
	//-----------
  return 0;//(int)msg.wParam; 	
}; 