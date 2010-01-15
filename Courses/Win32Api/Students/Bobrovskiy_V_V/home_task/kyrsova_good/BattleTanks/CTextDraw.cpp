#include "CTextDraw.h"
//----------------------------
CTextDraw::CTextDraw(){
///-----	
};
CTextDraw::~CTextDraw(){
///-----
};
//----------------------------
const LOGFONT CTextDraw::DefineFont(const int heigth,const int width){
///------
	LOGFONT tmpFont;
	
    tmpFont.lfHeight = heigth;
    tmpFont.lfWidth =width;
    tmpFont.lfEscapement =0;
    tmpFont.lfOrientation =0;
    tmpFont.lfWeight = FW_NORMAL;
    tmpFont.lfItalic = false;
    tmpFont.lfUnderline = false;
    tmpFont.lfStrikeOut = false;
    tmpFont.lfCharSet = RUSSIAN_CHARSET;
    tmpFont.lfOutPrecision = OUT_DEFAULT_PRECIS;
    tmpFont.lfClipPrecision  = CLIP_DEFAULT_PRECIS;
    tmpFont.lfQuality = CLEARTYPE_QUALITY;
    tmpFont.lfPitchAndFamily = DEFAULT_PITCH;
	lstrcpy(tmpFont.lfFaceName,"Times");

	return tmpFont;
};
//----------------------
void CTextDraw::drawGameData(HDC hDC,int w, int h,int gClientWidth, const gscore& score){
///-----
	int startPos = 10;
	
	RECT rect;
	rect.left = gClientWidth;
	rect.top = 0;
	rect.right = w;
	rect.bottom = h;
	//---
	::SetTextColor(hDC,RGB(164,38,50));
	::SetBkColor(hDC,RGB(210,181,194));
	::SetBkMode(hDC,TRANSPARENT);
	//---
	LOGFONT logFont = DefineFont(16,8);
	HFONT hFon = ::CreateFontIndirect(&logFont);
	HFONT oldFont = (HFONT)::SelectObject(hDC,hFon);			
	//---
	TCHAR buf1[60];
	 wsprintf(buf1,"Level: %d", score.level);
 	  ::TextOut(hDC, gClientWidth+5, startPos, buf1, lstrlen(buf1));
	//---
	startPos+=40;
	TCHAR buf2[60];
	 wsprintf(buf2,"Points: %d", score.points);
	  ::TextOut(hDC, gClientWidth+5, startPos, buf2, lstrlen(buf2));
	//---
	startPos+=40;
	TCHAR buf3[60];
	wsprintf(buf3,"Lifes: %d", score.lifes);
	  ::TextOut(hDC, gClientWidth+5, startPos, buf3, lstrlen(buf3));
	//---
	startPos+=40;
	TCHAR buf4[60];
	wsprintf(buf4,"Enemys: %d", score.enemys);
	  ::TextOut(hDC, gClientWidth+5, startPos, buf4, lstrlen(buf4));
	//---
	::SelectObject(hDC,oldFont);
	::DeleteObject(hFon);
	//-----
	
};
//----------------------
