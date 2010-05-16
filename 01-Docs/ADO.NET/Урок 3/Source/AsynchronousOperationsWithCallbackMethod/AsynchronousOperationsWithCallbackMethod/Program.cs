using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace AsynchronousOperationsWithCallbackMethod
{
    public class AsyncMain
    {
        static void Main()
        {
            AsyncDemo ad = new AsyncDemo();

            AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);

            int dummy = 0;

            IAsyncResult result = caller.BeginInvoke(3000,
                out dummy,
                new AsyncCallback(CallbackMethod),
                "The call executed on thread {0}, with return value \"{1}\".");

            Console.WriteLine("The main thread {0} continues to execute...",
                Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(4000);

            Console.WriteLine("The main thread ends.");

            Console.ReadKey(true);
        }

        static void CallbackMethod(IAsyncResult ar)
        {
            AsyncResult result = (AsyncResult)ar;
            AsyncMethodCaller caller = (AsyncMethodCaller)result.AsyncDelegate;

            string formatString = (string)ar.AsyncState;

            int threadId = 0;

            string returnValue = caller.EndInvoke(out threadId, ar);

            Console.WriteLine(formatString, threadId, returnValue);
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
