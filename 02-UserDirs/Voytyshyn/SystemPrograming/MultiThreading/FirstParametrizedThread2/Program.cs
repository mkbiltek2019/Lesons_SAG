using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FirstAsyncDelegate
{
    class Taks
    {
        private int sum;
        public int Sum
        {
            get
            {
                if (isCompleted)
                {
                    return sum;
                }
                else
                {
                    throw new Exception("Task is not completed");
                }
            }
        }

        private bool isCompleted;        

        public void DoWork(object count)
        {
            this.isCompleted = false;
            int intCount = (int)count;
            sum = 0;
            for (int i = 1; i <= intCount; ++i)
            {
                sum += i;
                Thread.Sleep(1);
            }
            this.isCompleted = true;
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            Taks task = new Taks();
            Thread t = new Thread(task.DoWork);
            t.Start(5000);
            while (t.IsAlive)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Sum: " + task.Sum);
        }
    }
}
