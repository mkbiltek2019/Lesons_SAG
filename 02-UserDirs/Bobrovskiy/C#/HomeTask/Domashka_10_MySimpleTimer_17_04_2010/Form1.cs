using System;
using System.Windows.Forms;

using CountDownTimerSpace;
/*
 1. Доповнити таймер фукнцією паузи, передбачити можливість 
 * багаторазового призупинення таймера
2. В программі-таймері передбачити можливість блокування 
 * кнопок керування в залежності від поточного стану таймера
3. В программі-таймері реалізувати нотифікацію користувача про 
 * поточний стан таймера(працюючий, призупинений, зупинений, обнулений). 
 * Реалізувати через blinking заголовок форми
 */
namespace MySimpleTimer_10_04_2010
{
    public partial class MainForm : Form
    {
        private FormCommander formManager;

        public MainForm()
        {
            InitializeComponent();
            formManager = new FormCommander(MainTimer, CurrentTimerStateLabel, TimerValueLabel);
            //передоручаю обєкти форми менеджеру форми,
            //який буде реалізовати потрібні дії
        }
        
        private void StartTimerClick(object sender, EventArgs e)
        {
            formManager.TimerStart();
            StartTitleBlinking();
            StartTimer.Enabled = false;
        }

        private void StartTitleBlinking()
        {
            TitleBlinkingTimer.Start();
            Text = "Simple timer";
        }

        private void StopTimerClick(object sender, EventArgs e)
        {
            formManager.TimerStop();
            StopBlinkingTimer();
            StartTimer.Enabled = true;
        }

        private void StopBlinkingTimer()
        {
            TitleBlinkingTimer.Stop();
            Text = "Simple timer";
        }

        private void PauseButtonClick(object sender, EventArgs e)
        {
            formManager.TimerPause();
            StopBlinkingTimer();
            StartTimer.Enabled = true;
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            formManager.TimerAction();
        }

        private void GetTimeClick(object sender, EventArgs e)
        {
            TimerValueList.Items.Add(TimerValueLabel.Text);
        }

        private void ClearResultsClick(object sender, EventArgs e)
        {
            TimerValueList.Items.Clear();
        }

        private void TitleBlinkingTimer_Tick(object sender, EventArgs e)
        {
            Text = formManager.TitleBlinking();
        }
    }

}
