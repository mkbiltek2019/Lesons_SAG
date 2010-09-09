using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FirstAsyncDelegate
{
    class Program
    {        

        private static void Task()
        {
            int count = 10000;
            int s = 0;
            for (int i = 1; i <= count; ++i)
            {
                s += i;
                Thread.Sleep(1);
            }            
        }

        static void Main(string[] args)
        {            
            Thread t = new Thread(Task);
            t.Start();
            t.Join();
            //while (t.IsAlive)
            //{
            //    Console.Write(".");
            //    Thread.Sleep(1000);
            //}
            Console.WriteLine("Task is ended");
        }
    }
}
