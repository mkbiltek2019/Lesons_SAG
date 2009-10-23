// tank.cpp 
// By Frank Luna 
// August 24, 2004. 
 
//========================================================= 
// Includes 
//========================================================= 
#include <string> 
#include "BackBuffer.h" 
#include "Vec2.h" 
#include <list> 

using namespace std; 
 
//========================================================= 
// Globals 
//========================================================= 
HWND        ghMainWnd  = 0; // Main window handle. 
HINSTANCE   ghAppInst  = 0; // Application instance handle. 

 
// The backbuffer we will render onto. 
BackBuffer* gBackBuffer = 0; 
 
// The text that will appear in the main window's caption bar. 
string gWndCaption = "Game Institute Tank Sample"; 
 
// Client rectangle dimensions we will use. 
const int gClientWidth  = 800; 
const int gClientHeight = 600; 
 
// Center point of client rectangle. 
const POINT gClientCenter =  
{ 
  gClientWidth  / 2, 
  gClientHeight / 2 
}; 
 
// Pad window dimensions so that there is room for window 
// borders, caption bar, and menu. 
const int gWindowWidth  = gClientWidth  + 6; 
const int gWindowHeight = gClientHeight + 52; 
 
// Client area rectangle, which we will use to detect 
// if a bullet travels "out-of-bounds." 
RECT gMapRect = {0, 0, 800, 600}; 
 
// Vector to store the center position of the tank, 
// relative to the client area rectangle. 
Vec2 gTankPos(400.0f, 300.0f); 
 
// Handle to a pen we will use to draw the tank's gun. 
HPEN gGunPen; 
 
// A vector describing the direction the tank's gun 
// is aimed in.  The vector's magnitude denotes the 
// length of the gun. 
Vec2 gGunDir(0.0f, -120.0f); 
 
// A list, where we will add bullets to as they are fired. 
// The list stores the bullet positions, so that we can 
// draw an ellipse at the position of each bullet. 
list<Vec2> gBulletList; 
 
//========================================================= 
// Function Prototypes 
//========================================================= 
 
bool InitMainWindow(); 
int  Runn(); 
void DrawFramesPerSecond(float deltaTime); 
 
LRESULT CALLBACK  WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam); 
 
//========================================================= 
// Name: WinMain 
// Desc: Program execution starts here. 
//========================================================= 
 
int WINAPI  WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,  
  PSTR cmdLine, int showCmd) 
{ 
  ghAppInst = hInstance; 
 
  // Create the main window. 
  if( !InitMainWindow() )  { 
    MessageBox(0, "Window Creation Failed.", "Error", MB_OK); 
   return 0; 
 } 
 
  // Enter the message loop. 
  return Runn(); 
} 
  
//========================================================= 
// Name: InitMainWindow 
// Desc: Creates the main window upon which we will 
//       draw the game graphics onto.   
//========================================================= 
bool InitMainWindow() 
{ 
  WNDCLASS wc;  
  wc.style         = CS_HREDRAW | CS_VREDRAW; 
  wc.lpfnWndProc   = WndProc; 
  wc.cbClsExtra    = 0; 
  wc.cbWndExtra    = 0; 
  wc.hInstance     = ghAppInst; 
  wc.hIcon         = ::LoadIcon(0, IDI_APPLICATION); 
  wc.hCursor       = ::LoadCursor(0, IDC_ARROW); 
  wc.hbrBackground = (HBRUSH)::GetStockObject(NULL_BRUSH); 
  wc.lpszMenuName  = 0; 
  wc.lpszClassName = "MyWndClassName"; 
 
  RegisterClass( &wc ); 
 
  // WS_OVERLAPPED | WS_SYSMENU: Window cannot be resized 
  // and does not have a min/max button.   
  //ghMainMenu = LoadMenu(ghAppInst, MAKEINTRESOURCE(IDR_MENU)); 
  ghMainWnd = ::CreateWindow("MyWndClassName", gWndCaption.c_str(), WS_OVERLAPPED,  
    200, 200, gWindowWidth, gWindowHeight, 0, 0, ghAppInst, 0); 
 
  if(ghMainWnd == 0) 
 { 
    ::MessageBox(0, "CreateWindow - Failed", 0, 0); 
   return 0; 
 } 
 
 ShowWindow(ghMainWnd, SW_NORMAL); 
 UpdateWindow(ghMainWnd); 
 
  return true; 
} 
 
