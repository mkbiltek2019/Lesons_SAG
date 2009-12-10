#include "MyWndClass.h"
//----------------------
Tank fTank = NULL;
Tank sTank = NULL;
Dir d = NULL;
Bullet fBullet = NULL;
//----------------------
enum tankwidthheight{twidth = 60, theight = 60};
//----------------------
static int Score = 0;
static int maxlevel = 50;
const int scoreup =5;
bool gameOver = false;
static int dir2 = 1;
static bool startGame = true;
//----------------------
HMENU ghMainMenu  = 0;
HWND gMainWnd = 0;
//----------------------
HDC ghSpriteDC = 0; 
//----------------------
enum dirr{up=1,down=2,left=3,right=4};
//----------------------
static bool secondPlayer = false;
//----------------------
BackBuffer* gBackBuffer = 0; 
Sprite*     gBackground = 0; 
Sprite*     gTank       = 0; 
Sprite*     gBullet     = 0; 
//----------------------

//----------------------
list<Vec2> gBulletPos; 
RECT gMapRect = {0, 0, 800, 640}; 
//----------------------
const int gClientWidth  = 800; 
const int gClientHeight = 640;  
//----------------------
const int gWindowWidth  = gClientWidth; 
const int gWindowHeight = gClientHeight; 
//----------------------
const POINT gClientCenter = {gClientWidth  / 2, gClientHeight / 2-20 }; 
//=====================================================================
const int n=30;
const int m=30;
const int margin = 5;
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
   //-------------
	 Vec2   p0;//(gClientCenter); 
	  p0.x = gClientCenter.x;
	  p0.y = gClientCenter.y;
	 Vec2   v0(0.0f, 0.0f); 	
   //-------------
	switch(uMsg){
	case WM_CREATE: {
		//-----load game icon----------
		HICON hIcon = LoadIcon(GetModuleHandle(NULL), MAKEINTRESOURCE(IDI_ICON1));
		 SetClassLong(hWnd, GCL_HICON, (LONG)hIcon);
		  SetClassLong(hWnd, GCL_HICONSM, (LONG)hIcon);
		//-----------------------------
		gBackground = new Sprite(GetModuleHandle(NULL), IDB_BACKGROUND, IDB_BACKGROUNDMASK,  p0, v0); 
		//------create tank-----------
		  d = new CDirection();
		   fTank = new CTank();
		    fTank->tankCreate(GetModuleHandle(NULL), twidth, theight);
		     p0.y =p0.y+280;
		      fTank->SetTankPos(p0,v0);
		//-----new bullet---------------------
		 fBullet = new CBullet();
		  p0.x = 0.0f; 
		   p0.y = 0.0f; 
		    fBullet->bulletCreate(GetModuleHandle(NULL), twidth, theight);
		     fBullet->SetBulletPos(p0,v0);
		//--------------------------		 		
		// Create system memory DCs  
		ghSpriteDC = CreateCompatibleDC(0);  
		 // Create the backbuffer. 
		gBackBuffer = new BackBuffer(hWnd, gClientWidth, gClientHeight);
	}break;
	//---------------
	case WM_COMMAND:{
		switch(LOWORD(wParam)){
			case ID_FILE_MYEXIT:{
				::SendMessage(hWnd,WM_DESTROY,0,0);
			}break;
			case ID_SECONDPLAYER:{
				if(!secondPlayer) {					
					HMENU hMenu = GetMenu(hWnd); 					
					CheckMenuItem(hMenu, ID_SECONDPLAYER, MF_BYCOMMAND | MF_CHECKED);					
				} else	{					
					HMENU hMenu = GetMenu(hWnd);					
					CheckMenuItem(hMenu,ID_SECONDPLAYER, MF_BYCOMMAND | MF_UNCHECKED);					
				}
				secondPlayer = !secondPlayer;
			}break;
		}//switch
	}break;
	//---------------
	case WM_KEYDOWN: {		
		   switch(wParam) {
		     //-------first player----------------
			  case 'A': {//left. 
				    fTank->tankRotate(d->moveLeft());
					fTank->tankMove(d->moveLeft());					
				
			   }break; 			   
			   case 'D': {//right. 
				   fTank->tankRotate(d->moveRight());
					fTank->tankMove(d->moveRight());
					
			   }break; 			   
			   case 'W':{ // up 
				  fTank->tankRotate(d->moveUp());
				  fTank->tankMove(d->moveUp());
				
				  
			   }break; 			   
			   case 'S':{ //down. 
				  fTank->tankRotate(d->moveDown());
				  fTank->tankMove(d->moveDown());
				  	  
			   }break; 
			   case VK_SPACE: { //Add a bullet to the bullet list
				   	fBullet->setBulletStartPos(fTank->getTankPos());
			   }break; 
		    //------------second player ----------
				case VK_UP: {	
					dir2 = 1;					
				}break;
				case VK_DOWN: {	
					dir2 = 2;
				}break;
				case VK_LEFT: {		
					dir2 = 3;
				}break;
				case VK_RIGHT: {
					dir2 = 4;
				}break;
			//-----------------------------------
		  } //switch
		   //---
		    
	}break;
	//---------------
	case WM_DESTROY:{
		  delete gBackground; 
		  delete gTank; 	
		  delete fTank;
		  delete gBullet; 
		  delete d;
		  delete gBackBuffer; 
		  DeleteDC(ghSpriteDC); 
		PostQuitMessage(0);	
	}break;
	default:
		return DefWindowProc(hWnd,uMsg,wParam,lParam);
	};
	return 0;
};
//===================================================
MyWndClass::MyWndClass(HINSTANCE hInstancem):hInstance(hInstancem){
};
//----
void MyWndClass::CreateWndClass(){
	this->szClassName = "MyBattleTanks";
	//----
	wc.cbSize=sizeof(wc);
	wc.style=CS_HREDRAW | CS_VREDRAW;

	wc.lpfnWndProc=WndProcStub;
	wc.cbClsExtra=0;
	wc.cbWndExtra=0;
	wc.hInstance=this->hInstance;
	wc.hIcon=LoadIcon(NULL, MAKEINTRESOURCE(IDI_ICON1));

	wc.hCursor=LoadCursor(NULL,IDC_HAND);
	
	wc.hbrBackground=(HBRUSH)GetStockObject(WHITE_BRUSH);

	wc.lpszMenuName = NULL;
	wc.lpszClassName = szClassName.c_str();
	wc.hIconSm = LoadIcon(NULL, MAKEINTRESOURCE(IDI_ICON1));

};
//---
int MyWndClass::CreateWnd(){
	if(!RegisterClassEx(&this->wc)){
		throw "Error can't register window class";		
	};
	//---
	ghMainMenu = LoadMenu(::GetModuleHandle(NULL), MAKEINTRESOURCE(IDR_MENU1));

	hMainWnd=CreateWindow(this->szClassName.c_str(), "Battle Tanks", WS_EX_PALETTEWINDOW|WS_SYSMENU,
		0, 0, gWindowWidth, gWindowHeight, (HWND)NULL,
		(HMENU)ghMainMenu, (HINSTANCE)this->hInstance, NULL);
	
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
	 ShowWindow(hMainWnd,SW_SHOWNORMAL);
	  UpdateWindow(hMainWnd); 
	   gMainWnd = hMainWnd;
	//---
	return Runn();
};
//=================================================== 
int MyWndClass::Runn() {
///---------
	const float updateval = 0.01f;
	const int sleeptime = 20;
//------
 MSG msg; 
 ZeroMemory(&msg, sizeof(MSG)); 
 //---------
  while(msg.message != WM_QUIT) {    
   if(PeekMessage(&msg, 0, 0, 0, PM_REMOVE)) { 
	 TranslateMessage(&msg); 
	 DispatchMessage(&msg); 
  } else {    
  //-------------------------------------
	// Draw objects. 
   gBackground->draw(gBackBuffer->getDC(), ghSpriteDC);
   //--------
	fTank->tankUpdate(updateval); 	  
	 fTank->tankMoveBorders(gMapRect);
      fTank->tankDraw(gBackBuffer->getDC(), ghSpriteDC);
  //-------------------------------------------------------
	fBullet->bulletUpdate(updateval);
	 fBullet->bulletRotate(d->getDir());
	  fBullet->bulletDraw(gBackBuffer->getDC(), ghSpriteDC, d->getDir());
  //-------------------------------------------------------
 
   //---draw sceen-----
   gBackBuffer->present(); 
   //---
   Sleep(sleeptime); 
    
   } //if
  }//while 
 
  return (int)msg.wParam; 
} 
 
//========================================================= 
