using System;

namespace DecimalRoundingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal devidend = decimal.One;
            decimal devisor = 3;
            //нижеследующая строка выводит в консоль 1
            Console.WriteLine(Math.Round(devidend / devisor * devisor));
        }
    }
}
