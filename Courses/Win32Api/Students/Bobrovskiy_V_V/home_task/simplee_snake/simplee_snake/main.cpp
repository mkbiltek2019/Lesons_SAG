#include "MyWndClass.h"
//---------
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,LPSTR lpCmdLine,int nCmdShow) {
///--------
	int err=0;
	try {
	  MyWndClass mywindow(hInstance);
	  err= mywindow.Run();
	} catch(TCHAR* mess) {
		MessageBox(NULL,mess,"Error",MB_OK);
	}
	catch(...) {
	    MessageBox(NULL,"Unkonwn Error","Error",MB_OK);	
	}
	return err;
};