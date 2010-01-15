#include "CEnemy.h"
//------------------
//--------------------
void CEnemy::SetBaseBitmap() {
///--
	if(baseBitmap!=NULL) DeleteObject (baseBitmap);
	if(baseBitmapMask!=NULL) DeleteObject (baseBitmapMask);
	//--------
	switch(this->curPowerState){
			case pow1:{
				 baseBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_ET1));;
				 baseBitmapMask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_T1BG));						  
			}break;
			case pow2:{
				 baseBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_ET2));;
				 baseBitmapMask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_T1BG));	
			}break;
			case pow3:{
				 baseBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_ET3));;
				 baseBitmapMask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_T1BG));	
			}break;
		}//switch
};
void CEnemy::rotEnemy(int degree) {
///--
	Vec2   p1(getEnemyPos().x, getEnemyPos().y);
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

	   this->gEnemy->reloadSprite2(::GetModuleHandle(NULL), resBitmap, resBitmapMask, p0, v0);
	   this->SetEnemyPos(p1, v1); 
	//----	
	delete a;
	
};

CEnemy::CEnemy():curPowerState(2),curLifeCount(3) {
///------
	prev = 0; dt = 0;
};
void CEnemy::init(const int h, const int w) {
///------
	Vec2   p1(w,h);
	p0 = p1;
	Vec2   v1(0.0f, 0.0f); 
	v0 = v1;
};
void CEnemy::SetEnemyPos(const Vec2& p0, const Vec2& v0){
///----
	this->gEnemy->mPosition = p0;
	this->gEnemy->mVelocity = v0;
};	
void CEnemy::enemyMove(const int direction, const std::vector<RECT>& brik, std::vector<int>& mainmap){
///---- tyt bla popravutu ryh voroguiv
	Vec2   p0(getEnemyPos().x, getEnemyPos().y);
	  POINT	pt = {(int)p0.x, (int)p0.y};
	 Vec2   v0(0.0f, 0.0f); 
	 SetEnemyPos(p0, v0); 
	   int dir = direction;
	   const int marg = 20;
	   const int margt = 12;
//---------------tank can't move through the walls-----------------------
	 int k = 0;
	 for(int i = 0; i < mapn; ++i){
		 for(int j = 0; j < mapn; ++j){
			 //---up-----
			 switch(direction) {
			 case up:{
				 RECT br(brik[k]);
				 br.right += margt;
				  br.left -= margt; 
				   br.bottom += marg;
				POINT p = {(int)gEnemy->mPosition.x, (int)gEnemy->mPosition.y};
				 if( PtInRect(&br, p)&&(mainmap[k]>= wall)){
					dir = 0;
				 }		 
			 }break;
			  case down:{
			     RECT br(brik[k]);
				 br.right += margt;
				  br.left -= margt; 
				   br.top -= marg;
				 POINT p = {(int)gEnemy->mPosition.x, (int)gEnemy->mPosition.y};
				 if( PtInRect(&br, p)&& (mainmap[k]>=wall)){
					dir = 0;
				 }		 
			 }break;
		      case left:{
			     RECT br(brik[k]);
				  br.top -= margt;
				   br.right += marg; 
				    br.bottom += margt;
				POINT p = {(int)gEnemy->mPosition.x, (int)gEnemy->mPosition.y};
				 if( PtInRect(&br, p)&& (mainmap[k]>=wall)){
					dir = 0;
				 }	 
			 }break;
		      case right:{
				 RECT br(brik[k]);
				  br.top -= margt;
				   br.left -= marg; 
				    br.bottom += margt;
				 POINT p = {(int)gEnemy->mPosition.x, (int)gEnemy->mPosition.y};
				 if( PtInRect(&br, p)&& (mainmap[k]>=wall)){
					dir = 0;
				 }		 
			 }break;
			 }//switch
			 //--------
			 //if(dir!=0) {
			 if(PtInRect(&brik[k], pt)) {
				//static int	prev  = k;
				//if(mainmap[prev]==0){
				////	this->setLife(3);
				//	mainmap[k] = - this->getLife();
				//  mainmap[prev] = 0;
				//}else{
				// this->setLife(abs(mainmap[prev]));
				//}
				mainmap[k] = enemy;
				if(mainmap[prev]==enemy)
				 mainmap[prev] = 0;
				prev = k;
			 }
			 //}
			//-----
			 ++k;
		 }//j
	 }//i
//---
	switch(dir){
	 case up:{ 
			gEnemy->mPosition.y -= margin; 			
	 }break;
	 case down:{ 
			gEnemy->mPosition.y += margin;			
	 }  break;
	 case left:{ 
			gEnemy->mPosition.x -= margin;			 
	 } break;
	 case right:{
			gEnemy->mPosition.x += margin;				
	 } break;
	};//switch
	//---------------

};	
void CEnemy::enemyEnginePlaySound(){

};
void CEnemy::enemyEngineStopSound(){

};
void CEnemy::enemyCreate(const HINSTANCE hInst, const int h, const int w, Vec2 tp){
///-------
	SetBaseBitmap();
	init(h, w);
	 Vec2 v1(0,0);
	 this->gEnemy = new Sprite();
	  gEnemy->reloadSprite2(::GetModuleHandle(NULL), baseBitmap, baseBitmapMask, p0, v0);
	   SetEnemyPos(tp, v1);

};	
void CEnemy::enemyRotate(const int direction){
///--------
switch(direction){
	 case up: this->rotEnemy(updegree); break;
	  case down: this->rotEnemy(downdegree); break;
	   case left: this->rotEnemy(leftdegree); break;
	    case right: this->rotEnemy(rightdegree); break;
	};//switch
};
//---
void CEnemy::enemyDraw(HDC bufferDC, HDC tankDC){
///---
	if(this->getLife()==0){
		if(baseBitmap!=NULL) DeleteObject (baseBitmap);
		if(baseBitmap!=NULL) DeleteObject (baseBitmapMask);
		if(!fBulletList.empty()) fBulletList.clear();
		delete this->gEnemy;
	} else {
		this->gEnemy->draw(bufferDC, tankDC); 	
	}
};
void CEnemy::enemyUpdate(float dt){
///-----
	this->gEnemy->update(dt);
};	
void CEnemy::enemyMoveBorders(const RECT& gMapRect){
///-----
	if(this->gEnemy->mPosition.x < (gMapRect.left+15) ) { 
     this->gEnemy->mPosition.x = (float)gMapRect.left+15; 
      this->gEnemy->mVelocity.x = 0.0f; 
       this->gEnemy->mVelocity.y = 0.0f; 
   } 
    if( this->gEnemy->mPosition.x > (gMapRect.right-215)) { 
     this->gEnemy->mPosition.x = (float)gMapRect.right-215; 
      this->gEnemy->mVelocity.x = 0.0f; 
       this->gEnemy->mVelocity.y = 0.0f;
	} 
    if( this->gEnemy->mPosition.y < (gMapRect.top+15) ) { 
     this->gEnemy->mPosition.y = (float)gMapRect.top+15; 
      this->gEnemy->mVelocity.x = 0.0f; 
       this->gEnemy->mVelocity.y = 0.0f; 
   } 
    if( this->gEnemy->mPosition.y > gMapRect.bottom-60 ) { 
     this->gEnemy->mPosition.y = (float)gMapRect.bottom-60; 
      this->gEnemy->mVelocity.x = 0.0f; 
       this->gEnemy->mVelocity.y = 0.0f; 
   }
};
const Vec2 CEnemy::getEnemyPos(){
///------
	return this->gEnemy->mPosition;
};
const HBITMAP CEnemy::getTankImage(){
	return this->gEnemy->getImageBitmap();
};
//---
void CEnemy::shoot(const int direction){
///-------
		float currTime  = (float)timeGetTime(); 
		float deltaTime = (currTime - lastTime1)*0.001f; 
		//-------
		  dt += deltaTime;
		if(dt > 0.5f) {
			buld tmp;
			tmp.dir = direction;
			Bullet tmpBullet = new CBullet();		
			//----
			Vec2 v0;
			Vec2 p1;
			v0.x = 0.0f; 
			v0.y = 0.0f; 
			//----
			tmpBullet->bulletCreate(GetModuleHandle(NULL), twidth, theight);
			tmpBullet->SetBaseBitmap();

			switch(direction) {
				case up:{
					p1.x = this->getEnemyPos().x;
					p1.y = this->getEnemyPos().y-25;
					  }break;
				case down:{
					  p1.x = this->getEnemyPos().x;
					p1.y = this->getEnemyPos().y+25;
					  }break;
				case left:{
					  p1.x = this->getEnemyPos().x-25;
					p1.y = this->getEnemyPos().y;
					  }break;
				case right:{
					  p1.x = this->getEnemyPos().x+25;
					p1.y = this->getEnemyPos().y;
					  }break;
			}
			tmpBullet->SetBulletPos(p1,v0);

	  		tmpBullet->bulletRotate(direction); 
			//--------------------------------
			tmp.fBullet = tmpBullet;
			tmp.dir = direction;
			this->fBulletList.push_back(tmp);
		dt = 0;	
		}
	//--------------------------------		
		lastTime1 = currTime;
};
void CEnemy::drawbullet(const int direction,HDC bufferDC, HDC tankDC,const std::vector<RECT>& brik,
						std::vector<int>& mainmap, CTank* good){
///---------
	 std::list<buld>::iterator i = this->fBulletList.begin();
   //--------
   while( i != fBulletList.end() ) { 
   //-------------------------------
		i->fBullet->bulletMove(i->dir, brik, mainmap);
		POINT p = {(int)i->fBullet->getBulletPos().x, (int)i->fBullet->getBulletPos().y};
		//p.x = i->fBullet->getBulletPos().x;
		//p.y = i->fBullet->getBulletPos().y;
	//-------------------------------
    //-------------------------------
	RECT gamerect = {0,0,600,600};
	if( !PtInRect(&gamerect, p) ) {
		i = fBulletList.erase(i); 			
	}
     else { 		
		 bool hit = false;

		 POINT po = {(int)good->getTankPos().x, (int)good->getTankPos().y};
				//-----
				RECT r = {0,0,0,0};
				//-----
				r.top = po.y - 13;
				r.left = po.x -13;
				r.bottom = po.y +13;
				r.right = po.x+13;
				//-----
				if(PtInRect(&r,po)&&(PtInRect(&r,p))) {
					i = fBulletList.erase(i);					
					 hit = true;
					if(good->getLife()>0){
						good->subLife();						
					} else {
						//good->destroy();						
					}//if				
				}//if
		 //---------------------------
		  if(!hit) {
			 if(i->fBullet->getlife()>0)
			   i->fBullet->bulletDraw(bufferDC, tankDC); 
			++i; 
		  }
     }//if
   }//while 
};
//---
void CEnemy::addPower(){
///-----
	if(this->curPowerState>=pow1&&this->curPowerState<pow3)
		++this->curPowerState;
};
void CEnemy::subPower(){
///---
	if(this->curPowerState>pow1&&this->curPowerState<=pow3)
		--this->curPowerState;
};
const int CEnemy::getPowerState(){
///-----
	return this->curPowerState;
};
//---
void CEnemy::addLife(){
	++this->curLifeCount;
};
void CEnemy::setLife(const int l){
///-----
	this->curLifeCount = l;
};
void CEnemy::setPower(const size_t power){
///-----
	switch(power){
	 case pow1:{
	   this->curPowerState = pow1;
	 }break;
	 case pow2:{
	   this->curPowerState = pow2;
	 }break;
	 case pow3:{
		 this->curPowerState = pow3;	   
	 }break;
	};	
};
void CEnemy::subLife(){
	if(this->curLifeCount>0)
	 --this->curLifeCount;
	/*else {
	 if(baseBitmap!=NULL) DeleteObject (baseBitmap);
	 if(baseBitmap!=NULL) DeleteObject (baseBitmapMask);
	 if(!fBulletList.empty()) fBulletList.clear();
	 delete this->gEnemy;	
	}*/
};
const int CEnemy::getLife(){
return this->curLifeCount;
};
//-------------------	
CEnemy::~CEnemy(){
//----
	if(baseBitmap!=NULL) DeleteObject (baseBitmap);
	if(baseBitmap!=NULL) DeleteObject (baseBitmapMask);
	if(!fBulletList.empty()) fBulletList.clear();
	delete this->gEnemy;

};