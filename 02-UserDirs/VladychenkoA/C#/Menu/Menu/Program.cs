using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Меню №1";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.Write("\n\n\n\n\n\t\t\tВведите Ваше имя: ");
            string name;
            name = Console.ReadLine();
            if (name == "")
                Console.WriteLine("\n\n\n\n\n\t\t\tЗдравствуй, мир!");
            else
                Console.WriteLine("\n\n\n\n\n\t\t\tЗдравствуйте, " + name + "!");
            Console.ReadKey();
            bool k = true;
            int choice;
            while (k)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t\tМеню.");
                Console.WriteLine("\n\t\t\t1.  Нарисовать елочку .");
                Console.WriteLine("\t\t\t2.  Прямоугольник.");
                Console.WriteLine("\t\t\t3.  Таблица умножения.");
                Console.WriteLine("\t\t\t4.  Проверка строки на симметричность.");
                Console.WriteLine("\t\t\t5.  Проверка целого числа на симметричность.");
                Console.WriteLine("\t\t\t6.  Сумма элементов массива.");
                Console.WriteLine("\t\t\t7.  Сумма элементов матрицы.");
                Console.WriteLine("\t\t\t8.  Движение прямоугольника по экрану.");
                Console.WriteLine("\t\t\t9.  Подсчет количества слов длинее <n> символов.");
                Console.WriteLine("\t\t\t10. Количество вхождений слова в предложение.");
                Console.WriteLine("\t\t\t11. Шифратор/дешифратор строк по алгоритму Цезаря.");
                Console.WriteLine("\t\t\t12. Переворот строки");
                Console.WriteLine("\t\t\t13. Вывод на экран трегольника Паскаля.");
                Console.WriteLine("\t\t\t14. Сортировка столбцов матрицы по их суммам.");
                Console.WriteLine("\t\t\t15. Сортировка символов в предложении по алфавиту.");
                Console.WriteLine("\t\t\t16. Выход.");
                Console.Write("\n\n\t\t\t Сделайте выбор: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Tree();
                        Console.ReadKey();
                        break;
                    case 2:
                        Rectangle();
                        Console.ReadKey();
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        CheckStringForSimetry();
                        break;
                    case 5:
                        CheckNumberForSimetry();
                        break;
                    case 6:
                        SumArray();
                        Console.ReadKey();
                        break;
                    case 7:
                        SumMatrix();
                        Console.ReadKey();
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        break;
                    case 12:
                        break;
                    case 13:
                        break;
                    case 14:
                        break;
                    case 15:
                        break;
                    case 16:
                        Console.WriteLine("\n\n\t\t\tВыход. . .");
                        Console.WriteLine("             ___                  ");
                        Console.WriteLine("             \\  \\               ");
                        Console.WriteLine("              \\  \\              ");
                        Console.WriteLine("               \\  \\            ");
                        Console.WriteLine("                \\  \\             ");
                        Console.WriteLine("                 \\__\\           ");
                        Console.WriteLine("                 /  /           ");
                        Console.WriteLine("                /  /           ");
                        Console.WriteLine("               /  /             ");
                        Console.WriteLine("              /  /              ");
                        Console.WriteLine("             /__/               ");
                        Console.WriteLine("                              ");
                        k = false;
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("\n\n\t\t\tНе правильно введен номер!(Введите от 1 до 16.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void Tree()
        {
            Console.Clear();
            int star = 1,  space;
            Console.Write("\n\n\t\t\tВведите высоту елочки(от 2 до 20):");
            space = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n\n\n\n\n");
            for (int i = 0; i < space; i++)
            {
                Console.Write("\t\t\t");
                for (int j = 0; j < space; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < star; k++)
                {
                    Console.Write("*");
                }
                Console.Write("\t\t");
                Console.WriteLine();
                space--;
                star += 2;
            }
        }
        static void Rectangle()
        {
            Console.Clear();
            int length, width;
            Console.Write("\n\n\t\t\tВведите длину прямоугольника:");
            length = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n\n\t\t\tВведите ширину прямоугольника:");
            width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n\n\n\n\n");
            for (int i = 0; i < width; i++)
            {
                Console.Write("\t\t");
                for (int j = 0; j < length; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        static void MultiplicationTable()
        {
            Console.Clear();
            Console.Write("Введите число до которого выводится таблица:");
            int number;
            number = Convert.ToInt32(Console.ReadLine());
            const string format = "│{0} * {1} = {2}│";
            const int k1 = 1;
            const int k2 = 2;
            int k3 = 3;
            int k4 = 4;
            int top = 1;
            int left = 0;
            int step = 1;
            int firstMarg = 20;
            int secondMarg = 40;
            int thirdMarg = 60;
            int one = 1;
            int four = 4;

            Console.CursorTop = top;

            //for (int i = one; i <= second; ++i)
            //{
            //    if (i == k1) { left = one; }
            //    if (i == k2) { left = firstMarg; }
            //    if (i == k3) { left = secondMarg; }
            //    if (i == k4) { left = thirdMarg; top += (second + one); }
            //    for (int j = one; j <= second; ++j)
            //    {
            //        Console SetCursorLeft(left);
            //        ConsoleWrapper.SetCursorTop(ConsoleWrapper.GetCursorTop() + step);
            //        ConsoleWrapper.Write(format, i, j, i * j);
            //    }
            //    ConsoleWrapper.SetCursorTop(top);

            //    if (i % four == 0)
            //    {
            //        ConsoleWrapper.SetCursorLeft(0);
            //        k1 += four;
            //        k2 += four;
            //        k3 += four;
            //        k4 += four;
            //    }
            //}
            //ConsoleWrapper.ReadKey();
        }
        static void SumArray()
        {
            int size = 10;
            Random randObj = new Random();
            int[] Arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Arr[i] = randObj.Next(1, 100);
            }
            int sum = 0;
            Console.Write(" \n\n\n\n\n\t\t\tВывод массива на экран:");
            Console.WriteLine();
            foreach (int item in Arr)
            {
                sum += item;
                Console.Write("\t" + item);
            }
            Console.Write("\n\n\t\t\tСумма = {0}", sum);
        }

        static void SumMatrix()
        {
            Console.Clear();
            int row, col;
            int sum = 0;
            Console.Write("\n\n\n\t\t\tВведите количество колонок: ");
            col = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n\n\n\t\t\tВедите количество рядков: ");
            row = Convert.ToInt32(Console.ReadLine());
            Random randObj = new Random();
            int[,] Arr = new int[col, row];
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    Arr[i, j] = randObj.Next(1, 100);
                }
            }
            Console.WriteLine("\n\n\n\n\t\t\tМатрица.");
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    Console.Write(Arr[i, j] + "\t");
                    sum += Arr[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n\t\t\tСумма = {0}", sum);
        }
        static void CheckStringForSimetry()
        {
            Console.Clear();
            Console.Write("\n\n\n\n\n\t\tВведите строку для проверки на симетрию: ");

            string startString = Console.ReadLine();
            char[] tmp = startString.ToCharArray();
            char[] res = tmp.Reverse().ToArray();
            string ss = new string(res);
            bool b = false;

            if (startString.Equals(ss))
            {
                b = true;
            }

            if (b)
            {
                Console.WriteLine("\n\n\t\tВведенная строка симетрична.");
            }
            else
            {
                Console.WriteLine("\n\n\t\tВведенная строка не симетрична.");
            }

            Console.ReadKey();
        }
        static void CheckNumberForSimetry()
        {
            Console.Clear();
            Console.Write("\n\n\n\n\n\t\tВведите число для проверки на симетрию: ");

            string startString = Console.ReadLine();
            char[] tmp = startString.ToCharArray();
            char[] res = tmp.Reverse().ToArray();
            string ss = new string(res);
            bool b = false;

            if (startString.Equals(ss))
            {
                b = true;
            }

            if (b)
            {
                Console.WriteLine("\n\n\t\tВведенное число симетрично.");
            }
            else
            {
                Console.WriteLine("\n\n\t\tВведенное число не симетрично.");
            }

            Console.ReadKey();
        }
    }
}
