using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//-----------------
/*0.     Выход из программы
1.       Нарисовать елочку (задается высота елки)
2.       Прямоугольник (задается ширина и высота прямоугольника в знакоместах)
3.       Таблица умножения (задается число до которого, начиная с единицы, столбиками
 * на экран выводится таблица умножения. Предусмотреть максимально оптимальный способ 
 * вывода таблиц на экран, т.е. чтобы одновременно было видно максимум таблиц)
4.       Проверка строки на симметричность (строка вводится с клавиатуры)
5.       Проверка целого числа на симметричность (число вводится с клавиатуры.
 * Предусмотреть обработку ситуации когда пользователь ввел не целое или не число)
6.       Сумма элементов массива (размер массива вводится вручную и заполняется он 
 * либо произвольными числами либо вручную)
7.       Сумма элементов матрицы (размеры матрицы вводятся вручную, элементы 
 * матрицы должны заполняться произвольными числами от 7 до 42)
8.       Движение прямоугольника по экрану (управление осуществляется
* стрелками или клавишами w,a,s,d) (размеры прямоугольника вводятся с клавиатуры)
9.       Подсчет количества слов длинее <n> символов (n вводится с клавиатуры. 
* Словами принято считать подстроки разделенные между собой пробелами)  
10.   Количество вхождений слова в предложение (слово и предложение вводятся с клавиатуры)
11.   Шифратор/дешифратор строк по алгоритму Цезаря 
* (http://ru.wikipedia.org/wiki/Шифр_Цезаря. Реализация должна позволять 
* ввести строку и вывести ее зашифрованый аналог и наоборот) 
12.   Переворот строки (abc -> cba)
13.   Вывод на экран трегольника Паскаля (задается степень полинома 
* для которой нужно расписать треугольник)
14.   Сортировка столбцов матрицы по их суммам (элементы столбцов 
* не трогаем, переставляем только сами столбцы)
15.   Сортировка символов в предложении по алфавиту (пробелы удаляются, 
* предложение вводится с клавиатуры)*/
//-----------------
namespace domashka_1
{
    public enum MenuChoice
    {
        one = 1, two = 2, three = 3, four = 4, five = 5, six = 6,
        seven = 7, eigth = 8, nine = 9, ten = 10, eleven = 11, twelve = 12,
        thirteen = 13, fourteen = 14, fifteen = 15, exit = 0
    };

    public static class SafeIntegerRead {
        public static int UserChoice()
        {
            ///---- safe integer input
            string inputString = ConsoleWrapper.ReadLine();
            int result = 0;
            int defaultValue = 16; // used to return normal value in case of some input error
            string errorMessage = "Bad input!!!!!!";
            try
            {
                result = int.Parse(inputString);
            }
            catch (ArgumentNullException e)
            {
                ConsoleWrapper.WriteLine(errorMessage);
                result = defaultValue;
            }
            catch (FormatException e)
            {
                ConsoleWrapper.WriteLine(errorMessage);
                result = defaultValue;
            }
            catch (OverflowException e)
            {
                ConsoleWrapper.WriteLine(errorMessage);
                result = defaultValue;
            }
            return result;
        }
    }

    public static class ConsoleWrapper
    {
        public enum Color
        {
            Black = 0, DarkBlue = 1, DarkGreen = 2,
            DarkCyan = 3, DarkRed = 4, DarkMagenta = 5,
            DarkYellow = 6, Gray = 7, DarkGray = 8,
            Blue = 9, Green = 10, Cyan = 11,
            Red = 12, Magenta = 13, Yellow = 14,
            White = 15,
        };

        private static int prevTop;
        private static int prevLeft;

        public static void SetCursorPosition(int left, int top)
        {
            prevTop = top;
            prevLeft = left;
            SetCursorTop(top);
            SetCursorLeft(left);
        }

        public static void SetCursorTop(int top)
        {
            System.Console.CursorTop = top;
        }

        public static void SetCursorLeft(int left)
        {
            System.Console.CursorLeft = left;
        }

        public static int GetCursorLeft() {
            return System.Console.CursorLeft;
        }

        public static int GetCursorTop()
        {
            return System.Console.CursorTop;
        }

        public static void RestoreCursorPosition()
        {
            System.Console.CursorLeft = prevLeft;
            System.Console.CursorTop = prevTop;
        }

        public static void RestoreCursorLeft()
        {
            System.Console.CursorLeft = prevLeft;
        }

