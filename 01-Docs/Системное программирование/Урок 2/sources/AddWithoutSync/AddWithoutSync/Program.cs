using System;
using System.Threading;

namespace AddWithoutSync
{
    class AddWithoutSyncClass
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[5];

            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i] = new Thread(delegate()
                {
                    for (int j = 1; j <= 1000000; ++j)
                        ++Counter.count;
                });
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; ++i)
                threads[i].Join();

            Console.WriteLine("counter = {0}", Counter.count);
        }
    }

    class Counter
    {
        public static int count;
    }
}
