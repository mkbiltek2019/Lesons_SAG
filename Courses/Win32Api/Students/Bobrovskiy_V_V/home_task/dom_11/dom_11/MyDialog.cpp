#include "MyDialog.h"
#include <time.h>
#include <TCHAR.H>
//-----
inputedData Mydata;
//-------------
fileList myFileList = NULL;
static std::vector<std::basic_string<TCHAR> > vect;
static bool edit = false;
//-----------------------------------
void setreadonly(bool val,HWND hwnd) {
//----
	HWND h = ::GetDlgItem(hwnd,IDC_NAME);
	::SendMessage(h,EM_SETREADONLY,val,0);
	//---2--
	h = ::GetDlgItem(hwnd,IDC_SURNAME);
	::SendMessage(h,EM_SETREADONLY,val,0);
	//---3--
	h = ::GetDlgItem(hwnd,IDC_THIRDNAME);
	::SendMessage(h,EM_SETREADONLY,val,0);
	//---4--
	h = ::GetDlgItem(hwnd,IDC_PHONE);
	::SendMessage(h,EM_SETREADONLY,val,0);
	//---5--
	h = ::GetDlgItem(hwnd,IDC_ADRESS);
	::SendMessage(h,EM_SETREADONLY,val,0);
	//---6--
	h = ::GetDlgItem(hwnd,IDC_FAMYLYSTATE);
	::SendMessage(h,EM_SETREADONLY,val,0);
	//---7--
	h = ::GetDlgItem(hwnd,IDC_NATIONALITYCOMBO);
	::SendMessage(h,EM_SETREADONLY,val,0);
	//---8--
	h = ::GetDlgItem(hwnd,IDC_GENDERCOMBO);
	::SendMessage(h,EM_SETREADONLY,val,0);
	//-----
	h = ::GetDlgItem(hwnd,IDC_PHOTONAME);
	::SendMessage(h,EM_SETREADONLY,val,0);
}
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
	h = ::GetDlgItem(hwnd,IDC_GENDERCOMBO);
	::SetWindowText(h, Mydata.Nationality);
	//---8--
	h = ::GetDlgItem(hwnd,IDC_NATIONALITYCOMBO);
	::SetWindowText(h, Mydata.Gender);
	//-----
	h = ::GetDlgItem(hwnd,IDC_PHOTONAME);
	::SetWindowText(h, Mydata.PhotoPath);
	//------
	HBITMAP im =(HBITMAP)::LoadImage(::GetModuleHandle(0),Mydata.PhotoPath,IMAGE_BITMAP,400,400,LR_LOADFROMFILE|LR_DEFAULTSIZE);
    ::SendDlgItemMessage(hwnd,IDC_IM1,BM_SETIMAGE,IMAGE_BITMAP,LPARAM(im));
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
	::GetDlgItemText(hwnd,IDC_GENDERCOMBO,Mydata.Nationality,40);
	//-----
	::GetDlgItemText(hwnd,IDC_NATIONALITYCOMBO,Mydata.Gender,40);
	//-----
	::GetDlgItemText(hwnd,IDC_PHOTONAME,Mydata.PhotoPath,40);

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
	char s3[30] = "українка";
	::SendMessage(Gender,CB_ADDSTRING,0,(LPARAM)s2);
	::SendMessage(Gender,CB_ADDSTRING,0,(LPARAM)s3);
//---------
	 return true;
}	
//----------------------
void MyDialog::OnWmCommand(HWND hwnd, int id, HWND hwndCtl, UINT codeNotify){
///-----
	pDialogWnd pThis = (pDialogWnd)GetWindowLong(hwnd, GWL_USERDATA);

	if(id == ID_CHOOSE) {//
	//------------create IDD_QUESTIONARIE dialog --------------
 		pDialogWnd CurDialog = NULL;
 		 HWND hh = CurDialog->CreateDlg(hwnd,IDD_QUESTIONARIE,false);		   
	} 
	//-------------------------
	if(id == IDC_SELECTFORM) {/*&Завантажити список анкет*/
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
	if(id == IDC_LOADIMAGE) {
		OPENFILENAME ofn; 
		char szFile[260];
		ZeroMemory(&ofn, sizeof(ofn));
		ofn.lStructSize = sizeof(ofn);
		ofn.hwndOwner = hwnd;
		ofn.lpstrFile = szFile;
		ofn.lpstrFile[0] = '\0';
		ofn.nMaxFile = sizeof(szFile);
		ofn.lpstrFilter = "All\0*.*\0Bitmap\0*.bmp\0";
		ofn.nFilterIndex = 1;
		ofn.lpstrFileTitle = NULL;
		ofn.nMaxFileTitle = 0;
		ofn.lpstrInitialDir = NULL;
		ofn.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST;
		//-----		
		if (GetOpenFileName(&ofn)==TRUE) {
			//----------
			 WIN32_FIND_DATA FindFileData;
			   FindFirstFile(ofn.lpstrFile, &FindFileData);			  
				//FindFileData.cFileName;
				 std::basic_string<TCHAR> buff;
				 buff.append("..\\formlist\\");
				  buff.append(FindFileData.cFileName);
			//----------
				 ::SetDlgItemText(hwnd,IDC_PHOTONAME,buff.c_str());			
		}
		//-----
		HBITMAP im =(HBITMAP)::LoadImage(::GetModuleHandle(0),ofn.lpstrFile,IMAGE_BITMAP,400,400,LR_LOADFROMFILE|LR_DEFAULTSIZE);
    	 ::SendDlgItemMessage(hwnd,IDC_IM1,BM_SETIMAGE,IMAGE_BITMAP,LPARAM(im));
		 
	}
	//--------------------------
	if(id == IDC_SELECTFORMT) {//&Обрати
	  edit = true;
	   	HWND list = ::GetDlgItem(hwnd,IDC_LIST2);
		 LRESULT ind = SendMessage(list, LB_GETCURSEL,0,0);
		  Mydata = myFileList->readdatafromfile(vect[ind]);
	       setFormdata(hwnd);
	} 
	//--------------------------
	if(id == IDC_STORETOFILE) {//Записати у файл	
		 getFormData(hwnd);
		  myFileList->writedatatofile(Mydata);		
	} 	
	//--------------------------
	if(id == IDC_MYSHOW) {//&Показати
		setFormdata(hwnd);	
		setreadonly(edit,hwnd);			
	} 
	//-------------------------
	if(id == IDC_MODIFYLIST) {//&Редагувати
	   edit = false;
	 	HWND list = ::GetDlgItem(hwnd,IDC_LIST2);
		 LRESULT ind = SendMessage(list, LB_GETCURSEL,0,0);
		  Mydata = myFileList->readdatafromfile(vect[ind]);
			setFormdata(hwnd);								
	}
	//--------------------------
	if(id == IDC_DELETEUSERFORM) {//&Видалити
		HWND list = ::GetDlgItem(hwnd,IDC_LIST2);
		LRESULT ind = SendMessage(list, LB_GETCURSEL,0,0);		  
		TCHAR buf[80];
		SendMessage(hwnd,LB_DELETESTRING,(WPARAM)ind,0);
		  std::string st("..\\formlist\\");
		   st.append(vect[ind]);
		    myFileList->removeFile(st);
		     vect.erase(vect.begin()+ind);		    
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
		  HANDLE_MSG(hWnd, WM_CLOSE, pThis->DlgOnClose);		
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
