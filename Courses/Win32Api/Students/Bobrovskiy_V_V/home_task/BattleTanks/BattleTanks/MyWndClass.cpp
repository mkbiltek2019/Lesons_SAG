#include "MyWndClass.h"
//----------------------
//----------------------
static int Level = 1;
static int Score = 0;
static int maxlevel = 50;
const int scoreup =5;
static int Life = 3;
bool gameOver = false;
static int dir1 = 1;
static int dir2 = 1;
//----------------------
HMENU ghMainMenu  = 0;
HWND gMainWnd = 0;
//----------------------
HDC ghSpriteDC = 0; 
//----------------------
BackBuffer* gBackBuffer = 0; 
Sprite*     gBackground = 0; 
Sprite*     gTank       = 0; 
Sprite*     gBullet     = 0; 
//----------------------
list<Vec2> gBulletPos; 
RECT gMapRect = {0, 0, 800, 600}; 
//----------------------
const int gClientWidth  = 800; 
const int gClientHeight = 600;  
//----------------------
const int gWindowWidth  = gClientWidth; 
const int gWindowHeight = gClientHeight; 
//----------------------
const POINT gClientCenter = {gClientWidth  / 2, gClientHeight / 2 }; 
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
	 
		gTank = new Sprite(GetModuleHandle(NULL), IDB_TANKLEVEL1, IDB_TANKLEVEL1MASK, p0, v0); 
	 
		 p0.x = 0.0f; 
		 p0.y = 0.0f; 
		gBullet = new Sprite(GetModuleHandle(NULL), IDB_BULLET, IDB_BULLETMASK,  p0, v0); 
	 
		// Create system memory DCs  
		ghSpriteDC = CreateCompatibleDC(0);  
		 // Create the backbuffer. 
		gBackBuffer = new BackBuffer(hWnd, gClientWidth, gClientHeight);
	}break;
	//---------------
	case WM_KEYDOWN: {
		   switch(wParam) {
		     //-------first player----------------
			   case 'A': {//left. 
				    dir1 = 3;
					gTank->mPosition.x -= margin;					
			   }break; 			   
			   case 'D': {//right. 
				    dir1 = 4;
					gTank->mPosition.x += margin; 
			   }break; 			   
			   case 'W':{ // up 
				    dir1 = 1;
					gTank->mPosition.y -= margin; 
			   }break; 			   
			   case 'S':{ //down. 
				    dir1 = 2;
					gTank->mPosition.y += margin; 
			   }break; 
			   case VK_SPACE: { //Add a bullet to the bullet list
					Vec2 v = gTank->mPosition;
					if(dir1==2) v.y = v.y+20;
					if(dir1==1) v.y = v.y-20;
					if(dir1==3) v.x = v.x-20;
					if(dir1==4) v.x = v.x+20;
					//-----------------
					gBulletPos.push_back(v); 
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
	}break;
	//---------------
	case WM_DESTROY:{
		  delete gBackground; 
		  delete gTank; 		 
		  delete gBullet; 
		  delete gBackBuffer; 
		  DeleteDC(ghSpriteDC); 
		PostQuitMessage(0);	
	}break;
	default:
		return DefWindowProc(hWnd,uMsg,wParam,lParam);
	};
	return 0;
};
//---------------------
MyWndClass::MyWndClass(HINSTANCE hInstancem):hInstance(hInstancem){
};
//----
void MyWndClass::CreateWndClass(){
	this->szClassName="MyBattleTanks";
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

	wc.lpszMenuName=NULL;
	wc.lpszClassName=szClassName.c_str();
	wc.hIconSm =LoadIcon(NULL, MAKEINTRESOURCE(IDI_ICON1));

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
//========================================================= 
int MyWndClass::Runn() {
///---------
 MSG msg; 
 ZeroMemory(&msg, sizeof(MSG)); 
 //---------
  while(msg.message != WM_QUIT) {    
   if(PeekMessage(&msg, 0, 0, 0, PM_REMOVE)) { 
	 TranslateMessage(&msg); 
	 DispatchMessage(&msg); 
  } else {   

   gTank->update(0.01f);//!!!!!!!!Speed
 //--------rotate tank------------
	if(dir1==3) {//left
		Vec2   p0(gTank->mPosition.x, gTank->mPosition.y);
		Vec2   v0(0.0f, 0.0f); 
		gTank->reloadSprite(GetModuleHandle(NULL), IDB_TANKLEFT, IDB_TANKLEFTMASK, p0,v0);
	}
	if(dir1==1) {//up
		Vec2   p0(gTank->mPosition.x, gTank->mPosition.y);
		Vec2   v0(0.0f, 0.0f); 
		gTank->reloadSprite(GetModuleHandle(NULL), IDB_TANKLEVEL1, IDB_TANKLEVEL1MASK, p0,v0);
	}
	if(dir1==2) {//down
		Vec2   p0(gTank->mPosition.x, gTank->mPosition.y);
		Vec2   v0(0.0f, 0.0f); 
		gTank->reloadSprite(GetModuleHandle(NULL), IDB_TANKDOWN, IDB_TANKDOWNMASK, p0,v0);
	}
	if(dir1==4) {//right
		Vec2   p0(gTank->mPosition.x, gTank->mPosition.y);
		Vec2   v0(0.0f, 0.0f); 
		gTank->reloadSprite(GetModuleHandle(NULL), IDB_TANKRIGHT, IDB_TANKRIGHTMASK, p0,v0);
	}
	//------------map borders--------
    if( gTank->mPosition.x < (gMapRect.left+13) ) { 
    gTank->mPosition.x = (float)gMapRect.left+13; 
    gTank->mVelocity.x = 0.0f; 
    gTank->mVelocity.y = 0.0f; 
   } 
    if( gTank->mPosition.x > (gMapRect.right-213)) { 
    gTank->mPosition.x = (float)gMapRect.right-213; 
    gTank->mVelocity.x = 0.0f; 
    gTank->mVelocity.y = 0.0f;
	} 
    if( gTank->mPosition.y < (gMapRect.top+13) ) { 
    gTank->mPosition.y = (float)gMapRect.top+13; 
    gTank->mVelocity.x = 0.0f; 
    gTank->mVelocity.y = 0.0f; 
   } 
    if( gTank->mPosition.y > gMapRect.bottom-60 ) { 
    gTank->mPosition.y = (float)gMapRect.bottom-60; 
    gTank->mVelocity.x = 0.0f; 
    gTank->mVelocity.y = 0.0f; 
   } 
  //-------------------------------------
	// Draw objects. 
   gBackground->draw(gBackBuffer->getDC(), ghSpriteDC); 
   gTank->draw(gBackBuffer->getDC(), ghSpriteDC); 
  //---------------------------------------
   list<Vec2>::iterator i = gBulletPos.begin(); 
    while( i != gBulletPos.end() ) { 
       // Update the position.
	//--------------------------------
	if(dir1==1) {//up
	   Vec2 bulletVelocity(0.0f, -300.0f); 
      *i += bulletVelocity *0.01f;// deltaTime; 
	}
	if(dir1==2) {//down
		 Vec2 bulletVelocity(0.0f, -300.0f); 
      *i -= bulletVelocity *0.01f;
	}
	if(dir1==3) {//left
		 Vec2 bulletVelocity(-300.0f, 0.0f); 
      *i += bulletVelocity *0.01f;
	}
	if(dir1==4) {//right
		 Vec2 bulletVelocity(-300.0f, 0.0f); 
      *i -= bulletVelocity *0.01f;
	}
	//-------------------------------
    POINT p;// = *i; 
	p.x = i->x;
	p.y = i->y;
    //-------------------------------
	RECT gamerect = {0,0,600,600};
     if( !PtInRect(&gamerect, p) ) 
		 i = gBulletPos.erase(i); 
     else { 
		 gBullet->mPosition.x = i->x;
		 gBullet->mPosition.y = i->y; 	
			
		gBullet->draw(gBackBuffer->getDC(), ghSpriteDC); 
		++i; 
     }//if
   } 
 
   gBackBuffer->present(); 

   Sleep(20); 
             } 
      } 
 
  return (int)msg.wParam; 
} 
 
//========================================================= 
