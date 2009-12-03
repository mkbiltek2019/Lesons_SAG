#ifndef SPRITE_H 
#define SPRITE_H 
 
#include <windows.h> 
#include "Vec2.h" 
 
class Sprite 
{ 
public: 
 Sprite(HINSTANCE hAppInst, int imageID, int maskID, const Vec2& p0, const Vec2& v0); 
 
 ~Sprite(); 
 
  int width(); 
  int height(); 
 
  void update(float dt); 
  void draw(HDC hBackBufferDC, HDC hSpriteDC); 
  void reloadSprite(HINSTANCE hAppInst, int imageID, int maskID, const Vec2& p0, const Vec2& v0);
public: 
  // Keep these public because they need to be 
  // modified externally frequently. 
  Vec2      mPosition;  
  Vec2      mVelocity; 
 
private: 
  // Make copy constructor and assignment operator private 
  // so client cannot copy Sprites.  We do this because 
  // this class is not designed to be copied because it 
 // is not efficient--copying bitmaps is slow (lots of memory). 
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