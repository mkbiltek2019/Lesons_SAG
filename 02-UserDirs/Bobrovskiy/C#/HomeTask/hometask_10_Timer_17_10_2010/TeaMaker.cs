using System;

namespace lesson_12_winform
{
    public enum State { Start = 1, Stop = 2 };

    public class CountDownTimer
    {
        private State currentState = State.Stop;
        private TimeSpan countDownValue = TimeSpan.Zero;
        private TimeSpan timeLeft = TimeSpan.Zero;

        public State CurrentState
        {
            get
            {
                return currentState;
            }
        }

        public TimeSpan TimeLeft
        {
            get
            {
                return timeLeft;
            }
        }

        public CountDownTimer(TimeSpan startTime, TimeSpan substractValue)
        {
            timeLeft = startTime;
            countDownValue = substractValue;
        }

        public void Start()
        {
            currentState = State.Start;
        }

        public void Tick()
        {
            if (timeLeft > TimeSpan.Zero)
            {
                if (currentState == State.Start)
                {
                    timeLeft -= countDownValue;

                    if (timeLeft <= TimeSpan.Zero)
                    {
                        Stop();
                    }
                }
            }
            else
            {
                Stop(); 
            }
        }

        public string TickAndOut()
        {
            Tick();

            return string.Format("{0:00}:{1:00}.{2:00}",
                    timeLeft.Minutes,
                    timeLeft.Seconds,
                    timeLeft.Milliseconds / 10);
        }

        public void Stop()
        {
            currentState = State.Stop;
        }
    }
}
