using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsynchronousOperationsWithEndInvoke
{
    public class AsyncMain
    {
        public static void Main()
        {
            int threadId;

            AsyncDemo ad = new AsyncDemo();

            AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);

            IAsyncResult result = caller.BeginInvoke(3000,
                out threadId, null, null);

            Thread.Sleep(0);
            Console.WriteLine("Main thread {0} does some work.",
                Thread.CurrentThread.ManagedThreadId);

            string returnValue = caller.EndInvoke(out threadId, result);

            Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".",
                threadId, returnValue);

            Console.ReadKey(true);
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
}
