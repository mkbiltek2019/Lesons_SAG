using System;
using System.Threading;

namespace OneInstanceApp
{
    class OneInstanceAppClass
    {
        static Mutex m;

        static void Main(string[] args)
        {
            try
            {
                m = Mutex.OpenExisting("MY_MUTEX");
            }
            catch (WaitHandleCannotBeOpenedException e) { }

            if (m != null)
            {
                Console.WriteLine("Приложение уже запущено!");
                Console.ReadKey();
                return;
            }

            using (m = new Mutex(true, "MY_MUTEX"))
            {
                Console.WriteLine("Приложение работает.\nНажмите любую клавишу для закрытия приложения...");
                Console.ReadKey();
            }
        }
    }
}
