using System;

namespace DecimalSample
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal devidend = decimal.One;
            //нижеследующая строка выводит в консоль 1
            Console.WriteLine(devidend);
            decimal devisor = 3;
            devidend = devidend / devisor;
            //нижеследующая строка выводит в консоль 0,3333333333333333333333333333
            Console.WriteLine(devidend);            
            //нижеследующая строка выводит в консоль 0,9999999999999999999999999999
            //из чего можно сделать вывод, что ошибки округления привели к потере данных
            Console.WriteLine(devidend * devisor);
            double doubleDevidend = 1;
            //нижеследующая строка выводит в консоль 1
            Console.WriteLine(doubleDevidend);
            double doubleDevisor = 3;
            doubleDevidend = doubleDevidend / doubleDevisor;
            //нижеследующая строка выводит в консоль 0,33333333333333
            Console.WriteLine(doubleDevidend);
            //нижеследующая строка выводит в консоль 1
            Console.WriteLine(doubleDevidend * doubleDevisor);
        }
    }
}
