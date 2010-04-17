using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TeaMaker
{
    public partial class MainForm : Form
    {
        private const int SW_RESTORE = 9;
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        private TimeSpan totalTimeLeft;

        public MainForm()
        {
            InitializeComponent();

            propertyGrid1.SelectedObject = this;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Text = string.Format("{0:00}:{1:00}.{2:00}",
                       totalTimeLeft.Minutes,
                       totalTimeLeft.Seconds,
                       totalTimeLeft.Milliseconds / 10);

            totalTimeLeft -= TimeSpan.FromMilliseconds(timer.Interval);
            if(totalTimeLeft <= TimeSpan.Zero)
            {
                timer.Stop();
                MessageBox.Show("Alert!", "Tea is ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Text = "Ready";
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            int minutesLeft = (int)minutesNumericUpDown.Value;
            int secondsLeft = (int)secondsNumericUpDown.Value;

            totalTimeLeft = new TimeSpan(0, minutesLeft, secondsLeft);
            timer.Start();
        }

        private void MainForm_ClientSizeChanged(object sender, EventArgs e)
        {
            if(ClientSize == Size.Empty)
            {
                Hide();
                restoreToolStripMenuItem.Enabled = true;
            }
        }

        private void RestoreForm(object sender, EventArgs e)
        {
            Show();
            ShowWindowAsync(Handle, SW_RESTORE);

            restoreToolStripMenuItem.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult promtResult = MessageBox.Show(
                                        "Are you really want to exit?",
                                        "Exit promt",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);

            if(promtResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}