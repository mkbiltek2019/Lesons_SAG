using System;
using System.Runtime.InteropServices;
using System.Text;

namespace HooksInDotNET.Win32
{
    /// <summary>
    /// Implementation of hooking mechanism
    /// </summary>
    public class LocalWindowsHook
    {
        #region Imports

        [DllImport("user32.dll")]
        protected static extern IntPtr SetWindowsHookEx(HookType code, HookProc func, IntPtr hInstance, int threadID);

        [DllImport("user32.dll")]
        protected static extern int UnhookWindowsHookEx(IntPtr hhook);

        [DllImport("user32.dll")]
        protected static extern int CallNextHookEx(IntPtr hhook, int code, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        protected static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        protected static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        protected static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        protected  static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        #endregion

        #region Private memebers

        private IntPtr m_hhook = IntPtr.Zero;
        protected HookProc m_filterFunc = null;
        protected HookType m_hookType;

        #endregion

        #region Delegates & Events

        public delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);

        #endregion

        public LocalWindowsHook(HookType hookType, HookProc filterFunction)
        {
            m_hookType = hookType;
            m_filterFunc = filterFunction;
        }
       
        ///<summary>
        /// CallNextHookEx 
        /// </summary>
        public int CallNextHook(IntPtr hhook, int code, IntPtr wParam, IntPtr lParam)
        {
            return CallNextHookEx(hhook, code, wParam, lParam);
        }

        /// <summary>
        /// Installs hook
        /// </summary>
        public void Install(int threadId)
        {
            m_hhook = SetWindowsHookEx(m_hookType, m_filterFunc, IntPtr.Zero, threadId);
        }

        /// <summary>
        /// Uninstalls hook
        /// </summary>
        public void Uninstall()
        {
            UnhookWindowsHookEx(m_hhook);
        }

        public IntPtr HookHandle
        {
            get { return m_hhook; }
        }

        #region extract different data using win32api
        
        ///<summary>
        /// GetModuleHandle by Process ModuleName
        /// </summary>
        /// 
        internal int GetModuleID(string moduleName)
        {
            return GetModuleHandle(moduleName).ToInt32();
        }

        ///<summary>
        /// GetForegroundWindow get current active window
        /// </summary>
        /// 
        internal IntPtr GetActivedWindow()
        {
            return GetForegroundWindow();
        }

        ///<summary>
        /// GetWindowTextLength get window title text length
        /// </summary>
        /// 
        internal int GetWindowTitleLength(IntPtr ipForegroundWindow)
        {
            return GetWindowTextLength(ipForegroundWindow);
        }

        ///<summary>
        /// GetWindowText get window title
        /// </summary>
        /// 
        internal string GetWindowTitle()
        {
            IntPtr ipForegroundWindow = GetActivedWindow();
            int nLength = GetWindowTitleLength(ipForegroundWindow);
            StringBuilder activeWindowTitle = new StringBuilder(string.Empty, nLength + 1);
            GetWindowText(ipForegroundWindow, activeWindowTitle, activeWindowTitle.Capacity);

            return activeWindowTitle.ToString();
        }

        #endregion
    }
}