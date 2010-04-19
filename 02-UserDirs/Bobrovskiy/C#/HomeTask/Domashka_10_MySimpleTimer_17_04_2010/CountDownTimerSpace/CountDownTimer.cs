using System;
/*
 * базовий клас таймера для прямого та зворотнього відліку
 * може бути використаний у звязці з будь-яким таймером .НЕТ
*/
namespace CountDownTimerSpace
{
    public enum State { Start = 1, Stop = 2, Pause = 3, Zeroed = 4 };
    public enum MoveDirection { Forward = 1, Back = 2 };
	public delegate void SubAddHandler();
	
    public class CountDownTimer
    {
        private State currentState = State.Stop;
        private MoveDirection currentTimerDirection = MoveDirection.Forward;
        private TimeSpan timerStep = TimeSpan.Zero;
        private TimeSpan startTimerPosition = TimeSpan.Zero;
		private TimeSpan currnetTimerValue = TimeSpan.Zero;
		private TimeSpan maxTimerValue = TimeSpan.Zero;			
		private SubAddHandler operationHandler;
		
		private void AddTime()
		{
			 currnetTimerValue += timerStep;			 
		}
		
		private void SubTime()
		{
			 currnetTimerValue -= timerStep;			 
		}
		
		private void SetCurrentDirectionHandler(MoveDirection direction)
		{
			switch(direction)
			{
				case MoveDirection.Forward:
				{
                    operationHandler = AddTime;
				}break;
				case MoveDirection.Back:
				{
                    operationHandler = SubTime;
				}break;
			}
		}
							
        public State CurrentState
        {
            get
            {
                return currentState;
            }
        }

        public TimeSpan CurrentValue
        {
            get
            {
                return currnetTimerValue;
            }
        }
			
        public CountDownTimer(TimeSpan startTimerValue, 
						TimeSpan maxTimerValueForForwardDirection,
						TimeSpan timerStep, 
						MoveDirection direction)
        {
            startTimerPosition = startTimerValue;
			currnetTimerValue = startTimerValue;
            this.timerStep = timerStep;  	
			currentTimerDirection = direction;
			maxTimerValue = maxTimerValueForForwardDirection;
			SetCurrentDirectionHandler(direction);			
        }
		
		public CountDownTimer(TimeSpan startTimerValue, 						
						TimeSpan timerStep, 
						MoveDirection direction)
        {
            startTimerPosition = startTimerValue;
			currnetTimerValue = startTimerValue;
			this.timerStep = timerStep;  	
			currentTimerDirection = direction;			
			SetCurrentDirectionHandler(direction);			
        }

        public void Start()
        {
            currentState = State.Start;
        }
		
		public void Stop()
        {
            currentState = State.Stop;
        }

        public void Pause()
        {
            currentState = State.Pause;
        }
		
		public void ClearCurrentTime()
		{			
			currnetTimerValue = startTimerPosition;
		    currentState = State.Zeroed;
		}
		        	
        public void Tick()
        {
			switch(currentState)
			{
				case State.Start:
				{
				 if (currnetTimerValue >= TimeSpan.Zero)
				 {
					operationHandler.Invoke();	
				 }
				 else
				 {
					Stop();
				 }				 
				}break;
				case State.Stop:
				{
					Stop();
				}break;
				case State.Pause:
				{
					Stop();
				}break;
				case State.Zeroed:
				{
					ClearCurrentTime();
				}break;			
			}

            switch (currentTimerDirection)
			{
				case MoveDirection.Forward:
				{
					if(currnetTimerValue >= maxTimerValue)
					{
						Stop();
					}
				}break;
				case MoveDirection.Back:
				{
					if(currnetTimerValue <= TimeSpan.Zero)
					{
						Stop();
					}
				}break;
			}		
            
        }

        public string TickAndOut()
        {
            Tick();

            return string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    currnetTimerValue.Hours,
                    currnetTimerValue.Minutes,
                    currnetTimerValue.Seconds,
                    currnetTimerValue.Milliseconds / 10);
        }
    }

}
