#ifndef MY_DIALOG_WINDOW
#define MY_DIALOG_WINDOW
//------------
#include "windows.h"
#include "resource.h"
#include <WindowsX.h>
#include <commctrl.h>
#include <vector>
#include <list>
#include <Tlhelp32.h> 
#include <Psapi.h>
///-----------

//------------
class MyDialog {
private:
	HWND hDialog;	
public:
	//----
	MyDialog();
	static BOOL CALLBACK DlgProcStub( HWND hwnd,  UINT msg,  WPARAM wParam,  LPARAM lParam);
	BOOL  DlgProc( HWND hwnd,  UINT msg,  WPARAM wParam,  LPARAM lParam);
	//----
	int CreateDlg( HWND hwnd, INT resource, bool modal);	
	//----
	void DlgOnClose(HWND hWnd);
	void LMouseButDown(HWND hwnd, BOOL fDoubleClick, int x, int y, UINT keyFlags);
	void OnWmCommand(HWND hwnd, int id, HWND hwndCtl, UINT codeNotify);
	BOOL Cls_OnInitDialog(HWND hwnd, HWND hwndFocus, LPARAM lParam);
	//----
	VOID TimerProc(HWND hwnd, UINT uMsg, UINT_PTR idEvent, DWORD dwTime);
	static VOID CALLBACK TimerProcStub(HWND hwnd, UINT uMsg, UINT_PTR idEvent, DWORD dwTime);
	//----
	 void Cls_OnLButtonDown(HWND hwnd, BOOL fDoubleClick, int x, int y, UINT keyFlags);
};
//---
typedef MyDialog* pDialogWnd;
static INT_PTR hMod;
static bool Mod;
//------------
#endif