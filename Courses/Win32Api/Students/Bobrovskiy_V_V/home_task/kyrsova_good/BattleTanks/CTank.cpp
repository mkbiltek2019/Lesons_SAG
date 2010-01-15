#include "CTank.h"
//-------------------
void CTank::SetBaseBitmap() {
/// -- set base tank bitmap according the tank power level
	if(baseBitmap!=NULL) DeleteObject (baseBitmap);
	if(baseBitmapMask!=NULL) DeleteObject (baseBitmapMask);
	//--------
	switch(this->curPowerState){
			case pow1:{
				// baseBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_TANKLEVEL1));
				// baseBitmapMask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_TANKLEVEL1MASK));
				baseBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_T1));
				 baseBitmapMask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_T1BG));
			}break;
			case pow2:{
				 baseBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_T2));
				 baseBitmapMask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_T1BG));						  
			}break;
			case pow3:{
				 baseBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_T3));
				 baseBitmapMask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_T1BG));
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
CTank::CTank():curPowerState(1),curLifeCount(3){
};
//------
void CTank::SetTankPos(const Vec2& p0, const Vec2& v0) {
///--- set tank position
	this->gTank->mPosition = p0;
	this->gTank->mVelocity = v0;
};
//------
void CTank::tankEnginePlaySound() {
///----------
	//TCHAR snd[] = "SND_TANKENGINE";//tankengine id in resources
	//PlaySoundA(snd, NULL, SND_RESOURCE|SND_ASYNC);
};
void CTank::tankEngineStopSound() {
///------
	//PlaySoundA(NULL, NULL, SND_RESOURCE|SND_ASYNC|SND_PURGE);
};
//------
void CTank::tankMove(const int direction,const std::vector<RECT>& brik, std::vector<int>& mainmap ) {
///- move tank 
	 Vec2   p0(getTankPos().x, getTankPos().y);
	  POINT	pt = {(int)p0.x, (int)p0.y};
	 Vec2   v0(0.0f, 0.0f); 
	  SetTankPos(p0, v0); 
	   int dir = direction;
	   const int marg = 20;
	   const int margt = 12;
	   static int prev = 393;
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
				POINT p = {(int)gTank->mPosition.x,(int) gTank->mPosition.y};
				 if( PtInRect(&br, p)&&(mainmap[k]>=wall)){
					dir = 0;
				 }		 
			 }break;
			  case down:{
			     RECT br(brik[k]);
				 br.right += margt;
				  br.left -= margt; 
				   br.top -= marg;
				 POINT p = {(int)gTank->mPosition.x, (int)gTank->mPosition.y};
				 if( PtInRect(&br, p)&& (mainmap[k]>=wall)){
					dir = 0;
				 }		 
			 }break;
		      case left:{
			     RECT br(brik[k]);
				  br.top -= margt;
				   br.right += marg; 
				    br.bottom += margt;
				POINT p = {(int)gTank->mPosition.x, (int)gTank->mPosition.y};
				 if( PtInRect(&br, p)&& (mainmap[k]>=wall)){
					dir = 0;
				 }	 
			 }break;
		      case right:{
				 RECT br(brik[k]);
				  br.top -= margt;
				   br.left -= marg; 
				    br.bottom += margt;
				 POINT p = {(int)gTank->mPosition.x, (int)gTank->mPosition.y};
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
				  	mainmap[k] = tank;
					if(mainmap[prev]==tank)
					mainmap[prev] = 0;
					prev = k;				  
			  }
			// }
			//-----
			 ++k;
		 }//j
	 }//i
