using System;
using System.Threading;

namespace StaticThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Шаг 1");
            Thread.Sleep(1000); // Остановка текущего потока на 1 сек.
            Console.WriteLine("Шаг 2");


            // Получаем объект текущего потока в программе.
            Thread thisThread = Thread.CurrentThread;

            // Выводим ID текущего потока в программе.
            Console.WriteLine(thisThread.GetHashCode().ToString());
        }
    }
}