        public static void RestoreCursorTop()
        {
            System.Console.CursorTop = prevTop;
        }

        public static void ClearConsole() {
            System.Console.Clear();
        }
        
        public static void WriteMenuLine(string formatedString, int value) {
            System.Console.WriteLine(formatedString, value);
        }

        public static void WriteMenuLine(string formatedString, int value1, int value2)
        {
            System.Console.WriteLine(formatedString, value1, value2);
        }

        public static void WriteMenuLine(string formatedString, string someText) {
            System.Console.WriteLine(formatedString, someText);
        }

        public static void WriteLine(string text)
        {
            System.Console.WriteLine(text);
        }
        
        public static void Write(string text)
        {
            System.Console.Write(text);
        }

        public static void Write(char ch)
        {
            System.Console.Write(ch);
        }

        public static void Write(string formatedString, int value1, int value2, int value3)
        {
            System.Console.Write(formatedString, value1, value2, value3);
        }

        public static void Write(int value)
        {
            System.Console.Write("{0}",value);
        }

        public static void ReadKey() {
            System.Console.ReadKey();
        }

        public static ConsoleKeyInfo ReadKey(bool value)
        {
           return System.Console.ReadKey(value);
        }

        public static string ReadLine() {
            return System.Console.ReadLine();
        }

        public static void SetColor(ConsoleWrapper.Color color)
        {
            SetTextColor(color);
            SetBackgroundColor(color);
        }

        public static void SetTextColor(ConsoleWrapper.Color color)
        {
            System.Console.ForegroundColor = (ConsoleColor) color;
        }

        public static void SetBackgroundColor(ConsoleWrapper.Color color)
        {
            System.Console.BackgroundColor = (ConsoleColor) color;
        }
    }

    class FlagDraw
    {
       private bool exit = true;       
       private enum FlagSize { min = 21, max = 41 };
       private enum FlagFont { font = 1, picture = 0 }
       private int flagSide;
       private int[,] flag = new int[(int)FlagSize.max, (int)FlagSize.max];

       private void Menu()
        {
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.WriteLine("┌────────────────────────────────┐");
            ConsoleWrapper.WriteMenuLine("│Ввести сторону прапора <{0}>      │", (int)MenuChoice.one);
            ConsoleWrapper.WriteMenuLine("│Намалювати прапорa     <{0}>      │", (int)MenuChoice.two);
            ConsoleWrapper.WriteMenuLine("│Вихiд                  <{0}>      │", (int)MenuChoice.exit);
            ConsoleWrapper.WriteLine("└────────────────────────────────┘");
            ConsoleWrapper.Write("Оберiть пункт меню: ");
        }

       private void ExitApp()
        {
            ConsoleWrapper.Write("Good bye");
            ConsoleWrapper.ReadKey();
            exit = false;
        }

       private void InputFlagSide()
        {
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.WriteMenuLine("Введiть сторону прапора (вiд {0} до {1}): ", (int)FlagSize.min, (int)FlagSize.max);
            flagSide = SafeIntegerRead.UserChoice();

            if (flagSide < (int)FlagSize.min)
            {
                flagSide = (int)FlagSize.min;
            }
            if (flagSide > (int)FlagSize.max)
            {
                flagSide = (int)FlagSize.max;
            }
        }

       private void CreatFlag()
        {
            for (int i = 0; i < flagSide; ++i)
            {
                for (int j = 0; j < flagSide; ++j)
                {
                    flag[i, j] = 0;
                }
            }

            const int margKeoficient = 10;
            const int one = 1;
            const int two = 2;
            int marginTop = flagSide / margKeoficient - one;
            int marginBottom = flagSide - (flagSide / margKeoficient);

            for (int i = 0; i < flagSide; ++i)
            {
                for (int j = 0; j < flagSide; ++j)
                {
                    if ((i > marginTop) && (i < marginBottom) && (j > marginTop) && (j < marginBottom))
                    {
                        int margBot = (flagSide / two) - (flagSide / margKeoficient + one);
                        int margBot1 = (flagSide / two) + (flagSide / margKeoficient + one);
                        
                        if ((i < margBot) && (j < margBot))
                        {
                            flag[i, j] = (int)FlagFont.font;
                        }
                       
                        if ((i < margBot) && (j > margBot1))
                        {
                            flag[i, j] = (int)FlagFont.font;
                        }
                        
                        if ((i > margBot1) && (j < margBot))
                        {
                            flag[i, j] = (int)FlagFont.font;
                        }
                        
                        if ((i > margBot1) && (j > margBot1))
                        {
                            flag[i, j] = (int)FlagFont.font;
                        }

                    }
                    else
                    {
                        flag[i, j] = (int)FlagFont.font;
                    }
                }
            }
        }

