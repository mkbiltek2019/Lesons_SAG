// Hello1.cpp
#include <windows.h>

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
void ShowRectangle(HDC hDC, int x, int y);
void HideRectangle(HDC hDC, int x, int y);

BOOL rectangleShown = false;

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
	static HDC hDC;
	static int x, y;
	static BOOL tracking = false;

	switch (msg)
	{
	case WM_CREATE:
		hDC = GetDC(hWnd);
		return 0;
	case WM_PAINT:
		{
			if (rectangleShown)
			{
				ShowRectangle(hDC, x, y);
			}
			return 0;
		}
	case WM_LBUTTONDOWN:
		{
			tracking = true;
			x = LOWORD(lParam);
			y = HIWORD(lParam);
			ShowRectangle(hDC, x, y);
			return 0;
		}
	case WM_MOUSEMOVE:
		{
			if (tracking)
			{
				HideRectangle(hDC, x, y);
				x = LOWORD(lParam);
				y = HIWORD(lParam);
				ShowRectangle(hDC, x, y);
			}
			return 0;
		}
	case WM_LBUTTONUP:
		{
			tracking = false;
			return 0;
		}
	case WM_CLOSE:
		DestroyWindow(hWnd);
		return 0;

    case WM_DESTROY:
		ReleaseDC(hWnd, hDC);
		PostQuitMessage(0);
		return 0;

	default:
		return DefWindowProc(hWnd, msg, wParam, lParam);
	}

	return 0;
}

void ShowRectangle(HDC hDC, int x, int y)
{
	int width = 40;
	int height = 20;
	Rectangle(hDC, x, y, x + width, y + height);
	rectangleShown = true;
}

void HideRectangle(HDC hDC, int x, int y)
{
	if (rectangleShown)
	{
		int width = 40;
		int height = 20;
		Rectangle(hDC, x, y, x + width, y + height);
		rectangleShown = false;
	}
}