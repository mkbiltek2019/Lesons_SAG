#ifndef MY_DIALOG_WINDOW
#define MY_DIALOG_WINDOW
//------------
#include "windows.h"
#include "resource.h"
#include <WindowsX.h>
#include "CListOfFiles.h"
///-----------
class MyDialog {
private:
	HWND hDialog;	
public:
	//----
	MyDialog();
	static BOOL CALLBACK DlgProcStub( HWND hwnd,  UINT msg,  WPARAM wParam,  LPARAM lParam);
	BOOL  DlgProc( HWND hwnd,  UINT msg,  WPARAM wParam,  LPARAM lParam);
	//----
	HWND CreateDlg( HWND hwnd, INT resource, bool modal);	
	//----
	void DlgOnClose(HWND hWnd);
	void LMouseButDown(HWND hwnd, BOOL fDoubleClick, int x, int y, UINT keyFlags);
	void OnWmCommand(HWND hwnd, int id, HWND hwndCtl, UINT codeNotify);
	BOOL OnWmInitDialog(HWND hwnd, HWND hwndFocus, LPARAM lParam);
	//----
};
//---
typedef MyDialog* pDialogWnd;
static INT_PTR hMod;
static HWND hhhh = NULL;
static bool Mod;
//------------
#endif