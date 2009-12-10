#ifndef _C_MY_TANK_
#define _C_MY_TANK_
//------------------
#include "windows.h"
#include "resource.h"
#include "Sprite.h"
#include "BackBuffer.h"
#include "Vec2.h"
#include "imagerot.h"
//------------------
class CTank {
 private:	
	enum {margin=5}; //move step
	enum {life = 3};
	int curLifeCount;
	enum power{pow1 = 1, pow2 = 2, pow3 = 3};
	int curPowerState;
	enum {up =1 , down = 2, left = 3, right = 4};
	//----------
	enum {updegree = 0 , downdegree = 180, leftdegree = 90, rightdegree = -90};
	//----------
	int tankBmp;
	int tankBmpMask;
	Sprite* gTank;
	Vec2   p0;
	Vec2   v0;
	//----------
	HBITMAP baseBitmap;
	HBITMAP baseBitmapMask;
	//----------
	void SetBaseBitmap();
	void rotTank(int degree);
public:
	CTank();
	void init(const int h, const int w);
	void SetTankPos(const Vec2& p0, const Vec2& v0);	
	void tankMove(const int direction);	
	void tankCreate(const HINSTANCE hInst, const int h, const int w);	
	void tankRotate(const int direction);
	//---
	void tankDraw(HDC bufferDC, HDC tankDC);
	void tankUpdate(float dt);	
	void tankMoveBorders(const RECT& gMapRect);
	const Vec2 getTankPos();
	const HBITMAP getTankImage();
	//---
	void addPower();
	void subPower();
	const int getPowerState();
	//---
	void addLife();
	void subLife();
	const int getLife();
	//---
	~CTank();
};
typedef CTank* Tank;
//------------------
#endif