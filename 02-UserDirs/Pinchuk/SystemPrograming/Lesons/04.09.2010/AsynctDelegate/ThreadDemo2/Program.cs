using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadDemo2
{
    class Program
    {
        public class Task
        {
            private int sum;
            public int Summ { get { return sum; } }

            public void DoWork(object  Count)
            {
                int count = (int)Count;
                sum = 0;
                for (int i = 0; i < count; i++)
                {
                    sum += i;
                    Thread.Sleep(1);
                }
            }
        }
        

        static void Main(string[] args)
        {
            Task task =new Task();
            Thread thread = new Thread(task.DoWork);
            thread.Start(1000);
            thread.Join();
            Console.WriteLine("Summ ={0}",task.Summ);

        }
    }
}
