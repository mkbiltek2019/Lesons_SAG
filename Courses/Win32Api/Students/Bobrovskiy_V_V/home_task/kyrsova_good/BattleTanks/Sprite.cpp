#include "Sprite.h"
#include <assert.h>
//----------------------------------------------------------
Sprite::Sprite(){
///---
	mhImage = NULL;
	mhMask = NULL;
};
//-----
void Sprite::createSprite(HINSTANCE hAppInst, int imageID, int maskID, const Vec2& p0, const Vec2& v0) {
 ///-------
  mhAppInst = hAppInst; 
 
  if(mhImage!=NULL) DeleteObject (mhImage);
  if(mhMask!=NULL) DeleteObject (mhMask);

  mhImage = LoadBitmap(hAppInst, MAKEINTRESOURCE(imageID)); 
  mhMask  = LoadBitmap(hAppInst, MAKEINTRESOURCE(maskID)); 
 
  GetObject(mhImage, sizeof(BITMAP), &mImageBM); 
  GetObject(mhMask,  sizeof(BITMAP), &mMaskBM); 
 
  assert(mImageBM.bmWidth  == mMaskBM.bmWidth); 
  assert(mImageBM.bmHeight == mMaskBM.bmHeight);  
  
  mPosition       = p0; 
  mVelocity       = v0; 
};  
//-----
Sprite::Sprite(HINSTANCE hAppInst, int imageID, int maskID, const Vec2& p0, const Vec2& v0) { 
///-------
   createSprite(hAppInst, imageID, maskID, p0, v0);
} 
//----
void Sprite::reloadSprite(HINSTANCE hAppInst, int imageID, int maskID, const Vec2& p0, const Vec2& v0) {
///-----------
	createSprite(hAppInst, imageID, maskID, p0, v0);
}
//----
void Sprite::reloadSprite2(HINSTANCE hAppInst, HBITMAP imageBitmap, HBITMAP maskBitmap, const Vec2& p0, const Vec2& v0){
///-----
  mhAppInst = hAppInst; 

 	if(mhImage!=NULL) DeleteObject (mhImage);
	if(mhMask!=NULL) DeleteObject (mhMask);

  mhImage = imageBitmap; 
  mhMask  = maskBitmap; 
 
  GetObject(mhImage, sizeof(BITMAP), &mImageBM); 
  GetObject(mhMask,  sizeof(BITMAP), &mMaskBM); 
 
  assert(mImageBM.bmWidth  == mMaskBM.bmWidth); 
  assert(mImageBM.bmHeight == mMaskBM.bmHeight);  
  
  mPosition       = p0; 
  mVelocity       = v0; 

};
//----
const HBITMAP Sprite::getImageBitmap(){
	return mhImage;
};;
//----
Sprite::~Sprite() { 
///-----
 DeleteObject(mhImage); 
 DeleteObject(mhMask); 
} 
//----
int Sprite::width() { 
///----
  return mImageBM.bmWidth; 
} 
//----
int Sprite::height() { 
///---
  return mImageBM.bmHeight; 
} 
//----
void Sprite::update(float dt) { 
 ///---
  mPosition += mVelocity * dt;   
} 
//----
void Sprite::draw(HDC hBackBufferDC, HDC hSpriteDC) { 
///-------- 
  int w = width(); 
  int h = height(); 
 
  // Upper-left corner. 
  int x = (int)mPosition.x - (w / 2); 
  int y = (int)mPosition.y - (h / 2); 

  HGDIOBJ oldObj = SelectObject(hSpriteDC, mhMask); 
 
  BitBlt(hBackBufferDC, x, y, w, h, hSpriteDC, 0, 0, SRCAND);  
 
  SelectObject(hSpriteDC, mhImage); 

  BitBlt(hBackBufferDC, x, y, w, h, hSpriteDC, 0, 0, SRCPAINT); 
 
  SelectObject(hSpriteDC, oldObj); 
  ::ReleaseDC(NULL,hSpriteDC);
} 
//----
