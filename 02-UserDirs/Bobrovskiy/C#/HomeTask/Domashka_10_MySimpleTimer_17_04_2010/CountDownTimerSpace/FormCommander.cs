using System;
using System.Windows.Forms;

namespace CountDownTimerSpace
{
    public class FormCommander
    {
        private Timer currentFormTimer;
        private Label currnetTimerState;
        private Label currnetTimerValue;
        private bool blink = false;

        //- створюєть таймер на десять хвилин з кроком 16 мілісекунд
        //- зовнішній таймер має Interval = 1;
        private CountDownTimer countDownTimer = new CountDownTimer(TimeSpan.Zero,
                            new TimeSpan(0, 0, 10, 0, 0),
                            new TimeSpan(0, 0, 0, 0, 16),
                            MoveDirection.Forward);

        public FormCommander(Timer formTimer, Label timerState, Label timerValue)
        {
            currentFormTimer = formTimer;
            currnetTimerState = timerState;
            currnetTimerValue = timerValue;
        }

        public string TitleBlinking()
        {
            string text = string.Empty;

            if (blink)
            {
                text = string.Empty;
                blink = false;
            }
            else
            {
                text = "Simple timer";
                blink = true;
            }

            return text;
        }

        public void TimerStart()
        {
            currentFormTimer.Start();
            countDownTimer.Start();
            currnetTimerState.Text = "Current timer state: " +
                            countDownTimer.CurrentState.ToString();
        }

        public void TimerStop()
        {
            countDownTimer.ClearCurrentTime();
            countDownTimer.Stop();
            currentFormTimer.Stop();
            currnetTimerState.Text = "Current timer state: " +
                            countDownTimer.CurrentState.ToString();
        }

        public void TimerPause()
        {
            countDownTimer.Pause();
            currentFormTimer.Stop();
            currnetTimerState.Text = "Current timer state: " +
                countDownTimer.CurrentState.ToString();
        }

        public void TimerAction()
        {
            currnetTimerValue.Text = countDownTimer.TickAndOut();
            currnetTimerState.Text = "Current timer state: " +
                            countDownTimer.CurrentState.ToString();
        }
    }

}
