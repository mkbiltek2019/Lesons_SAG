using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FirstAsyncDelegate
{
    class Taks
    {
        public Taks(int count)
        {
            this.Count = count;
        }

        private int sum;
        public int Sum
        {
            get
            {
                return sum;
            }
        }

        public int Count { get; set; }

        public void DoWork()
        {
            sum = 0;
            for (int i = 1; i <= Count; ++i)
            {
                sum += i;
                Thread.Sleep(1);
            }
        }       

    }

    class Program
    {

        static void Main(string[] args)
        {
            Taks task = new Taks(10000);
            Thread t = new Thread(task.DoWork);
            t.Start();
            while (t.IsAlive)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Sum: " + task.Sum);
        }
    }
}
