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
    //------
    class flagDraw
    {
        bool exit = true;
        enum menuChoice { one = 1, two = 2, exit = 0 };
        enum flagSize { min = 21, max = 41 };
        enum flagfont { font = 1, picture = 0 }
        int flagSide;
        int[,] flag = new int[41, 41];
        //---
        void menu()
        {
            System.Console.Clear();
            System.Console.WriteLine("┌────────────────────────────────┐");
            System.Console.WriteLine("│Ввести сторону прапора <{0}>      │", (int)menuChoice.one);
            System.Console.WriteLine("│Намалювати прапорa     <{0}>      │", (int)menuChoice.two);
            System.Console.WriteLine("│Вихiд                  <{0}>      │", (int)menuChoice.exit);
            System.Console.WriteLine("└────────────────────────────────┘");
            System.Console.Write("Оберiть пункт меню:: ");
        }     
        int userChoice()
        {
            ///---- get user input and check it
            string s = " ";
            s = System.Console.ReadLine();
            int res = 0;
            try
            {
                res = int.Parse(s);
            }
            catch (ArgumentNullException e)
            {
                System.Console.WriteLine("Bad input!!!!!!");
                res = 1;
            }
            catch (FormatException e)
            {
                System.Console.WriteLine("Bad input!!!!!!");
                res = 1;
            }
            catch (OverflowException e)
            {
                System.Console.WriteLine("Bad input!!!!!!");
                res = 1;
            }
            //finally {                
            //    //System.Console.Clear();
            //    //System.Console.ReadKey();
            //}
            return res;
        }
     
        void exitApp()
        {
            System.Console.WriteLine("Good bye");
            System.Console.ReadKey();
            exit = false;
        }       
        void inputFlagSide()
        {
            System.Console.Clear();
            System.Console.Write("Введiть сторону прапора (вiд {0} до {1}): ", (int)flagSize.min, (int)flagSize.max);
            flagSide = userChoice();
            if (flagSide < (int)flagSize.min)
            {
                flagSide = (int)flagSize.min;
            }
            if (flagSide > (int)flagSize.max)
            {
                flagSide = (int)flagSize.max;
            }
        }        
        void creatFlag()
        {
            for (int i = 0; i < flagSide; ++i)
            {
                for (int j = 0; j < flagSide; ++j)
                    flag[i, j] = 0;
            }
            int marginTop = flagSide / 10 - 1;
            int marginBottom = flagSide - (flagSide / 10);
            for (int i = 0; i < flagSide; ++i)
            {
                for (int j = 0; j < flagSide; ++j)
                {
                    if ((i > marginTop) && (i < marginBottom) && (j > marginTop) && (j < marginBottom))
                    {
                        int margBot = (flagSide / 2) - (flagSide / 10 + 1);
                        int margBot1 = (flagSide / 2) + (flagSide / 10 + 1);
                        //------
                        if ((i < margBot) && (j < margBot))
                        {
                            flag[i, j] = (int)flagfont.font;
                        }
                        //------
                        if ((i < margBot) && (j > margBot1))
                        {
                            flag[i, j] = (int)flagfont.font;
                        }
                        //------
                        if ((i > margBot1) && (j < margBot))
                        {
                            flag[i, j] = (int)flagfont.font;
                        }
                        //------
                        if ((i > margBot1) && (j > margBot1))
                        {
                            flag[i, j] = (int)flagfont.font;
                        }

                    }
                    else
                    {
                        flag[i, j] = (int)flagfont.font;
                    }
                }
            }
        }       
        void drawFlag()
        {
            System.Console.Clear();
            for (int i = 0; i < flagSide; ++i)
            {
                for (int j = 0; j < flagSide; ++j)
                {
                    if (flag[i, j] == (int)flagfont.font)
                    {
                        System.Console.ForegroundColor = System.ConsoleColor.Red;
                        System.Console.BackgroundColor = System.ConsoleColor.Red;
                        System.Console.Write("o");
                        System.Console.ResetColor();
                        System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
                        System.Console.BackgroundColor = System.ConsoleColor.Gray;
                    }
                    if (flag[i, j] == (int)flagfont.picture)
                    {
                        System.Console.ForegroundColor = System.ConsoleColor.White;
                        System.Console.BackgroundColor = System.ConsoleColor.White;
                        System.Console.Write("+");
                        System.Console.ResetColor();
                        System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
                        System.Console.BackgroundColor = System.ConsoleColor.Gray;
                    }
                }
                System.Console.Write("\n");
            }
            System.Console.ReadKey();
        }      
        void setChoice()
        {
            switch (userChoice())
            {
                case (int)menuChoice.exit:
                    {
                        exitApp();
                    } break;
                //---
                case (int)menuChoice.one:
                    {
                        inputFlagSide();
                        creatFlag();
                    } break;
                //---
                case (int)menuChoice.two:
                    {
                        drawFlag();
                    } break;
                //---
                default:
                    {
                        System.Console.WriteLine("Hmm..");
                    } break;
            }
        }     
        void mainApplication()
        {
            while (exit)
            {
                menu();
                setChoice();
            }
        }       
        public void run()
        {
            mainApplication();
        }
    }
    //------
    class simpleHome
    {
        bool exit = true;
        enum menuChoice { one = 1, two = 2, three = 3, four = 4, five = 5, six = 6, 
            seven = 7, eigth =8, nine =9,  ten =10, eleven = 11, twelve =12, 
            thirteen = 13, fourteen =14, fifteen =15, exit = 0 };
        string userName;
        //---
        void userNameHello() {
            System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
            System.Console.BackgroundColor = System.ConsoleColor.Gray;
            System.Console.Clear();
            System.Console.WriteLine("┌──────────────────────────────────────────────────────────┐");
                System.Console.Write("│Введiть iмя користувача: ");
            userName = System.Console.ReadLine();
            System.Console.WriteLine("│                                                          │");
            System.Console.WriteLine("│Радi вас знову бачити користувачу {0}", userName);
            System.Console.WriteLine("└──────────────────────────────────────────────────────────┘");
            System.Console.ReadKey();
            System.Console.ResetColor();
        }
        //---
        void menu()
        {
            System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
            System.Console.BackgroundColor = System.ConsoleColor.Gray;
            System.Console.Clear();
            System.Console.WriteLine("┌──────────────────────────────────────┐");
            System.Console.WriteLine("│Намалювати ялинку             <{0}>     │", (int)menuChoice.one);
            System.Console.WriteLine("│Намалювати прямокутник        <{0}>     │", (int)menuChoice.two);
            System.Console.WriteLine("│Намалювати табличку множення  <{0}>     │", (int)menuChoice.three);
            System.Console.WriteLine("│Перевiрка стрiчки на симетрiю <{0}>     │", (int)menuChoice.four);
            System.Console.WriteLine("│Перевiрка числа на симетрiю   <{0}>     │", (int)menuChoice.five);
            System.Console.WriteLine("│Сума елементiв масиву         <{0}>     │", (int)menuChoice.six);
            System.Console.WriteLine("│Сума елементiв матрицi        <{0}>     │", (int)menuChoice.seven);
            System.Console.WriteLine("│Рух прямокутника по екрану    <{0}>     │", (int)menuChoice.eigth);
            System.Console.WriteLine("│Пiдрахунок кiлькостi слiв     <{0}>     │", (int)menuChoice.nine);
            System.Console.WriteLine("│Входження слова в реченнi    <{0}>     │", (int)menuChoice.ten);
            System.Console.WriteLine("│Кодування/декодування        <{0}>     │", (int)menuChoice.eleven);
            System.Console.WriteLine("│Перевернення стрiчки         <{0}>     │", (int)menuChoice.twelve);
            System.Console.WriteLine("│Трикутник Паскаля            <{0}>     │", (int)menuChoice.thirteen);
            System.Console.WriteLine("│Сортування стовпцiв матрицi  <{0}>     │", (int)menuChoice.fourteen);
            System.Console.WriteLine("│Сортування символiв          <{0}>     │", (int)menuChoice.fifteen);
            System.Console.WriteLine("│Вихiд                         <{0}>     │", (int)menuChoice.exit);
            System.Console.WriteLine("└──────────────────────────────────────┘");
            System.Console.Write("  Оберiть пункт меню: ");           
        }
        //---
        void drawTree() {
            System.Console.Clear();
            System.Console.Write(" Введiть висоту ялинки: ");  
             string s = System.Console.ReadLine();
             int treeHeight = int.Parse(s);
             int treeLevel = 3;
             //--------
             System.Console.Clear();
             for (int k = 0; k < 3; ++k ){                 

                 int lowheight = treeHeight / 3 + 2*k;
                    int lowWidth = lowheight*2 + 2*k;
                 
                 for (int i = 0; i < lowheight; ++i)
                 {
                     for (int j = 0; j < lowWidth; ++j)
                     {
                         if (k == 0&& j==0) {
                             for (int t = 0; t < 2 * treeLevel; ++t)
                             System.Console.Write(" ");
                         }
                         if (k == 1 && j == 0)
                         {
                             for (int t = 0; t < 2 * (treeLevel)-3; ++t)
                                System.Console.Write(" ");   
                         }
                        

                         if ((j >= (lowWidth / 2 - i)) && (j <= (lowWidth / 2 + i)))
                         {
                             System.Console.ForegroundColor = System.ConsoleColor.Green;
                             System.Console.BackgroundColor = System.ConsoleColor.Green;
                             System.Console.Write("▲");
                             System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
                             System.Console.BackgroundColor = System.ConsoleColor.Gray;
                         }
                         else
                         {
                             System.Console.Write(" ");
                         }
                     }
                     System.Console.Write("\n");
                 }

            }
             //--------      
             System.Console.ReadKey();
        }
        //---
        void drawFlag() {
            flagDraw myFlag = new flagDraw();
            myFlag.run();
        }
        //---
        void drawMultiplyTable() {
            System.Console.Clear();
            System.Console.Write("Введiть максимальне число до якого виводити таблицю: ");
            string s = System.Console.ReadLine();
            int second = 0;
            try
            {
                second = int.Parse(s);
            }
            catch (ArgumentNullException e)
            {
                System.Console.WriteLine("Bad input!!!!!!");
                second = 1;
            }
            catch (FormatException e)
            {
                System.Console.WriteLine("Bad input!!!!!!");
                second = 1;
            }
            catch (OverflowException e)
            {
                System.Console.WriteLine("Bad input!!!!!!");
                second = 1;
            }

            string format = "│{0} * {1} = {2}│";
            int k1 = 1; int k2 = 2; int k3 = 3; int k4 = 4;
            int top = 1; int left = 0;
            int step = 1;
            for (int i = 1; i <= second; ++i)
            {                
                if (i == k1) { left = 1; }
                if (i == k2) { left = 20; }
                if (i == k3) { left = 40; }
                if (i == k4) { left = 60; top += (second+1); }
                for (int j = 1; j <= second; ++j)
                {
                    System.Console.CursorLeft = left;
                    System.Console.CursorTop += step;
                    System.Console.Write(format, i, j, i * j);
                }
                
                 System.Console.CursorTop = top;
                if (i % 4 == 0)
                {                   
                    System.Console.CursorLeft = 0;                    
                    k1 += 4;
                    k2 += 4;
                    k3 += 4;
                    k4 += 4;                   
                }             
            }
            System.Console.ReadKey();
        }
        //---
        void checkStringForSimetry(int n) {
            System.Console.Clear();
            if(n==0)
                System.Console.Write("Введiть стрiчку для перевiрки на симетрiю: ");
            else
                System.Console.Write("Введiть число для перевiрки на симетрiю: ");
              string s = System.Console.ReadLine();
           
                 char[] tmp = s.ToCharArray();
                   char[] res = tmp.Reverse().ToArray();

                  string ss = new string(res);
                  bool b = false;
                  if (s.Equals(ss) == true) {
                      b = true;
                  }         

                  if (b)
                  {
                      System.Console.WriteLine("Введена стрiчка симетрична.");
                  }
                  else
                  {
                      System.Console.WriteLine("Введена стрiчка не симетрична.");
                  }
             
            System.Console.ReadKey();
        }
        //---
        void sumOfArrayElements() { 
           System.Console.Clear();
           System.Console.Write("Введiть кiлькiсть елементiв мaсиву: ");
             string s = System.Console.ReadLine();
             int numOfElem = int.Parse(s);
             System.Console.Write("Для ручного введення масиву введiть 0 (або iнше число): ");
             string punkt = System.Console.ReadLine();
              int option = int.Parse(punkt);
              if (option == 0)
              {
                  int sum = 0;
                  for (int i = 0; i < numOfElem; ++i) {
                      string s1 = System.Console.ReadLine();
                      int number = int.Parse(s1);
                      sum += number;
                  }
                  System.Console.WriteLine("Сума елементiв введеного масиву: {0}", sum);
              }
              else {
                  int[] array = new int[numOfElem];
                  Random rand = new Random();
                  int sum = 0;
                  for (int i = 0; i < numOfElem; ++i)
                  {
                      array[i] = rand.Next(20);
                      sum += array[i];
                  }
                  System.Console.WriteLine("Сума елементiв введеного масиву: {0}", sum);
              }

              System.Console.ReadKey();
        }
        //---
        void sumOfMatrixElements() {
            System.Console.Clear();
            System.Console.WriteLine("Сума елементів матриці. ");
            System.Console.Write("Введiть кiлькiсть рядкiв: ");
             string s1 = System.Console.ReadLine();
              int rows = int.Parse(s1);
            System.Console.Write("Введiть кiлькiсть стовпців: ");
             string s2 = System.Console.ReadLine();
              int cols = int.Parse(s2);

              System.Console.Write("Для ручного введення матрицi введiть 0 (або iнше число): ");
            string punkt = System.Console.ReadLine();
            int option = int.Parse(punkt);
            if (option == 0)
            {
                int sum = 0;
                for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < cols; ++j){
                     string s3 = System.Console.ReadLine();
                     int number = int.Parse(s3);
                     sum += number;
                    }                  
                }

                System.Console.WriteLine("Сума елементiв матрицi: {0}", sum);
            }
            else
            {
                int[,] array = new int[rows, cols];
                Random rand = new Random();
                int sum = 0;
                 for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < cols; ++j){
                      array[i,j] = rand.Next(7,42);
                      sum += array[i, j];
                    }                  
                }               

               System.Console.WriteLine("Сума елементiв матрицi: {0}", sum);
            }

             System.Console.ReadKey();
        }
        //---
        void rectangleMoovment() {
            System.Console.Clear();
            ConsoleKeyInfo cki;

            System.Console.Write("Введiть сторону прямокутника: ");
            string s3 = System.Console.ReadLine();
            int side = int.Parse(s3);
            //--
            System.Console.Clear();
            string st = " ";
            System.Console.Write("Для виходу натиснiть (ESC) керування (W,S,A,D) ");
            //--
             System.Console.CursorLeft = 40;
             System.Console.CursorTop = 40;
            //--
             System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
             System.Console.BackgroundColor = System.ConsoleColor.DarkRed;
            //--
             for (int i = 0; i < side; ++i) {
                 for (int j = 0; j < side; ++j)
                 {
                     System.Console.Write("♦");                                        
                 }
                 System.Console.CursorTop -=1;
                 System.Console.CursorLeft = 40;
             }
            //--
             System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
             System.Console.BackgroundColor = System.ConsoleColor.Gray;
            do
            {         
                cki = Console.ReadKey(true);
                 st = cki.Key.ToString();
                //----------
                 //--
                 int prevLeft1 = System.Console.CursorLeft;
                 int prevTop1 = System.Console.CursorTop;
                 //--
                 System.Console.ForegroundColor = System.ConsoleColor.Gray;
                 System.Console.BackgroundColor = System.ConsoleColor.Gray;
                 for (int i = 0; i < side; ++i)
                 {
                     for (int j = 0; j < side; ++j)
                     {
                         System.Console.Write("♦");
                     }
                     System.Console.CursorTop -= 1;
                     System.Console.CursorLeft = prevLeft1;
                 }
                 System.Console.CursorTop = prevTop1;
                 //--
                //-----------
                switch (st)
                {
                    case "W":
                        {
                            if (System.Console.CursorTop > side)
                             System.Console.CursorTop -= 1;
                        } break;
                    case "S":
                        {
                            if (System.Console.CursorTop <(90-side))
                            System.Console.CursorTop += 1;
                        } break;
                    case "A":
                        {
                            if (System.Console.CursorLeft > side)
                            System.Console.CursorLeft -= 1;
                        } break;
                    case "D":
                        {
                            if (System.Console.CursorLeft < (72 - side))
                            System.Console.CursorLeft += 1;
                        } break;                    
                }
                //--
                int prevLeft = System.Console.CursorLeft;
                int prevTop = System.Console.CursorTop;
                //--                
                System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
                System.Console.BackgroundColor = System.ConsoleColor.DarkRed;
                for (int i = 0; i < side; ++i)
                {
                    for (int j = 0; j < side; ++j)
                    {
                        System.Console.Write("♦");                       
                    }
                    System.Console.CursorTop -= 1;
                    System.Console.CursorLeft = prevLeft;
                }
                System.Console.CursorTop = prevTop;
                //--
                System.Console.ForegroundColor = System.ConsoleColor.Gray;
                System.Console.BackgroundColor = System.ConsoleColor.Gray;
            } while (st !=  "Escape");
            //--
            System.Console.ReadKey();
        }
        //---
        void calcNumberOfWordsLongerThen() { 
            System.Console.Clear();
            System.Console.Write("Введiть стрiчку: ");
             string st = System.Console.ReadLine();
             System.Console.Write("Введiть максимальну довжину слова: ");
             int max = int.Parse(System.Console.ReadLine());
            //--
             string[] arr = st.Split(new Char[] { ' ', ',', '.', ':' });
              int count = 0;
              for (int i = 0; i < arr.Length; ++i) {
                  if (arr[i].Length > max) {
                      ++count;
                  }
              }
            //---
              System.Console.Write("Кiлькiсть слiв, що мають довжину бiльше {0} , становить {1}.", max, count);
              System.Console.ReadKey();
        }
        //---
        void calcNumberOfWordRepeats() {
            System.Console.Clear();
            System.Console.Write("Введiть стрiчку: ");
            string st = System.Console.ReadLine();
            System.Console.Write("Введiть словo: ");
            string curWord = System.Console.ReadLine(); 
            //--
            string[] arr = st.Split(new Char[] { ' ', ',', '.', ':' });
            int count = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i].Equals(curWord))
                {
                    ++count;
                }
            }  
            //--
            System.Console.Write("Кiлькiсть повторiв становить {0}.", count);
            System.Console.ReadKey();
        }
        //---
        void ceasarShifr() {
            // CeASAR algo for encrypting using ASCII table 
            System.Console.Clear();
            System.Console.Write("Введiть стрiчку: ");
            string st = System.Console.ReadLine();
            //---
            char[] shifr = new char[st.Length]; 
             int key = 3;
            //--shifr-           
           for (int i = 0; i < st.Length; i++)
              {
                 int tmp = 0;
                 tmp = ((int)st[i]  + key);
                 //--
                 if (tmp>=256) tmp -= 256;
                 shifr[i] = (char)tmp;
             }
            //----------- 
            string shifrStr =new string(shifr);
            System.Console.WriteLine("Закодована стрiчка: {0}", shifrStr);
            //--de shifr-           
            char[] deShifr = new char[shifrStr.Length]; 
            for (int i = 0; i < shifrStr.Length; i++)
           {
               int tmp = 0;
                tmp = (shifrStr[i] - key);
               //--
               if (tmp < 0) tmp += 256;
               deShifr[i] = (char)tmp;
           }
           //---
            string deshifrStr = new string(deShifr);
            System.Console.WriteLine("Розкодована стрiчка: {0}", deshifrStr);
            //---
            System.Console.ReadKey();
        }
        //---
        void stringReverse() {
            System.Console.Clear();
            System.Console.Write("Введiть стрiчку: ");
            string s = System.Console.ReadLine();
            char[] tmp = s.ToCharArray();
            char[] res = tmp.Reverse().ToArray();
            string reversedString = new string(res);
            System.Console.WriteLine("Оберненa стрiчка: {0}", reversedString);
            System.Console.ReadKey();
        }
        //---
        void thePascalTriangleDraw() {
            System.Console.Clear();

            System.Console.Write("Введiть степiнь полiнома: ");
            string s3 = System.Console.ReadLine();
            int side = int.Parse(s3);
            //---
            int n = side;
            for (int i = 0; i <= n; i++)
            {
                for (int space = 0; space < 4 * (n - i) / 2; space++)
                    System.Console.Write(" ");
                for (int j = 0; j <= i; j++) {
                    int k;
                    int ifac = 1;
                    for (k = 2; k <= i; k++) // i!
                        ifac *= k;

                    int jfac = 1;
                    for (k = 2; k <= j; k++) // j!
                        jfac *= k;

                    int ijfac = 1;
                    for (k = 2; k <= i - j; k++) // (i-j)!
                        ijfac *= k;

                    int c = ifac / (jfac * ijfac);
                    if (c > 99)
                         System.Console.Write(" {0} ",c);
                    else if (c > 9)
                        System.Console.Write(" {0} ",c);
                    else System.Console.Write(" {0} ", c);
                }
                System.Console.Write("\n");
            }
            //---
            System.Console.ReadKey();
        }
        //---
        void sortMatrixCols() {
            System.Console.Clear();
            System.Console.Write("Введiть кiлькiсть рядкiв: ");
            string s1 = System.Console.ReadLine();
            int rows = int.Parse(s1);
            System.Console.Write("Введiть кiлькiсть стовпців: ");
            string s2 = System.Console.ReadLine();
            int cols = int.Parse(s2);

            System.Console.Write("Для ручного введення матрицi введiть 0 (або iнше число): ");
            string punkt = System.Console.ReadLine();
            int option = int.Parse(punkt);

            int[,] sortedArray = new int[rows, cols];

            if (option == 0)
            {
                int[,] array = new int[rows, cols];

                for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < cols; ++j)
                    {
                        string s3 = System.Console.ReadLine();
                        int number = int.Parse(s3);
                        array[i, j] = number; 
                    }
                }
                //--add sorting here-
                int[] buf = new int[rows];
                //---
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
                //--- 
            } else  {
                int[,] array = new int[rows, cols];
                Random rand = new Random();
                int sum = 0;

                for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < cols; ++j)
                    {
                        array[i, j] = rand.Next(0, 50);                        
                    }
                }
                //--add sorting here-
                int[] buf = new int[rows];                
                //---
                for (int j = 0; j < cols; ++j )
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
            //--
             System.Console.WriteLine("Матриця сортована по стовпцях.");
             for (int i = 0; i < cols; ++i)
             {
                 for (int j = 0; j < rows; ++j)
                 {
                     System.Console.Write("{0}\t", sortedArray[i, j]);
                 }
                 System.Console.Write("\n");
             }
            //--
            System.Console.ReadKey(); 
        }
        //---
        void sortSimbolsInString() {
            System.Console.Clear();
            System.Console.Write("Введiть стрiчку: ");
            string s = System.Console.ReadLine();
            for (int i = 0; i < s.Length; ++i )
            {
                if (s[i] == ' ')
                    s.Remove(i, 1);
            }
            char[] tmp = s.ToCharArray();

            Array.Sort(tmp);

            string sortedString = new string(tmp);

            System.Console.WriteLine("Сортована стрiчка: {0}", sortedString);
            System.Console.ReadKey();
        }
        //---
        int userChoice()
        {
            ///---- get user input and check it
            string s = System.Console.ReadLine();
            int res = 0;
            try
            {
                res = int.Parse(s);
            }
            catch (ArgumentNullException e)
            {
                System.Console.WriteLine("Bad input!!!!!!");
                res = 1;
            }
            catch (FormatException e)
            {
                System.Console.WriteLine("Bad input!!!!!!");
                res = 1;
            }
            catch (OverflowException e)
            {
                System.Console.WriteLine("Bad input!!!!!!");
                res = 1;
            }
            //finally {                
            //    //System.Console.Clear();
            //    //System.Console.ReadKey();
            //}
            return res;
        }
        //---
        void exitApp()
        {
            System.Console.WriteLine("Good bye");
            System.Console.ReadKey();
            exit = false;
        }
        //---
        void setChoice()
        {
            switch (userChoice())
            {
                case (int)menuChoice.exit:
                    {
                        exitApp();
                    } break;
               case (int)menuChoice.one:
                    {
                        drawTree();
                    } break;
               case (int)menuChoice.two:
                    {
                        drawFlag();
                    } break;
               case (int)menuChoice.three:
                   {
                       drawMultiplyTable();
                   } break;
               case (int)menuChoice.four:
                   {
                       checkStringForSimetry(0);
                   } break;
               case (int)menuChoice.five:
                   {
                       checkStringForSimetry(1);
                   } break;
               case (int)menuChoice.six:
                   {
                       sumOfArrayElements();
                   } break;
               case (int)menuChoice.seven:
                   {
                       sumOfMatrixElements();
                   } break;

               case (int)menuChoice.eigth:
                   {
                       rectangleMoovment();
                   } break;
               case (int)menuChoice.nine:
                   {
                       calcNumberOfWordsLongerThen(); 
                   } break;
               case (int)menuChoice.ten:
                   {
                       calcNumberOfWordRepeats(); 
                   } break;
               case (int)menuChoice.eleven:
                   {
                       ceasarShifr();
                   } break;
               case (int)menuChoice.twelve:
                   {
                       stringReverse(); 
                   } break;
               case (int)menuChoice.thirteen:
                   {
                       thePascalTriangleDraw(); 
                   } break;
               case (int)menuChoice.fourteen:
                   {
                       sortMatrixCols();  
                   } break;
               case (int)menuChoice.fifteen:
                   {
                       sortSimbolsInString(); 
                   } break; 
               default:
                    {
                        System.Console.WriteLine("Hmm..");
                    } break;
            }
        }
        //---
        void mainApplication()
        {
            userNameHello();
            while (exit)
            {
                menu();
                setChoice();
            }
        }
       //---
        public void run()
        {
            mainApplication();
        }
    }

    //---
    class Program
    {
        static void Main(string[] args)
        {
            simpleHome mySimple= new simpleHome();
            mySimple.run();
        }
    }
}
