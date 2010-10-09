using System;
using System.Threading;

namespace BackgroundThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart ts = new ThreadStart(Method);
            Thread t = new Thread(ts);

            // Делаем поток фоновым.
            t.IsBackground = true; //попробовать заменить на false

            t.Start();

            Console.WriteLine("Нажмите любую клавишу для завершения работы приложения");
            Console.ReadKey();
        }

        static void Method()
        {
            for (int i = 10; i >= 0; i--)
            {
                Thread.Sleep(1000);
                Console.Write(i.ToString() + " ");
            }
            Console.WriteLine("Фоновый поток завершил свою работу");
        }
    }
}
