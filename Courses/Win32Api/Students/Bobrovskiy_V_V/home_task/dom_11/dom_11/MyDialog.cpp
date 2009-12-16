#include "MyDialog.h"
#include <time.h>
#include <TCHAR.H>
//-----
//const int len = 40;
//-----
//struct inputedData{
//	
//	 TCHAR Name[len];
//	 TCHAR Surname[len];
//	 TCHAR ThirdName[len];
//	//-----
//	 TCHAR Phone[len];
//	 TCHAR Adress[len];
//	 TCHAR FamilyState[len];
//	 //----
//	 TCHAR Gender[len];
//	 TCHAR Nationality[len];
//	 //TCHAR Comment[len*10]; 
//	//------
//	// TCHAR FileName[len*10];	
//};
inputedData Mydata;
//-------------
fileList myFileList = NULL;
static std::vector<std::string> vect;
//-----------------------------------
void setFormdata(HWND hwnd) {
///------------
	//---1--
	HWND h = ::GetDlgItem(hwnd,IDC_NAME);
	::SetWindowText(h, Mydata.Name);
	//---2--
	h = ::GetDlgItem(hwnd,IDC_SURNAME);
	::SetWindowText(h, Mydata.Surname);
	//---3--
	h = ::GetDlgItem(hwnd,IDC_THIRDNAME);
	::SetWindowText(h, Mydata.ThirdName);
	//---4--
	h = ::GetDlgItem(hwnd,IDC_PHONE);
	::SetWindowText(h, Mydata.Phone);
	//---5--
	h = ::GetDlgItem(hwnd,IDC_ADRESS);
	::SetWindowText(h, Mydata.Adress);
	//---6--
	h = ::GetDlgItem(hwnd,IDC_FAMYLYSTATE);
	::SetWindowText(h, Mydata.FamilyState);
	//---7--
	h = ::GetDlgItem(hwnd,IDC_NATIONALITYCOMBO);
	::SetWindowText(h, Mydata.Nationality);
	//---8--
	h = ::GetDlgItem(hwnd,IDC_GENDERCOMBO);
	::SetWindowText(h, Mydata.Gender);
	//-----
}
//---
void getFormData(HWND hwnd) {
///----
	::GetDlgItemText(hwnd,IDC_NAME,Mydata.Name,40);
	//---
	::GetDlgItemText(hwnd,IDC_SURNAME, Mydata.Surname ,40);
	//----	
	::GetDlgItemText(hwnd,IDC_THIRDNAME, Mydata.ThirdName ,40);
	//----
	::GetDlgItemText(hwnd,IDC_PHONE,Mydata.Phone ,40);
	//----
	::GetDlgItemText(hwnd,IDC_ADRESS,Mydata.Adress ,40);
	//---
	::GetDlgItemText(hwnd,IDC_FAMYLYSTATE,Mydata.FamilyState ,40);
	//----get data from combobox ----
	::GetDlgItemText(hwnd,IDC_NATIONALITYCOMBO,Mydata.Nationality,40);
	//-----
	::GetDlgItemText(hwnd,IDC_GENDERCOMBO,Mydata.Gender,40);
}
//-----------------------------------
void MyDialog::DlgOnClose(HWND hWnd){
///-----
	  if(Mod){
		   ::EndDialog(hWnd,hMod);
		   ::DestroyWindow(hWnd);
		   ::PostQuitMessage(0);
	  } else {
		   ::DestroyWindow(hWnd);
		   ::PostQuitMessage(0);
	  }
};
//----------------------
BOOL MyDialog::OnWmInitDialog(HWND hwnd, HWND hwndFocus, LPARAM lParam){
//---------
	char s[3] = "Ч";
	char s1[3] = "Ж";
	HWND NationCom = ::GetDlgItem(hwnd, IDC_NATIONALITYCOMBO);
	::SendMessage(NationCom,CB_ADDSTRING,0,(LPARAM)s);
	::SendMessage(NationCom,CB_ADDSTRING,0,(LPARAM)s1);
	//---------
	HWND Gender = ::GetDlgItem(hwnd, IDC_GENDERCOMBO);
	char s2[30] = "українець";
	char s3[30] = "росіянин";
	char s4[30] = "поляк";
	char s5[30] = "білорус";
	::SendMessage(Gender,CB_ADDSTRING,0,(LPARAM)s2);
	::SendMessage(Gender,CB_ADDSTRING,0,(LPARAM)s3);
	::SendMessage(Gender,CB_ADDSTRING,0,(LPARAM)s4);
	::SendMessage(Gender,CB_ADDSTRING,0,(LPARAM)s5);
//---------
//---------
	 return true;
}	
//----------------------
void MyDialog::OnWmCommand(HWND hwnd, int id, HWND hwndCtl, UINT codeNotify){
///-----
	pDialogWnd pThis = (pDialogWnd)GetWindowLong(hwnd, GWL_USERDATA);

	if(id == ID_CHOOSE) {
	//------------create IDD_QUESTIONARIE dialog --------------
 		pDialogWnd CurDialog = NULL;
 		 HWND hh = CurDialog->CreateDlg(hwnd,IDD_QUESTIONARIE,false);		   
	}
	//-------------------------
	if(id == IDC_SELECTFORM) {
		//-----------load ankets file names to IDD_QUESTIONARIE dialog------
		HWND h = ::GetDlgItem(hwnd, IDC_LIST2);
		//------
		 	myFileList = new CListOfFiles();
			 myFileList->createListOfFiles("..\\formlist\\");
			 vect = myFileList->getListOfFiles();
			for(int i=0; i<vect.size(); ++i) {
				::SendMessage( h, LB_ADDSTRING, (WPARAM)0, (LPARAM)vect[i].c_str());
			}
		//------		
			delete myFileList;	
	}
	//--------------------------
	if(id == IDC_SELECTFORMT) {
		char str[80];
		HWND list = ::GetDlgItem(hwnd,IDC_LIST2);
		LRESULT ind = SendMessage(list, LB_GETCURSEL,0,0);
		Mydata = myFileList->readdatafromfile(vect[ind]);
		setFormdata(hhhh);
	}
	//--------------------------
	if(id == IDC_STORETOFILE) {
		getFormData(hwnd);
		 myFileList->writedatatofile(Mydata);
	}
	//--------------------------
	//--------------------------
	if(id == IDC_DELETEFORM) {
		HWND list = ::GetDlgItem(hwnd,IDC_LIST2);
		LRESULT ind = SendMessage(list, LB_GETCURSEL,0,0);		  
		TCHAR buf[80];
		SendMessage(hwnd,LB_DELETESTRING,(WPARAM)ind,0);
		  std::string st("..\\formlist\\");
		  st.append(vect[ind]);
		  myFileList->removeFile(st);
		  vect.erase(vect.begin()+ind);
		  ind = 0;
	}
	//--------------------------
	if(id == ID_MYDIALOGEXIT) {
	  if(Mod){
		   ::EndDialog(hwnd,hMod);
		   ::DestroyWindow(hwnd);
		   ::PostQuitMessage(0);
	  } else {
		   ::DestroyWindow(hwnd);
		   ::PostQuitMessage(0);
	  }
	}
};
//----------------------
MyDialog::MyDialog(){
	SetWindowLong( hDialog, GWL_USERDATA, (LONG)this);
	SetWindowLong( hDialog, GWL_WNDPROC, (LONG)DlgProcStub);
	Mod = false;
};
//----
BOOL CALLBACK MyDialog::DlgProcStub( HWND hWnd,  UINT msg,  WPARAM wParam,  LPARAM lParam) {
///---
	pDialogWnd pThis = (pDialogWnd)GetWindowLong(hWnd, GWL_USERDATA);
	 return pThis->DlgProc(hWnd, msg, wParam, lParam);
};
//----
BOOL MyDialog::DlgProc( HWND hWnd,  UINT msg,  WPARAM wParam,  LPARAM lParam) {
///---	
	pDialogWnd pThis = (pDialogWnd)GetWindowLong(hWnd, GWL_USERDATA);
//--------
	switch(msg){
		HANDLE_MSG(hWnd,WM_INITDIALOG,pThis->OnWmInitDialog);		
		HANDLE_MSG(hWnd, WM_COMMAND, pThis->OnWmCommand);		
		//HANDLE_MSG(hWnd, WM_LBUTTONDOWN, pThis->LMouseButDown);
		HANDLE_MSG(hWnd, WM_CLOSE, pThis->DlgOnClose);	
		case WM_SETFOCUS: {
				setFormdata(hhhh);			  
		}return true;
	};
	return false;
};
//----
HWND MyDialog::CreateDlg( HWND hWnd, INT resource, bool modal){
///---
	 MSG msg;
	 Mod = modal;
	 //----------
		if(modal)
			hMod = ::DialogBox((HINSTANCE)NULL, MAKEINTRESOURCE(resource), hWnd, (DLGPROC)DlgProcStub);
		else
			hhhh = ::CreateDialog((HINSTANCE)NULL, MAKEINTRESOURCE(resource), hWnd, (DLGPROC)DlgProcStub);
	//----------
		//::AnimateWindow(h,500,AW_BLEND);// fade window effect
		::ShowWindow(hhhh,SW_SHOW);		
		SetFocus(hhhh); 
	//---
	while (GetMessage(&msg, NULL, 0, 0)) {  
			TranslateMessage(&msg); 
			DispatchMessage(&msg); 
	} 
	//---
	return hhhh;
};
