#include "Sprite.h"
#include <assert.h>

//----------------------------------------------------------
Sprite::Sprite(HINSTANCE hAppInst, int imageID, int maskID,  
            const Vec2& p0, const Vec2& v0) 
{ 
  mhAppInst = hAppInst; 
 
  // Load the bitmap resources. 
  mhImage = LoadBitmap(hAppInst, MAKEINTRESOURCE(imageID)); 
  mhMask  = LoadBitmap(hAppInst, MAKEINTRESOURCE(maskID)); 
 
  // Get the BITMAP structure for each of the bitmaps. 
 GetObject(mhImage, sizeof(BITMAP), &mImageBM); 
 GetObject(mhMask,  sizeof(BITMAP), &mMaskBM); 
 
  // Image and Mask should be the same dimensions. 
  assert(mImageBM.bmWidth  == mMaskBM.bmWidth); 
  assert(mImageBM.bmHeight == mMaskBM.bmHeight); 
 
  
  mPosition       = p0; 
  mVelocity       = v0; 
} 
//----
void Sprite::reloadSprite(HINSTANCE hAppInst, int imageID, int maskID, const Vec2& p0, const Vec2& v0){
	 mhAppInst = hAppInst; 
 
  // Load the bitmap resources. 
  mhImage = LoadBitmap(hAppInst, MAKEINTRESOURCE(imageID)); 
  mhMask  = LoadBitmap(hAppInst, MAKEINTRESOURCE(maskID)); 
 
  // Get the BITMAP structure for each of the bitmaps. 
 GetObject(mhImage, sizeof(BITMAP), &mImageBM); 
 GetObject(mhMask,  sizeof(BITMAP), &mMaskBM); 
 
  // Image and Mask should be the same dimensions. 
  assert(mImageBM.bmWidth  == mMaskBM.bmWidth); 
  assert(mImageBM.bmHeight == mMaskBM.bmHeight); 
 
  
  mPosition       = p0; 
  mVelocity       = v0; 
};
//----
Sprite::~Sprite() 
{ 
  // Free the resources we created in the constructor. 
 DeleteObject(mhImage); 
 DeleteObject(mhMask); 
} 
//----
int Sprite::width() 
{ 
  return mImageBM.bmWidth; 
} 
//----
int Sprite::height() 
{ 
  return mImageBM.bmHeight; 
} 
//----
void Sprite::update(float dt) 
{ 
  // Update the sprites position. 
  mPosition += mVelocity * dt; 
 
  // Update bounding circle, too.  That is, the b
  // circle moves with the sprite. 
  
} 
//----
void Sprite::draw(HDC hBackBufferDC, HDC hSpriteDC) 
{ 
  // The position BitBlt wants is not the sprite's center 
  // position; rather, it wants the upper-left position,  
  // so compute that. 
 
  int w = width(); 
  int h = height(); 
 
  // Upper-left corner. 
  int x = (int)mPosition.x - (w / 2); 
  int y = (int)mPosition.y - (h / 2); 
 
  // Note: For this masking technique to work, it is assumed 
  // the backbuffer bitmap has been cleared to some  
  // non-zero value. 
 
  // Select the mask bitmap. 
  HGDIOBJ oldObj = SelectObject(hSpriteDC, mhMask); 
 
  // Draw the mask to the backbuffer with SRCAND.  This  
  // only draws the black pixels in the mask to the backbuffer, 
  // thereby marking the pixels we want to draw the sprite 
  // image onto. 
  BitBlt(hBackBufferDC, x, y, w, h, hSpriteDC, 0, 0, SRCAND);  
 
  // Now select the image bitmap. 
 SelectObject(hSpriteDC, mhImage); 
   // Draw the image to the backbuffer with SRCPAINT.  This  
  // will only draw the image onto the pixels that where previously 
  // marked black by the mask. 
  BitBlt(hBackBufferDC, x, y, w, h, hSpriteDC, 0, 0, SRCPAINT); 
 
  // Restore the original bitmap object. 
 SelectObject(hSpriteDC, oldObj); 
} 
//----