       private void DrawFlag()
       {
           ConsoleWrapper.ClearConsole();
           for (int i = 0; i < flagSide; ++i)
           {
               for (int j = 0; j < flagSide; ++j)
               {
                   if (flag[i, j] == (int)FlagFont.font)
                   {
                       ConsoleWrapper.SetColor(ConsoleWrapper.Color.Red);
                       ConsoleWrapper.Write("o");
                       ConsoleWrapper.SetTextColor(ConsoleWrapper.Color.DarkBlue);
                       ConsoleWrapper.SetBackgroundColor(ConsoleWrapper.Color.Gray);                    
                   }
                   if (flag[i, j] == (int)FlagFont.picture)
                   {
                       ConsoleWrapper.SetColor(ConsoleWrapper.Color.White);
                       ConsoleWrapper.Write("+");
                       ConsoleWrapper.SetTextColor(ConsoleWrapper.Color.DarkBlue);
                       ConsoleWrapper.SetBackgroundColor(ConsoleWrapper.Color.Gray);
                   }
               }
               ConsoleWrapper.Write("\n");
           }
           ConsoleWrapper.ReadKey();
       }

       #region Flag class executor
       private void SetChoice()
        {
            switch (SafeIntegerRead.UserChoice())
            {
                case (int)MenuChoice.exit:
                    {
                        ExitApp();
                    } break;               
                case (int)MenuChoice.one:
                    {
                        InputFlagSide();
                        CreatFlag();
                    } break;                
                case (int)MenuChoice.two:
                    {
                        DrawFlag();
                    } break;              
                default:
                    {
                       ConsoleWrapper.WriteLine("Hmm..");
                    } break;
            }
        }

       private void MainApplication()
        {
            while (exit)
            {
                Menu();
                SetChoice();
            }
        }

       public void Run()
       {
           MainApplication();
       }
       #endregion
    }

    class SimpleHome
    {
        private bool exit = true;
        private string userName;

        private void UserNameHello()
        {
            ConsoleWrapper.SetTextColor(ConsoleWrapper.Color.DarkBlue);
            ConsoleWrapper.SetBackgroundColor(ConsoleWrapper.Color.Gray);
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.WriteLine("┌──────────────────────────────────────────────────────────┐");
            ConsoleWrapper.Write("│Введiть iмя користувача: ");
            userName = ConsoleWrapper.ReadLine();
            ConsoleWrapper.WriteLine("│                                                          │");
            ConsoleWrapper.WriteMenuLine("│Радi вас знову бачити користувачу {0}", userName);
            ConsoleWrapper.WriteLine("└──────────────────────────────────────────────────────────┘");
            ConsoleWrapper.ReadKey();            
        }

        private void Menu()
        {
            ConsoleWrapper.SetTextColor(ConsoleWrapper.Color.DarkBlue);
            ConsoleWrapper.SetBackgroundColor(ConsoleWrapper.Color.Gray);
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.WriteLine("┌──────────────────────────────────────┐");
            ConsoleWrapper.WriteMenuLine("│Намалювати ялинку             <{0}>     │", (int)MenuChoice.one);
            ConsoleWrapper.WriteMenuLine("│Намалювати прямокутник        <{0}>     │", (int)MenuChoice.two);
            ConsoleWrapper.WriteMenuLine("│Намалювати табличку множення  <{0}>     │", (int)MenuChoice.three);
            ConsoleWrapper.WriteMenuLine("│Перевiрка стрiчки на симетрiю <{0}>     │", (int)MenuChoice.four);
            ConsoleWrapper.WriteMenuLine("│Перевiрка числа на симетрiю   <{0}>     │", (int)MenuChoice.five);
            ConsoleWrapper.WriteMenuLine("│Сума елементiв масиву         <{0}>     │", (int)MenuChoice.six);
            ConsoleWrapper.WriteMenuLine("│Сума елементiв матрицi        <{0}>     │", (int)MenuChoice.seven);
            ConsoleWrapper.WriteMenuLine("│Рух прямокутника по екрану    <{0}>     │", (int)MenuChoice.eigth);
            ConsoleWrapper.WriteMenuLine("│Пiдрахунок кiлькостi слiв     <{0}>     │", (int)MenuChoice.nine);
            ConsoleWrapper.WriteMenuLine("│Входження слова в реченнi    <{0}>     │", (int)MenuChoice.ten);
            ConsoleWrapper.WriteMenuLine("│Кодування/декодування        <{0}>     │", (int)MenuChoice.eleven);
            ConsoleWrapper.WriteMenuLine("│Перевернення стрiчки         <{0}>     │", (int)MenuChoice.twelve);
            ConsoleWrapper.WriteMenuLine("│Трикутник Паскаля            <{0}>     │", (int)MenuChoice.thirteen);
            ConsoleWrapper.WriteMenuLine("│Сортування стовпцiв матрицi  <{0}>     │", (int)MenuChoice.fourteen);
            ConsoleWrapper.WriteMenuLine("│Сортування символiв          <{0}>     │", (int)MenuChoice.fifteen);
            ConsoleWrapper.WriteMenuLine("│Вихiд                         <{0}>     │", (int)MenuChoice.exit);
            ConsoleWrapper.WriteLine("└──────────────────────────────────────┘");
            ConsoleWrapper.Write("  Оберiть пункт меню: ");
        }

