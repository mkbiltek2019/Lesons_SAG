using System;

namespace CharMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Описание действия метода:                 Результат:
            -----------------------------------------------------*/

            //определяет является ли символ управляющим
            Console.WriteLine(char.IsControl('\t'));    //true
            //определяет является ли символ цифрой
            Console.WriteLine(char.IsDigit('5'));       //true
            //определяет является ли символ бувенным
            Console.WriteLine(char.IsLetter('x'));      //true
            //определяет находится ли символ в 
            //нижнем регистре
            Console.WriteLine(char.IsLower('m'));       //true
            //определяет находится ли символ 
            //в верхнем регистре
            Console.WriteLine(char.IsUpper('P'));       //true
            //определяет является ли символ числом
            Console.WriteLine(char.IsNumber('2'));      //true
            //определяет является ли символ 
            //разделителем
            Console.WriteLine(char.IsSeparator('.'));   //false
            //определяет является ли символ 
            //специальным символом
            Console.WriteLine(char.IsSymbol('<'));      //true
            //определяет является ли символ пробелом
            Console.WriteLine(char.IsWhiteSpace(' '));  //true
            //переводит символ в нижний регистр
            Console.WriteLine(char.ToLower('T'));       //t
            //переводит символ в верхний регистр
            Console.WriteLine(char.ToUpper('t'));       //T
        }
    }
}
