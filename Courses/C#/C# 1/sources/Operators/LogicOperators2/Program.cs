using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicOperators2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            Console.WriteLine(2 > 7 && 5 != 8); //false второй операнд 
            //не  вычисляется, так как результатом в первом 
            //операнде уже является false           
            Console.WriteLine(2 != 4 && 2 != 5);// true
            Console.WriteLine(8 < 10 & 8 < 20);//true
            Console.WriteLine("my" == "my" || "my" != "hello");//true
            Console.WriteLine(false == true);//false 
            Console.WriteLine(2 > 7 && 2 / a != 5);
            /*нет ошибки!!! Второй операнд
                 не вычисляется, так как результатом в первом 
                операнде уже является false   
                Console.WriteLine(2>7 & 2/a!=5); 
            ошибка!!! Вычисляются оба 
                операнда, причем вычисление второго приводит к ошибке*/
        }
    }
}
