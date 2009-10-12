#include "MyWndClass.h"

//----------------------
MyWndClass::MyWndClass() {	
	SetWindowLong( hMainWnd, GWL_USERDATA, (LONG)this);
	SetWindowLong( hMainWnd, GWL_WNDPROC, (LONG)WndProcStub);
 
};
//----------------------
MyWndClass::MyWndClass(HINSTANCE hInstancem):hInstance(hInstancem) {
	SetWindowLong( hMainWnd, GWL_USERDATA, (LONG)this);
	SetWindowLong( hMainWnd, GWL_WNDPROC, (LONG)WndProcStub);
};
//----------------------
LRESULT CALLBACK MyWndClass::WndProcStub(HWND hWnd,UINT msg,WPARAM wParam,LPARAM lParam) {
	pMyWndClass pThis = (pMyWndClass)GetWindowLong(hWnd, GWL_USERDATA);
	return pThis->WndProc(hWnd, msg, wParam, lParam);
};
//---------------------
void MyWndClass::DrawPartOfPie(HWND hWnd,const COLORREF col,const int startAngle,const int endAngle,const char* text) {
/// --- splitted pie chart
	RECT rect;
	HDC hDC = GetDC(hWnd);
	::GetClientRect(hWnd,&rect);
	POINT center;		
	//---
	double pi = 3.14159265359;
	int r=200; 
	double sAng = pi*startAngle/180;
	double eAng = pi*endAngle/180;
	double txtAng = pi*((endAngle+startAngle)/2)/180;
	
	int x1=0, y1=0, x2=0, y2=0, x3=0, y3=0; 
	
	center.x = (rect.right + rect.left)/3;
	center.y = (rect.top + rect.bottom)/3;
	
	x3 = (int)(center.x+(r/2)*cos(txtAng));
	y3 = (int)(center.y-(r/2)*sin(txtAng));

	center.x = center.x + x3/3 ;
	center.y = center.y + y3/3 ;

	//---
	HBRUSH hOld, hNew;	 
    hNew = CreateSolidBrush (col);         
    hOld = (HBRUSH)SelectObject(hDC,hNew);
	//---
    x1 = (int)(center.x+r*cos(sAng)); 
    y1 = (int)(center.y-r*sin(sAng)); 	   

    x2 = (int)(center.x+r*cos(eAng)); 
    y2 = (int)(center.y-r*sin(eAng));

	x3 = (int)(center.x+(r/2)*cos(txtAng));
	y3 = (int)(center.y-(r/2)*sin(txtAng));

    Pie (hDC,center.x-r,center.y-r,center.x+r,center.y+r,x1,y1,x2,y2); 
	
	::TextOut(hDC,x3,y3,text,strlen(text));
	//---
    SelectObject(hDC,hOld);   
    ::ReleaseDC(hWnd,hDC);
    ::DeleteObject(hNew);		 
}
//---------------------
void MyWndClass::circleDiagram(HWND hWnd){
	const int deg = 36;

	DrawPartOfPie(hWnd,RGB(225,125,125),0,3*deg,"30%");

	DrawPartOfPie(hWnd,RGB(225,225,125),3*deg,7*deg,"40%");

	DrawPartOfPie(hWnd,RGB(205,25,125),7*deg,9*deg,"20%");

	DrawPartOfPie(hWnd,RGB(125,25,125),9*deg,10*deg,"10%");
};
//----------------------
LRESULT MyWndClass::WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
	PAINTSTRUCT ps;
	RECT rect;

	switch(uMsg) {
	case WM_PAINT: {
		::BeginPaint(hWnd, &ps);		
		
		circleDiagram(hWnd);
		//-----------------------
		::EndPaint(hWnd, &ps);
		}
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	};
	return 0;
};
//---------------------
void MyWndClass::CreateWndClass() {
	this->szClassName="MyClassTimer";
	//--
	wc.cbSize = sizeof(wc);
	wc.style = CS_HREDRAW | CS_VREDRAW;
	wc.lpfnWndProc = WndProcStub;
	wc.cbClsExtra = 0;
	wc.cbWndExtra=0;
	wc.hInstance = this->hInstance;
	wc.hIcon = LoadIcon(NULL,IDI_EXCLAMATION);
	wc.hCursor = LoadCursor(NULL,IDC_HAND);	
	wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	wc.lpszMenuName = NULL;
	wc.lpszClassName = szClassName.c_str();
	wc.hIconSm = LoadIcon(NULL, IDI_EXCLAMATION);
};
//---
int MyWndClass::CreateWnd(){
	if(!RegisterClassEx(&this->wc)){
		throw "Error can't register window class";		
	};
	//--
	hMainWnd=CreateWindow(this->szClassName.c_str(), "Hallo man ", WS_OVERLAPPEDWINDOW,
		100, 100, 600, 600,(HWND)NULL,
		(HMENU)NULL, (HINSTANCE)this->hInstance, NULL);
	
	if(!hMainWnd){
		throw "Cant create main window";		
	};
	return 0;
};
//---
int MyWndClass::Run() {
	//--
	CreateWndClass();
	//--
	CreateWnd();
	//--
	ShowWindow(hMainWnd, SW_SHOWNORMAL);
	//--
	while(GetMessage(&msg, NULL, 0, 0)) {
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	};
	return msg.wParam;
};
//---