using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsynchronousOperationsWithIsCompleted
{
    public class AsyncMain
    {
        static void Main()
        {
            int threadId;

            AsyncDemo ad = new AsyncDemo();

            AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);

            IAsyncResult result = caller.BeginInvoke(3000,
                out threadId, null, null);

            while (result.IsCompleted == false)
            {
                Thread.Sleep(250);
                Console.Write(".");
            }

            string returnValue = caller.EndInvoke(out threadId, result);

            Console.WriteLine("\nThe call executed on thread {0}, with return value \"{1}\".",
                threadId, returnValue);

            Console.ReadKey(true);
        }
    }

    public class AsyncDemo
    {
        public string TestMethod(int callDuration, out int threadId)
        {
            Console.WriteLine("Test method begins.");
            Thread.Sleep(callDuration);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return String.Format("My call time was {0}.", callDuration.ToString());
        }
    }

    public delegate string AsyncMethodCaller(int callDuration, out int threadId);
}
