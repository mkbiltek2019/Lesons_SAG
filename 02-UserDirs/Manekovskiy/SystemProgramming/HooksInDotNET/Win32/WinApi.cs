using System;

namespace HooksInDotNET.Win32
{
    internal struct WinApi
    {
        internal struct MOUSEHOOKSTRUCT
        {
            public POINT pt;
            public IntPtr hwnd;
            public uint wHitTestCode;
            public IntPtr dwExtraInfo;
        }

        internal struct POINT
        {
            public int x;
            public int y;
        }

        internal const int WM_RBUTTONDOWN = 0x0204;
        internal const int WM_RBUTTONUP = 0x0205;
        internal const int WM_RBUTTONDBLCLK = 0x0206;

        internal const int WM_NCRBUTTONDOWN = 0x00A4;
        internal const int WM_NCRBUTTONUP = 0x00A5;
        internal const int WM_NCRBUTTONDBLCLK = 0x00A6;

        internal const int WM_NCLBUTTONDOWN = 0x00A1;
        internal const int WM_NCLBUTTONUP = 0x00A2;
        internal const int WM_NCLBUTTONDBLCLK = 0x00A3;

        internal const int WM_LBUTTONDOWN = 0x201;
        internal const int WM_LBUTTONUP = 0x202;
        internal const int WM_LBUTTONDBLCLK = 0x203;


        internal const int WM_MOUSEMOVE = 0x0200;

        internal const int HC_ACTION = 0;
    }
}