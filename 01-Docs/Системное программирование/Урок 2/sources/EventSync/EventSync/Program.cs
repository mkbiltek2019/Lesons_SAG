using System;
using System.Threading;

namespace EventSync
{
    class EventSyncClass
    {
        static void Main(string[] args)
        {
            ManualEventTest();
            AutoEventTest();
        }

        private static void AutoEventTest()
        {
            Console.WriteLine("\nСобытие с авто сбросом:");
            AutoResetEvent are = new AutoResetEvent(true);

            for (int i = 0; i < 10; ++i)
                ThreadPool.QueueUserWorkItem(SomeEventMethod, are);

            Console.ReadKey();
        }

        private static void ManualEventTest()
        {
            Console.WriteLine("Событие с ручным сбросом:");
            ManualResetEvent mre = new ManualResetEvent(true);

            for (int i = 0; i < 10; ++i)
                ThreadPool.QueueUserWorkItem(SomeEventMethod, mre);

            Console.ReadKey();
        }

        static void SomeEventMethod(object obj)
        {
            EventWaitHandle ev = obj as EventWaitHandle;

            if (ev.WaitOne(10))
            {
                Console.WriteLine("Поток {0} успел проскочить", Thread.CurrentThread.ManagedThreadId);
                ev.Reset();
            }
            else
                Console.WriteLine("Поток {0} опоздал", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
