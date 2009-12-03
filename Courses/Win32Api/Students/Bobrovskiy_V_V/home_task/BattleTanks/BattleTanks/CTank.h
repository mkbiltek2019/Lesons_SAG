#ifndef _C_MY_TANK_
#define _C_MY_TANK_
//------------------
#include "windows.h"
#include "Sprite.h"
#include "BackBuffer.h"
#include "Vec2.h"
//------------------
class CTank {
 private:
	Sprite* gTank;
	Vec2   p0;
	Vec2   v0;
	int tankBmp;
	int tankBmpMask;
	void SetBitmap(int direction);
 public:
	CTank(const HINSTANCE hInst, const int tankBitmap,const int tankMask,const Vec2 p0, const Vec2 v0);
	
	void SetTankPos(const Vec2 p0, const Vec2 v0);
	
	void tankMove(const int direction);
	
	void tankUpdate();
	
	void tankRotate(const int direction);
	
	void tankDraw(HDC bufferDC, HDC tankDC);

	const Vec2 getTankPos();

	~CTank();
};
typedef CTank* Tank;
//------------------
#endif