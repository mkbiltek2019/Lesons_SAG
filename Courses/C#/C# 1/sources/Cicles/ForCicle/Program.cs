using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForCicle
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string str = "кабак";
            //Сравниваем первую букву с последней, 
            //вторую с предпоследней и т.д
            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            {
                if (str[i] == str[j])
                    counter++;    //если буквы равны приращиваем счетчик                
            }
            //если счетчик равен длина_строки/2, 
            //то строка является палиндромом
            if (counter == str.Length / 2)
            {
                Console.WriteLine("Строка палиндром");
            }
            else
                Console.WriteLine("Строка не палиндром");
        }
    }
}
