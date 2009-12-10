#include "CBullet.h"
//----------------------
void CBullet::SetBaseBitmap(){
///------
	switch(this->curPowerState){
			case pow1:{
				baseBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_BULLET));
				 baseBitmapMask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_BULLETMASK));						  
			}break;
			case pow2:{
				 baseBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_BULLET));
				  baseBitmapMask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_BULLETMASK));						  
			}break;
			case pow3:{
				 baseBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_BULLET));
				  baseBitmapMask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_BULLETMASK));
			}break;
	}//switch
};
//-------
const Vec2 CBullet::getBulletPos(){
	return gBullet->mPosition;
};
//-------
void CBullet::rotBullet(int degree){
///-------
	Vec2   p1(getBulletPos().x, getBulletPos().y);
	 Vec2   v1(0.0f, 0.0f); 
	//----------
	HBITMAP resBitmap = NULL;
	 HBITMAP resBitmapMask = NULL;
	//----------
	 SetBaseBitmap();
	//----------
	 Rot a = new aarot();
	 resBitmap = a->rotate(baseBitmap, degree, 0, true);
	  resBitmapMask =  a->rotate(baseBitmapMask, degree, 0, true);		
	   gBullet->reloadSprite2(::GetModuleHandle(NULL), resBitmap, resBitmapMask, p0, v0);
	    SetBulletPos(p1, v1); 
	delete a;
};
//----------------------
CBullet::CBullet():curPowerState(1),curLifeCount(1){
///-----
};
CBullet::~CBullet(){
///------
	delete gBullet;
};
//---------
void CBullet::init(const int h, const int w){
///-----
	Vec2   p1(w,h);
	  p0 = p1;
	Vec2   v1(0.0f, 0.0f); 
	  v0 = v1;
};
void CBullet::SetBulletPos(const Vec2& p0, const Vec2& v0){
///-----
	this->gBullet->mPosition = p0;
	this->gBullet->mVelocity = v0;
};	
void CBullet::bulletMove(const int direction) {
///----
	 Vec2   p0(getBulletPos().x, getBulletPos().y);
	 Vec2   v0(0.0f, 0.0f); 
	 SetBulletPos(p0, v0); 
//---
	switch(direction){
	 case up: {
	 
	 } break;
	 case down: {
	 
	 } break;
	 case left: {
	 
	 }  break;
	 case right: {
				 
	 }  break;
	};//switch
};	
void CBullet::bulletCreate(const HINSTANCE hInst, const int h, const int w){
///------
 SetBaseBitmap();
	init(h, w);
	this->gBullet = new Sprite();
	  gBullet->reloadSprite2(::GetModuleHandle(NULL), baseBitmap, baseBitmapMask, p0, v0);
	   SetBulletPos(p0, v0);
};	
void CBullet::bulletRotate(const int direction){
///---
	switch(direction){
	 case up: rotBullet(updegree); break;
	  case down: rotBullet(downdegree); break;
	   case left: rotBullet(leftdegree); break;
	    case right: rotBullet(rightdegree); break;
	};//switch
};
//---
void CBullet::bulletDraw(HDC bufferDC, HDC tankDC, const int direction){
///-----
	const float strpos = 300.0f;
	const float koef = 0.01f;
	std::list<Vec2>::iterator i = gBulletPos.begin(); 
   while( i != gBulletPos.end() ) { 
       // Update the position.
	//--------------------------------
		if(direction==up) {//up
		   Vec2 bulletVelocity(0.0f, -strpos); 
		  *i += bulletVelocity *koef;// deltaTime; 
		}
		if(direction==down) {//down
			 Vec2 bulletVelocity(0.0f, -strpos); 
		  *i -= bulletVelocity *koef;
		}
		if(direction==left) {//left
			 Vec2 bulletVelocity(-strpos, 0.0f); 
		  *i += bulletVelocity *koef;
		}
		if(direction==right) {//right
			 Vec2 bulletVelocity(-strpos, 0.0f); 
		  *i -= bulletVelocity *koef;
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
			
		gBullet->draw(bufferDC, tankDC); 
		++i; 
     }//if
	 
	// i = gBulletPos.end(); 
   }//while 
};
//------
void CBullet::setBulletStartPos(const Vec2& v){
	gBulletPos.push_back(v); 
};
//------
void CBullet::bulletUpdate(float dt){
///-----
	this->gBullet->update(dt);
};	
void CBullet::bulletMoveBorders(const RECT& gMapRect){
///----
	if(gBullet->mPosition.x < (gMapRect.left+15) ) { 
     gBullet->mPosition.x = (float)gMapRect.left+15; 
      gBullet->mVelocity.x = 0.0f; 
       gBullet->mVelocity.y = 0.0f; 
   } 
    if( gBullet->mPosition.x > (gMapRect.right-215)) { 
     gBullet->mPosition.x = (float)gMapRect.right-215; 
      gBullet->mVelocity.x = 0.0f; 
       gBullet->mVelocity.y = 0.0f;
	} 
    if( gBullet->mPosition.y < (gMapRect.top+15) ) { 
     gBullet->mPosition.y = (float)gMapRect.top+15; 
      gBullet->mVelocity.x = 0.0f; 
       gBullet->mVelocity.y = 0.0f; 
   } 
    if( gBullet->mPosition.y > gMapRect.bottom-60 ) { 
     gBullet->mPosition.y = (float)gMapRect.bottom-60; 
      gBullet->mVelocity.x = 0.0f; 
       gBullet->mVelocity.y = 0.0f; 
   }
};
//---
void CBullet::addPower(){
///---
	if(curPowerState>=pow1&&curPowerState<pow3)
		++curPowerState;
};
const int CBullet::getPowerState() {
///---
	return curPowerState;
};
//---	
void CBullet::subLife() {
///----
	--curLifeCount;
	delete gBullet;
};	
//---
//----------------------