//---
	switch(dir){
	 case up:{ 
			gTank->mPosition.y -= margin; 			
	 }break;
	 case down:{ 
			gTank->mPosition.y += margin;			
	 }  break;
	 case left:{ 
			gTank->mPosition.x -= margin;			 
	 } break;
	 case right:{
			gTank->mPosition.x += margin;				
	 } break;
	};//switch
	//---------------

};
//------
void CTank::tankCreate(const HINSTANCE hInst,const int h, const int w, Vec2 tp) {
///---
   SetBaseBitmap();
	init(h, w);
	 Vec2 v1(0,0);
	 this->gTank = new Sprite();
	  gTank->reloadSprite2(::GetModuleHandle(NULL), baseBitmap, baseBitmapMask, p0, v0);
	   SetTankPos(tp, v1);
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
	this->SetBaseBitmap();
	if(resBitmap!=NULL) DeleteObject (resBitmap);
	if(resBitmapMask!=NULL) DeleteObject (resBitmapMask);
	//----------
	 Rot a = new aarot();
	 resBitmap = a->rotate(baseBitmap, degree, 0, true);
	  resBitmapMask =  a->rotate(baseBitmapMask, degree, 0, true);		

	   this->gTank->reloadSprite2(::GetModuleHandle(NULL), resBitmap, resBitmapMask, p0, v0);
	    this->SetTankPos(p1, v1); 

	
	delete a;
};
//------
void CTank::tankRotate(const int direction){
///-------
	switch(direction){
	 case up: this->rotTank(updegree); break;
	  case down: this->rotTank(downdegree); break;
	   case left: this->rotTank(leftdegree); break;
	    case right: this->rotTank(rightdegree); break;
	};//switch
};
//------
const HBITMAP CTank::getTankImage(){
	return this->gTank->getImageBitmap();
};
//------
void CTank::tankDraw(HDC bufferDC, HDC tankDC) {
///-----
	if(this->getLife()==0){
		delete this->gTank;
	} else {
		this->gTank->draw(bufferDC, tankDC); 	
	}
};
//------
void CTank::tankUpdate(float dt){
	this->gTank->update(dt);
};
//------
const Vec2 CTank::getTankPos() {
///-------
	return this->gTank->mPosition;
};
//------
void CTank::tankMoveBorders(const RECT& gMapRect){
///-----
	if(this->gTank->mPosition.x < (gMapRect.left+15) ) { 
     this->gTank->mPosition.x = (float)gMapRect.left+15; 
      this->gTank->mVelocity.x = 0.0f; 
       this->gTank->mVelocity.y = 0.0f; 
   } 
    if( this->gTank->mPosition.x > (gMapRect.right-215)) { 
     this->gTank->mPosition.x = (float)gMapRect.right-215; 
      this->gTank->mVelocity.x = 0.0f; 
       this->gTank->mVelocity.y = 0.0f;
	} 
    if( this->gTank->mPosition.y < (gMapRect.top+15) ) { 
     this->gTank->mPosition.y = (float)gMapRect.top+15; 
      this->gTank->mVelocity.x = 0.0f; 
       this->gTank->mVelocity.y = 0.0f; 
   } 
    if( this->gTank->mPosition.y > gMapRect.bottom-60 ) { 
     this->gTank->mPosition.y = (float)gMapRect.bottom-60; 
      this->gTank->mVelocity.x = 0.0f; 
       this->gTank->mVelocity.y = 0.0f; 
   }
//--------------------
};
//------
void CTank::destroy() {
///---------
	if(baseBitmap!=NULL) DeleteObject (baseBitmap);
	if(baseBitmap!=NULL) DeleteObject (baseBitmapMask);
	if(!fBulletList.empty()) fBulletList.clear();
	delete this->gTank;
};
//------
CTank::~CTank() {
///------
	if(baseBitmap!=NULL) DeleteObject (baseBitmap);
	if(baseBitmap!=NULL) DeleteObject (baseBitmapMask);
	if(!fBulletList.empty()) fBulletList.clear();
	delete this->gTank;
};
//------
void CTank::addPower(){
	if(this->curPowerState>=pow1&&this->curPowerState<pow3)
		++this->curPowerState;
};
void CTank::subPower(){
	if(this->curPowerState>pow1&&this->curPowerState<=pow3)
		--this->curPowerState;
};
const int CTank::getPowerState(){
	return this->curPowerState;
};
//---
void CTank::addLife(){
	++this->curLifeCount;
};
void CTank::subLife(){
	--this->curLifeCount;
};
const int CTank::getLife(){
	return this->curLifeCount;
};
void CTank::setLife(const int l){
///----
	this->curLifeCount = l;
};
//-------------------
void CTank::shoot(const int direction,HDC bufferDC, HDC tankDC) {
///-------------
		//float currTime  = (float)timeGetTime(); 
		//float deltaTime = (currTime - lastTime)*0.001f; 

		//if(deltaTime>0.3f) {
			buldir tmp;
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
					p1.x = this->getTankPos().x;
					p1.y = this->getTankPos().y-25;
					  }break;
				case down:{
					  p1.x = this->getTankPos().x;
					p1.y = this->getTankPos().y+25;
					  }break;
				case left:{
					  p1.x = this->getTankPos().x-25;
					p1.y = this->getTankPos().y;
					  }break;
				case right:{
					  p1.x = this->getTankPos().x+25;
					p1.y = this->getTankPos().y;
					  }break;
			}
			tmpBullet->SetBulletPos(p1,v0);

	  		tmpBullet->bulletRotate(direction); 
			//--------------------------------
			tmp.fBullet = tmpBullet;
			tmp.dir = direction;
			this->fBulletList.push_back(tmp);
			
		//}
	//--------------------------------		
		//lastTime = currTime;
};
const size_t CTank::drawbullet(const int direction,HDC bufferDC, HDC tankDC,const std::vector<RECT>& brik,
					   std::vector<int>& mainmap, std::vector<tn>* enem) {
///-----------
 size_t value = 0;
  std::list<buldir>::iterator i = this->fBulletList.begin();
   //--------
   while( i != fBulletList.end() ) { 
   //-------------------------------
	value += i->fBullet->bulletMove(i->dir, brik, mainmap);
	POINT p = {(int)i->fBullet->getBulletPos().x, (int)i->fBullet->getBulletPos().y};
	//-------------------------------
	 RECT gamerect = {0,0,600,600};
	 if( !PtInRect(&gamerect, p) ) {
		 i = fBulletList.erase(i);		
	 } else { 		
	    //---------------------------
		 std::vector<tn>::iterator it = enem->begin();
		 bool hit = false;
		while( it != enem->end() ) {		
		 POINT po = {(int)it->tank->getEnemyPos().x, (int)it->tank->getEnemyPos().y};
				//-----
				RECT r={0,0,0,0};
				//-----
				r.top = po.y - 13;
				r.left = po.x -13;
				r.bottom = po.y +13;
				r.right = po.x+13;
				//-----
				if(PtInRect(&r,po)&&(PtInRect(&r,p))) {
					if(i!=fBulletList.end())
					  i = fBulletList.erase(i);					
					   hit = true;
					if(it->tank->getLife()>1){
						it->tank->subLife();
						 ++it;
					} else {
						value = tankpoints;
						it = enem->erase(it);						
					}//if				
				}//if
				else {++it;}
			}//for
	    //---------------------------
		  if(!hit) {
			 if(i->fBullet->getlife()>0)
				i->fBullet->bulletDraw(bufferDC, tankDC); 
		   ++i; 
		 }
     }//if	
   }//while	
   return value;
};
//-------------------
