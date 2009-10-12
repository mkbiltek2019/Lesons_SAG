#include "MyWndClass.h"
//---------
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,LPSTR lpCmdLine,int nCmdShow)
{
	MyWndClass mywindow(hInstance);
	return mywindow.Run();
};