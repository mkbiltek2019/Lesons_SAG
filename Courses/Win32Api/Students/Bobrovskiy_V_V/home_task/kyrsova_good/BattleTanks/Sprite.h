#ifndef SPRITE_H 
#define SPRITE_H 
 //-----------------
#include <windows.h> 
#include "Vec2.h" 
#include <iostream>
#include <sstream>
 //-----------------
class Sprite { 
public:  
   Vec2      mPosition;  
   Vec2      mVelocity; 
   //----
   Sprite();//
  //-----
   Sprite(HINSTANCE hAppInst, int imageID, int maskID, const Vec2& p0, const Vec2& v0); 
   ~Sprite(); 
 
  int width(); 
  int height(); 
 
  void update(float dt); 
  void draw(HDC hBackBufferDC, HDC hSpriteDC); 
  void reloadSprite(HINSTANCE hAppInst, int imageID, int maskID, const Vec2& p0, const Vec2& v0); 
  void reloadSprite2(HINSTANCE hAppInst, HBITMAP imageBitmap, HBITMAP maskBitmap, const Vec2& p0, const Vec2& v0); 

  const HBITMAP getImageBitmap();
private: 
  void createSprite(HINSTANCE hAppInst, int imageID, int maskID, const Vec2& p0, const Vec2& v0);  	
  Sprite(const Sprite& rhs); 
  Sprite& operator=(const Sprite& rhs); 
 
protected: 
 HINSTANCE mhAppInst; 
  HBITMAP   mhImage; 
  HBITMAP   mhMask; 
  BITMAP    mImageBM; 
  BITMAP    mMaskBM; 
}; 
 
#endif // SPRITE_H 