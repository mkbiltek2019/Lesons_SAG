#include "CBullet.h"
//----------------------
void CBullet::SetBaseBitmap(){
///------
	if(this->baseBitmap!=NULL) DeleteObject (this->baseBitmap);
	if(this->baseBitmapMask!=NULL) DeleteObject (this->baseBitmapMask);

	switch(this->curPowerState){
			case pow1:{
				this->baseBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_BULLET));
				 this->baseBitmapMask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_BULLETMASK));						  
			}break;
			case pow2:{
				this-> baseBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_BULLET));
				  this->baseBitmapMask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_BULLETMASK));						  
			}break;
			case pow3:{
				 this->baseBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_BULLET));
				  this->baseBitmapMask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_BULLETMASK));
			}break;
	}//switchhb
};
//-------
const Vec2 CBullet::getBulletPos(){
	return this->gBullet->mPosition;
};
//-------
void CBullet::rotBullet(int degree){
///-------
	Vec2   p1(this->getBulletPos().x, this->getBulletPos().y);
	 Vec2   v1(0.0f, 0.0f); 
	//----------
	HBITMAP resBitmap = NULL;
	 HBITMAP resBitmapMask = NULL;
	//----------
	 this->SetBaseBitmap();
	 if(resBitmap!=NULL) DeleteObject (resBitmap);
	 if(resBitmapMask!=NULL) DeleteObject (resBitmapMask);
	//----------
	 Rot a = new aarot();
	 resBitmap = a->rotate(baseBitmap, degree, 0, true);
	  resBitmapMask =  a->rotate(baseBitmapMask, degree, 0, true);		
	   this->gBullet->reloadSprite2(::GetModuleHandle(NULL), resBitmap, resBitmapMask, p0, v0);
	    this->SetBulletPos(p1, v1); 	

	delete a;
};
//----------------------
CBullet::CBullet():curPowerState(1),curLifeCount(1){
///-----
};
CBullet::~CBullet(){
///------
	if(baseBitmap!=NULL) DeleteObject (baseBitmap);
	if(baseBitmapMask!=NULL) DeleteObject (baseBitmapMask);

	delete this->gBullet;
};
//---------
void CBullet::destroy(){
///-------
	this->curLifeCount = 0;
	this->curPowerState = 0;
	//-------
	Vec2 p0(0,0);
	this->gBullet->mPosition = p0;
	this->gBullet->mVelocity = p0;
	//-------
	if(baseBitmap!=NULL) DeleteObject (baseBitmap);
	if(baseBitmapMask!=NULL) DeleteObject (baseBitmapMask);
	
	delete this->gBullet;
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
//-----
const size_t CBullet::bulletMove(const int direction,const std::vector<RECT>& brik,
						 std::vector<int>& mainmap) {
///----
//------ 
	 enum {wallpoints = 50};
	 size_t value = 0;
	 Vec2   p0(this->getBulletPos().x, this->getBulletPos().y);
	 Vec2   v0(0.0f, 0.0f); 
   //----- 
	 RECT gMapRect = {10, 10, 590, 590}; 
	 POINT p = {this->getBulletPos().x, this->getBulletPos().y};
   //-----
	 if(!PtInRect(&gMapRect, p)) {
		this->destroy(); this->curLifeCount = 0; 
	}
	//-----	 
	if(curLifeCount!=0) {	
	 int k = 0;
	 for(int i = 0; i < mapn; ++i){
		 for(int j = 0; j < mapn; ++j){			 
			 if( PtInRect(&brik[k], p)&& (mainmap[k]!=0)){
				if((mainmap[k]>0)&&(mainmap[k]<=3)) {
					if(mainmap[k]==1) value = wallpoints;
					 --mainmap[k]; 
					 this->destroy();
					 this->curLifeCount = 0; 						
				 }
				if(mainmap[k] == unbreakwall) { this->destroy(); this->curLifeCount = 0; }
			  }	
			 //--------
			 ++k;
		 }
	 }
	  }
	//-----
	 if(this->curLifeCount!=0) {
		switch(direction){
		 case up:{ 
				gBullet->mPosition.y -= margin; 			
		 }break;
		 case down:{ 
				gBullet->mPosition.y += margin;			
		 }  break;
		 case left:{ 
				gBullet->mPosition.x -= margin;			 
		 } break;
		 case right:{
				gBullet->mPosition.x += margin;				
		 } break;
		};//switch	 
   }
	 return value;
};	
void CBullet::bulletCreate(const HINSTANCE hInst, const int h, const int w){
///------
	this->SetBaseBitmap();
	this->init(h, w);
	
	this->gBullet = new Sprite();
	  this->gBullet->reloadSprite2(::GetModuleHandle(NULL), baseBitmap, baseBitmapMask, p0, v0);
	   this->SetBulletPos(p0, v0);
};	
void CBullet::bulletRotate(const int direction){
///---
	switch(direction){
	 case up: this->rotBullet(updegree); break;
	  case down: this->rotBullet(downdegree); break;
	   case left: this->rotBullet(leftdegree); break;
	    case right: this->rotBullet(rightdegree); break;
	};//switch
};
//---
void CBullet::bulletDraw(HDC bufferDC, HDC tankDC){
///-----
	this->gBullet->draw(bufferDC, tankDC);
};
//------
void CBullet::setBulletStartPos(const Vec2& v){
	this->gBulletPos = v; 
};
//------
void CBullet::bulletUpdate(float dt){
///-----
	this->gBullet->update(dt);
};	
void CBullet::bulletMoveBorders(const RECT& gMapRect){
///----
};
//---
void CBullet::addPower(){
///---
	if(this->curPowerState>=pow1&&this->curPowerState<pow3)
		++this->curPowerState;
};
const int CBullet::getPowerState() {
///---
	return this->curPowerState;
};
//---	
void CBullet::subLife() {
///----
	--this->curLifeCount;
	if(this->curLifeCount==0)
	destroy(); 
};	
//---
const int CBullet::getlife(){
///----
	if(this->curLifeCount<=0)
		return 0;
	else
		return this->curLifeCount;
};
//----------------------