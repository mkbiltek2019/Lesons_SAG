using System;
using System.Runtime.InteropServices;

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
    }
}