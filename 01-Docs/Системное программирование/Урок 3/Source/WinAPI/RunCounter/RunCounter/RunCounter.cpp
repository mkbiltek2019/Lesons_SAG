// RunCounter.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "RunCounter.h"

#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;								// current instance
TCHAR szTitle[MAX_LOADSTRING];					// The title bar text
TCHAR szWindowClass[MAX_LOADSTRING];			// the main window class name
HKEY phkResult = NULL;
HWND hVal;

// Forward declarations of functions included in this code module:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK SetParams(HWND, UINT, WPARAM, LPARAM);
int CheckVal();
int SetVal(int);

int APIENTRY _tWinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPTSTR    lpCmdLine,
                     int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

 	// TODO: Place code here.
	MSG msg;
	HACCEL hAccelTable;

	// Initialize global strings
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_RUNCOUNTER, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_RUNCOUNTER));

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
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_RUNCOUNTER));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_RUNCOUNTER);
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
	int val = 0;
	char buf[255];
	RECT rect;
	char* text = " Runs left";
	switch (message)
	{
	case WM_COMMAND:
		wmId    = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		// Parse the menu selections:
		switch (wmId)
		{
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		case ID_PARAMS_SETPARAMS:			
			DialogBox(hInst, MAKEINTRESOURCE(IDD_DIALOG1), hWnd, SetParams);
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
		
		GetClientRect(hWnd, &rect);
		val = CheckVal();
		
		
		_itoa(val,buf,10);
		strncat_s(buf,_countof(buf),text,_countof(buf)-strlen(buf));
		DrawText(hdc, buf, -1, &rect,
			DT_SINGLELINE | DT_CENTER | DT_VCENTER );

		EndPaint(hWnd, &ps);
		break;
	case WM_CREATE:
		//Проверяем сколько осталось попыток запуска программы
		val = CheckVal();
		if(val > 0)
			//Устанавливаем на 1 попытку меньше
			SetVal(--val);
		//Если попыток не осталось
		else
		{
			//Выводим сообщение
			MessageBox(NULL,"Value is 0",NULL,MB_OK);	
			//и не даем программе запуститься - уничтожаем окно программы
			DestroyWindow(hWnd);
		}
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

//Функция проверки значения реестра
int CheckVal()
{
	DWORD pcbData = sizeof(DWORD);
	DWORD data = 10;

	LONG lResult = RegOpenKeyEx(HKEY_LOCAL_MACHINE,"SOFTWARE\\TestDir",0,KEY_ALL_ACCESS,&phkResult);
	if(lResult != ERROR_SUCCESS)
	{
		if (lResult == ERROR_FILE_NOT_FOUND) 
		{
			if(MessageBox(NULL,"Key Not Found. Create it?",NULL,MB_YESNO) == IDYES)
			{
				//Попытка создания ключа реестра
				lResult = RegCreateKeyEx(HKEY_LOCAL_MACHINE,"SOFTWARE\\TestDir",0,NULL,REG_OPTION_NON_VOLATILE,KEY_ALL_ACCESS,NULL,&phkResult,NULL);
				if(lResult != ERROR_SUCCESS)
				{
					MessageBox(NULL,"Error Create Key",NULL,MB_OK);
					return NULL;
				}
				else
				{							
					MessageBox(NULL,"Key Created",NULL,MB_OK);					
					lResult = RegSetValueEx(phkResult,"TestRuns",0,REG_DWORD,(BYTE*)&data,sizeof(DWORD));
				}
			}
		} 
		else 
		{
			MessageBox(NULL,"Error Open",NULL,MB_OK);	
			return NULL;
		}		
	}

	else
	{
		
		lResult = RegGetValue(HKEY_LOCAL_MACHINE,"SOFTWARE\\TestDir","TestRuns",RRF_RT_REG_DWORD,NULL,&data,&pcbData);
		if (lResult != ERROR_SUCCESS)
		{
			lResult = RegSetValueEx(phkResult,"TestRuns",0,REG_DWORD,(BYTE*)&data,sizeof(DWORD));
		}

	}
	return data;

}

//Функция установки значения реестра
int SetVal(int val)
{
	DWORD pcbData = sizeof(DWORD);
	DWORD data = val;

	//Открываем ветку реестра
	LONG lResult = RegOpenKeyEx(HKEY_LOCAL_MACHINE,"SOFTWARE\\TestDir",0,KEY_ALL_ACCESS,&phkResult);
	if(lResult != ERROR_SUCCESS)
	{
		
		MessageBox(NULL,"Error Open",NULL,MB_OK);	
		return NULL;
	
	}

	else
	{	
		//Получаем значение из параметра реестра
		lResult = RegSetValueEx(phkResult,"TestRuns",0,REG_DWORD,(BYTE*)&data,sizeof(DWORD));
		if (lResult != ERROR_SUCCESS)
		{
			MessageBox(NULL,"Error Set Value",NULL,MB_OK);	
		}
	}
	return data;
}

INT_PTR CALLBACK SetParams(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	hVal = GetDlgItem(hDlg,IDC_EDIT1);
	char Val[255] = {'0'};
	char* buf = new char[255];
	int val = CheckVal();
	switch (message)
	{
	case WM_INITDIALOG:
			
		buf = _itoa(val,buf,10);
		SetWindowText(hVal,buf);
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}

		//Обработчик нажатия кнопки Set Val
		if (LOWORD(wParam) == IDC_BT_SETVAL && HIWORD(wParam) == BN_CLICKED)
		{
			//Получаем значение из окна
			GetWindowText(hVal,Val,255);
			val = atoi(Val);
			//и устанавливаем его в параметр реестра
			if(SetVal(val) != NULL)
				MessageBox(NULL,"Succes",NULL,MB_OK);	
		}
		break;
	}
	return (INT_PTR)FALSE;
}

// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}
