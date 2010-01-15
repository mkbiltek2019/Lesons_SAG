#include "MyWndClass.h"
//----------------------
textDrawer tDraw;
//-------
static bool enem = true;
std::vector<tn> enemys;
//---
static bool enem1 = false;
std::vector<tn> enemys1;
//---
static bool enem2 = false;
std::vector<tn> enemys2;
//---
const size_t enemysPerWave = 5;
//---
enum en{onePlayerEnemy = 10, twoPlayersEnemy = 10};
static int endir[5];
static bool newlevel = false;
//-------
Tank fTank = NULL;
//Tank sTank = NULL;
Dir d1 = NULL;
//Dir d2 = NULL;
Bullet fBullet = NULL;
gameMap gMap = NULL;
//----------------------
enum tankwidthheight{twidth = 30, theight = 30};
enum {wall = 2, unbreakwall=8, tank = 4, flag = 3, enemy = 5};
enum {wallpoints = 50, tankpoints = 500};
enum {pow1 = 1, pow2 = 2, pow3 = 3};
//----------------------
static size_t gameLevel = 1;
static size_t Score = 0;
static gscore currentsco; 
//----------------------
bool gameOver = false;
static bool startGame = false;
//----------------------
static bool secondplayer = false;
//----------------------
UINT_PTR timer = 1;
UINT_PTR timer2 = 2;
HMENU ghMainMenu  = 0;
HWND gMainWnd = 0;
//----------------------
HDC ghSpriteDC = 0; 
//----------------------
enum dirr{up = 1, down = 2, left = 3, right = 4,mapn = 20};
//----------------------
BackBuffer* gBackBuffer = 0; 
Sprite*     gBackground = 0; 
Sprite*     gSky = 0; 
Sprite*     gGameOver = 0; 
Sprite*     gTank       = 0; 
Sprite*     gBullet     = 0; 
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
//-----------------------------------
void createFirstUser() {
///----
	Vec2   p0(gClientCenter.x, gClientCenter.y); 
	 Vec2   v0(0.0f, 0.0f); 	 
	//------create tank for first user-----------				
		fTank = new CTank();
		p0.y =p0.y+280;  p0.x =p0.x+5;
		int k = 0; 
		for(int i = 0; i < mapn; ++i){
		 for(int j = 0; j < mapn; ++j){
		  POINT p = {(int)p0.x, (int)p0.y};
		  RECT re(gMap->getBrRect(k));
		  if(PtInRect(&re, p)) {
		    gMap->setgcmap(k,tank);
		  }
		  ++k;
		 }
		}				
		fTank->tankCreate(GetModuleHandle(NULL), twidth, theight,p0);		
		///------create tank for second user-----------
				/* sTank = new CTank();
				  p0.y =p0.y+280;  p0.x =p0.x-230;
				   sTank->tankCreate(GetModuleHandle(NULL), twidth, theight,p0);*/							
}
//---
void enemiesCreate(const size_t power, std::vector<tn>* enemys) {
///-------
	Vec2   p0(0, 0); 
	Vec2   v0(0.0f, 0.0f); 	 
	Vec2 p1(70, 20);
	Vec2 p2(310, 20);
	Vec2 p3(530, 20);
	 //-------create enemys ---------
		for(int ti = 0; ti < enemysPerWave; ++ti) {
		  tn tmp;
		  Enemy enemyTmp = new CEnemy();					 
		 //---
		 switch(ti){
		  case 0: case 1: {
			  p0.x = p1.x; p0.y = p1.y;	  
		  }break; 
		  //----
		  case 2: case 3:{
			 p0.x = p2.x; p0.y = p2.y;	  
		  }break; 
		  //----
		  case 4: case 5:{
			 p0.x = p3.x; p0.y = p3.y;  
		  }break; 		  
		 };	
		//---
		 int k = 0; 
		 for(int i = 0; i < mapn; ++i){
			 for(int j = 0; j < mapn; ++j){
				 POINT p={(int)p0.x,(int)p0.y};
				 RECT re = gMap->getBrRect(k);
				if(PtInRect(&re, p)) {
					gMap->setgcmap(k,enemy);
				}
				++k;
			 }
		 }
		//---
		enemyTmp->enemyCreate(GetModuleHandle(NULL), twidth, theight, p0);
		enemyTmp->setPower(power);
		//---
		tmp.tank = enemyTmp;
		tmp.visible = true;
		enemys->push_back(tmp);
	 }
	//--------
}
//-----------------------------------
void enemiesMoove(std::vector<tn>* eny) {
///------------
	std::vector<tn>::iterator it = eny->begin();
	int i = 0;
	while(it != eny->end()) {
		it->tank->enemyRotate(endir[i]);
		 it->tank->enemyMove(endir[i],gMap->getBrikRect(),gMap->getgvMap());
		  it->tank->enemyMoveBorders(gMapRect);
		   it->tank->shoot(endir[i]);
		++it; 
		 ++i;
	}
}
//-----------------------------------
void enemysChangeDirection(std::vector<tn>* enemys) {
///----
	const int dir = 4;
	for(size_t i=0; i<enemys->size(); ++i) 
		endir[i]=rand()%dir+1;	
}
//-----------------------------------
void createGameMap(HWND hWnd) {
///-------
	Vec2   p0(gClientCenter.x, gClientCenter.y); 
	 Vec2   v0(0.0f, 0.0f); 
	//------create game background and map-----------------------
	gBackground = new Sprite(GetModuleHandle(NULL), IDB_BACKGROUND, IDB_BACKGROUNDMASK,  p0, v0); 
	gSky = new Sprite(GetModuleHandle(NULL), IDB_SKY, IDB_SKYMASK,  p0, v0); 
	gGameOver = new Sprite(GetModuleHandle(NULL), IDB_GAMEOVER, IDB_SKYMASK,  p0, v0); 
	d1 = new CDirection();
	//d2 = new CDirection();				
	  //---------------------------
	// Create system memory DCs  
	ghSpriteDC = CreateCompatibleDC(NULL);  
	// Create the backbuffer. 
	gBackBuffer = new BackBuffer(hWnd, gClientWidth, gClientHeight);
	//---------------
	gMap = new CMap();
	gMap->loadMapFromFile(gameLevel,gBackBuffer->getDC(), ghSpriteDC);
}
//-----------------------------------
void clearGameData(HWND hWnd) {
///-----------
	delete gBackground; 
	delete gTank; 	
	delete fTank;
	delete gBullet; 
	delete d1;
	//delete d2;
	delete gSky;
	delete gMap;
	delete gBackBuffer; 
	delete gGameOver;
	::KillTimer(hWnd,timer);
	::KillTimer(hWnd,timer2);
	if(!enemys.empty()) {
		enemys.clear();
	}
	if(!enemys1.empty()) {
		enemys.clear();
	}
	if(!enemys2.empty()) {
		enemys.clear();
	}
	DeleteDC(ghSpriteDC);
	PostQuitMessage(0);	
}
//-----------------------------------
LRESULT MyWndClass::WndProc(HWND hWnd,UINT uMsg,WPARAM wParam,LPARAM lParam){
	pMyWndClass pThis = (pMyWndClass)GetWindowLong(hWnd, GWL_USERDATA);
   //-------------
	 Vec2   p0(gClientCenter.x, gClientCenter.y); 
	 Vec2   v0(0.0f, 0.0f); 
	 const int left = 100;
	 const int rigthshift = 605;
	 static float sub=0;
	 const int moovetime = 100;
	 const int changedirectiontime = 5000;
	 //::SetWindowPos(hWnd,HWND_TOPMOST,left,0,0,0, SWP_NOSIZE);
	 static bool lft = true;
   //-------------
	switch(uMsg){
	case WM_LBUTTONDOWN:{	
		if(startGame) {
			if(lft){			
				::MoveWindow(hWnd, left, 0, rigthshift ,gClientHeight,true);
				 gBackBuffer->present(); 
				 Sleep(moovetime);
				lft = false;
			}else {
				::MoveWindow(hWnd, 100, 0, gClientWidth, gClientHeight,true);
				 gBackBuffer->present();
				  Sleep(moovetime);
				lft = true;
			}
		}
	}break;
	case WM_CREATE: {
			::SetTimer(hWnd,timer,moovetime,NULL); // enemy moovment and shooting
			::SetTimer(hWnd,timer2,changedirectiontime,NULL);	//enemy direction change		
			//-----load game icon----------
			HICON hIcon = LoadIcon(GetModuleHandle(NULL), MAKEINTRESOURCE(IDI_ICON1));
			SetClassLong(hWnd, GCL_HICON, (LONG)hIcon);
			SetClassLong(hWnd, GCL_HICONSM, (LONG)hIcon);	
			//-----------------
			createGameMap(hWnd);
			//-----------------
			//createFirstUser();
			//-----------------
			//enemiesCreate(pow1, &enemys);			 				
			//-----------------
	}break;
	//---------------
	case WM_COMMAND:{
		switch(LOWORD(wParam)){
			case ID_FILE_STARTGAME:{
				 //---------
					currentsco.points = 0;
					createGameMap(hWnd);
					 createFirstUser();
					 if(!enemys.empty()) enemys.clear();
					 if(enemys.empty()) enemiesCreate(pow1, &enemys);
				 //---------
					startGame = true;
					gameOver = false;
			}break;
			//-------------------
			case ID_SECONDPLAYER: {
				if(startGame==false) {
				  if(secondplayer) {				
					HMENU hMenu = GetMenu(hWnd); 				
					CheckMenuItem(hMenu,ID_SECONDPLAYER, MF_BYCOMMAND | MF_UNCHECKED);
				  } else {				
					HMENU hMenu = GetMenu(hWnd);				
					CheckMenuItem(hMenu, ID_SECONDPLAYER , MF_BYCOMMAND | MF_CHECKED);						
				  }
				  secondplayer = !secondplayer;	
				}
			}break;
			//-------------------
			case ID_FILE_MYEXIT:{
				clearGameData(hWnd);					
			}break;
		  //---------------------	
		}//switch
	}break;
	//---------------
	case WM_TIMER:{
		switch (wParam)  { 
			case 1: { //timer          
				if(enem) enemiesMoove(&enemys);
				if(enem1) enemiesMoove(&enemys1);
				if(enem2) enemiesMoove(&enemys2);
			}return 1;
			//---------
			case 2:{  //timer2 here enemy change direction 
				if(enemys2.empty() && enemys1.empty() && enemys.empty()) {
					++gameLevel;
					if(gameLevel>3) 
						gameLevel = 1;
					
					createGameMap(hWnd);
					if(!enemys.empty()) enemys.clear();
					if(enemys.empty()) enemiesCreate(pow1, &enemys);
				}
				//---------
				if(enem) enemysChangeDirection(&enemys);
				if(enem1) enemysChangeDirection(&enemys1);
				if(enem2) enemysChangeDirection(&enemys2);
			}return 1; 
		}//switch				
	}break;
	//---------------
	case WM_KEYDOWN: {	
		if(startGame) {
		     switch(wParam) {
		     //-------first player----------------
			  case 'A': {//left. 
				    fTank->tankRotate(d1->moveLeft());
					fTank->tankMove(d1->moveLeft(),gMap->getBrikRect(),gMap->getgvMap());					
			  }break; 			   
			   case 'D': {//right. 
				   fTank->tankRotate(d1->moveRight());
				   fTank->tankMove(d1->moveRight(),gMap->getBrikRect(),gMap->getgvMap());
			  }break; 			   
			   case 'W':{ // up 
				  fTank->tankRotate(d1->moveUp());
				  fTank->tankMove(d1->moveUp(),gMap->getBrikRect(),gMap->getgvMap());
			   }break; 			   
			   case 'S':{ //down. 
				  fTank->tankRotate(d1->moveDown());
				  fTank->tankMove(d1->moveDown(),gMap->getBrikRect(),gMap->getgvMap());
			   }break; 
			   case VK_SPACE: { //Add a bullet to the bullet list
				   float currTime  = (float)timeGetTime(); 
				   float deltaTime = (currTime - lastTime)*0.001f; 
				    sub +=deltaTime;
				   if(sub>0.7) {// time beetwin shoot  
  				      fTank->shoot(d1->getDir(),gBackBuffer->getDC(), ghSpriteDC);
						sub = 0;
				   }
					lastTime = currTime;
			   }break; 
		    //------------second player ----------
				//case VK_UP: {	
				//	/* sTank->tankRotate(d2->moveUp());
				//	  sTank->tankMove(d2->moveUp(),gMap->getBrikRect(),gMap->getgvMap());*/								
				//} break;
				//case VK_DOWN: {	
				//	 sTank->tankRotate(d2->moveDown());
				//	  sTank->tankMove(d2->moveDown(),gMap->getBrikRect(),gMap->getgvMap());
				//}break;
				//case VK_LEFT: {		
				//	sTank->tankRotate(d2->moveLeft());
				//	 sTank->tankMove(d2->moveLeft(),gMap->getBrikRect(),gMap->getgvMap());		
				//}break;
				//case VK_RIGHT: {
				//	sTank->tankRotate(d2->moveRight());
				//	 sTank->tankMove(d2->moveRight(),gMap->getBrikRect(),gMap->getgvMap());		
				//}break;
				//case VK_RETURN:{
				//  /* float currTime  = (float)timeGetTime(); 
				//   float deltaTime = (currTime - lastTime)*0.001f; 
				//	if(deltaTime>0.3f)*/
  		//		      sTank->shoot(d2->getDir(),gBackBuffer->getDC(), ghSpriteDC);
				//	//lastTime = currTime;
				//}break;
			//-----------------------------------
		  } //switch
		   //---
		}//if start game
		   fTank->tankMoveBorders(gMapRect);
		   }break;

	//---------------
	case WM_DESTROY:{
		clearGameData(hWnd);			
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
	wc.style=CS_HREDRAW | CS_VREDRAW|PRF_ERASEBKGND|CS_OWNDC;

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
/*
1. танки не можуть наїжджати один на одного
4. вороги - обєкти одного один типу (використати булівську змінну) (це означає, що воно не можуть знищувати оде одного), гравець інший тип
5.  
*/
 MSG msg; 
 ZeroMemory(&msg, sizeof(MSG)); 
	//const float updateval = 25.0f;
	const int sleeptime = 10;
//---- do not draw game picture every time need some delay-
	__int64 cntsPerSec = 0;
	bool perfExists = QueryPerformanceFrequency((LARGE_INTEGER*)&cntsPerSec)!=0;
	if( !perfExists ) {
		throw "Performance timer does not exist!";
		return 0;
	}
	double timeScale = 1.0 / (double)cntsPerSec;
	// Get the current time.
	__int64 lastTime = 0;
	QueryPerformanceCounter((LARGE_INTEGER*)&lastTime);	
	//-------
	static double timeElapsed = 0.0f;
	 static double tel = 0.0f;
	  static double bas = 0.0f;
	   static double enshoot = 0.0f;
   //---------
  while(msg.message != WM_QUIT) {    
   if(PeekMessage(&msg, 0, 0, 0, PM_REMOVE)) { 
	 TranslateMessage(&msg); 
	  DispatchMessage(&msg); 
  } else {    
  //-------------------------------------
	  __int64 currTime = 0; 
    	QueryPerformanceCounter((LARGE_INTEGER*)&currTime);
		double deltaTime = (double)(currTime - lastTime) * timeScale;
		timeElapsed += deltaTime;
  			tel+=deltaTime;
			bas+=deltaTime;
			enshoot+=deltaTime;
		//--------------------
		if(!startGame){
			if( bas >= 10 ) { 
			   gSky->draw(gBackBuffer->getDC(), ghSpriteDC);
				gBackBuffer->present(); 
				 bas = 0;
				 Sleep(400);
			}
			if(gameOver) {
				gGameOver->draw(gBackBuffer->getDC(), ghSpriteDC);
				 gBackBuffer->present(); 
				  Sleep(400);				
			}
		}
		//--------------------
		if(startGame) {
			startGame = true;
			gameOver = false;
			 // Only update once every 1/100 seconds.
			if( timeElapsed >= 0.01 ) { 
				// Draw objects. 
				if( bas >= 0.01 ) { 
					gBackground->draw(gBackBuffer->getDC(), ghSpriteDC);					
					//--------
					currentsco.level = gameLevel; 
					 currentsco.enemys = enemys.size();
					  currentsco.lifes = fTank->getLife();
					   //currentsco.points = 0;
					tDraw->drawGameData(gBackBuffer->getDC(),gClientWidth, 
										  gClientHeight,gClientWidth-190,currentsco); 
					//--------
					 gMap->mapDraw(gBackBuffer->getDC(), ghSpriteDC);
					 gMap->updateMap(gMap->getgvMap());
					bas = 0;
				}				
				//------------------------------------
				//fTank->tankUpdate((float)timeElapsed); 	  
				fTank->tankDraw(gBackBuffer->getDC(), ghSpriteDC);				
				currentsco.points += fTank->drawbullet(d1->getDir(),gBackBuffer->getDC(), ghSpriteDC,
					              gMap->getBrikRect(), gMap->getgvMap(), &enemys);
			  //-------------------------------------------------------			 
			//----------------draw enemies t1--------
				if(tel > 0.01) { //set enemy visiable			
					for(size_t i=0; i<enemys.size(); ++i) {
						//enemys[i].tank->tankUpdate((float)timeElapsed); 						
					  enemys[i].tank->enemyDraw(gBackBuffer->getDC(), ghSpriteDC);
					  enemys[i].tank->drawbullet(endir[i],gBackBuffer->getDC(), 
						        ghSpriteDC,gMap->getBrikRect(), gMap->getgvMap(), fTank);
					}//for i
				 tel = 0;
				 //-------draw enemies t2----------
				 if(enemys.empty()){enem = false; enem1 = true; }
				//--------draw enemies t3----------
				 if(enemys1.empty()&&enem1) {enem1 = false; enem2 = true; }			 
				}//if tel
				//--------start new level----------
				//if(enemys2.empty() && enemys1.empty() && enemys.empty()) {
				//	newlevel = true;
				//	/*if(gameLevel<3) {
				//		++gameLevel;
				//	} else{
				//		gameLevel = 1;
				//	}*/
				//}
				//---------game over---------------
				if(fTank->getLife()==0) {
					fTank->destroy();
						startGame = false;
						gameOver = true;
				}
				if((gMap->getgvMap()[389]<1)||(gMap->getgvMap()[390]<1)||(gMap->getgvMap()[369]<1)||(gMap->getgvMap()[370]<1)){
						startGame = false;
						gameOver = true;
				}
			//--------------------------------------
			   gBackBuffer->present(); 			 
			   //---
			  Sleep(sleeptime); 
			timeElapsed = 0;
			}			
			lastTime = currTime; 
		} //if
	 }//startgame
	
  }//while 

  return (int)msg.wParam; 
} 
 
//========================================================= 
