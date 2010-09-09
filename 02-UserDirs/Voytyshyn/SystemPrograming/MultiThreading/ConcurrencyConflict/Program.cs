using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace ConcurrencyConflict
{

    public class StateObject
    {
        private int state = 5;

        private object sync = new object();

        public void ChangeState(int loop)
        {
            lock (sync)
            {
                if (state == 5)
                {
                    state++;
                    Trace.Assert(state == 6, "Race condition occurred after " + loop + " loops");
                }
                state = 5;
            }
        }
    }

    class Program
    {
        private static void RaceCondition(object o)
        {
            StateObject state = o as StateObject;
            int i = 0;
            while (true)
            {
                state.ChangeState(i++);
            }
        }

        static void Main(string[] args)
        {
            StateObject state = new StateObject();
            for (int i = 0; i < 20; i++)
            {
                new Thread(RaceCondition).Start(state);
            }
        }
    }
}
