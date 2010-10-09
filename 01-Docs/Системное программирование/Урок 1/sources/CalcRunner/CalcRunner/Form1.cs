using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CalcRunner
{
    public partial class CalcRunner : Form
    {
        public CalcRunner()
        {
            InitializeComponent();
            myProcess.StartInfo = new ProcessStartInfo("calc.exe");
        }

        private void Start_Click(object sender, EventArgs e)
        {
            myProcess.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            myProcess.CloseMainWindow();
            myProcess.Close();
        }
    }
}
