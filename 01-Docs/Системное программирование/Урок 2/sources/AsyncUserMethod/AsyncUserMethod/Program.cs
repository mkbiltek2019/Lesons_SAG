using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsyncUserMethod
{
    class AsyncUserMethodClass
    {
        private delegate UInt64 AsyncSumDel(UInt64 n);

        static void Main(string[] args)
        {
            AsyncSumDel del = Sum;
            del.BeginInvoke(1000000, EndSum, del);
            Console.ReadKey();
        }

        public static UInt64 Sum(UInt64 n)
        {
            UInt64 sum = 1;
            for (UInt64 i = 2; i < n; ++i)
                sum += i;
            return sum;
        }

        private static void EndSum(IAsyncResult ar)
        {
            AsyncSumDel del = (AsyncSumDel)ar.AsyncState;
            UInt64 res = del.EndInvoke(ar);

            Console.WriteLine("Сумма = " + res);
        }
    }
}
