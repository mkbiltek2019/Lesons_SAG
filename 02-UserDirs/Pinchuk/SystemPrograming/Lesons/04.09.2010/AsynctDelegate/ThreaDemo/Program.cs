using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreaDemo
{
    class Program
    {
        public static void Summa()
        {
            int count = 1000;
            int s = 0;
            for (int i = 0; i < count; i++)
            {
                s += i;
                //Thread.Sleep(20);
            }
        }

        static void Main(string[] args)
        {
           
            Thread thread = new Thread(Summa);
            thread.Start();
            thread.Join();

            //while (!asyncResult.IsCompleted)
            //{
            //    Console.Write(".");
            //    Thread.Sleep(10);
            //}
            //Console.WriteLine("Thead eneble");
            //Console.WriteLine("Summa" + taskDelegate.EndInvoke(asyncResult));
        }
    }
}