//========================================================= 
// Name: Run 
// Desc: Encapsulates the message loop. 
//========================================================= 
int Runn() { 

 MSG msg; 
 ZeroMemory(&msg, sizeof(MSG)); 
 
  // Get the current time. 
  float lastTime =1; //(float)timeGetTime();  
 
  while(msg.message != WM_QUIT)  { 
   // IF there is a Windows message then process it. 
   if(PeekMessage(&msg, 0, 0, 0, PM_REMOVE))   { 
   TranslateMessage(&msg); 
   DispatchMessage(&msg); 
  } 
   // ELSE, do game stuff. 
   else 
            {   
    // Get the time now. 
  //  float currTime  = (float)timeGetTime(); 
 
    // Compute the differences in time from the last 
    // time we checked.  Since the last time we checked 
    // was the previous loop iteration, this difference 
    // gives us the time between loop iterations... 
    // or, I.e., the time between frames. 
    float deltaTime = 0.01f;//(currTime - lastTime)*0.001f; 
	// Get the backbuffer DC. 
 HDC bbDC = gBackBuffer->getDC(); 
// Clear the entire backbuffer black.  This gives 
// up a black background. 
 HBRUSH oldBrush = (HBRUSH)SelectObject(bbDC, GetStockObject(BLACK_BRUSH)); 
 Rectangle(bbDC, 0, 0, 800, 600); 
// Draw the base of the tank--a rectangle surrounding
// the tank's center position point. 
 SelectObject(bbDC, GetStockObject(DKGRAY_BRUSH)); 
 Rectangle(bbDC, 
  (int)gTankPos.x - 50, 
  (int)gTankPos.y - 75, 
  (int)gTankPos.x + 50, 
  (int)gTankPos.y + 75); 
// Draw the gun base--an ellipse surrounding 
// the tank's center position point. 
 SelectObject(bbDC, GetStockObject(GRAY_BRUSH)); 
 Ellipse(bbDC, 
  (int)gTankPos.x - 40, 
  (int)gTankPos.y - 40, 
  (int)gTankPos.x + 40, 
  (int)gTankPos.y + 40); 
 // Draw the gun itself--a line from the tank's 
// center position point to the tip of the gun. 
 HPEN oldPen = (HPEN)SelectObject(bbDC, gGunPen); 
 MoveToEx(bbDC, (int)gTankPos.x, (int)gTankPos.y, 0); 
 LineTo(bbDC,  
  (int)(gTankPos.x + gGunDir.x),  
  (int)(gTankPos.y + gGunDir.y)); 
// Draw any bullets that where fired. 
 SelectObject(bbDC, GetStockObject(WHITE_BRUSH)); 
 SelectObject(bbDC, oldPen); 
// Bullet velocity is 5X the gun's direction's 
// magnitude. 
 Vec2 bulletVel = gGunDir * 5.0f; 
 list<Vec2>::iterator i = gBulletList.begin(); 
while( i != gBulletList.end() ) 
 { 
   // Update the bullet position. 
  *i += bulletVel * deltaTime; 
   // Get POINT form. 
  POINT p;
  p.x= i->x; p.y= i->y; 
  // Only draw bullet if it is still inside the 
// map boundaries, otherwise, delete it. 
if( !PtInRect(&gMapRect, p) ) 
  i = gBulletList.erase(i); 
else 
 { 
	       // Draw bullet as a circle. 
     Ellipse(bbDC,  
      p.x - 4, 
      p.y - 4, 
      p.x + 4, 
      p.y + 4); 
 
     ++i; // Next in list. 
    } 
   } 
 
   SelectObject(bbDC, oldBrush); 
  
   DrawFramesPerSecond(deltaTime); 
 
    // Now present the backbuffer contents to the main 
    // window client area. 
   gBackBuffer->present(); 
     
    // We are at the end of the loop iteration, so 
    // prepare for the next loop iteration by making 
    // the "current time" the "last time." 
   
   //lastTime = currTime; 
 
    // Free 20 miliseconds to Windows so we don't hog 
    // the system resources. 
   Sleep(20); 
             } 
       } 
  // Return exit code back to operating system. 
  return (int)msg.wParam; 
} 
 
