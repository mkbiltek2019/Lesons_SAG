namespace ConsoleApplication1
{
    public enum runnerState
    {
        run = 1,
        wait = 2
    }

    public class Runner
    {
        public runnerState state = runnerState.wait;
        public int currentDistance = 0;
        private readonly int speed = 0;
        public string name = string.Empty;
        public event RunningStateHandler StopRunning;

        public Runner(int runnerSpeedValue, string runnerName)
        {
            speed = runnerSpeedValue;
            currentDistance = 0;
            name = runnerName;
            state = runnerState.run;
        }

        public void Action()
        {
            bool stop = false;

            if (state == runnerState.run)
            {
                currentDistance += speed;
                if (StopRunning != null)
                {
                    StopRunning.Invoke(currentDistance, name, ref stop);
                    if (stop)
                    {
                        Stop();
                    }
                }
            }


        }

        public void Stop()
        {
            state = runnerState.wait;
        }

        public void Start()
        {
            state = runnerState.run;
        }
    }
}
