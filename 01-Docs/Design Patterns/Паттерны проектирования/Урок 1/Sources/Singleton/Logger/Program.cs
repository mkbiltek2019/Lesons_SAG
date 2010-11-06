using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Instance.PutMessage("Application Started");
            Logger.Instance.PutMessage("Hello from logger!!!");
            Logger.Instance.PutMessage("Application Ended");
        }
    }
}
