using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RateConverter.Core;

namespace RateConverter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager.Instance.PutMessage("Application started");
            //ConvertTask task = new ConvertTask();
            //task.Execute("rates.txt");
            ExcelApp.Instance.CreateWorkbook();
            ExcelApp.Instance.FillHead();
            LogManager.Instance.PutMessage("Application ended");
        }
    }
}
