using System;
using System.Threading;

namespace DeadLock
{
    class DeadLockClass
    {
        static void Main(string[] args)
        {
            DeadLockClass dlc = new DeadLockClass();

            Monitor.Enter(dlc);
            dlc = null;

            GC.Collect(0);
            GC.WaitForPendingFinalizers();


            Console.WriteLine("Эта строка не будет напечатана");
        }

        ~DeadLockClass()
        {
            lock (this)
            {
                Console.WriteLine("Запись лог-файла");
            }
        }
    }
}
