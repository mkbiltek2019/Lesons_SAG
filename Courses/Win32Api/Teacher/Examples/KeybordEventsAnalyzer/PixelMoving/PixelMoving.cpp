// Hello1.cpp
#include <windows.h>
#include <wingdi.h>

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
void DrawPixel(HDC hDc);
void InitializePixel();
void InvalidatePixel(HWND hWnd, RECT oldPixel, RECT newPixel);
RECT GetPixelRect(POINT p);

POINT pixelLocation;
const int step = 5;
COLORREF pixelColor;


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

	InitializePixel();

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

			GetClientRect(hWnd, &rect);

			DrawPixel(hDC);

			EndPaint(hWnd, &ps);
			return 0;
		}
	case WM_KEYDOWN:
			switch (wParam)
			{
			case VK_UP:
				{
				POINT p = pixelLocation;
				pixelLocation.y -= step;				
				InvalidatePixel(hWnd, GetPixelRect(p), GetPixelRect(pixelLocation));
				break;
				}
			case VK_DOWN: 
				{
				POINT p = pixelLocation;
				pixelLocation.y += step;				
				InvalidatePixel(hWnd, GetPixelRect(p), GetPixelRect(pixelLocation));
				break;
				}
			case VK_RIGHT: 
				{
				POINT p = pixelLocation;
				pixelLocation.x += step;				
				InvalidatePixel(hWnd, GetPixelRect(p), GetPixelRect(pixelLocation));
				break;
				}
			case VK_LEFT: 
				{
				POINT p = pixelLocation;
				pixelLocation.x -= step;				
				InvalidatePixel(hWnd, GetPixelRect(p), GetPixelRect(pixelLocation));
				break;
				}
			}
			
		break;
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

void DrawPixel(HDC hDc)
{
	SetPixel(hDc, pixelLocation.x, pixelLocation.y, pixelColor);
}

void InitializePixel()
{
	pixelLocation.x = 0;
	pixelLocation.y = 0;

	pixelColor = RGB(0, 0, 0);;
}

void InvalidatePixel(HWND hWnd, RECT oldPixel, RECT newPixel)
{
	InvalidateRect(hWnd, &oldPixel, false);
	InvalidateRect(hWnd, &newPixel, false);
}

RECT GetPixelRect(POINT p)
{
	RECT rect;

	rect.top = p.y - 1;
	rect.bottom = p.y + 1;
	rect.left = p.x - 1;
	rect.right = p.x + 1;

	return rect;
}