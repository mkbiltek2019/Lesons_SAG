using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            Functions1();
            Functions2();
            Functions3();
            Functions4();
        }

        static void Functions1()
        {
            string str = "Простая строка";
            char[] chrArr = new char[6];

            Console.WriteLine("Реверсирование строки с помощью индексатора");
            for (int i = str.Length - 1; i >= 0; --i)
                Console.Write(str[i]);

            Console.WriteLine("\nКопирование строки в массив символов");
            //Копируем шесть символов начиная с восьмой позиции и помещаем в 
            //массив
            str.CopyTo(8, chrArr, 0, 6);
            Console.WriteLine(chrArr);
        }

        static void Functions2()
        {
            string str1 = "Простая строка";
            string str2 = "Строка";
            string str3 = "строка";
            string[] strArr = { "ШАГ", "шагаем", "бежим", "ем", "Играем" };

            Console.WriteLine("\"" + str1 + "\" equal \"" + str2 + "\" : " +
                str1.Equals(str2));
            Console.WriteLine("\"" + str2 + "\" == \"Строка\" : " +
                (str2 == "Строка"));
            Console.WriteLine("\"" + str2 + "\".CompareTo(\"" + str3 +
                "\") : " + str2.CompareTo(str3));

            Console.WriteLine("Сравнение без учета регистра:");
            Console.WriteLine("\"" + str2 + "\" equal \"" + str3 + "\" : " +
                  str2.Equals(str3, StringComparison.CurrentCultureIgnoreCase));

            Console.Write("Слова начинающиеся на \"шаг\": ");
            foreach (string s in strArr)
                if (s.StartsWith("шаг", StringComparison.CurrentCultureIgnoreCase))
                    Console.Write(s + " ");
            Console.Write("\nСлова заканчивающиеся на \"ем\": ");
            foreach (string s in strArr)
                if (s.EndsWith("ем", StringComparison.CurrentCultureIgnoreCase))
                    Console.Write(s + " ");
            Console.WriteLine();
        }

        static void Functions3()
        {
            string str1 = "ПолиморфизмНаследованиеИнкапсуляция";
            string str2 = "АБВГДЕЖЗИКЛМН";

            Console.WriteLine("Первое вхождение символа \'Н\': " + 
                str1.IndexOf('Н'));
            Console.WriteLine("Первое вхождение подстроки \"Наследование\" : " 
                + str1.IndexOf('Н'));
            Console.WriteLine("Последнее вхождение символа \'И\': " + 
                str1.LastIndexOf('И'));
            Console.WriteLine("Последнее вхождение любого из символов строки "+ 
                 "АБВГДЕЖЗИКЛМН\" : " + 
                    str1.LastIndexOfAny(str2.ToCharArray()));
            Console.WriteLine("Подстрока начиная с 11 символа по 23-й : " +
                str1.Substring(11, 12));
        }


        static void Functions4()
        {
            string str1 = "Я ";
            string str2 = "учу ";
            string str3 = "C#";
            string str4 = str1 + str2 + str3;

            Console.WriteLine("{0} + {1} + {2} = {3}", str1, str2, str3, str4);

            str4 = str4.Replace("учу", "изучаю");
            Console.WriteLine(str4);

            str4 = str4.Insert(2, "упорно ").ToUpper();
            Console.WriteLine(str4);

            if (str4.Contains("упорно"))
                Console.WriteLine("Учу таки упорно :)");
            else
                Console.WriteLine("Учу как могу");

            str4 = str4.PadLeft(25, '*');
            str4 = str4.PadRight(32, '*');
            Console.WriteLine(str4);
            str4 = str4.TrimStart("*".ToCharArray());
            Console.WriteLine(str4);
            string[] strArr = str4.Split(" *".ToCharArray(),
            StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strArr)
                Console.WriteLine(str);
            str4 = str4.Remove(9);
            str4 += "учусь";
            Console.WriteLine(str4);
        }	

    }
}
