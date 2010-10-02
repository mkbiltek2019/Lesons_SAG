using System;

namespace HooksInDotNET.Win32
{
    /// <summary>
    /// Hook event arguments
    /// </summary>
    public class HookEventArgs : EventArgs
    {
        public int HookCode;    // Hook code
        public IntPtr wParam;   // WPARAM argument
        public IntPtr lParam;   // LPARAM argument
    }
}