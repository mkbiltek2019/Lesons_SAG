using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace lesson_12_winform
{
    public partial class MainForm : Form
    {
        private const int SW_RESTORE = 9;
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        private CountDownTimer countDownTimer;
        private bool blink = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void TitleBlinking(State currentState)
        {
            if (currentState == State.Start)
            {
                if (blink)
                {
                    Text = "";
                    blink = false;
                }
                else
                {
                    Text = "Prepearing ";
                    blink = true;
                }
            }
            else
            {
                Text = "Tea is Ready";
            }
        }

        private void EnableNumericUpDown(bool value)
        {
            minutesNumericUpDown.Enabled = value;
            secondsNumericUpDown.Enabled = value;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            int minutesLeft = (int)minutesNumericUpDown.Value;
            int secondsLeft = (int)secondsNumericUpDown.Value;

            TimeSpan totalTimeLeft = new TimeSpan(0, 0, minutesLeft, secondsLeft, 0);

            countDownTimer = new CountDownTimer(totalTimeLeft, new TimeSpan(0, 0, 0, 0, MainTimer.Interval));
            countDownTimer.Start();
            MainTimer.Start();
            EnableNumericUpDown(false);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            MainTimer.Stop();
            Text = "Tea is Ready";
            countDownTimer.Stop();
            EnableNumericUpDown(true);
        }

        private void RestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            ShowWindowAsync(Handle, SW_RESTORE);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            //timeLeftLabel.Text = "Time Left : " +
            //        string.Format("{0:00}:{1:00}.{2:00}",
            //        countDownTimer.TimeLeft.Minutes,
            //        countDownTimer.TimeLeft.Seconds,
            //        countDownTimer.TimeLeft.Milliseconds / 10);

            timeLeftLabel.Text = "Time Left : " + countDownTimer.TickAndOut();
            TitleBlinking(countDownTimer.CurrentState);

            if(countDownTimer.CurrentState == State.Stop)
            {
                ShowWindowAsync(Handle, SW_RESTORE);
                TopMost = true;
                TopMost = false;
                EnableNumericUpDown(true);
            }
        }

        private void MainForm_ClientSizeChanged(object sender, EventArgs e)
        {
            if (ClientSize == System.Drawing.Size.Empty)
            {
                Hide();
            }
        }
    }

}
