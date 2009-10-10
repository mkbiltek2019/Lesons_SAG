// Hello1.cpp
#include <windows.h>

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

LOGFONT DefineLogFontParams();

///////////////////////////////////////////////////////////////////////////////////////////////
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	HWND hMainWnd;  
	char szClassName[] = "MyClass";
	MSG msg;
	WNDCLASSEX wc;
	
	// Заполняем структуру класса окна
	wc.cbSize        = sizeof(wc);		
	wc.style         = CS_HREDRAW | CS_VREDRAW;
	wc.lpfnWndProc   = WndProc;
	wc.cbClsExtra	 = 0;
	wc.cbWndExtra    = 0;
	wc.hInstance     = hInstance;
	wc.hIcon         = LoadIcon(NULL, IDI_APPLICATION);
	wc.hCursor       = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	wc.lpszMenuName  = NULL;
	wc.lpszClassName = szClassName;
	wc.hIconSm       = LoadIcon(NULL, IDI_APPLICATION);

	// Регистрируем класс окна
	if (!RegisterClassEx(&wc)) {
		MessageBox(NULL, "Cannot register class", "Error", MB_OK);
		return 0;
	}
	
	// Создаем основное окно приложения
	hMainWnd = CreateWindow( 
		szClassName, "A Hello1 Application", WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0,
		(HWND)NULL, (HMENU)NULL,
		(HINSTANCE)hInstance, NULL
	);
	
	if (!hMainWnd) {
		MessageBox(NULL, "Cannot create main window", "Error", MB_OK);
		return 0;
	}

	// Показываем наше окно
	ShowWindow(hMainWnd, nCmdShow); 
//	UpdateWindow(hMainWnd);

	// Выполняем цикл обработки сообщений до закрытия приложения
	while (GetMessage(&msg, NULL, 0, 0))  {
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	return msg.wParam;
}
///////////////////////////////////////////////////////////////////////////////////////////////
LRESULT CALLBACK WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC;
	PAINTSTRUCT ps;
	RECT rect;

	switch (msg)
	{
	case WM_PAINT:
		{
			hDC = BeginPaint(hWnd, &ps);
			
			SetTextAlign(hDC, TA_LEFT);

			GetClientRect(hWnd, &rect);

			LOGFONT logFont = DefineLogFontParams();

			HFONT newFont = CreateFontIndirect(&logFont);

			HFONT oldFont = (HFONT)SelectObject(hDC, newFont);		

			char faceName[32];
			GetTextFace(hDC, 32, faceName);

			DrawText(hDC, faceName, -1, &rect,
				DT_SINGLELINE | DT_CENTER | DT_VCENTER );
			
			DeleteObject(SelectObject(hDC, oldFont));

			EndPaint(hWnd, &ps);
			return 0;
		}
	case WM_CLOSE:
		DestroyWindow(hWnd);
		return 0;

    case WM_DESTROY:
		PostQuitMessage(0);
		return 0;

	default:
		return DefWindowProc(hWnd, msg, wParam, lParam);
	}

	return 0;
}

LOGFONT DefineLogFontParams()
{
	LOGFONT logFont;
	logFont.lfCharSet = ANSI_CHARSET;

	logFont.lfHeight = 30; 
	logFont.lfWidth = 12; 
	logFont.lfEscapement = 30; 
	logFont.lfOrientation = 50; 
	logFont.lfWeight = FW_LIGHT; 
	logFont.lfItalic = TRUE; 
	logFont.lfUnderline = FALSE; 
	logFont.lfStrikeOut = TRUE; 
	logFont.lfOutPrecision = OUT_DEFAULT_PRECIS; 
	logFont.lfClipPrecision = CLIP_DEFAULT_PRECIS; 
	logFont.lfQuality = ANTIALIASED_QUALITY; 
	logFont.lfPitchAndFamily = FIXED_PITCH; 
	strcpy(logFont.lfFaceName, "Verdana"); 


	return logFont;
}