//========================================================= 
// Name: DrawFramesPerSecond 
// Desc: This function is called every frame and updates 
//       the frame per second display in the main window 
//       caption. 
//========================================================= 
void DrawFramesPerSecond(float deltaTime) 
{ 
  // Make static so the variables persist even after 
  // the function returns. 
  static int   frameCnt    = 0; 
  static float timeElapsed = 0.0f; 
  static char  buffer[256]; 
 
  // Function called implies a new frame, so increment 
  // the frame count. 
 ++frameCnt; 
 
  // Also increment how much time has passed since the 
  // last frame.   
  timeElapsed += deltaTime; 
 
  // Has one second passed? 
  if( timeElapsed >= 1.0f ) 
	  { 
   // Yes, so compute the frames per second. 
   // FPS = frameCnt / timeElapsed, but since we 
   // compute only when timeElapsed = 1.0, we can  
   // reduce to: 
   // FPS = frameCnt / 1.0 = frameCnt. 
   
    sprintf(buffer, "--Frames Per Second = %d", frameCnt); 
 
   // Add the frames per second string to the main 
   // window caption--that is, we'll display the frames 
   // per second in the window's caption bar. 
    string newCaption = gWndCaption + buffer; 
 
   // Now set the new caption to the main window. 
  SetWindowText(ghMainWnd, newCaption.c_str()); 
  
   // Reset the counters to prepare for the next time 
   // we compute the frames per second. 
    frameCnt    = 0; 
  timeElapsed = 0.0f; 
 } 
} 
 
//========================================================= 
// Name: WndProc 
// Desc: The main window procedure. 
//========================================================= 
 
LRESULT CALLBACK  WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam) 
{  
 LOGPEN lp; 
 
  switch( msg ) 
 {  
  // Create application resources. 
  case WM_CREATE: 
 
   // Create the tank's gun pen. 
    lp.lopnColor   = RGB(150, 150, 150); 
    lp.lopnStyle   = PS_SOLID; 
  lp.lopnWidth.x = 10; 
  lp.lopnWidth.y = 10; 
  gGunPen = CreatePenIndirect(&lp); 
 
   // Create the backbuffer. 
  gBackBuffer = new BackBuffer( 
   hWnd,  
   gClientWidth, 
   gClientHeight); 
 
   return 0; 
 
 // case WM_COMMAND: 
 //  switch(LOWORD(wParam)) 
 // { 
	//     // Destroy the window when the user selects the 'exit' 
 //  // menu item. 
 //  case WM_DESTROY: 
	//DestroyWindow(ghMainWnd); 
 //   break; 
 // } 
 //  return 0; 
 
  case WM_KEYDOWN: 
   switch(wParam) 
  { 
   // Move left. 
   case 'A': 
   gTankPos.x -= 5.0f; 
    break; 
   // Move right. 
   case 'D': 
   gTankPos.x += 5.0f; 
    break; 
   // Move up--remember in Windows coords, -y = up. 
   case 'W':  
   gTankPos.y -= 5.0f; 
    break; 
   // Move down. 
   case 'S': 
	   gTankPos.y += 5.0f; 
    break; 
   // Rotate tank gun to the left. 
   case 'Q': 
   gGunDir.Rotate(-0.1f); 
    break; 
   // Rotate tank gun to the right. 
   case 'E': 
   gGunDir.Rotate(0.1f); 
    break; 
   // Fire a bullet. 
   case VK_SPACE: 
   gBulletList.push_back(gTankPos + gGunDir); 
    break; 
  } 
   return 0; 
 
  // Destroy application resources. 
  case WM_DESTROY:   
  DeleteObject(gGunPen); 
   delete gBackBuffer; 
  PostQuitMessage(0);  
   return 0;   
 }  
  // Forward any other messages we didn't handle to the 
  // default window procedure. 
  return DefWindowProc(hWnd, msg, wParam, lParam); 
} 