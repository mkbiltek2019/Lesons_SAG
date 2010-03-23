#include <windows.h>

LRESULT CALLBACK HelloWorldWndProc (HWND, UINT, UINT, LONG);
int WINAPI WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow){

	HWND hWnd;
	WNDCLASS WndClass;
	MSG Msg;
	char szClassName[] = "Hello World";

	WndClass.style = CS_HREDRAW | CS_VREDRAW /*| CS_NOCLOSE*/;
	WndClass.lpfnWndProc = HelloWorldWndProc;
	WndClass.cbClsExtra = 0;
	WndClass.cbWndExtra = 0;
	WndClass.hInstance = hInstance;
	WndClass.hIcon = LoadIcon (NULL, IDI_EXCLAMATION);
	WndClass.hCursor = LoadCursor (NULL, IDC_HAND);
	WndClass.hbrBackground = (HBRUSH) GetStockObject (WHITE_BRUSH);
	WndClass.lpszMenuName = NULL;
	WndClass.lpszClassName = szClassName;

	if(!RegisterClass(&WndClass)){
	
		MessageBox(NULL, "Can't register class", "Error", MB_OK);
		return 0;
	}

	hWnd = CreateWindow(szClassName, "Programm #1", WS_OVERLAPPEDWINDOW | WS_HSCROLL | WS_VSCROLL,
						CW_USEDEFAULT, CW_USEDEFAULT,
						CW_USEDEFAULT, CW_USEDEFAULT,
						NULL, NULL, hInstance, NULL);

	if(!hWnd){
	
		MessageBox(NULL, "Can't create window", "Error", MB_OK);
		return 0;
	}

	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);

	while(GetMessage(&Msg, NULL, 0, 0)){
	
		TranslateMessage(&Msg);
		DispatchMessage(&Msg);
	}

	return Msg.wParam;
}

LRESULT CALLBACK HelloWorldWndProc(HWND hWnd, UINT Message, UINT wParam, LONG lParam){

	HDC hDC, hCompatibleDC;
	PAINTSTRUCT PaintStruct;
	HANDLE hBitmap, hOldBitmap; 
	RECT Rect;
	BITMAP Bitmap;

	switch(Message){
	
		case WM_PAINT:
			hDC = BeginPaint(hWnd, &PaintStruct);
			hBitmap = LoadImage(NULL, "015-0023.bmp", IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE);
			GetObject(hBitmap, sizeof(BITMAP), &Bitmap);
			hCompatibleDC = CreateCompatibleDC(hDC);
			hOldBitmap = SelectObject(hCompatibleDC, hBitmap);
			GetClientRect(hWnd, &Rect);
			BitBlt(hDC, 0, 0, Rect.right, Rect.bottom, hCompatibleDC, 0, 0, /*Bitmap.bmWidth, Bitmap.bmHeight,*/ NOTSRCCOPY);
			SelectObject(hCompatibleDC, hOldBitmap);
			DeleteObject(hBitmap);
			DeleteDC(hCompatibleDC);
			//DrawText(hDC, "Hello World!!!", -1, &Rect, DT_SINGLELINE | DT_CENTER | DT_VCENTER);
			EndPaint(hWnd, &PaintStruct);
			return 0;

		case WM_DESTROY:
			PostQuitMessage(0);
			return 0;
	}

	return DefWindowProc(hWnd, Message, wParam, lParam);

}