using System;
using System.Threading;

namespace AbortThread
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart ts = new ThreadStart(Method);
            Thread t = new Thread(ts);
            t.Start();
            Console.WriteLine("Нажмите кнопку для завершения потока");
            Console.ReadKey();
            t.Abort(); // Принудительное завершение работы потока.
            Console.WriteLine("Нажмите кнопку для завершения потока");
            Console.ReadKey();
        }
        static void Method()
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(i.ToString());
                }
            }
            finally
            {
                // Попадаем сюда в любом случае.
                Console.WriteLine("End Thread Work");
            }
        }
    }
}
