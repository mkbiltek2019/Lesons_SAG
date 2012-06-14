using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int Sp = 0;
            int Sk = 0;
            int SpSk = 0;
            int ostatok = 0;
            Console.Write("Введите размер стороны прямоугольника А:");
            string A = Console.ReadLine();
            int a = Convert.ToInt32(A);
            Console.Write("Введите размер стороны прямоугольника B:");
            string B = Console.ReadLine();
            int b = Convert.ToInt32(B);
            Console.Write("Введите размер стороны квадрата C:");
            string С = Console.ReadLine();
            int c = Convert.ToInt32(С);
            if (c > a | c > b)
            {
                Console.WriteLine("Error:Задача невыполнима. Сторона квадрата больше стороны прямоугольника!");
            }
            else
            {
                Sp = a * b;
                Sk = c * c;
                Console.WriteLine("Площадь прямоугольника равна = " + Sp);
                Console.WriteLine("Площадь квадрата равна = " + Sk);
                SpSk = Sp / Sk;
                Console.WriteLine("В прямоугольник можно вписать = " + SpSk + " квадрата");
                ostatok = Sp % Sk;
                Console.WriteLine("Площа которая осталась не заятой = 0." + ostatok);
            }
        }
    }
}
