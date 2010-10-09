using System;
using System.Threading;
namespace ThreadSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание делегата, связанного с методом.
            ThreadStart threadstart = new ThreadStart(Method);

            // Создание объекта потока.
            Thread thread = new Thread(threadstart);
            thread.Start(); // Запуск работы потока.

            // Работа основного потока.
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Hello in main");
            }
        }

        //Метод в котором будет выполнятся поток.
        static void Method()
        {
            // Работа вторичного потока.
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("\t\t\tHello in thread");
            }
        }
    }
}
