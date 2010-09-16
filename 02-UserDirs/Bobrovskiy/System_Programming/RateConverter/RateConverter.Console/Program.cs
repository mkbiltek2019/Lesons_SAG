using System;
using RateConverter.Core;

namespace RateConverter.Console
{
    class Program
    {
        [MTAThread]
        static void Main(string[] args)
        {
            LogManager.Instance.PutMessage("Application started");

            ExcelApp.Instance.CreateWorkbook();
            ExcelApp.Instance.FillHead();

            ConvertTask task = new ConvertTask();          
            task.Execute("rates.txt");          
            task.Execute("rates1.txt");          
            task.Execute("rates2.txt");

            LogManager.Instance.PutMessage("Application ended");

            System.Console.ReadKey();
        }
    }
}
