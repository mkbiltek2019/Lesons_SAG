using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Special_Timer
{

    public partial class Form1 : Form
    {
        private int minutes=0;
        private int hours=0;
        private int seconds =0;

        private const int SW_RESTORE = 9;
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        public Form1()
        {
            InitializeComponent();
            FormTimer.Enabled = true;

            startToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = false;
            pauseToolStripMenuItem.Enabled = false;
            restoreToolStripMenuItem.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {

            TimeLabel.Text = hours.ToString() + ":"
                           + minutes.ToString() + ":"
                           + seconds.ToString();
            

            if (seconds > 0)
                seconds--;
            else if (seconds ==0)
            {
                if (minutes > 0)
                {
                    minutes--;
                    seconds = 59;
                }
                else if (minutes == 0)
                {
                    if (hours > 0)
                    {
                        hours--;
                        minutes = 59;
                        seconds = 59;
                    }
                    else if (hours == 0)
                    {
                        if (timer.Enabled == true)
                        {
                            timer.Enabled = false;
                            TimeLabel.Text = "ALARM !!!";
                        }
                       

                        
                    }
                }
            }

           
            
        }

        private void HourNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            hours = (int)HourNumericUpDown.Value;
            NullButton.Enabled = true;
        }

        private void MinuteNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            minutes = (int)MinuteNumericUpDown.Value;
            NullButton.Enabled = true;
        }

        private void SecondsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            seconds = (int)SecondsNumericUpDown.Value;
            NullButton.Enabled = true;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            InfoLabel.Visible = true;
            
            if (StartButton.Text == "START")
            {
                timer.Enabled = true;
                StopButton.Enabled = true;
                StartButton.Text = "PAUSE";
                InfoLabel.Text = "WORKING";
                pauseToolStripMenuItem.Enabled = true;
                stopToolStripMenuItem.Enabled = true;
            }
            else
            {
                StartButton.Text = "START";
                timer.Stop();
                InfoLabel.Text = "PAUSE";
                pauseToolStripMenuItem.Enabled = false;
                startToolStripMenuItem.Enabled = true;
            }
            NullButton.Enabled = false;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            HourNumericUpDown.Value = 0;
            MinuteNumericUpDown.Value = 0;
            SecondsNumericUpDown.Value = 0;
            timer.Enabled = false;
            InfoLabel.Text = "STOPPED";
            TimeLabel.Text = "00:00:00";
            StartButton.Text = "START";
            StopButton.Enabled = false;
            NullButton.Enabled = false;

            stopToolStripMenuItem.Enabled = false;
            pauseToolStripMenuItem.Enabled = false;
            startToolStripMenuItem.Enabled = false;
            restoreToolStripMenuItem.Enabled = false;
        }

        private void FormTimer_Tick(object sender, EventArgs e)
        {
            if (this.Text == "SPECIAL TIMER ")
                this.Text = " ";
            else
                this.Text = "SPECIAL TIMER ";
        }

        private void NullButton_Click(object sender, EventArgs e)
        {
            HourNumericUpDown.Value = 0;
            MinuteNumericUpDown.Value = 0;
            SecondsNumericUpDown.Value = 0;
            NullButton.Enabled = false;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_ClientSizeChanged(object sender, EventArgs e)
        {
            
            if (ClientSize == Size.Empty)
            {
                Hide();
                stopToolStripMenuItem.Enabled = true;
                pauseToolStripMenuItem.Enabled = true;

                restoreToolStripMenuItem.Enabled = true;
            }
           
        }

        private void RestoreForm(object sender, EventArgs e)
        {
            Show();
            ShowWindowAsync(Handle, SW_RESTORE);

            restoreToolStripMenuItem.Enabled = false;
           
        }

       

     
       

       

   
    }
      
}