        private void DrawTree()
        {
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.Write(" Введiть висоту ялинки: ");
            int treeHeight = SafeIntegerRead.UserChoice();
            const int treeLevel = 3; //can't be changed
            const int two = 2; //can't be changed
            const int three = 3; //can't be changed
            ConsoleWrapper.ClearConsole();

            for (int k = 0; k < three; ++k)
            {
                int lowheight = treeHeight / three + two * k;
                int lowWidth = lowheight * two + two * k;

                for (int i = 0; i < lowheight; ++i)
                {
                    for (int j = 0; j < lowWidth; ++j)
                    {
                        if (k == 0 && j == 0)
                        {
                            for (int t = 0; t < two * treeLevel; ++t)
                                ConsoleWrapper.Write(" ");
                        }
                        if (k == 1 && j == 0)
                        {
                            for (int t = 0; t < two * (treeLevel) - three; ++t)
                                ConsoleWrapper.Write(" ");
                        }
                        if ((j >= (lowWidth / two - i)) && (j <= (lowWidth / two + i)))
                        {
                            ConsoleWrapper.SetColor(ConsoleWrapper.Color.DarkGreen);
                            ConsoleWrapper.Write("▲");
                            ConsoleWrapper.SetTextColor(ConsoleWrapper.Color.DarkBlue);
                            ConsoleWrapper.SetBackgroundColor(ConsoleWrapper.Color.Gray);
                        }
                        else
                        {
                            ConsoleWrapper.Write(" ");
                        }
                    }
                    ConsoleWrapper.Write("\n");
                }
            }
            ConsoleWrapper.ReadKey();
        }

        private void DrawFlag()
        {
            FlagDraw myFlag = new FlagDraw();
            myFlag.Run();
        }

        private void DrawMultiplyTable()
        {
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.Write("Введiть максимальне число до якого виводити таблицю: ");
            int second = SafeIntegerRead.UserChoice();

            string format = "│{0} * {1} = {2}│";
            int k1 = 1;
            int k2 = 2;
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

            ConsoleWrapper.SetCursorPosition(left, step);

            for (int i = one; i <= second; ++i)
            {
                if (i == k1) { left = one; }
                if (i == k2) { left = firstMarg; }
                if (i == k3) { left = secondMarg; }
                if (i == k4) { left = thirdMarg; top += (second + one); }
                for (int j = one; j <= second; ++j)
                {
                    ConsoleWrapper.SetCursorLeft(left);                    
                    ConsoleWrapper.SetCursorTop(ConsoleWrapper.GetCursorTop() + step);
                    ConsoleWrapper.Write(format, i, j, i * j);
                }
                ConsoleWrapper.SetCursorTop(top);                

                if (i % four == 0)
                {
                    ConsoleWrapper.SetCursorLeft(0); 
                    k1 += four;
                    k2 += four;
                    k3 += four;
                    k4 += four;
                }
            }
            ConsoleWrapper.ReadKey();
        }

