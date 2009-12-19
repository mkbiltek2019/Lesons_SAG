// Hello1.cpp
#include <windows.h>
#include <time.h>


const int M = 5;
const int N = 3;

int Matrix[M][N]; 
int sum = 0;

void InitializeMatrix();
DWORD WINAPI MatrixSum(void* lpv);

HANDLE hThread;
HWND hParent;

const int UM_THREAD_DONE = WM_USER + 1;

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
	case WM_CREATE:
		{
			hParent = hWnd;
			InitializeMatrix();
			hThread = CreateThread(NULL, 0, MatrixSum, &hParent, 0, NULL);
			if (!hThread)
			{
				
			}
		}
	case WM_PAINT:
		{
			hDC = BeginPaint(hWnd, &ps);
			
			GetClientRect(hWnd, &rect);

			DrawText(hDC, "Hello from Win32 API", -1, &rect,
				DT_SINGLELINE | DT_CENTER | DT_VCENTER );			

			EndPaint(hWnd, &ps);
			return 0;
		}
	case UM_THREAD_DONE:
		{
			char csum[10];
			MessageBox(hWnd, itoa(sum, csum, 10), "Calculated Sum", 0);
			return 0;
		}
	case WM_CLOSE:
		DestroyWindow(hWnd);
		return 0;

    case WM_DESTROY:
		CloseHandle(hThread);
		PostQuitMessage(0);
		return 0;

	default:
		return DefWindowProc(hWnd, msg, wParam, lParam);
	}

	return 0;
}


void InitializeMatrix()
{
	srand((unsigned)time( NULL ));
	for (int i = 0; i < M; i++)
	{
		for (int j = 0; j < N; j++)
		{
			Matrix[i][j] = rand();
		}
	}
}

DWORD WINAPI MatrixSum(void* lpv)
{
	sum = 0;
	for (int i = 0; i < M; i++)
	{
		for (int j = 0; j < N; j++)
		{
			sum += Matrix[i][j];
		}
	}	
	SendMessage(*((HWND*)lpv), UM_THREAD_DONE, 0, 0);
	return 0;
}