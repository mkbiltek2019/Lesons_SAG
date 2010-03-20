using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parametrs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Передача значимого и ссылочного типа по значению" +
                "без пересоздания ссылочной переменной");
            int i = 0;
            int[] myArr = { 0, 1, 2, 4 };
            Console.WriteLine("i = {0}", i);
            Console.WriteLine("MyArr[0] = {0}", myArr[0]);
            Console.WriteLine("Вызов MyFunction");
            MyFunctionByVal1(myArr, i);
            Console.WriteLine("i = {0}", i);
            Console.WriteLine("MyArr[0] = {0}", myArr[0]);


            Console.WriteLine("\n\nПередача значимого и ссылочного типа по значению" +
                "с пересозданием ссылочной переменной");
            i = 10;
            myArr = new int[]{ 1, 2, 3 };
            Console.WriteLine("Внутри метода Main до передачи в метод " +
                "MyFunction i = {0}", i);
            Console.Write("MyArr { ");
            foreach (int val in myArr)
                Console.Write(val + " ");
            Console.WriteLine("}");
            MyFunctionByVal2(i, myArr);
            Console.WriteLine("Внутри метода Main после передачи в метод " +
                "MyFunction i = {0}", i);
            Console.Write("MyArr { ");
            foreach (int val in myArr)
                Console.Write(val + " ");
            Console.WriteLine("}");


            Console.WriteLine("\n\nПередача значимого и ссылочного типа по ссылке");
            i = 10;
            myArr = new int[]{ 1, 2, 3 };
            Console.WriteLine("Внутри метода Main до передачи в метод " +
                "MyFunction i = {0}", i);
            Console.Write("MyArr { ");
            foreach (int val in myArr)
                Console.Write(val + " ");
            Console.WriteLine("}");
            MyFunctionByRef(ref i, ref myArr);
            Console.WriteLine("Внутри метода Main после передачи в метод " +
                "MyFunction i = {0}", i);
            Console.Write("MyArr { ");
            foreach (int val in myArr)
                Console.Write(val + " ");
            Console.WriteLine("}");

        }

        static void MyFunctionByVal1(int[] MyArr, int i)
        {
            MyArr[0] = 100;
            i = 100;
        }

        private static void MyFunctionByVal2(int i, int[] myArr)
        {
            Console.WriteLine("Внутри функции MyFunction до изменения i = "+ 
                "{0}", i); 
            Console.Write("MyArr { ");
            foreach (int val in myArr)
      	        Console.Write(val + " ");
            Console.WriteLine("}");
            i = 100;
            myArr = new int[] { 3, 2, 1 };
            Console.WriteLine("Внутри функции MyFunction после изменения i ="+ 
                "{0}", i); 
            Console.Write("MyArr { ");
            foreach (int val in myArr)
      	        Console.Write(val + " ");
            Console.WriteLine("}");
        }
        private static void MyFunctionByRef(ref int i, ref int[] myArr)
        {
            Console.WriteLine("Внутри функции MyFunction до изменения i = "+ 
                "{0}", i); 
            Console.Write("MyArr { ");
            foreach (int val in myArr)
      	        Console.Write(val + " ");
            Console.WriteLine("}");
            i = 100;
            myArr = new int[] { 3, 2, 1 };
            Console.WriteLine("Внутри функции MyFunction после изменения i ="+ 
                "{0}", i); 
            Console.Write("MyArr { ");
            foreach (int val in myArr)
      	        Console.Write(val + " ");
            Console.WriteLine("}");
        }

    }
}
