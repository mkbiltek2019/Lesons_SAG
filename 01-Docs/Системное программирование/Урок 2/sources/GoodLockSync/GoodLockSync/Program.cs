using System;
using System.Threading;

namespace GoodLockSync
{
    class GoodLockSyncClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Синхронизация статического типа:");
            LockCounter lc = new LockCounter();
            Monitor.Enter(lc);
            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i] = new Thread(lc.UpdateFields);
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; ++i)
                threads[i].Join();

            Console.WriteLine("Count: {0}\n\n", lc.Count);
        }
    }

    class LockCounter
    {
        int count;
        object lockObj = new object();

        public int Count
        {
            get { return count; }
        }

        public void UpdateFields()
        {
            for (int i = 0; i < 1000000; ++i)
            {
                lock (lockObj)
                {
                    ++count;
                }
            }
        }
    }
}


