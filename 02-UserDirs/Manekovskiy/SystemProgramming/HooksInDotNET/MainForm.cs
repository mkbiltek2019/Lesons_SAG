using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HooksInDotNET.Win32;

namespace HooksInDotNET
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        protected static extern int CallNextHookEx(IntPtr hhook, int code, IntPtr wParam, IntPtr lParam);

        private LocalWindowsHook _localMouseHook;
        private int _currentThreadId;

        public MainForm()
        {
            InitializeComponent();
            _currentThreadId = AppDomain.GetCurrentThreadId();
        }

        private int MouseHookProc(int code, IntPtr wparam, IntPtr lparam)
        {
            WinApi.MOUSEHOOKSTRUCT mousehookstruct = (WinApi.MOUSEHOOKSTRUCT) Marshal.PtrToStructure(lparam, typeof (WinApi.MOUSEHOOKSTRUCT));

            const string messageLogFormat = "({0}; {1})\tbutton: {2}\r\n";
            
            string mouseButton = string.Empty;
            //if(code == WinApi.HC_ACTION)
            //{
            switch ((int)wparam)
            {
                case WinApi.WM_LBUTTONDOWN:
                    mouseButton = "Left";
                    break;
                case WinApi.WM_RBUTTONDOWN:
                    mouseButton = "Right";
                    break;
                default:
                    mouseButton = "None";
                    break;
            }
            //}
            messageLogTextBox.Text += string.Format(messageLogFormat, mousehookstruct.pt.x, mousehookstruct.pt.y, mouseButton);

            return CallNextHookEx(_localMouseHook.HookHandle, code, wparam, lparam);
        }

        private void InstallHookButton_Click(object sender, EventArgs e)
        {
            _localMouseHook = new LocalWindowsHook(HookType.WH_MOUSE, MouseHookProc);
            _localMouseHook.Install(_currentThreadId);
        }

        private void OnUninstallHook(object sender, EventArgs e)
        {
            try
            {
                if (_localMouseHook.HookHandle != IntPtr.Zero)
                {
                    _localMouseHook.Uninstall();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hook uninstallation failed");
            }
        }
    }
}
