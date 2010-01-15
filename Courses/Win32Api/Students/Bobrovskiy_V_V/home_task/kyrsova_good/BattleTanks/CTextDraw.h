#ifndef _MY_TEXT_DRAWER_
#define _MY_TEXT_DRAWER_
//-----------------------------
#include "windows.h"
#include "iostream"
//--------------
struct gscore{
	size_t level;
	size_t points;
	size_t lifes;
	size_t enemys;
};
//--------------
class CTextDraw {	
private:
	const LOGFONT DefineFont(const int heigth,const int width);	
public:
	CTextDraw();
	~CTextDraw();
	void drawGameData(HDC dc,int w, int h, int leftMerg,const gscore& score);
};
typedef CTextDraw* textDrawer;
//-----------------------------
#endif