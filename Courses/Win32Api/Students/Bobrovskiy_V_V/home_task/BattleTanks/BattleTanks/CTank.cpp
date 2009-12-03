#include "CTank.h"
//-------------------
void CTank::SetBitmap(int direction) {
///----
	if(direction==1) {//up
		this->tankBmp = IDB_TANKLEVEL1;
		this->tankBmpMask = IDB_TANKLEVEL1MASK;
	}
	if(direction==2) {//down
		this->tankBmp = IDB_TANKDOWN;
		this->tankBmpMask = IDB_TANKDOWNMASK;
	}
	if(direction==3) {//left
		this->tankBmp = IDB_TANKLEFT;
		this->tankBmpMask = IDB_TANKLEFTMASK;
	}
	if(direction==4) {//right
		this->tankBmp = IDB_TANKRIGHT;
		this->tankBmpMask = IDB_TANKRIGHTMASK;
	}
};
//------
CTank::CTank(const HINSTANCE hInst, const Vec2 p0, const Vec2 v0) {
///---
	SetBitmap(1);
	this->gTank = new Sprite(hInst, this->tankBmp, this->tankBmpMask, p0, v0); 
};
//------
void CTank::SetTankPos(const Vec2 p0, const Vec2 v0) {
///---
	
};
//------
void CTank::tankMove(const int direction) {
///--------
	if(direction==1) {//up
		gTank->mPosition.y -= margin;
	}
	if(direction==2) {//down
		gTank->mPosition.y += margin; 
	}
	if(direction==3) {//left
		gTank->mPosition.x -= margin;
	}
	if(direction==4) {//right
		gTank->mPosition.x += margin;
	}
gTank->mPosition.x -= margin;
};
//------
void CTank::tankUpdate() {
///---

};
//------
void CTank::tankRotate(const int direction) {
///------

};
//------
void CTank::tankDraw(HDC bufferDC, HDC tankDC) {
///-----

};
//------
const Vec2 CTank::getTankPos() {
///-------

};
//------
CTank::~CTank() {
///------
	delete gTank;
};
//-------------------