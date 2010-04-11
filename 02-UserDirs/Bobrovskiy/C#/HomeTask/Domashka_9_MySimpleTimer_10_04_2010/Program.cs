using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MySimpleTimer_10_04_2010
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
