using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Marafon
    {
        private int marafonDistance;
        private List<Runner> sportsmans;

        public Marafon(List<Runner> listOfRunners, int distance)
        {
            sportsmans = listOfRunners;
            marafonDistance = distance;
        }

        public void Start()
        {

            bool[] stateArray = new bool[sportsmans.Count];

            for (int i = 0; i < sportsmans.Count; i++)
            {
                sportsmans[i].StopRunning += MarafonFinish;
                stateArray[i] = false;
            }

            int numberOfFinishedSportsmans = 0;
            do
            {
                for (int i = 0; i < sportsmans.Count; i++)
                {
                    if (stateArray[i]) continue;

                    if (sportsmans[i].state == runnerState.run)
                    {
                        RunnerVisualizer.drawClearTurtle(i * 5, sportsmans[i].currentDistance);
                        sportsmans[i].Action();
                        RunnerVisualizer.drawColoredTurtle(i * 5, sportsmans[i].currentDistance, ConsoleColor.DarkGreen);
                        System.Threading.Thread.Sleep(100);
                    }
                    else
                    {
                        stateArray[i] = true;
                        numberOfFinishedSportsmans++;
                    }
                }
            } 
            while (numberOfFinishedSportsmans != (sportsmans.Count));
        }

        private void MarafonFinish(int distance, string name, ref bool stop)
        {
            if (distance >= marafonDistance)
            {
                stop = true;
            }
        }
    }
}
