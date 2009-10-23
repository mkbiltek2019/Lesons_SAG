#include "MyWndClass.h"
#include "math.h"
#include "matrix.h"
#include <fstream>
//-----------global variable-----------
 BackBuffer* gBackBuffer = 0;  

const int gClientWidth  = 600; 
const int gClientHeight = 600;  

const int gWindowWidth  = gClientWidth  ; 
const int gWindowHeight = gClientHeight ; 

 RECT gMapRect = {0, 0, 600, 600};
//----------------------------------
 HPEN snakePen = NULL;  

 Vec2 snakeDir(1.0f, 2.0f); 

 std::vector<POINT> snake; 
//----------------------

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
  //-------------------
  switch(uMsg){ 
   //------------1---------
   case WM_CREATE:{  
	   POINT p; 
	    p.x =10; p.y = 10;
	   snake.push_back(p);
	   p.x =30; p.y = 10;
	   snake.push_back(p);
	    p.x =50; p.y = 10;
	   snake.push_back(p);
   // Create snake pen 
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
		   switch(wParam) { 		  
		case VK_UP: {
			 snakeDir.Rotate(PI); 	
			 for(int i=snake.size()-1; i>=1; --i) {
				 snake[i].x = snake[i-1].x;
				 snake[i].y = snake[i-1].y; 
			 }
				 snake[0].y -= margin;
				 snake[0].x = snake[0].x;
				 
				 if(snake[0].y < 0) { 
					 snake[0].y = gClientHeight - margin/2;				 
				 }
				 if(snake[0].y > gClientHeight) { 			 
					 snake[0].y = margin/2;	
				 }		 

					}break;
		case VK_DOWN: {
			 snakeDir.Rotate(PI); 
			for(int i=snake.size()-1; i>=1; --i) {
				 snake[i].x = snake[i-1].x;
				 snake[i].y = snake[i-1].y; 
			 }
				 snake[0].y += margin;
				 snake[0].x =  snake[0].x;
				 
				 if(snake[0].y < 0) snake[0].y = gClientHeight - margin/2;
				 if(snake[0].y > gClientHeight) snake[0].y = margin/2;
			
					  }break;
		case VK_LEFT: {	
			 snakeDir.Rotate(PI);

			 for(int i=snake.size()-1; i>=1; --i) {
				 snake[i].x = snake[i-1].x;
				 snake[i].y = snake[i-1].y; 
			 }
				 snake[0].x -= margin;
				 snake[0].y =  snake[0].y;
				 
				 if(snake[0].x < 0) snake[0].x = gClientWidth - margin/2;
				 if(snake[0].x > gClientWidth) snake[0].x = margin/2;

			 }break;
		case VK_RIGHT: {
			snakeDir.Rotate(PI); 

			for(int i=snake.size()-1; i>=1; --i) {
				 snake[i].x = snake[i-1].x;
				 snake[i].y = snake[i-1].y; 
			 }
				 snake[0].x += margin;
				 snake[0].y =  snake[0].y;
				 
				 if(snake[0].x < 0) snake[0].x = gClientWidth - margin/2;
				 if(snake[0].x > gClientWidth) snake[0].x = margin/2;
			
			 }break;
	   }
   }break;
  //-------3----------
   case WM_DESTROY:{
		 DeleteObject(snakePen); 
		 delete gBackBuffer; 
		 PostQuitMessage(0); 
					 }break;
	default:
		return DefWindowProc(hWnd,uMsg,wParam,lParam);
	};
	return 0;
};
//---------------------
int  MyWndClass::Runn(){
 
 MSG msg; 
 ZeroMemory(&msg, sizeof(MSG)); 

  while(msg.message != WM_QUIT)  { 
   if(PeekMessage(&msg, 0, 0, 0, PM_REMOVE))   { 
	   TranslateMessage(&msg); 
	   DispatchMessage(&msg); 
   }  else   {   
    
	 HDC bbDC = gBackBuffer->getDC(); 
	//------------set font color---------------------	
	 HBRUSH oldBrush = (HBRUSH)SelectObject(bbDC, GetStockObject(LTGRAY_BRUSH)); 
	 Rectangle(bbDC, 0, 0, 600, 600); 
	//----------create map------------
	 HBRUSH Br1 = CreateSolidBrush(RGB(25,160,10)); 
	 HBRUSH Br2 = CreateSolidBrush(RGB(160,25,10)); 
	 int k=0;
	 for(int i=0; i<n; ++i) {
		for(int j=0; j<m; ++j) {
			if(map[i][j]==1) {
		      SelectObject(bbDC, Br1); 
			   Rectangle(bbDC,  (int)grid[k].x - 5,   (int)grid[k].y - 5,   (int)grid[k].x + 5, (int)grid[k].y + 5); 
			} else if(map[i][j]==2) {
			  SelectObject(bbDC, Br2); 
			   Rectangle(bbDC,  (int)grid[k].x - 5,   (int)grid[k].y - 5,   (int)grid[k].x + 5, (int)grid[k].y + 5); 
			}
			++k;
		}
	 }
	 //------------draw grid--------------------
	 RECT rect;
	::GetClientRect(hMainWnd,&rect);
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
	 SelectObject(bbDC, GetStockObject(WHITE_BRUSH)); 
	 SelectObject(bbDC, oldPe); 		
	 //---------draw snake-------------
	 SelectObject(bbDC, GetStockObject(DKGRAY_BRUSH)); 
	 HPEN oldPen = (HPEN)SelectObject(bbDC, snakePen); 
	 for(int i=1; i<snake.size(); ++i) {
	   MoveToEx(bbDC, (int)snake[i].x, (int)snake[i].y, 0);  
      LineTo(bbDC, (int)(snake[i].x + snakeDir.x), (int)(snake[i].y + snakeDir.y));		
	 }
	 //-------

	 //-------
	 SelectObject(bbDC, GetStockObject(WHITE_BRUSH)); 
	 SelectObject(bbDC, oldPen);  
	 SelectObject(bbDC, oldBrush);   
	//-----------
     gBackBuffer->present();      
    //-----------
	 Sleep(20); 
             } 
       } 
	//-----------
  return (int)msg.wParam; 	
}; 
//----
void MyWndClass::CreateWndClass(){
	this->szClassName="MyClassSnake";
	//----
	wc.cbSize=sizeof(wc);
	wc.style=CS_HREDRAW | CS_VREDRAW;

	wc.lpfnWndProc=WndProcStub;
	wc.cbClsExtra=0;
	wc.cbWndExtra=0;
	wc.hInstance=this->hInstance;
	wc.hIcon=LoadIcon(NULL,IDI_EXCLAMATION);

	wc.hCursor=LoadCursor(NULL,IDC_HAND);
	
	wc.hbrBackground=(HBRUSH)GetStockObject(NULL_BRUSH);

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
	hMainWnd=CreateWindow(this->szClassName.c_str()," Simplee snake ",WS_OVERLAPPED,
		200, 200, gWindowWidth, gWindowHeight,(HWND)NULL,
		(HMENU)NULL,(HINSTANCE)this->hInstance,NULL);
	
	if(!hMainWnd){
		throw "Can't create main window";		
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
	ShowWindow(hMainWnd,SW_NORMAL);
	UpdateWindow(hMainWnd); 
	//---
	/*while(GetMessage(&msg,NULL,0,0)){
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	};*/
	//return msg.wParam;
	return Runn();
};
//---