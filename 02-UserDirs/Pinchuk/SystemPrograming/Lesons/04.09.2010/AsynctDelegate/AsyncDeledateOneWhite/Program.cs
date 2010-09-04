using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsyncDeledateOneWhite
{
    class Program
    {
        public delegate int TaskDelegate(int count);
        public static int Summa(int count)
        {
            int s = 0;
            for (int i = 0; i < count; i++)
            {
                s += i;
                //Thread.Sleep(20);
            }
            return s;
        }

        static void Main(string[] args)
        {
            TaskDelegate taskDelegate = Summa;
            IAsyncResult asyncResult = taskDelegate.BeginInvoke(100, null, null);
            if (asyncResult.AsyncWaitHandle.WaitOne(20))
            {
                Console.WriteLine("Summa =" + taskDelegate.EndInvoke(asyncResult));
            }
            else
            {
                Console.WriteLine("Error timeout" );
            }
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
