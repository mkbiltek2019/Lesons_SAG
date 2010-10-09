using System;
using System.Threading;

namespace StaticTypeSync
{
    class StaticTypeSyncClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Синхронизация статического типа:");

            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i] = new Thread(StaticLockCounter.UpdateFields);
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; ++i)
                threads[i].Join();

            Console.WriteLine("Field1: {0}, Field2: {1}\n\n", StaticLockCounter.Field1, StaticLockCounter.Field2);

        }
    }

    static class StaticLockCounter
    {
        static int field1;
        static int field2;

        public static int Field1
        {
            get { return field1; }
        }

        public static int Field2
        {
            get { return field2; }
        }

        public static void UpdateFields()
        {
            for (int i = 0; i < 1000000; ++i)
            {
                lock (typeof(StaticLockCounter))
                {
                    ++field1;
                    if (field1 % 2 == 0)
                        ++field2;
                }
            }
        }
    }

}
