#ifndef _C_MY_TANK_
#define _C_MY_TANK_
//------------------
#include "windows.h"
#include "resource.h"
#include "Sprite.h"
#include "BackBuffer.h"
#include "Vec2.h"
#include "imagerot.h"
#include <stdio.h>
#include "CBullet.h"
#include "CEnemy.h"
//------------------
typedef struct tn;
//------------------
struct buldir{
	int dir;
	Bullet fBullet;
};
//------------------
 static float lastTime = 0; 
//------
class CTank {
 private:	
	enum {wall = 2, unbreakwall=8, tank = 4, flag = 3, enemy = 5};
	enum {margin=5, mapn = 20, twidth=30, theight=30}; //move step
	enum {wallpoints = 50, tankpoints = 500};
	enum {life = 3};
	int curLifeCount;
	//---------
	enum power{pow1 = 1, pow2 = 2, pow3 = 3};
	int curPowerState;
	enum {up =1 , down = 2, left = 3, right = 4};
	//----------
	enum {updegree = 0 , downdegree = 180, leftdegree = 90, rightdegree = 270};
	//----------
	Sprite* gTank;
	//----------
	std::list<buldir> fBulletList;
	//----------
	Vec2   p0;
	Vec2   v0;
	//----------
	HBITMAP baseBitmap;
	HBITMAP baseBitmapMask;
	//----------
	void SetBaseBitmap();
	void rotTank(int degree);
	//-------

public:
	CTank();
	void init(const int h, const int w);
	void SetTankPos(const Vec2& p0, const Vec2& v0);	
	void tankMove(const int direction, const std::vector<RECT>& brik, std::vector<int>& mainmap);	
	void tankEnginePlaySound();
	void tankEngineStopSound();
	void tankCreate(const HINSTANCE hInst, const int h, const int w, Vec2 tp);	
	void tankRotate(const int direction);
	//---
	void tankDraw(HDC bufferDC, HDC tankDC);
	void tankUpdate(float dt);	
	void tankMoveBorders(const RECT& gMapRect);
	const Vec2 getTankPos();
	const HBITMAP getTankImage();
	//---
	void shoot(const int direction,HDC bufferDC, HDC tankDC);
	const size_t drawbullet(const int direction,HDC bufferDC, HDC tankDC,const std::vector<RECT>& brik,
					std::vector<int>& mainmap, std::vector<tn>* enem);
	//---
	void addPower();
	void subPower();
	const int getPowerState();
	//---
	void addLife();
	void setLife(const int l);
	void subLife();
	const int getLife();
	//---	
	void destroy();
	~CTank();
};
///-----------------
typedef CTank* Tank;
//------------------
#endif