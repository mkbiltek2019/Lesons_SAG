using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsDateTime
{
    public partial class Form1 : Form
    {
        private static Timer timer = new Timer();
        private void ShowTime(Object obj, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
        }
       
        public Form1()
        {
            InitializeComponent();
            labelTime.Text = DateTime.Now.ToLongTimeString();
            timer.Tick += new EventHandler(ShowTime);
            timer.Interval = 1000;
            timer.Start();
            labelDate.Text = DateTime.Now.ToLongDateString();
             DayOfWeek k = (DayOfWeek)DateTime.Now.DayOfWeek;
                DayOfTheWeek dayOfTheWeek = new DayOfTheWeek();
            labelDay.Text = dayOfTheWeek.Day(k);
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (Equals(WindowState, FormWindowState.Minimized))
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(5000, "WinFormsO'Clock ", "Свернуто в трей", ToolTipIcon.Info);
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {

        }

        private void развернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Equals(WindowState, FormWindowState.Minimized))
            {
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (Equals(WindowState, FormWindowState.Minimized))
            {
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }
    }
}
