using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FirstAsyncDelegate
{
    class Program
    {

        private delegate int TaskDelegate(int count);

        private static int Task(int count)
        {
            int s = 0;
            for (int i = 1; i <= count; ++i)
            {
                s += i;
                //Thread.Sleep(1);
            }
            return s;
        }

        private static void TaskCompleted(IAsyncResult ar)
        {
            Console.WriteLine("Thread is completed");
            Console.WriteLine("Summa: " + ar.AsyncState);
        }

        static void Main(string[] args)
        {
            TaskDelegate d = Task;

            IAsyncResult ar = d.BeginInvoke(10000, TaskCompleted, "My State Object");
            Thread.Sleep(10000);
            //while (!ar.IsCompleted)
            //{
            //    Console.Write(".");
            //    Thread.Sleep(1000);
            //}
            //Console.WriteLine();
            //Console.WriteLine("Summa: " + d.EndInvoke(ar));
        }
    }
}
