#ifndef _C_MY_ENEMY_
#define _C_MY_ENEMY_
//--------------------
#include "windows.h"
#include "resource.h"
#include "Sprite.h"
#include "BackBuffer.h"
#include "Vec2.h"
#include "imagerot.h"
#include <stdio.h>
#include "CBullet.h"
#include "CTank.h"
//------------------
typedef class CTank;
//------------------
struct buld{
	int dir;
	Bullet fBullet;
};
//------------------
static float lastTime1 = 0;
//------
class CEnemy {
 private:	
    enum {wall = 2, unbreakwall=8, tank = 4, flag = 3, enemy = 5};
	enum {margin=5, mapn = 20, twidth=30, theight=30}; //move step
	enum {life = 3};
	enum power{pow1 = 1, pow2 = 2, pow3 = 3};
	enum {up =1 , down = 2, left = 3, right = 4};
	//----------
	int curPowerState;
	int curLifeCount;
	//----------
	 int prev;
	 float dt;
	//------
	enum {updegree = 0 , downdegree = 180, leftdegree = 90, rightdegree = 270};
	//----------
	Sprite* gEnemy;
	//-------------
	std::list<buld> fBulletList;
	//-------------
	Vec2   p0;
	Vec2   v0;
	//----------
	HBITMAP baseBitmap;
	HBITMAP baseBitmapMask;
	//----------
	void SetBaseBitmap();
	void rotEnemy(int degree);
	
public:
	CEnemy();
	void init(const int h, const int w);
	void SetEnemyPos(const Vec2& p0, const Vec2& v0);	
	void enemyMove(const int direction, const std::vector<RECT>& brik, std::vector<int>& mainmap);	
	void enemyEnginePlaySound();
	void enemyEngineStopSound();
	void enemyCreate(const HINSTANCE hInst, const int h, const int w, Vec2 tp);	
	void enemyRotate(const int direction);
	//---
	void enemyDraw(HDC bufferDC, HDC tankDC);
	void enemyUpdate(float dt);	
	void enemyMoveBorders(const RECT& gMapRect);
	const Vec2 getEnemyPos();
	const HBITMAP getTankImage();
	//---
	void shoot(const int direction);
	void drawbullet(const int direction,HDC bufferDC, HDC tankDC,
				    const std::vector<RECT>& brik, std::vector<int>& mainmap, CTank* good);
	//---
	void addPower();
	void subPower();
	void setPower(const size_t power);
	const int getPowerState();
	//---
	void addLife();
	void setLife(const int l);
	void subLife();
	const int getLife();
	//-------------------	
	~CEnemy();
};
typedef CEnemy* Enemy;
//--------------------
struct tn {
	Enemy tank;
	bool visible;
 };
//--------------------
#endif