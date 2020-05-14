﻿// lab7.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "lab7.h"

#define MAX_LOADSTRING 100
#define PER *x_part
// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name
HWND hAdd;										// value button
HWND hClear;									// clear button
HWND hRight;									//  to the right button
HWND hDelete;									// delete button
HWND hListBox1;									// listbox 1
HWND hListBox2;									// listbox 2
HWND hEdit;										// edit button

// Forward declarations of functions included in this code module:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);

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
	LoadStringW(hInstance, IDC_LAB7, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance(hInstance, nCmdShow))
	{
		return FALSE;
	}

	HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_LAB7));
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
	return (int)msg.wParam;
}


ATOM MyRegisterClass(HINSTANCE hInstance)	 //Registers the window class.
{
	HBRUSH hBrush = CreateSolidBrush(RGB(150, 150, 150));
	WNDCLASSEXW wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style = CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc = WndProc;
	wcex.cbClsExtra = 0;
	wcex.cbWndExtra = 0;
	wcex.hInstance = hInstance;
	wcex.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_LAB7));
	wcex.hCursor = LoadCursor(nullptr, IDC_ARROW);
	wcex.hbrBackground = hBrush;
	wcex.lpszMenuName = MAKEINTRESOURCEW(IDC_LAB7);
	wcex.lpszClassName = szWindowClass;
	wcex.hIconSm = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassExW(&wcex);
}


BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)		// Saves instance handle and creates main window
{
	//In this function, we save the instance handle in a global variable and
	//        create and display the main program window.
	hInst = hInstance; // Store instance handle in our global variable

	HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPED | WS_MINIMIZEBOX | WS_SYSMENU,
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);
	if (!hWnd)
	{
		return FALSE;
	}

	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);

	return TRUE;
}

int x_part;
TCHAR input_text[1024];

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam) //Processes messages for the main window.
{
	RECT rect;
	GetWindowRect(hWnd, &rect);
	x_part = (rect.right - rect.left) / 100;

	switch (message)
	{
	case WM_CREATE:
	{		
		hListBox1 = CreateWindow(L"LISTBOX", NULL, WS_CHILD | WS_VISIBLE | LBS_STANDARD,
			5 PER, 20, 30 PER, 500, hWnd, HMENU(IDC_LISTBOX1), hInst, NULL);

		hListBox2 = CreateWindow(L"LISTBOX", NULL, WS_CHILD | WS_VISIBLE | LBS_STANDARD,
			65 PER, 20, 30 PER, 500, hWnd, HMENU(IDC_LISTBOX2), hInst, NULL);

		hEdit = CreateWindow(L"EDIT", NULL, WS_CHILD | WS_VISIBLE | WS_BORDER,
			40 PER, 20, 20 PER, 20, hWnd, HMENU(IDM_EDIT), hInst, NULL);

		hAdd = CreateWindow(L"BUTTON", L"✍🏻", WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
			40 PER, 60, 20 PER, 100, hWnd, HMENU(IDM_ADD), hInst, NULL);

		hClear = CreateWindow(L"BUTTON", L"Clear", WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
			40 PER, 180, 20 PER, 100, hWnd, HMENU(IDM_CLEAR), hInst, NULL);

		hRight = CreateWindow(L"BUTTON", L"Clone", WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
			40 PER, 300, 20 PER, 100, hWnd, HMENU(IDM_CLONE), hInst, NULL);
		
		hDelete = CreateWindow(L"BUTTON", L"Delete", WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
			40 PER, 420, 20 PER, 100, hWnd, HMENU(IDM_DELETE), hInst, NULL);		
		break;
	}
	case WM_COMMAND:			//process the application menu
	{
		int wmId = LOWORD(wParam);
		// Parse the menu selections:
		switch (wmId)
		{
		case IDM_ADD:
			GetWindowText(hEdit, input_text, _countof(input_text));
			SetWindowText(hEdit, nullptr);
			if (input_text[0] != _T('\0') && SendMessage(hListBox1, LB_FINDSTRINGEXACT, -1, (LPARAM)input_text) == LB_ERR)
				SendMessage(hListBox1, LB_ADDSTRING, NULL, (LPARAM)input_text);
			break;
		case IDM_DELETE:
			SendMessage(hListBox1, LB_DELETESTRING,
				SendMessage(hListBox1, LB_GETCURSEL, NULL, NULL), NULL);
			SendMessage(hListBox2, LB_DELETESTRING,
				SendMessage(hListBox2, LB_GETCURSEL, NULL, NULL), NULL);
			break;
		case IDM_CLONE:
			SendMessage(hListBox1, LB_GETTEXT,
				SendMessage(hListBox1, LB_GETCURSEL, NULL, NULL), (LPARAM)input_text);
			if (SendMessage(hListBox2, LB_FINDSTRINGEXACT, -1, (LPARAM)input_text) == LB_ERR)
				SendMessage(hListBox2, LB_ADDSTRING, NULL, (LPARAM)input_text);
			break;
		case IDM_CLEAR:
			while (SendMessage(hListBox1, LB_GETCOUNT, NULL, NULL) > 0)
				SendMessage(hListBox1, LB_DELETESTRING, 0, NULL);
			while (SendMessage(hListBox2, LB_GETCOUNT, NULL, NULL) > 0)
				SendMessage(hListBox2, LB_DELETESTRING, 0, NULL);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
	}
	break;

	case WM_DESTROY:		// post a quit message and return
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}
