using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Resurse
{
    public class StateObject
    {
        private object sync = new object();
        private int state = 5;
        public void ChangeState(int loop)
        {
            lock (sync)
            {
                if (state == 5)
                {
                    state++;
                    Trace.Assert(state == 6, "RCOA" + loop + "loops");
                }
            }
        }
    }
    class Program
    {
        private static void RaceCondition(object o)
        {
            StateObject stateObject = o as StateObject;
            int i = 0;
            while (true)
            {
                stateObject.ChangeState(i++);
            }
        }

        static void Main(string[] args)
        {
            StateObject state =new StateObject();
            for (int i = 0; i < 20; i++)
            {
                new Thread(RaceCondition).Start(state);
            }
        }
    }
}
