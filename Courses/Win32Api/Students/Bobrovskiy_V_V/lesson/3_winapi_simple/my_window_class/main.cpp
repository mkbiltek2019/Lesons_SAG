#include "MyWndClass.h"
//---------
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,LPSTR lpCmdLine,int nCmdShow)
{	
	int message=0;
	//-----------
	try{
		MyWndClass mywindow(hInstance);
		message=mywindow.Run();
	}catch(char* s){
		MessageBox(NULL,"Error",s,SW_SHOW);
	}
	catch(...){
		MessageBox(NULL,"Error","Some unknown error...",SW_SHOW);
	};
	//-----------
	return message;
};