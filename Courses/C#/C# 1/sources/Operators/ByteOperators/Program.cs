using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ByteOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 1;
            int result = a >> b;//деление на 2 в степени второго 
            //операнда, в данном случае в степени 1, то есть просто на 2
            Console.WriteLine(result); // 10/2=5
            result = a << b;// умножение 2 в степени второго 
            //операнда, в данном случае в степени 1, то есть просто на 2
            Console.WriteLine(result); //10*2=20
            result = a | 5;
            Console.WriteLine(result); //15
            result = a & 3;
            Console.WriteLine(result);//2
            result = a ^ 6;
            Console.WriteLine(result);//12
        }
    }
}
