using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsertRates
{
    class Program
    {
        static void Main(string[] args)
        {
            Rates rates = new Rates();
            string date;
            Console.Write("Введите дату:");
            date = Console.ReadLine();
            rates.ReadFile(DateTime.Parse(date));
            rates.ArrayLiistRatesPrint(rates.ArrayListRates);
            Console.ReadKey();
            rates.SaveAll(rates.ArrayListRates);
        }
    }
}
