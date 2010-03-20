using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringAndArray
{
    class myClass
    {
        int select = 0, dySelection;

        ConsoleKeyInfo keyPres;

        string[] menu = new string[]{"0.  Выход из программы",            
                                    "1.  Нарисовать елочку ",
                                    "2.  Нарисовать прямоугольник ",
                                    "3.  Таблица умножения ",
                                    "4.  Проверка строки на симметричность ",
                                    "5.  Проверка целого числа на симметричность ",
                                    "6.  Сумма элементов массива ",
                                    "7.  Сумма элементов матрицы ",
                                    "8.  Движение прямоугольника по экрану ",
                                    "9.  Подсчет количества слов длинее <n> символов ",
                                    "10. Количество вхождений слова в предложение ",
                                    "11. Шифратор/дешифратор строк по алгоритму Цезаря ",
                                    "12. Переворот строки (abc -> cba)",
                                    "13. Вывод на экран трегольника Паскаля ",
                                    "14. Сортировка столбцов матрицы по их суммам ",
                                    "15. Сортировка символов в предложении по алфавиту "};
        public void Reset()
        {
            Console.ResetColor();
            Console.WriteLine("Для продолжения нажмете клавишу...");
            Console.ReadKey();
            Console.Clear();
            Console.WindowHeight = 25;
            Console.WindowWidth = 80;

        }
        public int ShowMenu()
        {
            do
            {
                for (int i = 0; i < menu.Length; ++i)
                {
                    if (i == select)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.WriteLine(menu[i]);
                    Console.ResetColor();

                }
                keyPres = Console.ReadKey(false);
                switch (keyPres.Key)
                {
                    case ConsoleKey.DownArrow:
                        dySelection = +1;
                        break;
                    case ConsoleKey.UpArrow:
                        dySelection = -1;
                        break;

                    default:
                        dySelection = 0;
                        break;
                }
                Console.Clear();
                select += dySelection;
                if (select < 0)
                    select = 15;
                if (select > 15)
                    select = 0;
            } while (keyPres.Key != ConsoleKey.Enter);

            return select;
        }
        public void DrawSpruce()
        {
            int heightSpruce;
            Console.Clear();
            Console.Write("Введите висоту елки:");
            heightSpruce = int.Parse(Console.ReadLine());
            if (heightSpruce >= Console.WindowHeight)
                Console.WindowHeight = heightSpruce + 3;
            if (heightSpruce * 2 - 1 >= Console.WindowWidth)
                Console.WindowWidth = heightSpruce * 2 + 1;

            for (int i = 1; i <= heightSpruce; i++)
            {
                for (int j = 0; j < heightSpruce - i; j++)
                {
                    Console.Write(" ");

                }

                for (int k = 1; k <= i * 2 - 1; k++)
                {
                    // Console.slepp
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("*");
                }
                Console.WriteLine("");

            }
            Reset();
        }
        public void DrawRectangle()
        {
            string rect = ("█");/*191*/
            int widthRect = 0;
            int heightRect = 0;
            Console.Write("Введите висоту прямоугольника:");
            heightRect = int.Parse(Console.ReadLine());
            Console.Write("Введите ширину прямоугольника:");
            widthRect = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < heightRect; i++)
            {

                for (int j = 0; j < widthRect; j++)
                {

                    Console.Write(rect);
                }
                Console.WriteLine();
            }
            Reset();
        }
        public void DrawMultiplicationtable()
        {
            int count;

            do
            {
                Console.Write("Введите число до которого нужно вивести таблицу(0-9):");
                count = int.Parse(Console.ReadLine());
                Console.Clear();
            } while ((count < 1) || (count > 10));

            for (int i = 1; i <= count; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    if (i * j > 9)
                    {
                        Console.Write("{0}*{1}={2}  ", j, i, i * j);
                    }
                    else
                    {
                        Console.Write("{0}*{1}={2}   ", j, i, i * j);
                    }
                }
                Console.WriteLine();
            }
            Reset();
        }
        public void TestString()
        {
            String str;
            bool strPalindrom = true;
            Console.Write("Ведите строку:");
            str = Console.ReadLine();
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - 1 - i])
                {
                    strPalindrom = false;
                }
            }
            if (strPalindrom)
                Console.WriteLine("Строка  єсть палиндромом!");
            else
                Console.WriteLine("Строка не  палиндром!");

            Reset();
        }
        public void TesrInteger()
        {
            int number = 0, count = 0, tmpL = 0, tmpR;
            bool intPalindrom = true;
            Console.Write("Введите чисо:");
            number = int.Parse(Console.ReadLine());
            tmpL = number;
            while (tmpL != 0)
            {
                count++;
                tmpL = tmpL / 10;
            }
            tmpL = number;
            tmpR = number;
            for (int i = 0; i < count / 2; i++)
            {
                tmpL = tmpL / (int)Math.Pow(10.0, (double)(count - 1 - i));
                if (tmpL != tmpR % 10)
                    intPalindrom = false;
                tmpR = tmpR / 10;
            }
            if (intPalindrom)
                Console.WriteLine("Строка  єсть палиндромом!");
            else
                Console.WriteLine("Строка не  палиндром!");
            Console.WriteLine("Count = {0}", count);
            Reset();
        }
        public void SumArray()
        {
            int menu = 0, sizeArray = 0;
            Random rand = new Random();
            Console.WriteLine("1. Сгенерировать. \n2. Вручну.");
            Console.Write("Вибор:");
            menu = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.Write("Введите размер масива:");
            sizeArray = int.Parse(Console.ReadLine());
            int[] arr = new int[sizeArray];
            Console.Clear();
            switch (menu)
            {
                case 1:
                    for (int i = 0; i < sizeArray; i++)
                    {
                        arr[i] = rand.Next(7, 42);

                    }
                    break;
                case 2:
                    for (int i = 0; i < sizeArray; i++)
                    {
                        Console.Write("Ведите {0}-й елемент масиву = ", i);
                        arr[i] = int.Parse(Console.ReadLine());

                    }
                    break;
                default:
                    break;
            }
            Console.Clear();
            for (int i = 0; i < sizeArray; i++)
            {
                Console.WriteLine("arr[{0}]={1}", i, arr[i]);

            }
            Console.WriteLine("Сума елементов масива S={0}", arr.Sum());
            Reset();
        }
        public void SumMatrix()
        {
            int menu = 0, sizeArrWidth = 0, sizeArrHeight = 0, SumMatrix = 0;
            Random rand = new Random();
            Console.WriteLine("1. Сгенерировать. \n2. Вручну.");
            Console.Write("Вибор:");
            menu = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.Write("Введите ширину масива:");
            sizeArrWidth = int.Parse(Console.ReadLine());
            Console.Write("Введите висоту масива:");
            sizeArrHeight = int.Parse(Console.ReadLine());
            int[,] arr = new int[sizeArrHeight, sizeArrWidth];
            Console.Clear();
            for (int i = 0; i < sizeArrHeight; i++)
            {
                for (int j = 0; j < sizeArrWidth; j++)
                {
                    if (1 == menu)
                    {
                        arr[i, j] = rand.Next(7, 42);
                    }
                    if (2 == menu)
                    {
                        Console.Write("Ведите [{0},{1}]-й елемент масиву = ", i, j);
                        arr[i, j] = int.Parse(Console.ReadLine());
                    }

                }

            }
            for (int i = 0; i < sizeArrHeight; i++)
            {
                for (int j = 0; j < sizeArrWidth; j++)
                {
                    Console.Write("   {0}", arr[i, j]);
                    SumMatrix += arr[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine("Сума елементов матрици S={0}", SumMatrix);
            Reset();

        }
        public void MoveRect()
        {
            ConsoleKeyInfo moveKey;
            string rect = ("█");/*191*/
            int witdhRect = 0, heightRect = 0, spaceRow = 0, spaceCol = 0, dx = 0, dy = 0;
            Console.Write("Введите висоту прямоугольника:");
            heightRect = int.Parse(Console.ReadLine());
            Console.Write("Введите ширину прямоугольника:");
            witdhRect = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            do
            {
                for (int row = 0; row < spaceRow; row++)
                {
                    Console.WriteLine();
                }
                for (int i = 0; i < heightRect; i++)
                {

                    for (int col = 0; col < spaceCol; col++)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 0; j < witdhRect; j++)
                    {

                        Console.Write(rect);
                    }
                    Console.WriteLine();
                }
                moveKey = Console.ReadKey(false);
                switch (moveKey.Key)
                {

                    case ConsoleKey.DownArrow:
                        dy = 1;
                        dx = 0;
                        break;
                    case ConsoleKey.LeftArrow:
                        dx = -1;
                        dy = 0;
                        break;
                    case ConsoleKey.RightArrow:
                        dx = 1;
                        dy = 0;
                        break;
                    case ConsoleKey.UpArrow:
                        dy = -1;
                        dx = 0;
                        break;
                    default:
                        dy = dx = 0;
                        break;

                }
                spaceCol += dx;
                spaceRow += dy;
                Console.Clear();
            } while (moveKey.Key != ConsoleKey.Escape);

        }
        public void CountNumberStr()
        {
            string str = string.Empty;
            int count = 0, lengthStr = 0;
            Console.Write("Введите строку:");
            str = Console.ReadLine();
            Console.Write("Введите длину слова:");
            lengthStr = int.Parse(Console.ReadLine());
            string[] split = str.Split(new Char[] { ' ' });
            foreach (var item in split)
            {
                Console.WriteLine("Подстроки:{0}", item);
                if (item.Length > lengthStr)
                    count++;
            }
            Console.WriteLine("К-во слоа длинее {0} равно: {1}", lengthStr, count);
            Reset();
        }
        public void CountWord()
        {
            string str = string.Empty;
            string word = string.Empty;
            int count = 0;
            Console.Write("Введите строку:");
            str = Console.ReadLine();
            Console.Write("Введите слово:");
            word = Console.ReadLine();
            string[] split = str.Split(new Char[] { ' ' });
            foreach (var item in split)
            {
                Console.WriteLine("Подстроки:{0}", item);
                if (item.Contains(word))
                    count++;

            }
            Console.WriteLine("К-во вхождений слоа длинее  равно: {0}", count);
        }
        public void Encryption()
        {
            int menu;
            string str = string.Empty;
            Console.WriteLine("1. Шифровать. \n2. Дешифровать.");
            Console.Write("Вибор:");
            menu = int.Parse(Console.ReadLine());
            Console.Write("Введите строку:");
            str = Console.ReadLine();
            Console.Write((char)(122));
            //Console.Clear();
            switch (menu)
            {
                case 1:                    
                    Console.Write("Шифрованя строка: ");
                    for (int i = 0; i < str.Length; i++)
                    {
                        Console.Write( (char)(((char)(str[i])) + 3));
                    }                    
                    break;
                case 2:
                    Console.Write("Дешифрованя строка: " );
                    for (int i = 0; i < str.Length; i++)
                    {
                        Console.Write((char)((int)str[i] - 3));
                    }
                    
                    break;
                default:
                    break;
            }
            Console.WriteLine();
            Reset();

        }
        public void RotateString()
        {
            string str = string.Empty;
            string tmp = string.Empty;
            Console.Write("Введите строку:");
            str = Console.ReadLine();
            Console.Write("Перевернута строка: ");
            for (int i = str.Length-1; i >=0 ; i--)
            {
                Console.Write(str[i]);
            }
            Console.WriteLine();
            Reset();
        }
        public void TrianglePascal()
        {
            int heightTriangle;
            Console.Clear();
            Console.Write("Введите висоту треугольника:");
            heightTriangle = int.Parse(Console.ReadLine());
            if (heightTriangle >= Console.WindowHeight)
                Console.WindowHeight = heightTriangle + 3;
            if (heightTriangle * 2 - 1 >= Console.WindowWidth)
                Console.WindowWidth = heightTriangle * 2 + 1;
            int[,] arr = new int[heightTriangle, heightTriangle*2-1];       

            for (int i = 0; i < heightTriangle; i++)
            {                
                for (int j = heightTriangle-1 - i; j <=(heightTriangle-1 -i+ 2*i); j+=2)
                {
                    if (j > heightTriangle - 1 - i && j < (heightTriangle - 1 - i + 2 * i  ))
                        arr[i, j] = arr[i-1, j-1] + arr[i-1, j+1];
                    else
                        arr[i, j] = 1;
                }
            }
            for (int i = 0; i < heightTriangle; i++)
            {
                for (int j = 0; j < heightTriangle*2-1; j++)
                {
                    if (arr[i, j]==0)
                        Console.Write(" ");
                    else
                    Console.Write(arr[i, j]);
                    
                }
                Console.WriteLine();
            }
            Reset();
 
        }
        public void SortSum()
        {
            Random rand=new Random();
            int menu = 0, sizeArrWidth = 0, sizeArrHeight = 0, SumMatrix = 0;
            Console.Write("Введите ширину матрици:");
            sizeArrWidth = int.Parse(Console.ReadLine());
            Console.Write("Введите висоту матрици:");
            sizeArrHeight = int.Parse(Console.ReadLine());
            int[,] arr = new int[sizeArrHeight, sizeArrWidth];
            int[,] res = new int[sizeArrHeight, sizeArrWidth];
            Console.Clear();
            for (int i = 0; i < sizeArrHeight; i++)
            {
                for (int j = 0; j < sizeArrWidth; j++)
                {
                    arr[i, j] = rand.Next(1, 10);

                }
                
            }
            int[] sum = new int[sizeArrWidth];
            for (int i = 0; i < sizeArrHeight; i++)
            {
                for (int j = 0; j < sizeArrWidth; j++)
                {
                    Console.Write(arr[i, j]+" ");

                }
                Console.WriteLine();
            }
            for (int i = 0; i < sizeArrWidth; i++)
            {
                for (int j = 0; j < sizeArrHeight; j++)
                {
                    sum [i]+=arr[j, i];

                }
                Console.WriteLine();
            }
            for (int i = 0; i < sum.Length; i++)
            {
                Console.Write(sum[i]+"  ");
            }
            Console.WriteLine();
            Array.Sort(sum);

            for (int i = 0; i < sum.Length; i++)
            {
                Console.Write(sum[i] + "  ");
            }
            for (int i = 0; i < sizeArrHeight; i++)
            {
                for (int j = 0; j < sizeArrWidth; j++)
                {
                    for (int k = 0; k < sizeArrHeight; k++)
                    {
                        if(k!=i)
                            res[i, j] = sum[j] - arr[j, k];
                    }
                    

                }

            }
            Reset();
                
            
        }
    }
}