        private void CheckStringForSimetry(int n)
        {
            ConsoleWrapper.ClearConsole(); 

            if (n == 0)
                ConsoleWrapper.Write("Введiть стрiчку для перевiрки на симетрiю: ");
            else
                ConsoleWrapper.Write("Введiть число для перевiрки на симетрiю: ");

            string startString = ConsoleWrapper.ReadLine();
            char[] tmp = startString.ToCharArray();
            char[] res = tmp.Reverse().ToArray();
            string ss = new string(res);
            bool b = false;

            if (startString.Equals(ss) == true)
            {
                b = true;
            }

            if (b)
            {
                ConsoleWrapper.WriteLine("Введена стрiчка симетрична.");
            }
            else
            {
                ConsoleWrapper.WriteLine("Введена стрiчка не симетрична.");
            }

            ConsoleWrapper.ReadKey();
        }

        private void SumOfArrayElements()
        {
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.Write("Введiть кiлькiсть елементiв мaсиву( 1 - 15): ");
            int numOfElem = SafeIntegerRead.UserChoice();
            ConsoleWrapper.Write("Для ручного введення масиву введiть 0 (або iнше число): ");
            int option = SafeIntegerRead.UserChoice();

            if (option == 0)
            {
                int sum = 0;
                for (int i = 0; i < numOfElem; ++i)
                {
                    string s1 = ConsoleWrapper.ReadLine();
                    int number = int.Parse(s1);
                    sum += number;
                }
                ConsoleWrapper.WriteMenuLine("Сума елементiв введеного масиву: {0}", sum);
            }
            else
            {
                int[] array = new int[numOfElem];
                Random rand = new Random();
                int sum = 0;
                for (int i = 0; i < numOfElem; ++i)
                {
                    array[i] = rand.Next(20);
                    ConsoleWrapper.Write(array[i]); 
                    ConsoleWrapper.Write('\t');
                    sum += array[i];
                }
                ConsoleWrapper.Write('\n');
                ConsoleWrapper.WriteMenuLine("Сума елементiв введеного масиву: {0}", sum);
            }
            ConsoleWrapper.ReadKey();
        }

