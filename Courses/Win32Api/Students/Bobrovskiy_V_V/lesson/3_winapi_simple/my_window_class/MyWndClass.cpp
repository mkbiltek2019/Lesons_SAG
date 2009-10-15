#include "MyWndClass.h"
#include "atltime.h"
//----------------------
//- need to declare window procedure as static method of class 
LRESULT CALLBACK MyWndClass::WndProc(HWND hWnd,UINT uMsg,WPARAM wParam,LPARAM lParam){
	HDC hDC;
	PAINTSTRUCT ps;
	RECT rect;
	//----
	switch(uMsg){
	case WM_CREATE:
		SetClassLong(hWnd,GCL_HBRBACKGROUND,(LONG)CreateSolidBrush(RGB(200,160,255)));	
			break;
	case WM_PAINT:
		hDC=BeginPaint(hWnd,&ps);
		GetClientRect(hWnd,&rect);
		SetBkMode(hDC,TRANSPARENT);
		DrawText(hDC," Hallo ",-1,&rect,DT_SINGLELINE|DT_CENTER|DT_VCENTER);
		/*
		 DrawText() Format Flags
			#define DT_TOP                      0x00000000
			#define DT_LEFT                     0x00000000
			#define DT_CENTER                   0x00000001
			#define DT_RIGHT                    0x00000002
			#define DT_VCENTER                  0x00000004
			#define DT_BOTTOM                   0x00000008
			#define DT_WORDBREAK                0x00000010
			#define DT_SINGLELINE               0x00000020
			#define DT_EXPANDTABS               0x00000040
			#define DT_TABSTOP                  0x00000080
			#define DT_NOCLIP                   0x00000100
			#define DT_EXTERNALLEADING          0x00000200
			#define DT_CALCRECT                 0x00000400
			#define DT_NOPREFIX                 0x00000800
			#define DT_INTERNAL                 0x00001000		
			#define DT_EDITCONTROL              0x00002000
			#define DT_PATH_ELLIPSIS            0x00004000
			#define DT_END_ELLIPSIS             0x00008000
			#define DT_MODIFYSTRING             0x00010000
			#define DT_RTLREADING               0x00020000
			#define DT_WORD_ELLIPSIS            0x00040000			
			#define DT_NOFULLWIDTHCHARBREAK     0x00080000			
			#define DT_HIDEPREFIX               0x00100000
			#define DT_PREFIXONLY               0x00200000
		*/
		EndPaint(hWnd,&ps);
		break;
	case WM_TIMER:
		std::string time;
		CTime t = CTime::GetCurrentTime();   
		char buff[10];
		itoa(t.GetHour(),buff,10);
		time.append(buff); time.append(".");
		
		itoa(t.GetMinute(),buff,10);
		time.append(buff); time.append(".");
		
		itoa(t.GetSecond(),buff,10);
		time.append(buff); time.append(".");
		
		hDC=BeginPaint(hWnd,&ps);
		GetClientRect(hWnd,&rect);
		SetBkMode(hDC,TRANSPARENT);
		DrawText(hDC," Hallo ",-1,&rect,DT_SINGLELINE|DT_CENTER|DT_VCENTER);
		
		break;
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd,uMsg,wParam,lParam);
	};
	return 0;
};
//---------------------
MyWndClass::MyWndClass(HINSTANCE hInstancem):hInstance(hInstancem){
};
//----
void MyWndClass::SetWndClass(){
	this->szClassName="MyClass";
	//----
	wc.cbSize=sizeof(wc);
	wc.style=CS_HREDRAW | CS_VREDRAW;
	/*	Class styles
		#define CS_VREDRAW          0x0001
		#define CS_HREDRAW          0x0002
		#define CS_DBLCLKS          0x0008
		#define CS_OWNDC            0x0020
		#define CS_CLASSDC          0x0040
		#define CS_PARENTDC         0x0080
		#define CS_NOCLOSE          0x0200
		#define CS_SAVEBITS         0x0800
		#define CS_BYTEALIGNCLIENT  0x1000
		#define CS_BYTEALIGNWINDOW  0x2000
		#define CS_GLOBALCLASS      0x4000
	*/
	wc.lpfnWndProc=WndProc;
	wc.cbClsExtra=0;
	wc.cbWndExtra=0;
	wc.hInstance=this->hInstance;
	wc.hIcon=LoadIcon(NULL,IDI_EXCLAMATION);
	/*
		#define IDI_APPLICATION     MAKEINTRESOURCE(32512)
		#define IDI_HAND            MAKEINTRESOURCE(32513)
		#define IDI_QUESTION        MAKEINTRESOURCE(32514)
		#define IDI_EXCLAMATION     MAKEINTRESOURCE(32515)
		#define IDI_ASTERISK        MAKEINTRESOURCE(32516)
		#define IDI_WINLOGO         MAKEINTRESOURCE(32517)
		#define IDI_SHIELD          MAKEINTRESOURCE(32518)
		#define IDI_WARNING     IDI_EXCLAMATION
		#define IDI_ERROR       IDI_HAND
		#define IDI_INFORMATION IDI_ASTERISK
	*/
	wc.hCursor=LoadCursor(NULL,IDC_HAND);
		/*
		#define IDC_ARROW           MAKEINTRESOURCE(32512)
		#define IDC_IBEAM           MAKEINTRESOURCE(32513)
		#define IDC_WAIT            MAKEINTRESOURCE(32514)
		#define IDC_CROSS           MAKEINTRESOURCE(32515)
		#define IDC_UPARROW         MAKEINTRESOURCE(32516)
		#define IDC_SIZE            MAKEINTRESOURCE(32640)   OBSOLETE: use IDC_SIZEALL 
		#define IDC_ICON            MAKEINTRESOURCE(32641)   OBSOLETE: use IDC_ARROW 
		#define IDC_SIZENWSE        MAKEINTRESOURCE(32642)
		#define IDC_SIZENESW        MAKEINTRESOURCE(32643)
		#define IDC_SIZEWE          MAKEINTRESOURCE(32644)
		#define IDC_SIZENS          MAKEINTRESOURCE(32645)
		#define IDC_SIZEALL         MAKEINTRESOURCE(32646)
		#define IDC_NO              MAKEINTRESOURCE(32648) not in win3.1 
		#define IDC_HAND            MAKEINTRESOURCE(32649)
		#define IDC_APPSTARTING     MAKEINTRESOURCE(32650) not in win3.1 
		#define IDC_HELP            MAKEINTRESOURCE(32651)
		*/
	wc.hbrBackground=(HBRUSH)GetStockObject(LTGRAY_BRUSH);
	/* Stock Logical Objects 	 
		#define WHITE_BRUSH         0
		#define LTGRAY_BRUSH        1
		#define GRAY_BRUSH          2
		#define DKGRAY_BRUSH        3
		#define BLACK_BRUSH         4
		#define NULL_BRUSH          5
		#define HOLLOW_BRUSH        NULL_BRUSH
		#define WHITE_PEN           6
		#define BLACK_PEN           7
		#define NULL_PEN            8
		#define OEM_FIXED_FONT      10
		#define ANSI_FIXED_FONT     11
		#define ANSI_VAR_FONT       12
		#define SYSTEM_FONT         13
		#define DEVICE_DEFAULT_FONT 14
		#define DEFAULT_PALETTE     15
		#define SYSTEM_FIXED_FONT   16
	*/
	wc.lpszMenuName=NULL;
	wc.lpszClassName=szClassName.c_str();
	wc.hIconSm =LoadIcon(NULL,IDI_EXCLAMATION);
};
//---
int MyWndClass::CreateWnd(){
	//---	
	if(!RegisterClassEx(&this->wc)){
		throw("Error while register WndClass..");		
	};
	//---
	hMainWnd=CreateWindow(this->szClassName.c_str(),"Hallo man ",/*WS_EX_PALETTEWINDOW|*/WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT,0,CW_USEDEFAULT,0,(HWND)NULL,
		(HMENU)NULL,(HINSTANCE)this->hInstance,NULL);
	/*
		#define WS_OVERLAPPED       0x00000000L
		#define WS_POPUP            0x80000000L
		#define WS_CHILD            0x40000000L
		#define WS_MINIMIZE         0x20000000L
		#define WS_VISIBLE          0x10000000L
		#define WS_DISABLED         0x08000000L
		#define WS_CLIPSIBLINGS     0x04000000L
		#define WS_CLIPCHILDREN     0x02000000L
		#define WS_MAXIMIZE         0x01000000L
		#define WS_CAPTION          0x00C00000L      WS_BORDER | WS_DLGFRAME  
		#define WS_BORDER           0x00800000L
		#define WS_DLGFRAME         0x00400000L
		#define WS_VSCROLL          0x00200000L
		#define WS_HSCROLL          0x00100000L
		#define WS_SYSMENU          0x00080000L
		#define WS_THICKFRAME       0x00040000L
		#define WS_GROUP            0x00020000L
		#define WS_TABSTOP          0x00010000L
		#define WS_MINIMIZEBOX      0x00020000L
		#define WS_MAXIMIZEBOX      0x00010000L
		#define WS_TILED            WS_OVERLAPPED
		#define WS_ICONIC           WS_MINIMIZE
		#define WS_SIZEBOX          WS_THICKFRAME
		#define WS_TILEDWINDOW      WS_OVERLAPPEDWINDOW

		 Common Window Styles

		#define WS_OVERLAPPEDWINDOW (WS_OVERLAPPED     | \
									 WS_CAPTION        | \
									 WS_SYSMENU        | \
									 WS_THICKFRAME     | \
									 WS_MINIMIZEBOX    | \
									 WS_MAXIMIZEBOX)

		#define WS_POPUPWINDOW      (WS_POPUP          | \
									 WS_BORDER         | \
									 WS_SYSMENU)
		#define WS_CHILDWINDOW      (WS_CHILD)

		  Extended Window Styles
		#define WS_EX_DLGMODALFRAME     0x00000001L
		#define WS_EX_NOPARENTNOTIFY    0x00000004L
		#define WS_EX_TOPMOST           0x00000008L
		#define WS_EX_ACCEPTFILES       0x00000010L
		#define WS_EX_TRANSPARENT       0x00000020L
		#define WS_EX_MDICHILD          0x00000040L
		#define WS_EX_TOOLWINDOW        0x00000080L
		#define WS_EX_WINDOWEDGE        0x00000100L
		#define WS_EX_CLIENTEDGE        0x00000200L
		#define WS_EX_CONTEXTHELP       0x00000400L
		#define WS_EX_RIGHT             0x00001000L
		#define WS_EX_LEFT              0x00000000L
		#define WS_EX_RTLREADING        0x00002000L
		#define WS_EX_LTRREADING        0x00000000L
		#define WS_EX_LEFTSCROLLBAR     0x00004000L
		#define WS_EX_RIGHTSCROLLBAR    0x00000000L
		#define WS_EX_CONTROLPARENT     0x00010000L
		#define WS_EX_STATICEDGE        0x00020000L
		#define WS_EX_APPWINDOW         0x00040000L
		#define WS_EX_OVERLAPPEDWINDOW  (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE)
		#define WS_EX_PALETTEWINDOW     (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST)
		#define WS_EX_LAYERED           0x00080000
		#define WS_EX_NOINHERITLAYOUT   0x00100000L // Disable inheritence of mirroring by children
		#define WS_EX_LAYOUTRTL         0x00400000L // Right to left mirroring
		#define WS_EX_COMPOSITED        0x02000000L
		#define WS_EX_NOACTIVATE        0x08000000L
	*/
	if(!hMainWnd){
		throw("Error while create window..");		
	};	
	//---
	return 0;
};
//---
int MyWndClass::Run(){
	//---
	SetWndClass();
	//--
	CreateWnd();
	//--
	ShowWindow(hMainWnd,/*SW_SHOWNORMAL|*/SW_SHOWMAXIMIZED);
	/*#define SW_HIDE             0
	#define SW_SHOWNORMAL       1
	#define SW_NORMAL           1
	#define SW_SHOWMINIMIZED    2
	#define SW_SHOWMAXIMIZED    3
	#define SW_MAXIMIZE         3
	#define SW_SHOWNOACTIVATE   4
	#define SW_SHOW             5
	#define SW_MINIMIZE         6
	#define SW_SHOWMINNOACTIVE  7
	#define SW_SHOWNA           8
	#define SW_RESTORE          9
	#define SW_SHOWDEFAULT      10
	#define SW_FORCEMINIMIZE    11
	#define SW_MAX              11
	*/
	//---
	while(GetMessage(&msg,NULL,0,0)){
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	};
	return msg.wParam;
};
//---