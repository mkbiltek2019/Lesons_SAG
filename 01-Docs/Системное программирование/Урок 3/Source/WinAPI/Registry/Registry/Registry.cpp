// Registry.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "Registry.h"

#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;								// current instance
TCHAR szTitle[MAX_LOADSTRING];					// The title bar text
TCHAR szWindowClass[MAX_LOADSTRING];			// the main window class name

// Forward declarations of functions included in this code module:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	RegRun(HWND, UINT, WPARAM, LPARAM);

int APIENTRY _tWinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPTSTR    lpCmdLine,
                     int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);


	MSG msg;
	HACCEL hAccelTable;

	// Initialize global strings
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_REGISTRY, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_REGISTRY));

	// Main message loop:
	while (GetMessage(&msg, NULL, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return (int) msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
//  COMMENTS:
//
//    This function and its usage are only necessary if you want this code
//    to be compatible with Win32 systems prior to the 'RegisterClassEx'
//    function that was added to Windows 95. It is important to call this function
//    so that the application will get 'well formed' small icons associated
//    with it.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style			= CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc	= WndProc;
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_REGISTRY));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_REGISTRY);
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm		= LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassEx(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // Store instance handle in our global variable

   hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      500, 300, 300, 200, NULL, NULL, hInstance, NULL);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE:  Processes messages for the main window.
//
//  WM_COMMAND	- process the application menu
//  WM_PAINT	- Paint the main window
//  WM_DESTROY	- post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	int wmId, wmEvent;
	PAINTSTRUCT ps;
	HDC hdc;

	switch (message)
	{
	case WM_COMMAND:
		wmId    = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		// Parse the menu selections:
		switch (wmId)
		{
		case IDM_RUN:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_REG_RUN), hWnd, RegRun);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
		// TODO: Add any drawing code here...
		EndPaint(hWnd, &ps);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}


HKEY phkResult = NULL;
//Функция открытия ключа реестра 
//и если его нет то ключ создается
int CreateKey(HKEY hRoot,char sKey[])
{
	
	//Попытка открыть ключ реестра
	LONG lResult = RegOpenKeyEx(hRoot,sKey,0,KEY_ALL_ACCESS,&phkResult);
	if(lResult != ERROR_SUCCESS)
	{
		if (lResult == ERROR_FILE_NOT_FOUND) 
		{
			if(MessageBox(NULL,"Key Not Found. Create it?",NULL,MB_YESNO) == IDYES)
			{
				//Попытка создания ключа реестра
				lResult = RegCreateKeyEx(hRoot,sKey,0,NULL,REG_OPTION_NON_VOLATILE,KEY_ALL_ACCESS,NULL,&phkResult,NULL);
				if(lResult != ERROR_SUCCESS)
					MessageBox(NULL,"Error Create Key",NULL,MB_OK);
				else
				{							
					MessageBox(NULL,"Key Created",NULL,MB_OK);		
				}
			}
		} 
		else {
			MessageBox(NULL,"Error Open",NULL,MB_OK);	
		}

		
	}

	else
	{
		MessageBox(NULL,"Key Opened",NULL,MB_OK);
	}
	return lResult;
}


