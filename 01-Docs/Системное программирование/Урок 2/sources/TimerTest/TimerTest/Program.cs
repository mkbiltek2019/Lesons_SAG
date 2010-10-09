using System;
using System.Threading;

namespace TimerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer(TimerMethod, null, 0, 1000);

            Console.WriteLine("Основной поток {0} продолжается...", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            t.Dispose();
        }

        static void TimerMethod(Object obj)
        {
            Console.WriteLine("Поток {0} : {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
        }
    }
}
