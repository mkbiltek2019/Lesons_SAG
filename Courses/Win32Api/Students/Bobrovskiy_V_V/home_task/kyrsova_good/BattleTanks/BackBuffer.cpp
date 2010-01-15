// BackBuffer.cpp 
// By Frank Luna 
// August 24, 2004. 
 
#include "BackBuffer.h" 
 
BackBuffer::BackBuffer(HWND hWnd, int width, int height) 
{ 
  // Save a copy of the main window handle. 
  mhWnd = hWnd; 
 
  // Get a handle to the device context associated with 
  // the window. 
  HDC hWndDC = GetDC(hWnd); 
 
  // Save the backbuffer dimensions. 
  mWidth  = width; 
  mHeight = height; 
 
  // Create system memory device context that is compatible  
  // with the window one. 
  mhDC = CreateCompatibleDC(hWndDC); 
 
  // Create the backbuffer surface bitmap that is compatible 
  // with the window device context bitmap format.  That is 
  // the surface we will render onto. 
  mhSurface = CreateCompatibleBitmap(hWndDC, width, height); 
 
  // Done with window DC. 
 ReleaseDC(hWnd, hWndDC); 
   // At this point, the back buffer surface is uninitialized, 
  // so lets clear it to some non-zero value.  Note that it 
  // needs to be non-zero.  If it is zero then it will mess 
  // up our sprite blending logic.   
 
  // Select the backbuffer bitmap into the DC. 
  mhOldObject = (HBITMAP)SelectObject(mhDC, mhSurface); 
 
  // Select a white brush. 
  HBRUSH white    = (HBRUSH)GetStockObject(WHITE_BRUSH); 
  HBRUSH oldBrush = (HBRUSH)SelectObject(mhDC, white); 
 
  // Clear the backbuffer rectangle. 
  Rectangle(mhDC, 0, 0, mWidth, mHeight); 
 
  // Restore the original brush. 
 SelectObject(mhDC, oldBrush); 
} 
BackBuffer::~BackBuffer() 
{ 
 SelectObject(mhDC, mhOldObject); 
  DeleteObject(mhSurface); 
   DeleteDC(mhDC); 
} 
HDC BackBuffer::getDC() 
{ 
  return mhDC; 
} 
int BackBuffer::width() 
{ 
  return mWidth; 
}
int BackBuffer::height() 
{ 
  return mHeight; 
} 
void BackBuffer::present() 
{ 
  // Get a handle to the device context associated with 
  // the window. 
  HDC hWndDC = GetDC(mhWnd); 
 
  // Copy the backbuffer contents over to the  
  // window client area. 
  BitBlt(hWndDC, 0, 0, mWidth, mHeight, mhDC, 0, 0, SRCCOPY|SRCERASE|CAPTUREBLT); 
  /*
  #define SRCCOPY             (DWORD)0x00CC0020  dest = source                   
#define SRCPAINT            (DWORD)0x00EE0086 dest = source OR dest           *
#define SRCAND              (DWORD)0x008800C6  dest = source AND dest          /
#define SRCINVERT           (DWORD)0x00660046 dest = source XOR dest          *
#define SRCERASE            (DWORD)0x00440328  dest = source AND (NOT dest )   
#define NOTSRCCOPY          (DWORD)0x00330008  dest = (NOT source)             *
#define NOTSRCERASE         (DWORD)0x001100A6  dest = (NOT src) AND (NOT dest) *
#define MERGECOPY           (DWORD)0x00C000CA  dest = (source AND pattern)     
#define MERGEPAINT          (DWORD)0x00BB0226  dest = (NOT source) OR dest     *
#define PATCOPY             (DWORD)0x00F00021  dest = pattern                  *
#define PATPAINT            (DWORD)0x00FB0A09  dest = DPSnoo                   
#define PATINVERT           (DWORD)0x005A0049  dest = pattern XOR dest         
#define DSTINVERT           (DWORD)0x00550009  dest = (NOT dest)               
#define BLACKNESS           (DWORD)0x00000042  dest = BLACK                    
#define WHITENESS           (DWORD)0x00FF0062  dest = WHITE                    
#if(WINVER >= 0x0500)

#define NOMIRRORBITMAP      (DWORD)0x80000000  Do not Mirror the bitmap in this call 
#define CAPTUREBLT          (DWORD)0x40000000  Include layered windows 
  */
 
  // Always free window DC when done. 
 ReleaseDC(mhWnd, hWndDC); 
}