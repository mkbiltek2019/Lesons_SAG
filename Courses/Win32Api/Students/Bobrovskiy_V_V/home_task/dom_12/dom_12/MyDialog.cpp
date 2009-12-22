#include "MyDialog.h"
//-----
#pragma comment(linker, "/SECTION:.shr,RWS")
#pragma data_seg(".shr")
	HWND hGlobal = NULL;
#pragma data_seg()
//-----
static INT_PTR timer = 1;
//-----
std::vector< std::basic_string<TCHAR> > header;
//-----
static int iSlected = 0;
static bool pid = true;
static bool procname = true;
static bool username = true;
static bool threads = true;
static bool memory = true;
static bool proority = true;
static bool fullname = true;
//----
const int len = 40;
struct process {
	TCHAR PID[len];
	TCHAR exefilename[260];
	TCHAR usercreator[1000];
	TCHAR processname[1000];
	TCHAR memorysage[len];
	TCHAR priority[len];
	TCHAR threadnumber[len];
};
//-------------------------
std::vector<process> procList;
//-------------------------
bool KillProcByPid(DWORD pid) {
///---------
	DWORD ExitCode;
	HANDLE hp;
	bool ret = true;

	if(pid)	{
		hp = OpenProcess(PROCESS_TERMINATE, true, pid);
	  if (hp)	{
			GetExitCodeProcess(hp, &ExitCode);
	 		ret = TerminateProcess(hp, ExitCode);
	  }	else {
			return false;
	  }	
	} else 	{
			return false;
	 }

	CloseHandle(hp);
	return ret;
}

//-------------------------
bool SetDebugStatusForCurentProc() {
///--------not work with user rights
		HANDLE hToken;
		LUID DebugValue;
		TOKEN_PRIVILEGES tkp;

		if (!OpenProcessToken(GetCurrentProcess(),TOKEN_ADJUST_PRIVILEGES|PROCESS_QUERY_INFORMATION  |	TOKEN_QUERY,&hToken)) {
			return false;
		}

		if (!LookupPrivilegeValue((LPSTR) NULL,SE_DEBUG_NAME,&DebugValue)) {
			return false;
		}

		tkp.PrivilegeCount = 1;
		tkp.Privileges[0].Luid = DebugValue;
		tkp.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED|TOKEN_ADJUST_PRIVILEGES ;

		AdjustTokenPrivileges(hToken,FALSE,&tkp,sizeof(TOKEN_PRIVILEGES),(PTOKEN_PRIVILEGES)NULL,(PDWORD) NULL);

		if (GetLastError() != ERROR_SUCCESS) {
				return false;
		}

	return true;
}

