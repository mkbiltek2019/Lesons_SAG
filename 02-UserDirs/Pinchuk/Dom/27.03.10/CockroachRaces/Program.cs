using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CockroachRaces
{
    public delegate void StartMarathonHandler(object sender);
    public delegate void StopMarathonHandler(object sender);
    class Program
    {
        static void Main(string[] args)
        {
            Cockroach cockroach = new Cockroach(1,2);
            cockroach.CockroachList
            //Marathon marathon = new Marathon();
           // marathon.Draw();
           // PrintConsole.PrintRacetrack();
        }
    }
}
