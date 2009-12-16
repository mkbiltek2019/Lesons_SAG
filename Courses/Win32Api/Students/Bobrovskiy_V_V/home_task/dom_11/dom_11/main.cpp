#include "MyDialog.h"
#include "resource.h"
//---------
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,LPSTR lpCmdLine,int nCmdShow)
{
	int err=0;

	try{

	 pDialogWnd pDlgWnd = NULL;
		pDlgWnd->CreateDlg((HWND)NULL,IDD_MAINDIALOG,true);

	}catch(TCHAR* mess){
		MessageBox(NULL,mess,"Error",MB_OK);
	}
	catch(...){
	    MessageBox(NULL,"Unkonwn Error","Error",MB_OK);	
	}

	return err;
};