//-------------------------
BOOL ListProcessModules( DWORD dwPID ) {
///--------
	  HANDLE hModuleSnap = INVALID_HANDLE_VALUE;
	  MODULEENTRY32 me32;
	  // Take a snapshot of all modules in the specified process.
	  hModuleSnap = CreateToolhelp32Snapshot( TH32CS_SNAPMODULE, dwPID );
	  if( hModuleSnap == INVALID_HANDLE_VALUE ) {
		throw "CreateToolhelp32Snapshot (of modules)" ;
		return( FALSE );
	  }
	  // Set the size of the structure before using it.
	  me32.dwSize = sizeof( MODULEENTRY32 );
	  // Retrieve information about the first module,
	  // and exit if unsuccessful
	  if( !Module32First( hModuleSnap, &me32 ) ) {
		throw "Module32First" ; // Show cause of failure
		CloseHandle( hModuleSnap );    // Must clean up the   snapshot object!
		return( FALSE );
	  }
	  // Now walk the module list of the process,
	  // and display information about each module
	  do
	  {
	  /*printf( "\n\n     MODULE NAME:     %s",      me32.szModule );
		printf( "\n     executable     = %s",      me32.szExePath );
		printf( "\n     process ID     = 0x%08X",      me32.th32ProcessID );
		printf( "\n     ref count (g)  =     0x%04X",      me32.GlblcntUsage );
		printf( "\n     ref count (p)  =     0x%04X",      me32.ProccntUsage );
		printf( "\n     base address   = 0x%08X",      (DWORD) me32.modBaseAddr );
		printf( "\n     base size      = %d",      me32.modBaseSize );*/

	  } while( Module32Next( hModuleSnap, &me32 ) );

	  CloseHandle( hModuleSnap );
	  return( TRUE );
}
//-------
BOOL ListProcessThreads( DWORD dwOwnerPID ) { 
  HANDLE hThreadSnap = INVALID_HANDLE_VALUE; 
  THREADENTRY32 te32; 
 
  // Take a snapshot of all running threads  
  hThreadSnap = CreateToolhelp32Snapshot( TH32CS_SNAPTHREAD, 0 ); 
  if( hThreadSnap == INVALID_HANDLE_VALUE ) 
    return( FALSE ); 
 
  // Fill in the size of the structure before using it. 
  te32.dwSize = sizeof(THREADENTRY32 ); 
 
  // Retrieve information about the first thread,
  // and exit if unsuccessful
  if( !Thread32First( hThreadSnap, &te32 ) ) 
  {
    throw "Thread32First" ; // Show cause of failure
    CloseHandle( hThreadSnap );    // Must clean up the snapshot object!
    return( FALSE );
  }

  // Now walk the thread list of the system,
  // and display information about each thread
  // associated with the specified process
  do { 
    if( te32.th32OwnerProcessID == dwOwnerPID )  {
     /* printf( "\n\n     THREAD ID      = 0x%08X", te32.th32ThreadID ); 
      printf( "\n     base priority  = %d", te32.tpBasePri ); 
      printf( "\n     delta priority = %d", te32.tpDeltaPri );*/ 
    }
  } while( Thread32Next(hThreadSnap, &te32 ) ); 

  CloseHandle( hThreadSnap );
  return( TRUE );
}
//-------------------------
void createProcessList() {
///---------
	//-----
	HANDLE t = NULL;
	 PROCESS_MEMORY_COUNTERS ppsmemCounters;
	//------------
	   memset(&ppsmemCounters, 0, sizeof(PPROCESS_MEMORY_COUNTERS)); 
	//--------------
	HANDLE hSnapShot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0); 
	 PROCESSENTRY32 pe32={0}; 
	  memset(&pe32, 0, sizeof(PROCESSENTRY32)); 
	    pe32.dwSize = sizeof(PROCESSENTRY32);
		
		  //--------		
		  if(Process32First(hSnapShot, &pe32)) { 	
			process tmpst={0};
			 t = OpenProcess( PROCESS_QUERY_INFORMATION | PROCESS_VM_READ , FALSE, pe32.th32ProcessID);
			 GetProcessMemoryInfo(t, &ppsmemCounters, sizeof(ppsmemCounters));				
			//-------------
			
			DWORD dwUserNameOnlyLength = 1000;
			char lpszUserNameOnly[1000];

			DWORD dwDomainLength = 1000;
			char lpszDomain[1000];

			SID_NAME_USE snu;
			UCHAR   InfoBuffer[1000];
			PTOKEN_USER pTokenUser = (PTOKEN_USER)InfoBuffer;
			DWORD   dwInfoBufferSize, dwAccountSize = 200, dwDomainSize = 128;
			HANDLE   hAccessToken;
			
			OpenProcessToken(t, TOKEN_READ, &hAccessToken);
			if(GetTokenInformation(hAccessToken, TokenUser, InfoBuffer, 1000, &dwInfoBufferSize)){
				LookupAccountSid(NULL, pTokenUser->User.Sid, lpszUserNameOnly, &dwUserNameOnlyLength, lpszDomain, &dwDomainLength, &snu);
				wsprintf(tmpst.usercreator,lpszUserNameOnly);
			}else	
				wsprintf(tmpst.usercreator,"system");
			//--------------
			 wsprintf(tmpst.PID,"%d",pe32.th32ProcessID);
			  wsprintf( tmpst.exefilename, pe32.szExeFile);
			    wsprintf(tmpst.priority,"%d", pe32.pcPriClassBase);
				 wsprintf(tmpst.threadnumber,"%d", pe32.cntThreads);
				 CHAR buf[1000];	
				 memset(buf,0,sizeof(CHAR));
				 if(0 != GetModuleFileNameEx(t,NULL,buf,sizeof(buf))){
					wsprintf(tmpst.processname,buf );
				 } else
					wsprintf(tmpst.processname," ");				

				if(ppsmemCounters.WorkingSetSize>800000000 )
					wsprintf(tmpst.memorysage,"%d",0);
				else
					wsprintf(tmpst.memorysage,"%lu",ppsmemCounters.WorkingSetSize);
				//---
				 procList.push_back(tmpst); 
				::CloseHandle(t);
				
				//---
		while(Process32Next(hSnapShot, &pe32)) { 
			//----
			process tmpst={0};
			t = OpenProcess(PROCESS_QUERY_INFORMATION|PROCESS_VM_OPERATION | PROCESS_VM_READ , FALSE, pe32.th32ProcessID);
			 GetProcessMemoryInfo(t, &ppsmemCounters, sizeof(ppsmemCounters));
			//-------------
			DWORD dwUserNameOnlyLength = 1000;
			char lpszUserNameOnly[1000];

			DWORD dwDomainLength = 1000;
			char lpszDomain[1000];

			SID_NAME_USE snu;
			UCHAR   InfoBuffer[1000];
			PTOKEN_USER pTokenUser = (PTOKEN_USER)InfoBuffer;
			DWORD   dwInfoBufferSize, dwAccountSize = 200, dwDomainSize = 128;
			HANDLE  hAccessToken;
			
			OpenProcessToken(t, TOKEN_READ, &hAccessToken);
			if(GetTokenInformation(hAccessToken, TokenUser, InfoBuffer, 1000, &dwInfoBufferSize)){
				LookupAccountSid(NULL, pTokenUser->User.Sid, lpszUserNameOnly, &dwUserNameOnlyLength, lpszDomain, &dwDomainLength, &snu);
				wsprintf(tmpst.usercreator,lpszUserNameOnly);
			}else	
				wsprintf(tmpst.usercreator,"system");	
			//-------
			wsprintf(tmpst.PID,"%d",pe32.th32ProcessID);
			  wsprintf( tmpst.exefilename, pe32.szExeFile);
			  wsprintf(tmpst.priority,"%d", pe32.pcPriClassBase);
			  wsprintf(tmpst.threadnumber,"%d", pe32.cntThreads);
				//-------	
			  CHAR buf[1000];	
			   memset(buf,0,sizeof(CHAR));
				 if(0 != GetModuleFileNameEx(t,NULL,buf,sizeof(buf))){
					wsprintf(tmpst.processname,buf );
				 } else
					wsprintf(tmpst.processname," ");
				//------	
			  if(ppsmemCounters.WorkingSetSize>800000000)
					wsprintf(tmpst.memorysage,"%d",0);
				else
					wsprintf(tmpst.memorysage,"%lu",ppsmemCounters.WorkingSetSize);
				//----			  
				procList.push_back(tmpst);
				::CloseHandle(t);				
			//------
		} 
		} 
	 ::CloseHandle(t);	  
	 ::CloseHandle(hSnapShot);
}
//-------------------------
void createListHeader(HWND hList) {
///-------
	LVCOLUMN LvCol; // Make Coluom struct for ListView	
	const int colwidth = 80;
	//------------------------------------------
	header.push_back("PID");
	 header.push_back("Process Name");
	  header.push_back("User Name");
	   header.push_back("Threads");
	  header.push_back("Memory Usage");
	 header.push_back("Priority");
	header.push_back("Full Name");
	//-----		
		SendMessage(hList,LVM_SETTEXTBKCOLOR, 0,(LPARAM)CLR_NONE);				
        SendMessage(hList,LVM_SETEXTENDEDLISTVIEWSTYLE,0,LVS_EX_FULLROWSELECT); // Set style
		//----------------------list header ------------------
	    memset(&LvCol,0,sizeof(LvCol)); // Reset Coluom
		 LvCol.mask = LVCF_TEXT|LVCF_WIDTH|LVCF_SUBITEM; // Type of mask
		  LvCol.cx = colwidth;                       // width between each coloum
		   LvCol.pszText = (LPSTR)header[0].c_str();      // First Header
		    LvCol.cx = colwidth;
		// Inserting Couloms as much as we want
		SendMessage(hList,LVM_INSERTCOLUMN,0,(LPARAM)&LvCol); // Insert/Show the coloum
		for(int i = 1; i < header.size(); ++i) {
			LvCol.pszText = (LPSTR)header[i].c_str();               // Next coloum
			 SendMessage(hList,LVM_INSERTCOLUMN,i,(LPARAM)&LvCol); // .
		}
		//-------------------------------------------------------------------------
}
void fillList(HWND hList) {
///----
	int i;
		char Temp[255];	
		LVITEM LvItem;  // ListView Item struct
		memset(&LvItem,0,sizeof(LvItem)); // Reset Item Struct		
		//  Setting properties Of Items:
		 // Text to display (can be from a char variable) (Items)        
		//---------
		for(int j=0; j<procList.size(); ++j) {
			    LvItem.iItem=j;            // choose item  
				LvItem.iSubItem=0;         // Put in first coluom				
				SendMessage(hList,LVM_INSERTITEM,0,(LPARAM)&LvItem); // Send to the Listview
			//----------1----
				//if(pid) {
				LvItem.mask = LVIF_TEXT;   // Text Style
				LvItem.cchTextMax = 256; // Max size of test
				LvItem.iSubItem = 0;//i- column
				LvItem.iItem = j;
				wsprintf(Temp,procList[j].PID);
				LvItem.pszText = Temp;
				SendMessage(hList,LVM_SETITEM,j,(LPARAM)&LvItem); // Enter text to SubItems
				//}
			//----------2----	
				LvItem.mask = LVIF_TEXT;   // Text Style
				LvItem.cchTextMax = 256; // Max size of test
				LvItem.iSubItem = 1;//i- column
				LvItem.iItem = j;
				wsprintf(Temp,procList[j].exefilename);
				LvItem.pszText = Temp;
				SendMessage(hList,LVM_SETITEM,j,(LPARAM)&LvItem); // Enter text to SubItems
			//-----------3---
				LvItem.mask = LVIF_TEXT;   // Text Style
				LvItem.cchTextMax = 256; // Max size of test
				LvItem.iSubItem = 5;//i- column
				LvItem.iItem = j;
				wsprintf(Temp,procList[j].priority);
				LvItem.pszText = Temp;
				SendMessage(hList,LVM_SETITEM,j,(LPARAM)&LvItem); // Enter text to SubItems
			//---------4-----
				LvItem.mask = LVIF_TEXT;   // Text Style
				LvItem.cchTextMax = 256; // Max size of test
				LvItem.iSubItem = 3;//i- column
				LvItem.iItem = j;
				wsprintf(Temp,procList[j].threadnumber);
				LvItem.pszText = Temp;
				SendMessage(hList,LVM_SETITEM,j,(LPARAM)&LvItem); // Enter text to SubItems
			//---------5-----
				LvItem.mask = LVIF_TEXT;   // Text Style
				LvItem.cchTextMax = 256; // Max size of test
				LvItem.iSubItem = 4;//i- column
				LvItem.iItem = j;
				wsprintf(Temp,procList[j].memorysage);
				LvItem.pszText = Temp;
				SendMessage(hList,LVM_SETITEM,j,(LPARAM)&LvItem); // Enter text to SubItems
			//---------5-----
				LvItem.mask = LVIF_TEXT;   // Text Style
				LvItem.cchTextMax = 256; // Max size of test
				LvItem.iSubItem = 2;//i- column
				LvItem.iItem = j;
				wsprintf(Temp,procList[j].usercreator);
				LvItem.pszText = Temp;
				SendMessage(hList,LVM_SETITEM,j,(LPARAM)&LvItem); // Enter text to SubItems
			//---------5-----
				LvItem.mask = LVIF_TEXT;   // Text Style
				LvItem.cchTextMax = 256; // Max size of test
				LvItem.iSubItem = 6;//i- column
				LvItem.iItem = j;
				wsprintf(Temp,procList[j].processname);
				LvItem.pszText = Temp;
				SendMessage(hList,LVM_SETITEM,j,(LPARAM)&LvItem); // Enter text to SubItems
			//---------5-----
		}	
}
//-------------------------
VOID MyDialog::TimerProc(HWND hwnd, UINT uMsg, UINT_PTR idEvent, DWORD dwTime){
///----
	Sleep(10);
	HWND hList = ::GetDlgItem(hwnd,IDC_LIST); // get the ID of the ListView
		//---update list---
		procList.clear();
		SendMessage(hList,LVM_DELETEALLITEMS,60,0);
		SendMessage(hList,LVM_REDRAWITEMS,60,0);
		 createProcessList();
		  fillList(hList);
	  //-------------------
		ListView_SetItemState(hList,iSlected,LVIS_SELECTED ,LVIS_SELECTED);
         ListView_SetItemState(hList,iSlected,LVIS_FOCUSED ,LVIS_FOCUSED);		
	//---------------------
		 
};
VOID CALLBACK MyDialog::TimerProcStub(HWND hWnd, UINT uMsg, UINT_PTR idEvent, DWORD dwTime){
///-----
	pDialogWnd pThis = (pDialogWnd)GetWindowLong(hWnd, GWL_USERDATA);
	 return pThis->TimerProc(hWnd, uMsg, idEvent, dwTime);
};
//-----
BOOL MyDialog::Cls_OnInitDialog(HWND hwnd, HWND hwndFocus, LPARAM lParam) {
///------
//------------------------------
		bool AlreadyRunning;
			HANDLE hMutexOneInstance = ::CreateMutex( NULL, TRUE,"MYAPPNAME-088FA840-B10D-11D3-BC36-006067709674");

			AlreadyRunning = (GetLastError() == ERROR_ALREADY_EXISTS);

			if (hMutexOneInstance != NULL) {
				::ReleaseMutex(hMutexOneInstance);
			}
			if ( AlreadyRunning ) { /* активизируем окно работающего экземпл€ра */
				HWND hOther = this->hDialog;// hwndFocus;
				if (hOther != NULL) { /* помещаем окно поверх других */
					::SetForegroundWindow(hOther);
					if (IsIconic(hOther)) { /* разворачиваем окно */
						::ShowWindow(hOther, SW_RESTORE);
					} /* разворачиваем окно */
				} /* помещаем окно поверх других */

				return FALSE; // заканчиваем выполнение
			} /* активизируем окно работающего экземпл€ра */
//------------------------------
			::SetTimer(hwnd,timer,1000,&TimerProcStub);
			//-------  
			InitCommonControls(); // !!! must be called
			HWND hList = ::GetDlgItem(hwnd,IDC_LIST); // get the ID of the ListView
			//---create list---
			createProcessList();
			createListHeader(hList); 
			fillList(hList);
			//------
			ListView_SetItemState(hList,iSlected,LVIS_SELECTED ,LVIS_SELECTED);
			ListView_SetItemState(hList,iSlected,LVIS_FOCUSED ,LVIS_FOCUSED);
		 
	   //--------
	return true;
}
//-----
void MyDialog::DlgOnClose(HWND hWnd){
///-----
	  if(Mod){
		  ::KillTimer(hWnd,timer);
		   ::EndDialog(hWnd,hMod);
		   ::DestroyWindow(hWnd);
		   ::PostQuitMessage(0);
	  } else {
		   ::KillTimer(hWnd,timer);
		   ::DestroyWindow(hWnd);
		   ::PostQuitMessage(0);
	  }
};
//----------------------
void MyDialog::OnWmCommand(HWND hWnd, int id, HWND hwndCtl, UINT codeNotify){
///-----
	switch(id){
		case ID_COLUMNS_PID: {
		  if(pid) {
			
			HMENU hMenu = GetMenu(hWnd); 
			HWND hList = ::GetDlgItem(hWnd,IDC_LIST);
			CheckMenuItem(hMenu, ID_COLUMNS_PID , MF_BYCOMMAND | MF_UNCHECKED);
			//--------			
			ListView_SetColumnWidth(hList,0,0);
		  } else {
			
			HMENU hMenu = GetMenu(hWnd);
		    HWND hList = ::GetDlgItem(hWnd,IDC_LIST);
			CheckMenuItem(hMenu,ID_COLUMNS_PID, MF_BYCOMMAND | MF_CHECKED);
			ListView_SetColumnWidth(hList,0,70);			
		  }
		  pid = !pid;	
		}break;
		//-----------procname
		case ID_COLUMNS_D: {
		  if(procname) {			
			HMENU hMenu = GetMenu(hWnd); 
			HWND hList = ::GetDlgItem(hWnd,IDC_LIST);
			CheckMenuItem(hMenu, ID_COLUMNS_D , MF_BYCOMMAND | MF_UNCHECKED);
			//--------			
			ListView_SetColumnWidth(hList,1,0);
		  } else {
			
			HMENU hMenu = GetMenu(hWnd);
		    HWND hList = ::GetDlgItem(hWnd,IDC_LIST);
			CheckMenuItem(hMenu,ID_COLUMNS_D, MF_BYCOMMAND | MF_CHECKED);
			ListView_SetColumnWidth(hList,1,70);			
		  }
		  procname = !procname;	
		}break;
		//---------username
		case ID_COLUMNS_USERNAME: {
		  if(username) {
			
			HMENU hMenu = GetMenu(hWnd); 
			HWND hList = ::GetDlgItem(hWnd,IDC_LIST);
			CheckMenuItem(hMenu, ID_COLUMNS_USERNAME , MF_BYCOMMAND | MF_UNCHECKED);
			//--------			
			ListView_SetColumnWidth(hList,2,0);
		  } else {
			
			HMENU hMenu = GetMenu(hWnd);
		    HWND hList = ::GetDlgItem(hWnd,IDC_LIST);
			CheckMenuItem(hMenu,ID_COLUMNS_USERNAME, MF_BYCOMMAND | MF_CHECKED);
			ListView_SetColumnWidth(hList,2,70);			
		  }
		  username = !username;	
		}break;
		//-----------threads
		case ID_COLUMNS_THREADSCOUNT: {
		  if(threads) {			
			HMENU hMenu = GetMenu(hWnd); 
			 HWND hList = ::GetDlgItem(hWnd,IDC_LIST);
			  CheckMenuItem(hMenu, ID_COLUMNS_THREADSCOUNT , MF_BYCOMMAND | MF_UNCHECKED);
			//--------			
			ListView_SetColumnWidth(hList,3,0);
		  } else {			
			HMENU hMenu = GetMenu(hWnd);
		     HWND hList = ::GetDlgItem(hWnd,IDC_LIST);
			  CheckMenuItem(hMenu,ID_COLUMNS_THREADSCOUNT, MF_BYCOMMAND | MF_CHECKED);
			ListView_SetColumnWidth(hList,3,70);			
		  }
		  threads = !threads;	
		}break;
		//------------memory 
		case ID_COLUMNS_MEMORYUSAGE: {
		  if(memory) {			
			HMENU hMenu = GetMenu(hWnd); 
			 HWND hList = ::GetDlgItem(hWnd,IDC_LIST);
			  CheckMenuItem(hMenu, ID_COLUMNS_MEMORYUSAGE , MF_BYCOMMAND | MF_UNCHECKED);
			//--------			
			ListView_SetColumnWidth(hList,4,0);
		  } else {			
			HMENU hMenu = GetMenu(hWnd);
		     HWND hList = ::GetDlgItem(hWnd,IDC_LIST);
			  CheckMenuItem(hMenu,ID_COLUMNS_MEMORYUSAGE, MF_BYCOMMAND | MF_CHECKED);
			ListView_SetColumnWidth(hList,4,70);			
		  }
		  memory = !memory;	
		}break;
		//------------ proority 
		case ID_COLUMNS_PRIORITY: {
		  if(proority) {			
			HMENU hMenu = GetMenu(hWnd); 
			 HWND hList = ::GetDlgItem(hWnd,IDC_LIST);
			  CheckMenuItem(hMenu, ID_COLUMNS_PRIORITY , MF_BYCOMMAND | MF_UNCHECKED);
			//--------			
			ListView_SetColumnWidth(hList,5,0);
		  } else {			
			HMENU hMenu = GetMenu(hWnd);
		     HWND hList = ::GetDlgItem(hWnd,IDC_LIST);
			  CheckMenuItem(hMenu,ID_COLUMNS_PRIORITY, MF_BYCOMMAND | MF_CHECKED);
			ListView_SetColumnWidth(hList,5,70);			
		  }
		  proority = !proority;	
		}break;
		//------------ fullname
		case ID_COLUMNS_FULLNAME: {
		  if(fullname) {			
			HMENU hMenu = GetMenu(hWnd); 
			 HWND hList = ::GetDlgItem(hWnd,IDC_LIST);
			  CheckMenuItem(hMenu, ID_COLUMNS_FULLNAME , MF_BYCOMMAND | MF_UNCHECKED);
			//--------			
			ListView_SetColumnWidth(hList,6,0);
		  } else {			
			HMENU hMenu = GetMenu(hWnd);
		     HWND hList = ::GetDlgItem(hWnd,IDC_LIST);
			  CheckMenuItem(hMenu,ID_COLUMNS_FULLNAME, MF_BYCOMMAND | MF_CHECKED);
			ListView_SetColumnWidth(hList,6,70);			
		  }
		  fullname = !fullname;	
		}break;
		//---
	}
	//---------------------
	if(id == ID_FILE_EXIT) {
		DlgOnClose(hWnd);
	}
	//--------
	if(id==IDC_TERMINATE) {
		int i = atoi(procList[iSlected].PID);
		KillProcByPid(i);
		/* HANDLE h = OpenProcess( PROCESS_TERMINATE|PROCESS_QUERY_INFORMATION , TRUE, i);
		 ::TerminateProcess(h,NULL);
		 ::CloseHandle(h);*/
	}
	if(id == IDC_STARTPROCESS) {
		 STARTUPINFO si;
		 PROCESS_INFORMATION pi;
		 ZeroMemory(&si,sizeof(STARTUPINFO));
		 ZeroMemory(&pi,sizeof(PROCESS_INFORMATION));
		//-----------------
		OPENFILENAME ofn; 
		char szFile[260];
		ZeroMemory(&ofn, sizeof(ofn));
		ofn.lStructSize = sizeof(ofn);
		ofn.hwndOwner = hWnd;
		ofn.lpstrFile = szFile;
		ofn.lpstrFile[0] = '\0';
		ofn.nMaxFile = sizeof(szFile);
		ofn.lpstrFilter = "All\0*.*\0";
		ofn.nFilterIndex = 1;
		ofn.lpstrFileTitle = NULL;
		ofn.nMaxFileTitle = 0;
		ofn.lpstrInitialDir = NULL;
		ofn.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST;
		
		if (GetOpenFileName(&ofn)==TRUE) {
			::CreateProcess(ofn.lpstrFile,NULL,NULL,NULL,FALSE,0,NULL,NULL,&si,&pi);	
		}
	    //-----------------
		
	}
	//--------
	if(id == IDC_STOPPROCESS) {
		SetDebugStatusForCurentProc();
		int i = atoi(procList[iSlected].PID);
		KillProcByPid(i);
	}
	//-------
	if(id == IDC_RUNFILE) {
		//---------------
		OPENFILENAME ofn; 
		char szFile[260];
		ZeroMemory(&ofn, sizeof(ofn));
		ofn.lStructSize = sizeof(ofn);
		ofn.hwndOwner = hWnd;
		ofn.lpstrFile = szFile;
		ofn.lpstrFile[0] = '\0';
		ofn.nMaxFile = sizeof(szFile);
		ofn.lpstrFilter = "All\0*.*\0Text\0*.*\0";
		ofn.nFilterIndex = 1;
		ofn.lpstrFileTitle = NULL;
		ofn.nMaxFileTitle = 0;
		ofn.lpstrInitialDir = NULL;
		ofn.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST;
		
		if (GetOpenFileName(&ofn)==TRUE) {
			::ShellExecute(hWnd, "open", ofn.lpstrFile, NULL,NULL, SW_SHOW);
		}
		
	}
	//--------
};
//----------------------
void MyDialog::Cls_OnLButtonDown(HWND hwnd, BOOL fDoubleClick, int x, int y, UINT keyFlags){
///-----
	
}
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
		HANDLE_MSG(hWnd, WM_LBUTTONDOWN, pThis->Cls_OnLButtonDown);
		 HANDLE_MSG(hWnd, WM_COMMAND, pThis->OnWmCommand);		
		  HANDLE_MSG(hWnd, WM_INITDIALOG, pThis->Cls_OnInitDialog);
		   HANDLE_MSG(hWnd, WM_CLOSE, pThis->DlgOnClose);
		   //--------
		   //---------
		   case WM_NOTIFY: {
				if(((LPNMHDR)lParam)->code == NM_CLICK) {
					HWND hList = ::GetDlgItem(hWnd,IDC_LIST);
					 iSlected = SendMessage(hList,LVM_GETNEXTITEM,-1,LVNI_FOCUSED);				   			
				}
		  //---------
		}return true;
	};
	return false;
};
//----
int MyDialog::CreateDlg( HWND hWnd, INT resource, bool modal){
///---
	 MSG msg;
	 HWND h = NULL;
	 Mod = modal;
	 //----------
		if(modal)
			hMod = ::DialogBox((HINSTANCE)NULL, MAKEINTRESOURCE(resource), hWnd, (DLGPROC)DlgProcStub);
		else
			h = ::CreateDialog((HINSTANCE)NULL, MAKEINTRESOURCE(resource), hWnd, (DLGPROC)DlgProcStub);
	 //----------
		::AnimateWindow(h,500,AW_BLEND);// fade window effect
		::ShowWindow(h,SW_SHOW);		
		SetFocus(h); 
	//---
	while (GetMessage(&msg, NULL, 0, 0)) {  
			TranslateMessage(&msg); 
			DispatchMessage(&msg); 
		} 
	//---
	return msg.wParam;
};
