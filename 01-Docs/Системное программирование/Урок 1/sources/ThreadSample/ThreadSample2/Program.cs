using System;
using System.Threading;
namespace ThreadSample2
{
    // В данном примере два потока для своей работы используют один метод.

    class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart threadstart = new ParameterizedThreadStart(ThreadFunk);
           
            // Запуск первого потока.
            Thread thread1 = new Thread(threadstart);
            thread1.Start((object)"One");

            // Запуск второго потока.
            Thread thread2 = new Thread(threadstart);
            thread2.Start((object)"\t\tTwo");
        }

        static void ThreadFunk(object a)
        {
            // Получаем String из прнятого object.
            string ID = (string)a;

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(ID);
            }
        }
    }
}