        private void SumOfMatrixElements()
        {
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.WriteLine("Сума елементів матриці. ");
            ConsoleWrapper.Write("Введiть кiлькiсть рядкiв (1-15): ");
            int rows = SafeIntegerRead.UserChoice();
            ConsoleWrapper.Write("Введiть кiлькiсть стовпців(1-15): ");
            int cols = SafeIntegerRead.UserChoice();
            ConsoleWrapper.Write("Для ручного введення матрицi введiть 0 (або iнше число): ");
            int option = SafeIntegerRead.UserChoice();
            
            if (option == 0)
            {
                int sum = 0;
                for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < cols; ++j)
                    {
                        string s3 = ConsoleWrapper.ReadLine();
                        int number = int.Parse(s3);
                        sum += number;
                    }
                }
                ConsoleWrapper.WriteMenuLine("Сума елементiв матрицi: {0}", sum);
            }
            else
            {
                int[,] array = new int[rows, cols];
                Random rand = new Random();
                int sum = 0;
                for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < cols; ++j)
                    {
                        array[i, j] = rand.Next(7, 42);
                        sum += array[i, j];
                        ConsoleWrapper.Write(array[i, j]);
                        ConsoleWrapper.Write('\t');
                    }
                    ConsoleWrapper.Write('\n');
                }
                ConsoleWrapper.WriteMenuLine("Сума елементiв матрицi: {0}", sum);
            }
            ConsoleWrapper.ReadKey();
        }

        private void RectangleMoovment()
        {
            ConsoleWrapper.ClearConsole();
            ConsoleKeyInfo cki;
            ConsoleWrapper.Write("Введiть сторону прямокутника: ");
            int side = SafeIntegerRead.UserChoice();
            ConsoleWrapper.ClearConsole();
            string st = string.Empty;
            ConsoleWrapper.Write("Для виходу натиснiть (ESC) керування (W,S,A,D) ");
            const int startPosTop = 40;
            const int startPosLeft = 40;
            const int maxTop = 90;
            const int maxLeft = 72;
            const int one = 1;

            ConsoleWrapper.SetCursorTop(startPosTop);
            ConsoleWrapper.SetCursorLeft(startPosLeft);
            ConsoleWrapper.SetColor(ConsoleWrapper.Color.DarkRed);     
                       
            for (int i = 0; i < side; ++i)
            {
                for (int j = 0; j < side; ++j)
                {
                    ConsoleWrapper.Write("♦");
                }
                ConsoleWrapper.SetCursorTop(ConsoleWrapper.GetCursorTop()-1);
                ConsoleWrapper.SetCursorLeft(startPosLeft);              
            }           
            ConsoleWrapper.SetBackgroundColor(ConsoleWrapper.Color.Gray);
            ConsoleWrapper.SetTextColor(ConsoleWrapper.Color.DarkBlue);
          
            do
            {
                cki = ConsoleWrapper.ReadKey(true);
                st = cki.Key.ToString();

                int prevLeft1 = ConsoleWrapper.GetCursorLeft(); 
                int prevTop1 = ConsoleWrapper.GetCursorTop();

                ConsoleWrapper.SetBackgroundColor(ConsoleWrapper.Color.Gray);
                ConsoleWrapper.SetTextColor(ConsoleWrapper.Color.Gray);
                for (int i = 0; i < side; ++i)
                {
                    for (int j = 0; j < side; ++j)
                    {
                        ConsoleWrapper.Write("♦");
                    }                   
                    ConsoleWrapper.SetCursorTop(ConsoleWrapper.GetCursorTop() - 1);
                    ConsoleWrapper.SetCursorLeft(prevLeft1);  
                }
                ConsoleWrapper.SetCursorTop(prevTop1);
              
                switch (st)
                {
                    case "W":
                        {
                            if (ConsoleWrapper.GetCursorTop() > side)
                                ConsoleWrapper.SetCursorTop(ConsoleWrapper.GetCursorTop() - 1);
                        } break;
                    case "S":
                        {
                            if (ConsoleWrapper.GetCursorTop() < (maxTop - side))
                                ConsoleWrapper.SetCursorTop(ConsoleWrapper.GetCursorTop() + 1);
                        } break;
                    case "A":
                        {
                            if (ConsoleWrapper.GetCursorLeft() > side)
                                ConsoleWrapper.SetCursorLeft(ConsoleWrapper.GetCursorLeft() - 1);
                        } break;
                    case "D":
                        {
                            if (ConsoleWrapper.GetCursorLeft() < (maxLeft - side))
                                ConsoleWrapper.SetCursorLeft(ConsoleWrapper.GetCursorLeft() + 1);
                        } break;
                }

                int prevLeft = ConsoleWrapper.GetCursorLeft();
                int prevTop = ConsoleWrapper.GetCursorTop();

                ConsoleWrapper.SetBackgroundColor(ConsoleWrapper.Color.DarkRed);
                ConsoleWrapper.SetTextColor(ConsoleWrapper.Color.DarkRed);
                for (int i = 0; i < side; ++i)
                {
                    for (int j = 0; j < side; ++j)
                    {
                        ConsoleWrapper.Write("♦");
                    }
                    ConsoleWrapper.SetCursorTop(ConsoleWrapper.GetCursorTop() - 1);
                    ConsoleWrapper.SetCursorLeft(prevLeft);
                }
                ConsoleWrapper.SetCursorTop(prevTop);

                ConsoleWrapper.SetBackgroundColor(ConsoleWrapper.Color.Gray);
                ConsoleWrapper.SetTextColor(ConsoleWrapper.Color.Gray);
            } while (st != "Escape");
           
            ConsoleWrapper.ReadKey();
        }

        private void CalcNumberOfWordsLongerThen()
        {
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.Write("Введiть стрiчку: ");
            string st = ConsoleWrapper.ReadLine();
            ConsoleWrapper.Write("Введiть максимальну довжину слова: ");
            int max = int.Parse(ConsoleWrapper.ReadLine());
            string[] arr = st.Split(new Char[] { ' ', ',', '.', ':' });
            int count = 0;

            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i].Length > max)
                {
                    ++count;
                }
            }

            ConsoleWrapper.WriteMenuLine("Кiлькiсть слiв, що мають довжину бiльше {0} , становить {1}.", max, count);
            ConsoleWrapper.ReadKey();
        }

        private void CalcNumberOfWordRepeats()
        {
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.Write("Введiть стрiчку: ");
            string st = ConsoleWrapper.ReadLine();
            ConsoleWrapper.Write("Введiть словo: ");
            string curWord = ConsoleWrapper.ReadLine();
            string[] arr = st.Split(new Char[] { ' ', ',', '.', ':' });
            int count = 0;

            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i].Equals(curWord))
                {
                    ++count;
                }
            }

            ConsoleWrapper.WriteMenuLine("Кiлькiсть повторiв становить {0}.", count);
            ConsoleWrapper.ReadKey();
        }

        private void CeasarShifr()
        {
            // CeASAR algo for encrypting using ASCII table 
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.Write("Введiть стрiчку: ");
            string st = ConsoleWrapper.ReadLine();           
            char[] shifr = new char[st.Length];
            const int key = 3;
            const int maxASCII = 256;

            //--encrypt inputed string       
            for (int i = 0; i < st.Length; ++i)
            {
                int tmp = 0;
                tmp = ((int)st[i] + key);
                if (tmp >= maxASCII) tmp -= maxASCII;
                shifr[i] = (char)tmp;
            }
            
            string shifrStr = new string(shifr);
            ConsoleWrapper.WriteMenuLine("Закодована стрiчка: {0}", shifrStr);

            //--dencrypt inputed string             
            char[] deShifr = new char[shifrStr.Length];
            for (int i = 0; i < shifrStr.Length; ++i)
            {
                int tmp = 0;
                tmp = (shifrStr[i] - key);               
                if (tmp < 0) tmp += maxASCII;
                deShifr[i] = (char)tmp;
            }
            
            string deshifrStr = new string(deShifr);
            ConsoleWrapper.WriteMenuLine("Розкодована стрiчка: {0}", deshifrStr);            
            ConsoleWrapper.ReadKey();
        }

        private void StringReverse()
        {
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.Write("Введiть стрiчку: ");
            string s = ConsoleWrapper.ReadLine();
            char[] tmp = s.ToCharArray();
            char[] res = tmp.Reverse().ToArray();
            string reversedString = new string(res);
            ConsoleWrapper.WriteMenuLine("Оберненa стрiчка: {0}", reversedString);
            ConsoleWrapper.ReadKey();
        }

        private void ThePascalTriangleDraw()
        {
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.Write("Введiть степiнь полiнома: ");
            string s3 = ConsoleWrapper.ReadLine();
            int side = int.Parse(s3);
            int n = side;
            const int two = 2;
            const int four = 4;
            const int nine = 9;
            const int ninety = 99;

            for (int i = 0; i <= n; ++i)
            {
                for (int space = 0; space < four * (n - i) / two; space++)
                {
                    System.Console.Write(' ');
                }

                for (int j = 0; j <= i; ++j)
                {
                    int k;
                    int ifac = 1;
                    for (k = two; k <= i; ++k)
                    { // i!
                        ifac *= k;
                    }

                    int jfac = 1;
                    for (k = two; k <= j; ++k)
                    { // j!
                        jfac *= k;
                    }

                    int ijfac = 1;
                    for (k = two; k <= i - j; ++k)
                    {// (i-j)!
                        ijfac *= k;
                    }

                    int c = ifac / (jfac * ijfac);
                    if (c > ninety)
                    {
                        ConsoleWrapper.Write(' '); ConsoleWrapper.Write(c); ConsoleWrapper.Write(' ');
                    }
                    else if (c > nine)
                    {
                        ConsoleWrapper.Write(' '); ConsoleWrapper.Write(c); ConsoleWrapper.Write(' ');
                    }
                    else
                    {
                        ConsoleWrapper.Write(' '); ConsoleWrapper.Write(c); ConsoleWrapper.Write(' ');
                    }
                }
                ConsoleWrapper.Write('\n');
            }
            ConsoleWrapper.ReadKey();
        }

        private void SortMatrixCols()
        {
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.Write("Введiть кiлькiсть рядкiв: ");
            string numberOfRows = ConsoleWrapper.ReadLine();
            int rows = int.Parse(numberOfRows);
            ConsoleWrapper.Write("Введiть кiлькiсть стовпців: ");
            string numberOfColumns = ConsoleWrapper.ReadLine();
            int cols = int.Parse(numberOfColumns);
            ConsoleWrapper.Write("Для ручного введення матрицi введiть 0 (або iнше число): ");
            string punkt = ConsoleWrapper.ReadLine();
            int option = int.Parse(punkt);
            int[,] sortedArray = new int[rows, cols];

            if (option == 0)// hand array input
            {
                int[,] array = new int[rows, cols];

                for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < cols; ++j)
                    {
                        string s3 = ConsoleWrapper.ReadLine();
                        int number = int.Parse(s3);
                        array[i, j] = number;
                    }
                }

                int[] buf = new int[rows];
                //  sorting
                for (int j = 0; j < cols; ++j)
                {
                    for (int i = 0; i < rows; ++i)
                    {
                        buf[i] = array[i, j];
                    }
                    Array.Sort(buf);
                    for (int i = 0; i < rows; ++i)
                    {
                        sortedArray[i, j] = buf[i];
                    }
                }
            }
            else // automatic array input
            {
                int[,] array = new int[rows, cols];
                Random rand = new Random();
                int sum = 0;
                // initialize array
                for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < cols; ++j)
                    {
                        array[i, j] = rand.Next(0, 50);
                        ConsoleWrapper.Write('\t'); ConsoleWrapper.Write(array[i, j]);
                    }
                    ConsoleWrapper.Write('\n');
                }
                ConsoleWrapper.Write('\n');
                int[] buffer = new int[rows];
                //  sorting
                for (int j = 0; j < cols; ++j)
                {
                    for (int i = 0; i < rows; ++i)
                    {
                        buffer[i] = array[i, j];
                    }
                    Array.Sort(buffer);
                    for (int i = 0; i < rows; ++i)
                    {
                        sortedArray[i, j] = buffer[i];
                    }

                }
            }

            ConsoleWrapper.WriteLine("Матриця сортована по стовпцях.");
            for (int i = 0; i < cols; ++i)
            {
                for (int j = 0; j < rows; ++j)
                {
                    ConsoleWrapper.Write('\t'); ConsoleWrapper.Write(sortedArray[i, j]);
                }
                ConsoleWrapper.Write("\n");
            }
            ConsoleWrapper.ReadKey();
        }

        private void SortSimbolsInString()
        {
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.Write("Введiть стрiчку: ");
            string s = ConsoleWrapper.ReadLine();
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == ' ')
                    s.Remove(i, 1);
            }

            char[] tmp = s.ToCharArray();
            Array.Sort(tmp);
            string sortedString = new string(tmp);
            ConsoleWrapper.WriteMenuLine("Сортована стрiчка: {0}", sortedString);
            ConsoleWrapper.ReadKey();
        }
       
        #region  SimpleHome class executor
        private  void ExitApp()
        {
            ConsoleWrapper.WriteLine("Good bye");
            ConsoleWrapper.ReadKey();
            exit = false;
        }

        private void SetChoice()
        {
            switch ((MenuChoice)SafeIntegerRead.UserChoice())
            {
                case MenuChoice.exit:
                    {
                        ExitApp();
                    } break;
                case MenuChoice.one:
                    {
                        DrawTree();
                    } break;
                case MenuChoice.two:
                    {
                        DrawFlag();
                    } break;
                case MenuChoice.three:
                    {
                        DrawMultiplyTable();
                    } break;
                case MenuChoice.four:
                    {
                        int param = 0;
                        CheckStringForSimetry(param);
                    } break;
                case MenuChoice.five:
                    {
                        int param = 1;
                        CheckStringForSimetry(param);
                    } break;
                case MenuChoice.six:
                    {
                        SumOfArrayElements();
                    } break;
                case MenuChoice.seven:
                    {
                        SumOfMatrixElements();
                    } break;

                case MenuChoice.eigth:
                    {
                        RectangleMoovment();
                    } break;
                case MenuChoice.nine:
                    {
                        CalcNumberOfWordsLongerThen();
                    } break;
                case MenuChoice.ten:
                    {
                        CalcNumberOfWordRepeats();
                    } break;
                case MenuChoice.eleven:
                    {
                       CeasarShifr();
                    } break;
                case MenuChoice.twelve:
                    {
                        StringReverse();
                    } break;
                case MenuChoice.thirteen:
                    {
                        ThePascalTriangleDraw();
                    } break;
                case MenuChoice.fourteen:
                    {
                        SortMatrixCols();
                    } break;
                case MenuChoice.fifteen:
                    {
                        SortSimbolsInString();
                    } break;
                default:
                    {
                       ConsoleWrapper.WriteLine("Hmm..");
                    } break;
            }
        }

        private void MainApplication()
        {
            UserNameHello();
            while (exit)
            {
                Menu();
                SetChoice();
            }
        }
        
        public void Run()
        {
            MainApplication();
        }
        #endregion
    } 
    
    class Program
    {
        static void Main(string[] args)
        {
            SimpleHome mySimple = new SimpleHome();
            mySimple.Run();
        }
    }
}
