using System;
using System.Threading;

namespace LockSync
{
    class LockSyncClass
    {
        static void Main(string[] args)
        {
            BadAsync();

            GoodAsync();
        }

        private static void GoodAsync()
        {
            Console.WriteLine("Синхронизация Блокировкой:");
            MonitorLockCounter c = new MonitorLockCounter();

            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i] = new Thread(c.UpdateFields);
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; ++i)
                threads[i].Join();

            Console.WriteLine("Field1: {0}, Field2: {1}\n\n", c.Field1, c.Field2);
        }

        private static void BadAsync()
        {
            Console.WriteLine("Синхронизация Interlocked-методами:");
            InterlockedCounter c = new InterlockedCounter();

            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i] = new Thread(c.UpdateFields);
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; ++i)
                threads[i].Join();

            Console.WriteLine("Field1: {0}, Field2: {1}\n\n", c.Field1, c.Field2);
        }
    }

    class InterlockedCounter
    {
        int field1;
        int field2;

        public int Field1
        {
            get { return field1; }
        }

        public int Field2
        {
            get { return field2; }
        }

        public void UpdateFields()
        {
            for (int i = 0; i < 1000000; ++i)
            {
                Interlocked.Increment(ref field1);
                if (field1 % 2 == 0)
                    Interlocked.Increment(ref field2);
            }
        }
    }

    class MonitorLockCounter
    {
        int field1;
        int field2;

        public int Field1
        {
            get { return field1; }
        }

        public int Field2
        {
            get { return field2; }
        }

        public void UpdateFields()
        {
            for (int i = 0; i < 1000000; ++i)
            {
                Monitor.Enter(this);
                try
                {
                    ++field1;
                    if (field1 % 2 == 0)
                        ++field2;
                }
                finally
                {
                    Monitor.Exit(this);
                }
            }
        }
    }
}
