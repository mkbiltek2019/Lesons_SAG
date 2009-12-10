#include "CTank.h"
//-------------------
void CTank::SetBaseBitmap() {
/// -- set base tank bitmap according the tank power level
	switch(this->curPowerState){
			case pow1:{
				 baseBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_TANKLEVEL1));;
				 baseBitmapMask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_TANKLEVEL1MASK));						  
			}break;
			case pow2:{
				 baseBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_TANKLEVEL2));;
				 baseBitmapMask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_TANKLEVEL2MASK));						  
			}break;
			case pow3:{
				 baseBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_TANKLEVEL3));;
				 baseBitmapMask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_TANKLEVEL3MASK));
			}break;
		}//switch	
};
//--------------------
void CTank::init(const int h, const int w){
/// init first tank start position on the map
	Vec2   p1(w,h);
	p0 = p1;
	Vec2   v1(0.0f, 0.0f); 
	v0 = v1;
};
//------
CTank::CTank():curPowerState(1){
};
//------
void CTank::SetTankPos(const Vec2& p0, const Vec2& v0) {
///--- set tank position
	this->gTank->mPosition = p0;
	this->gTank->mVelocity = v0;
};
//------
void CTank::tankMove(const int direction) {
///- move tank 
	 Vec2   p0(getTankPos().x, getTankPos().y);
	 Vec2   v0(0.0f, 0.0f); 
	 SetTankPos(p0, v0); 
//---
	switch(direction){
	 case up: gTank->mPosition.y -= margin; break;
	  case down: gTank->mPosition.y += margin;  break;
	   case left: gTank->mPosition.x -= margin;  break;
	    case right: gTank->mPosition.x += margin;  break;
	};//switch
};
//------
void CTank::tankCreate(const HINSTANCE hInst,const int h, const int w) {
///---
	SetBaseBitmap();
	init(h, w);
	 this->gTank = new Sprite();
	  gTank->reloadSprite2(::GetModuleHandle(NULL), baseBitmap, baseBitmapMask, p0, v0);
	   SetTankPos(p0, v0);
};
//------
void CTank::rotTank(int degree) {
///-------
	Vec2   p1(getTankPos().x, getTankPos().y);
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
	   gTank->reloadSprite2(::GetModuleHandle(NULL), resBitmap, resBitmapMask, p0, v0);
	    SetTankPos(p1, v1); 
	delete a;
};
//------
void CTank::tankRotate(const int direction){
///-------
	switch(direction){
	 case up: rotTank(updegree); break;
	  case down: rotTank(downdegree); break;
	   case left: rotTank(leftdegree); break;
	    case right: rotTank(rightdegree); break;
	};//switch
};
//------
const HBITMAP CTank::getTankImage(){
	return this->gTank->getImageBitmap();
};
//------
void CTank::tankDraw(HDC bufferDC, HDC tankDC) {
///-----
	 gTank->draw(bufferDC, tankDC); 
};
//------
void CTank::tankUpdate(float dt){
	this->gTank->update(dt);
};
//------
const Vec2 CTank::getTankPos() {
///-------
	return gTank->mPosition;
};
//------
void CTank::tankMoveBorders(const RECT& gMapRect){
///-----
	if(gTank->mPosition.x < (gMapRect.left+15) ) { 
     gTank->mPosition.x = (float)gMapRect.left+15; 
      gTank->mVelocity.x = 0.0f; 
       gTank->mVelocity.y = 0.0f; 
   } 
    if( gTank->mPosition.x > (gMapRect.right-215)) { 
     gTank->mPosition.x = (float)gMapRect.right-215; 
      gTank->mVelocity.x = 0.0f; 
       gTank->mVelocity.y = 0.0f;
	} 
    if( gTank->mPosition.y < (gMapRect.top+15) ) { 
     gTank->mPosition.y = (float)gMapRect.top+15; 
      gTank->mVelocity.x = 0.0f; 
       gTank->mVelocity.y = 0.0f; 
   } 
    if( gTank->mPosition.y > gMapRect.bottom-60 ) { 
     gTank->mPosition.y = (float)gMapRect.bottom-60; 
      gTank->mVelocity.x = 0.0f; 
       gTank->mVelocity.y = 0.0f; 
   }
};
//------
CTank::~CTank() {
///------
	delete gTank;
};
//------
void CTank::addPower(){
	if(this->curPowerState>=pow1&&this->curPowerState<pow3)
		++curPowerState;
};
void CTank::subPower(){
	if(this->curPowerState>pow1&&this->curPowerState<=pow3)
		--curPowerState;
};
const int CTank::getPowerState(){
	return curPowerState;
};
//---
void CTank::addLife(){
	++curLifeCount;
};
void CTank::subLife(){
	--curLifeCount;
};
const int CTank::getLife(){
	return ++curLifeCount;
};
//-------------------