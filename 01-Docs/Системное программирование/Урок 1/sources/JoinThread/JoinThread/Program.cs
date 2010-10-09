using System;
using System.Threading;

namespace JoinThread
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart TS = new ThreadStart(Method);
            Thread T = new Thread(TS);
            Console.WriteLine("Сейчас будет запущен поток");
            T.Start();
            Thread.Sleep(200);
            Console.WriteLine("Ожидание завершения работы потока");
            T.Join();
            Console.WriteLine("Завершение работы программы");

            Console.ReadKey();

        }
        static void Method()
        {
            Console.WriteLine("Поток работает");
            Thread.Sleep(2000);
            Console.WriteLine("Поток завершил работу");
        }
    }
}