INT_PTR CALLBACK RegRun(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	
	//Переменные которые нам потребуются для работы с реестром
	HWND hCombobox = GetDlgItem(hDlg,IDC_COMBO1);
	HWND hKey = GetDlgItem(hDlg,IDC_EDIT1);
	HWND hValName = GetDlgItem(hDlg,IDC_EDIT2);
	HWND hVal = GetDlgItem(hDlg,IDC_EDIT3);
	HKEY hRoot[4] = {HKEY_CLASSES_ROOT,HKEY_CURRENT_USER,HKEY_LOCAL_MACHINE,HKEY_USERS};	

	//Временные буферы для хранения данных
	char sRoot[255] = {'0'};
	char sKey[255] = {'0'};
	char sValName[255] = {'0'};
	char sVal[255] = {'0'};
	
	int iPos = (int)SendMessage(hCombobox,CB_GETCURSEL,0,0);
	SendMessage(hCombobox,CB_GETLBTEXT,(WPARAM)iPos,(LPARAM)(LPTSTR)sRoot);
	GetWindowText(hKey,sKey,2550);
	GetWindowText(hValName,sValName,2550);
	GetWindowText(hVal,sVal,2550);

	char sPath[1024] = {'0'};
	strncpy(sPath,sRoot,strlen(sRoot));
	strncat(sPath,"\\",1);
	strncat(sPath,sKey,strlen(sKey));

	
	switch (message)
	{
	case WM_INITDIALOG:	
		//ComboBox Initialise
		SendMessage(hCombobox,CB_ADDSTRING,0,(LPARAM)(LPCTSTR)__T("HKEY_CLASSES_ROOT"));
		SendMessage(hCombobox,CB_ADDSTRING,0,(LPARAM)__T("HKEY_CURRENT_USER"));
		SendMessage(hCombobox,CB_ADDSTRING,0,(LPARAM)__T("HKEY_LOCAL_MACHINE"));
		SendMessage(hCombobox,CB_ADDSTRING,0,(LPARAM)__T("HKEY_USERS"));
		SendMessage(hCombobox,CB_SETCURSEL,(WPARAM)0,0);

		SetWindowText(hKey,TEXT("SOFTWARE\\TestDir"));

		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			//Если был открыт ключ реестра закрываем его
			if(phkResult != NULL)
				RegCloseKey(phkResult);
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}


		//Обработка нажатия кнопки Create Key
		if(LOWORD(wParam) == IDC_BTN_CREATE_KEY && HIWORD(wParam) == BN_CLICKED)
		{	
			//Если был открыт ключ реестра закрываем его
			if(phkResult != NULL)
				RegCloseKey(phkResult);
			CreateKey(hRoot[iPos],sKey);
		}

		//Обработка нажатия кнопки Create Val
		if(LOWORD(wParam) == IDC_BTN_CREATE_VAL && HIWORD(wParam) == BN_CLICKED)
		{
			//Если был открыт ключ реестра закрываем его
			if(phkResult != NULL)
				RegCloseKey(phkResult);
			int lResult = CreateKey(hRoot[iPos],sKey);
			if(lResult == ERROR_SUCCESS)
			{
				
				//Устанавливаем новое значение реестра
				lResult = RegSetValueEx(phkResult,sValName,0,REG_SZ,(const BYTE*)sVal,sizeof(sVal));
				//Если функция отработала корректно выводим соответствующее сообщение
				if(lResult == ERROR_SUCCESS)
				{
					MessageBox(NULL,"Create Value Success","",MB_OK);
				}
				else
					MessageBox(NULL,"Create Value Fail","",MB_OK);
			}
		}

		//Обработка нажатия кнопки Delete Key
		if(LOWORD(wParam) == IDC_BTN_DEL_KEY && HIWORD(wParam) == BN_CLICKED)
		{
			//Удаляем ветку реестра
			int lResult = RegDeleteKey(hRoot[iPos],sKey);
			//Если функция отработала корректно выводим соответствующее сообщение
			if(lResult == ERROR_SUCCESS)
			{
				MessageBox(NULL,"Delete Key Success","",MB_OK);
			}
			else
				MessageBox(NULL,"Delete Key Fail","",MB_OK);

		}

		//Обработка нажатия кнопки Delete Value
		if(LOWORD(wParam) == IDC_BTN_DEL_VAL && HIWORD(wParam) == BN_CLICKED)
		{	

			//Если был открыт ключ реестра закрываем его
			if(phkResult != NULL)
				RegCloseKey(phkResult);

			int lResult = CreateKey(hRoot[iPos],sKey);
			if(lResult == ERROR_SUCCESS)
			{
				
				//Удаляем значение реестра
				lResult = RegDeleteValue(phkResult,sValName);
				if(lResult == ERROR_SUCCESS)
				{
					MessageBox(NULL,"Delete Value Success","",MB_OK);
				}
				else
					MessageBox(NULL,"Delete Value Fail","",MB_OK);
			}
		}

		break;	
	}
	return (INT_PTR)FALSE;
}
