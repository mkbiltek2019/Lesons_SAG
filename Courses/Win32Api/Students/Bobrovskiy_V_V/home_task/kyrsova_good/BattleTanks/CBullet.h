#ifndef _MY_C_BULLET_
#define _MY_C_BULLET_
//---------------------
#include "windows.h"
#include "resource.h"
#include "Sprite.h"
#include "BackBuffer.h"
#include "Vec2.h"
#include <list> 
#include <vector>
//------------------
#include "imagerot.h"
//-------------------
class CBullet {
private:
	enum {wall = 2, unbreakwall=8, tank = 4, flag = 3, enemy = 5};
	enum {margin=8, mapn = 20}; //move 
	enum {life = 1};
	int curLifeCount;
	enum power{pow1 = 1, pow2 = 2, pow3 = 3};
	int curPowerState;
	enum {up =1 , down = 2, left = 3, right = 4};
	//----------
	enum {updegree = 0 , downdegree = 180, leftdegree = 90, rightdegree = 270};
	//----------
	Sprite* gBullet;
	Vec2   p0;
	Vec2   v0;
	//----------
	//std::list<Vec2> gBulletPos; 
	Vec2 gBulletPos;
	//----------
	HBITMAP baseBitmap;
	HBITMAP baseBitmapMask;
	//----------
public:
	void SetBaseBitmap();
	void rotBullet(int degree);

	CBullet();
	void init(const int h, const int w);
	void SetBulletPos(const Vec2& p0, const Vec2& v0);	
	const size_t bulletMove(const int direction, const std::vector<RECT>& brik, 
					std::vector<int>& mainmap);	
	void bulletCreate(const HINSTANCE hInst, const int h, const int w);	
	void bulletRotate(const int direction);
	//---
	void setBulletStartPos(const Vec2& v);
	//---
	void bulletDraw(HDC bufferDC, HDC tankDC);
	void bulletUpdate(float dt);	
	void bulletMoveBorders(const RECT& gMapRect);
	const Vec2 getBulletPos();
	//---
	void addPower();
	const int getPowerState();
	//---
	//---
	void subLife();	
	const int getlife();
	//---
	void destroy();
	~CBullet();	
};
typedef CBullet* Bullet;
//---------------------

//---------------------
#endif