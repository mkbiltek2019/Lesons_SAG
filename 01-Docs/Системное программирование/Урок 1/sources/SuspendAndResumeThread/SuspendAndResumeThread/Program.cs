using System;
using System.Threading;

namespace SuspendAndResumeThread
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart ts = new ThreadStart(Method);
            Thread t = new Thread(ts);
            t.Start(); // Запуск потока.
            Console.WriteLine("Нажмите любую клавишу для остановки");
            Console.ReadKey();
            t.Suspend(); // Приостановка потока.
            Console.WriteLine("Поток остановлен!");
            Console.WriteLine("Нажмите любую клавишу для возобновления");
            Console.ReadKey();
            t.Resume(); // Возобновление работы.
        }

        static void Method()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
    }
}
