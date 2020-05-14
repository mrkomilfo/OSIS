// lab6.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "lab6.h"

#define MAX_LOADSTRING 100
#define START_BUTTON 1147
#define STOP_BUTTON 1149
#define STR L"DEUS VULT!"
#define FONT L"Georgia"
#define TIMER 666

// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name
HFONT hFont = CreateFont(72, 0, 0, 0, 0, FALSE, 0, 0, 0, 0, 0, 0, 0, FONT);

// Forward declarations of functions included in this code module:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

void Draw(HDC hdc, int x, int y);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // TODO: Place code here.

    // Initialize global strings
    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_LAB6, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    // Perform application initialization:
    if (!InitInstance (hInstance, nCmdShow))
    {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_LAB6));

    MSG msg;

    // Main message loop:
    while (GetMessage(&msg, nullptr, 0, 0))
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
ATOM MyRegisterClass(HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style          = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc    = WndProc;
    wcex.cbClsExtra     = 0;
    wcex.cbWndExtra     = 0;
    wcex.hInstance      = hInstance;
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_ICON1));
    wcex.hCursor        = LoadCursor(hInstance, MAKEINTRESOURCE(IDC_CURSOR1));
    wcex.hbrBackground  = (HBRUSH)(COLOR_WINDOW+1);
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_LAB6);
    wcex.lpszClassName  = szWindowClass;
    wcex.hIconSm        = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_ICON1));

    return RegisterClassExW(&wcex);
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
   hInst = hInstance; // Store instance handle in our global variable

   HWND hWnd = CreateWindowW(szWindowClass, L"AVE MARIA!", WS_OVERLAPPEDWINDOW&(~WS_MAXIMIZEBOX),
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);

   HMENU hMenu = CreateMenu();
   HMENU hPopupMenu = CreatePopupMenu();
   AppendMenu(hMenu, MF_STRING | MF_POPUP, (UINT)hPopupMenu, L"Menu");
   AppendMenu(hPopupMenu, MF_STRING, START_BUTTON, L"Start");
   AppendMenu(hPopupMenu, MF_STRING, STOP_BUTTON, L"Stop");
   SetMenu(hWnd, hMenu);
   SetMenu(hWnd, hPopupMenu);

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
//  PURPOSE: Processes messages for the main window.
//
//  WM_COMMAND  - process the application menu
//  WM_PAINT    - Paint the main window
//  WM_DESTROY  - post a quit message and return
//
//
int x = 0;
int y = -100;
short step = 3;
short direction = 1;
bool flag = true;

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
    case WM_COMMAND:
        {
            int wmId = LOWORD(wParam);
            // Parse the menu selections:
            switch (wmId)
            {
            case START_BUTTON:
				SetTimer(hWnd, TIMER, 1, NULL);
                break;
            case STOP_BUTTON:
				KillTimer(hWnd, TIMER);
                break;
            default:
                return DefWindowProc(hWnd, message, wParam, lParam);
            }
        }
        break;
	case WM_TIMER:
	{			
		if (flag)
		{
			x += direction * step;
		}
		InvalidateRect(hWnd, NULL, NULL);
		break;
	}
	case WM_PAINT:
	{	
		PAINTSTRUCT ps;
		HDC hdc = BeginPaint(hWnd, &ps);		
		SelectObject(hdc, hFont);
		TextOut(hdc, x, y, STR, wcslen(STR));
		EndPaint(hWnd, &ps);
		ReleaseDC(hWnd, hdc);

		RECT rect;
		GetWindowRect(hWnd, &rect);
		int width = rect.right - rect.left;
		int middle = (rect.bottom - rect.top) / 2 - 64;
		flag = true;
		if (x < 10)
		{
			flag = false;
			direction = 1;
			x = 10;
		}
		if (x > width - 393)
		{
			flag = false;
			direction = -1;
			x = width - 393;
		}
		y = middle;
		break;
	}

    case WM_DESTROY:
		
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }
    return 0;
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
