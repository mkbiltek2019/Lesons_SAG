#ifndef _MY_C_BULLET_
#define _MY_C_BULLET_
//---------------------
#include "windows.h"
#include "resource.h"
#include "Sprite.h"
#include "BackBuffer.h"
#include "Vec2.h"
#include <list> 
//------------------
#include "imagerot.h"
//---------------------
class CBullet {
private:
	enum {margin=5}; //move step
	enum {life = 1};
	int curLifeCount;
	enum power{pow1 = 1, pow2 = 2, pow3 = 3};
	int curPowerState;
	enum {up =1 , down = 2, left = 3, right = 4};
	//----------
	enum {updegree = 0 , downdegree = 180, leftdegree = 90, rightdegree = -90};
	//----------
	int bulletBmp;
	int bulletMask;
	Sprite* gBullet;
	Vec2   p0;
	Vec2   v0;
	//----------
	std::list<Vec2> gBulletPos; 
	//----------
	HBITMAP baseBitmap;
	HBITMAP baseBitmapMask;
	//----------
	void SetBaseBitmap();
	void rotBullet(int degree);
public:
	CBullet();
	void init(const int h, const int w);
	void SetBulletPos(const Vec2& p0, const Vec2& v0);	
	void bulletMove(const int direction);	
	void bulletCreate(const HINSTANCE hInst, const int h, const int w);	
	void bulletRotate(const int direction);
	//---
	void setBulletStartPos(const Vec2& v);
	//---
	void bulletDraw(HDC bufferDC, HDC tankDC, const int direction);
	void bulletUpdate(float dt);	
	void bulletMoveBorders(const RECT& gMapRect);
	const Vec2 getBulletPos();
	//---
	void addPower();
	const int getPowerState();
	//---

	//---
	void subLife();	
	//---
	~CBullet();	
};
typedef CBullet* Bullet;
//---------------------
#endif