#include "CMap.h"
//--------------------
void CMap::SetBaseBitmap(){
///---------	
	if(hWallBitmap1!=NULL) DeleteObject (hWallBitmap1);
	if(hWallBitmap1Mask!=NULL) DeleteObject (hWallBitmap1Mask);

	if(hWallBitmap2!=NULL) DeleteObject (hWallBitmap2);
	if(hWallBitmap2Mask!=NULL) DeleteObject (hWallBitmap2Mask);

	if(hFlagBitmap!=NULL) DeleteObject (hFlagBitmap);
	if(hFlagBitmapMask!=NULL) DeleteObject (hFlagBitmapMask);
	//----------
	hWallBitmap1 = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_WALLT1));
	hWallBitmap1Mask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_WALLMASK));
	//---
	hWallBitmap2 = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_WALLT2));
	hWallBitmap2Mask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_WALLMASK));
	//---
	hFlagBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_FLAG));
	hFlagBitmapMask = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_FLAGMASK));
};
//----------
void CMap::loadMapSprite(){
///---------
	Vec2 p0(wallsize, wallsize);
	Vec2 p1(flagsize, flagsize);
	//-------------
	Vec2 v0(0,0);
	Vec2 v1(0,0);
	SetBaseBitmap();
	//-------------	
	 this->gFlag= new Sprite();
	//-------------
	  gFlag->reloadSprite2(::GetModuleHandle(NULL), hFlagBitmap, hFlagBitmapMask, p1, v1);
	//-------------
};
//----------
void CMap::setgcmap(const int i,int val){
//-----
	if(i>0&&i<gvMap.size()){
		gvMap[i] = val;
	}
};
//----------
CMap::CMap():curWallLifes(wallMaxlife),curFlagLifes(flagMaxlife){
///--------
	SetBaseBitmap();
	loadMapSprite();
};
CMap::~CMap() {
///----------	
	if(hWallBitmap1!=NULL) DeleteObject (hWallBitmap1);
	if(hWallBitmap1Mask!=NULL) DeleteObject (hWallBitmap1Mask);

	if(hWallBitmap2!=NULL) DeleteObject (hWallBitmap2);
	if(hWallBitmap2Mask!=NULL) DeleteObject (hWallBitmap2Mask);

	if(hFlagBitmap!=NULL) DeleteObject (hFlagBitmap);
	if(hFlagBitmapMask!=NULL) DeleteObject (hFlagBitmapMask);
	//-----
	delete gFlag;	
};
//------
bool CMap::loadMapFromFile(const int gamelevel,HDC bufferDC, HDC tankDC){
///------
	createGridAndMapRect();
	//------
	char buff[15];
	int count = 0;
	bool fla = true;
	if((gamelevel>=1) && (gamelevel<=5)) {
		wsprintf(buff,"map%i.dat",gamelevel);
		std::ifstream read(buff);
		int buf = 0;
		//while(read.good()) {
			for(int i=0; i<mapn; ++i) 
			for(int j=0; j<mapn; ++j) {
				read >> buf;
				gvMap.push_back(buf);
				gvMapcopy.push_back(buf);
			    if(buf == 3){
					flagcoor = i*j;
				}				
			//-----------
			}//for
		//}//while
		read.close();	  
	}// 
			
	//-------load map sprite-------
	int k = 0;
	for(int i=0; i<mapn; ++i) {
			for(int j=0; j<mapn; ++j) {
				if((gvMap[k] > 0) &&(gvMap[k] <= 2)) {
					//-----
					 Vec2 p0(this->gvGrid[k].x,this->gvGrid[k].y);
					  Vec2 v0(0,0);
					   Sprite* sp = new Sprite(); 
					    sp->reloadSprite2(::GetModuleHandle(NULL), hWallBitmap1, hWallBitmap1Mask, p0, v0);
						//-----
						spriteco sco;
						 sco.Wall = sp;
						  sco.k = k;
						SpWall.push_back(sco);
						//--------
					    ++numofbrik;									 
				}
				if(gvMap[k] == 8) {
					 Vec2 p0(this->gvGrid[k].x,this->gvGrid[k].y);
					  Vec2 v0(0,0);
					   Sprite* sp = new Sprite(); 
					    sp->reloadSprite2(::GetModuleHandle(NULL), hWallBitmap2, hWallBitmap2Mask, p0, v0);
					     //SpWall.push_back(sp);
					    spriteco sco;
						 sco.Wall = sp;
						  sco.k = k;
						SpWall.push_back(sco);  
						++numofbrik;									 
				}if(gvMap[k] == 3) {
					if(fla){
					 Vec2 p0(this->gvGrid[k].x+15,this->gvGrid[k].y+15);
					  Vec2 v0(0,0);
					   Sprite* sp = new Sprite(); 
					    sp->reloadSprite2(::GetModuleHandle(NULL), hFlagBitmap, hFlagBitmapMask, p0, v0);
					    spriteco sco;
						 sco.Wall = sp;
						  sco.k = k;
						SpWall.push_back(sco);
						// SpWall.push_back(sp);
					}
					fla = false;
				}

				++k;
			}
	}
	//----------------------------
	return true;
};
void CMap::createGridAndMapRect(){
///-----
	int x = margin/2;
	 int y = margin/2;
	 Vec2 p(0,0);
	 RECT rect = {0,0,0,0};
	//------
	for(int i = 0; i < mapn; ++i) {
		for(int j = 0; j < mapn; ++j) {
			p.x = x; 
			 p.y = y;
			  this->gvGrid.push_back(p);
			 //-------
			 rect.top = y - margin/2;
			  rect.left = x- margin/2;
			   rect.bottom = y + margin/2;
			    rect.right = x + margin/2;
			 this->gvMapRect.push_back(rect);
			 //-------
			   x = x + margin;
		}
		x = margin / 2;
	     y = y + margin;	
	};
};
//----
RECT& CMap::getBrRect(const int k){
///-----
		return this->gvMapRect[k];			
};
const std::vector<RECT>& CMap::getBrikRect(){
	return this->gvMapRect;
};
//-----
std::vector<int>& CMap::getgvMap() {
	return this->gvMap;
};
//----
void CMap::mapDraw(HDC bufferDC, HDC tankDC){
///----
	for(int j=0; j<SpWall.size(); ++j) {
		SpWall[j].Wall->draw(bufferDC, tankDC);						
	}	
	
};
bool CMap::checkTankPos(const Vec2& p0) {
///---
return 1;
};
bool CMap::checkBulletPos(const Vec2& p0) {
///-----
return 0;
};
//------
void CMap::updateMap(std::vector<int>& mainmap){
///----
	//---	
	for(int i=0; i<mainmap.size(); ++i){
		std::vector<spriteco>::iterator it = SpWall.begin();
		for(int j=0; j<SpWall.size(); ++j){
			if((SpWall[j].k == i)&&((this->gvMapcopy[i]-mainmap[i])==2)) {
				it = SpWall.erase(it);
			}//if
			++it;
		}
	}
	//-----------
};
//------
void CMap::subLife(){
///----

};
//--------------------