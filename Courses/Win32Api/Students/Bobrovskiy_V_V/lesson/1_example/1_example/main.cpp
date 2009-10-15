#include <windows.h>

/*
To compile this progect need change solution:
1_example->Properties->Character Set: Not Set or Use Multi-Byte Character Set 
*/
int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst,LPSTR cmdline,int show)
{

  MessageBox(NULL,"Hello","Hallo ",MB_OK);

return 0;
}