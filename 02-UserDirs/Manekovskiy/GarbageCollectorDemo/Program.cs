using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarbageCollectorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCount = 100000000;
            GCVictim[] gcVictim = new GCVictim[maxCount];
            //for (int i = 0; i < maxCount; i++)
            //{
            //    gcVictim[i] = new GCVictim();
            //}

            using (GCVictim victim = new GCVictim())
            {
                
            }

            Console.ReadKey();
            GC.Collect();
            Console.ReadKey();
        }
    }

    public class Point 
    {
        public int X
        {
            get;set;
        }
        public int Y
        {
            get;set;
        }
    }

    public class GCVictim : IDisposable
    {
        private Point start = new Point();
        private Point end = new Point();

        ~GCVictim()
        {
            Console.WriteLine("In destructor");
        }

        #region IDisposable Members

        public void Dispose()
        {
            Console.WriteLine("In Dispose");
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}