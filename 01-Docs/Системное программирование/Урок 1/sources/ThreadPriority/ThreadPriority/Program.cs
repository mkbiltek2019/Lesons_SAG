using System;
using System.Threading;

namespace ThreadPriority1
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart ts = new ParameterizedThreadStart(Method);
            Thread t1 = new Thread(ts);
            Thread t2 = new Thread(ts);

            // Назначение приоритета потоку
            t1.Priority = ThreadPriority.Highest;
            t2.Priority = ThreadPriority.Lowest;

            t2.Start((object)"\t\t\t2");
            t1.Start((object)"t1");

            Console.ReadKey();
        }
        static void Method(object str)
        {
            string text = (string)str;
            for (int i = 0; i < 2000; i++)
            {
                Console.WriteLine("{0} #{1}", text, i.ToString());
            }
        }
    }
}
