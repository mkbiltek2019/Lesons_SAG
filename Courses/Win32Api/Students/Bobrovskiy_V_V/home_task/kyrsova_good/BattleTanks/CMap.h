#ifndef _C_MY_MAP_CREATOR_
#define _C_MY_MAP_CREATOR_
//--------------------------
#include "Sprite.h" 
#include "BackBuffer.h" 
#include <windows.h>
#include <string> 
#include <list> 
#include <vector>
#include "matrix.h"
#include <fstream>
#include <mmsystem.h>
#include "Vec2.h"
#include "imagerot.h"
#include "CTank.h"
#include "CDirection.h"
#include "CBullet.h"
//--------------------------
struct spriteco{
	Sprite* Wall; 
	int k;
};
//----
class CMap {
private:
	std::vector<int> gvMap;//load map from file main game vector
	std::vector<int> gvMapcopy;
	//--------------------------
	Sprite* gWall; 
	Sprite* gFlag;
	//----------------
	std::vector<spriteco> SpWall; 

	int numofbrik;
	//-----------------
	enum {wallsize = 30, flagsize = 60};
	int flagcoor;
	//---------------------------
	enum {wallMaxlife = 2};
	int curWallLifes;
	//---------------------------
	enum {flagMaxlife = 3};
	int curFlagLifes;
	//---------------------------
	enum {up =1 , down = 2, left = 3, right = 4};
	enum {margin = 30, mapn = 20};
	enum {space = 0, wall1 = 1, wall2 = 2, flag = 3};
	//----------
	int tankBmp;
	int tankBmpMask;
	//----------
	HBITMAP hWallBitmap1;
	HBITMAP hWallBitmap1Mask;
	//----------
	HBITMAP hWallBitmap2;
	HBITMAP hWallBitmap2Mask;
	//----------
	HBITMAP hFlagBitmap;
	HBITMAP hFlagBitmapMask;
	//----------
	void SetBaseBitmap();
	void loadMapSprite();
	//----------	
public:
	CMap();
	~CMap();
	
	std::vector<Vec2> gvGrid;	//create automatically vector of map briks centers coordinate
	std::vector<RECT> gvMapRect;	//create automatically //vector of map rectangles
	
	//------
	bool loadMapFromFile(const int gamelevel,HDC bufferDC, HDC tankDC);
	void createGridAndMapRect();
	//----
	void mapDraw(HDC bufferDC, HDC tankDC);
	bool checkTankPos(const Vec2& p0);
	bool checkBulletPos(const Vec2& p0);
	//------
	const std::vector<RECT>& getBrikRect();
	RECT& getBrRect(const int k);
	std::vector<int>& getgvMap();
	//------
	void updateMap(std::vector<int>& mainmap);
	void setgcmap(const int i,int val);
	//------
	void subLife();
};
typedef CMap* gameMap;
//--------------------------
#endif