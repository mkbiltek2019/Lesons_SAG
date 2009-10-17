// Hello1.cpp
#include <windows.h>
#include <winuser.h>

int keyCount;

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

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
			
			GetClientRect(hWnd, &rect);

			char a[6] = {'\0', '\0', '\0', '\0', '\0', '\0'};
			DrawText(hDC, itoa(keyCount, a, 10), -1, &rect, 0);

			EndPaint(hWnd, &ps);
			return 0;
		}
	case WM_KEYDOWN:
		{
			//char a[6] = {'\0', '\0', '\0', '\0', '\0', '\0'};
			//MessageBox(hWnd, itoa(wParam, a, 10), "Key event", 0);
			
			/*keyCount = LOWORD(lParam);*/
			/*InvalidateRect(hWnd, NULL, false);*/

			switch (wParam)
			{
			case VK_UP: 
				
				break;
			case VK_DOWN: 

				break;
			case VK_RIGHT: 

				break;
			case VK_LEFT: 

				break;
			}

			break;
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