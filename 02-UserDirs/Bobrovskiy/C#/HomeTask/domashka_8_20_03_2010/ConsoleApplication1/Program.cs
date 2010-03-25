using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public delegate void RunningStateHandler(int distance, string name, ref bool stop);

    class Program
    {
        static void Main()
        {
            string[] runnerNames = new string[] { "Slow monkey", "Fast rabbit", "Fat Elaphant", "Young Lion", "Silly turtle" };
            const int numberOfRunnersInMarafdon = 5;
            const int runnersMaxSpeed = 8;
            const int runnersMinSpeed = 1;
            const int marafonDistance = 60;

            List<Runner> runnersList = new List<Runner>();
            Random rand = new Random();

            for (int i = 0; i < numberOfRunnersInMarafdon; i++)
            {
                Runner runner = new Runner(rand.Next(runnersMinSpeed, runnersMaxSpeed), runnerNames[i]);
                runnersList.Add(runner);
                System.Threading.Thread.Sleep(runnersMaxSpeed);
            }

            Marafon marafon = new Marafon(runnersList, marafonDistance);

            marafon.Start();
            
            Console.ReadKey();
        }
    }
}
