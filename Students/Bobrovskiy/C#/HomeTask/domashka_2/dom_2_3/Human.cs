using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace dom_2_3
{
    class Human
    {
        public string Name
        {
            get;
            set;
        }
        public string Surname
        {
            get;
            set;
        }
        public string ThirdName
        {
            get;
            set;
        }

    }
    //--
    class Pupil : Human
    {
        public int MiddleMark
        {
            get;
            set;
        }
        public string BirthDay
        {
            get;
            set;
        }
        public Pupil()
        {
            clearData();
        }
        public Pupil(Pupil curPupil)
        {
            Name = curPupil.Name;
            Surname = curPupil.Surname;
            ThirdName = curPupil.ThirdName;
            MiddleMark = curPupil.MiddleMark;
            this.BirthDay = curPupil.BirthDay;
        }
        public void clearData() {
            Name = string.Empty;
            ThirdName = string.Empty;
            Surname = string.Empty;
            MiddleMark = 0;
            BirthDay = string.Empty; 
        }
    }
    //--
    class Teacher : Human
    {
        public decimal Salary
        {
            get;
            set;
        }
        public Teacher()
        {
            clearData();
        }
        public Teacher(Teacher curTeacher)
        {
            Name = curTeacher.Name;
            Surname = curTeacher.Surname;
            ThirdName = curTeacher.ThirdName;
            Salary = curTeacher.Salary;
        }
        public void clearData()
        {
            Name = string.Empty;
            ThirdName = string.Empty;
            Surname = string.Empty;
            Salary = 0;
        }
    }
    //--
    class Buhgalter : Human
    {
        public decimal Salary
        {
            get;
            set;
        }
        public Buhgalter()
        {
            clearData();
        }
        public Buhgalter(Buhgalter curBuhgalter)
        {
            Name = curBuhgalter.Name;
            Surname = curBuhgalter.Surname;
            ThirdName = curBuhgalter.ThirdName;
            Salary = curBuhgalter.Salary;
        }
        public void clearData()
        {
            Name = string.Empty;
            ThirdName = string.Empty;
            Surname = string.Empty;
            Salary = 0;
        }
    }
    //----------------------------
    class PupilList
    {
        bool exit = true;

        enum menuChoice
        {
            one = 1, two = 2, three = 3, four = 4, five = 5, exit = 0
        };

        public readonly int numberOfPupils = 10;
        //---
        Pupil[] pupilArray;
        //---
        public PupilList(int numOfPupils)
        {
            numberOfPupils = numOfPupils;
            pupilArray = new Pupil[numberOfPupils];
        }
        void createBaseList()
        {

            string[] name = new string[5] { "Василь", "Микола", "Петро", "Оля", "Ніна" };
            string[] surname = new string[5] { "Пупкін", "Савчук", "Туркін", "Грищук", "Карпова" };
            string[] thirdname = new string[5] { "Миколайович", "Васильович", "Дмитрович", "Генадіївна", "Агапівна" };
            int[] marks = new int[5] { 3, 4, 5, 4, 4 };
            string[] dates = new string[5] { "02.04.1997", "12.08.1998", "02.06.1999", "13.03.2000", "04.05.2001" };

            for (int i = 0; i < 5; ++i)
            {
                Pupil tmp = new Pupil();
                tmp.Name = name[i];
                tmp.Surname = surname[i];
                tmp.ThirdName = thirdname[i];
                tmp.MiddleMark = marks[i];
                tmp.BirthDay = dates[i];
                pupilArray[i] = new Pupil(tmp);
            }
        }
        public bool addToList()
        {
            createBaseList();
            return true;
        }
        //--
        public bool deleteFromList()
        {
            string format = "Введіть номер учня для видалення: ";
             System.Console.Write(format);
             int value = UserInput.userChoice();
                --value;
             //---
             for (int i = 0; i < numberOfPupils; ++i)
             {                
                     if(i==value)
                     pupilArray[i].clearData();
                             
             }
            return true;
        }
        //--
        public bool modifyList()
        {
            string format = "Введіть номер учня для редагування: ";
             System.Console.Write(format);
            //--
              int value = UserInput.userChoice();
              Pupil tmp = new Pupil();
            //-----------------------
              string format1 = "Введiть iмя: ";
               System.Console.Write(format1);
                string name1 = System.Console.ReadLine();
                 tmp.Name = name1;
              //--
                 string format2 = "Введiть прiзвище: ";
                 System.Console.Write(format2);
                 string name2 = System.Console.ReadLine();
                 tmp.Surname = name2;
               //--
                 string format3 = "Введiть по-батьковi: ";
                 System.Console.Write(format3);
                 string name3 = System.Console.ReadLine();
                 tmp.ThirdName = name3;
              //--
                 string format4 = "Введiть дату народження: ";
                 System.Console.Write(format4);
                 string name4 = System.Console.ReadLine();
                 tmp.BirthDay = name4;
              //---------------------
              for (int i = 0; i < numberOfPupils; ++i)
              {
                  if (i == value)
                     pupilArray[i] = new Pupil(tmp);
                 
              }
            return true;
        }
        //--
        void drawList()
        {
            System.Console.Clear();
            System.Console.WriteLine("┌───────────────────────────────────────────────┐");        
            for (int i = 0; i < 5; ++i)
            {
                System.Console.Write("│ ");
                System.Console.Write("{0}", i+1);
                System.Console.Write(" ");
                System.Console.Write(pupilArray[i].ThirdName);
                System.Console.Write("\t");
                System.Console.Write(pupilArray[i].Surname);
                System.Console.Write("\t");
                System.Console.Write(pupilArray[i].Name);
                System.Console.Write("\t");
                System.Console.Write(pupilArray[i].BirthDay);
                System.Console.Write("\t│ \n");                
            }
            System.Console.WriteLine("└───────────────────────────────────────────────┘");
            System.Console.ReadKey();
        }
        //---
        void menu()
        {
            System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
            System.Console.BackgroundColor = System.ConsoleColor.Gray;
            System.Console.Clear();
            System.Console.WriteLine("┌──────────────────────────────────────┐");
            System.Console.WriteLine("│Додати учня до списку         <{0}>     │", (int)menuChoice.one);
            System.Console.WriteLine("│Видалити учня зi списку       <{0}>     │", (int)menuChoice.two);
            System.Console.WriteLine("│Редагувати данi про учня      <{0}>     │", (int)menuChoice.three);
            System.Console.WriteLine("│Вивести список учнiв          <{0}>     │", (int)menuChoice.four);
            System.Console.WriteLine("│Вихiд                         <{0}>     │", (int)menuChoice.exit);
            System.Console.WriteLine("└──────────────────────────────────────┘");
            System.Console.Write("  Оберiть пункт меню: ");
        }
        void setChoice()
        {
            switch (UserInput.userChoice())
            {
                case (int)menuChoice.exit:
                    {
                        exitApp();
                    } break;
                case (int)menuChoice.one:
                    {
                        addToList();
                    } break;
                case (int)menuChoice.two:
                    {
                        deleteFromList();
                    } break;
                case (int)menuChoice.three:
                    {
                        modifyList();
                    } break;
                case (int)menuChoice.four:
                    {
                        drawList();
                    } break;
                default:
                    {
                        System.Console.WriteLine("Hmm..");
                    } break;
            }
        }
        void exitApp()
        {
            System.Console.WriteLine("Good bye");
            System.Console.ReadKey();
            exit = false;
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
    //---------------
    class TeacherList
    {
        bool exit = true;
        enum menuChoice
        {
            one = 1, two = 2, three = 3, four = 4, five = 5, exit = 0
        };
        public readonly int numberOfTeacher = 10;      
        Teacher[] teacherArray;       
        public TeacherList(int numOfTeacher)
        {
            numberOfTeacher = numOfTeacher;
            teacherArray = new Teacher[numberOfTeacher];
        }
        void createBaseList()
        {

            string[] name = new string[5] { "Василь", "Микола", "Петро", "Оля", "Ніна" };
            string[] surname = new string[5] { "Пупкін", "Савчук", "Туркін", "Грищук", "Карпова" };
            string[] thirdname = new string[5] { "Миколайович", "Васильович", "Дмитрович", "Генадіївна", "Агапівна" };
            int[] salary = new int[5] { 3100, 4100, 5020, 4300, 4020 };
            string[] dates = new string[5] { "02.04.1997", "12.08.1998", "02.06.1999", "13.03.2000", "04.05.2001" };

            for (int i = 0; i < 5; ++i)
            {
                Teacher tmp = new Teacher();
                tmp.Name = name[i];
                tmp.Surname = surname[i];
                tmp.ThirdName = thirdname[i];
                tmp.Salary = salary[i];
                teacherArray[i] = new Teacher(tmp);
            }
        }
        public bool addToList()
        {
            createBaseList();
            return true;
        }
        //--
        public bool deleteFromList()
        {
            string format = "Введіть номер учня для видалення: ";
            System.Console.Write(format);
            int value = UserInput.userChoice();
                value -= 1;
            //---
            for (int i = 0; i < numberOfTeacher; ++i)
            {
                if (i == value)
                    teacherArray[i].clearData();

            }
            return true;            
        }
        //--
        public bool modifyList()
        {
            string format = "Введіть номер учня для редагування: ";
            System.Console.Write(format);
            //--
            int value = UserInput.userChoice();
            Teacher tmp = new Teacher();
            //-----------------------
            string format1 = "Введiть iмя: ";
            System.Console.Write(format1);
            string name1 = System.Console.ReadLine();
            tmp.Name = name1;
            //--
            string format2 = "Введiть прiзвище: ";
            System.Console.Write(format2);
            string name2 = System.Console.ReadLine();
            tmp.Surname = name2;
            //--
            string format3 = "Введiть по-батьковi: ";
            System.Console.Write(format3);
            string name3 = System.Console.ReadLine();
            tmp.ThirdName = name3;
            //--
            string format4 = "Введiть зарплату: ";
            System.Console.Write(format4);
            decimal val = (decimal)UserInput.userChoice();
            tmp.Salary = val;
            //---------------------
            for (int i = 0; i < numberOfTeacher; ++i)
            {
                if (i == value)
                    teacherArray[i] = new Teacher(tmp);

            }
            return true;
        }
        //--
        void drawList()
        {
            System.Console.Clear();
            System.Console.WriteLine("┌─────────────────────────────────────────┐");
            for (int i = 0; i < 5; ++i)
            {
                System.Console.Write("│ ");
                System.Console.Write("{0}", i+1);
                System.Console.Write(" ");
                System.Console.Write(teacherArray[i].ThirdName);
                System.Console.Write("\t");
                System.Console.Write(teacherArray[i].Surname);
                System.Console.Write("\t");
                System.Console.Write(teacherArray[i].Name);
                System.Console.Write("\t");
                System.Console.Write(teacherArray[i].Salary);
                System.Console.Write("\t│ \n");
            }
            System.Console.WriteLine("└─────────────────────────────────────────┘");
            System.Console.ReadKey();
        }
        //---
        void menu()
        {
            System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
            System.Console.BackgroundColor = System.ConsoleColor.Gray;
            System.Console.Clear();
            System.Console.WriteLine("┌──────────────────────────────────────┐");
            System.Console.WriteLine("│Додати вчителя до списку      <{0}>     │", (int)menuChoice.one);
            System.Console.WriteLine("│Видалити вчителя зi списку    <{0}>     │", (int)menuChoice.two);
            System.Console.WriteLine("│Редагувати данi про вчителя   <{0}>     │", (int)menuChoice.three);
            System.Console.WriteLine("│Вивести список вчителiв       <{0}>     │", (int)menuChoice.four);
            System.Console.WriteLine("│Вихiд                         <{0}>     │", (int)menuChoice.exit);
            System.Console.WriteLine("└──────────────────────────────────────┘");
            System.Console.Write("  Оберiть пункт меню: ");
        }
        void setChoice()
        {
            switch (UserInput.userChoice())
            {
                case (int)menuChoice.exit:
                    {
                        exitApp();
                    } break;
                case (int)menuChoice.one:
                    {
                        addToList();
                    } break;
                case (int)menuChoice.two:
                    {
                        deleteFromList();
                    } break;
                case (int)menuChoice.three:
                    {
                        modifyList();
                    } break;
                case (int)menuChoice.four:
                    {
                        drawList();
                    } break;
                default:
                    {
                        System.Console.WriteLine("Hmm..");
                    } break;
            }
        }
        void exitApp()
        {
            System.Console.WriteLine("Good bye");
            System.Console.ReadKey();
            exit = false;
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
    //---------------
    class BuhgalterList
    {
        bool exit = true;
        enum menuChoice
        {
            one = 1, two = 2, three = 3, four = 4, five = 5, exit = 0
        };
        public readonly int numberOfBuhgalters = 10;        
        Buhgalter[] buhgalterArray;       
        public BuhgalterList(int numOfBuhgalters)
        {
            numberOfBuhgalters = numOfBuhgalters;
            buhgalterArray = new Buhgalter[numberOfBuhgalters];
        }
        void createBaseList()
        {
            string[] name = new string[5] { "Василь", "Микола", "Петро", "Оля", "Ніна" };
            string[] surname = new string[5] { "Пупкін", "Савчук", "Туркін", "Грищук", "Карпова" };
            string[] thirdname = new string[5] { "Миколайович", "Васильович", "Дмитрович", "Генадіївна", "Агапівна" };
            int[] salery = new int[5] { 1233, 1254, 1235, 3244, 2834 };
            string[] dates = new string[5] { "02.04.1997", "12.08.1998", "02.06.1999", "13.03.2000", "04.05.2001" };

            for (int i = 0; i < 5; ++i)
            {
                Buhgalter tmp = new Buhgalter();
                tmp.Name = name[i];
                tmp.Surname = surname[i];
                tmp.ThirdName = thirdname[i];
                tmp.Salary = salery[i];                
                buhgalterArray[i] = new Buhgalter(tmp);
            }
        }
        public bool addToList()
        {
            createBaseList();
            return true;
        }
        //--
        public bool deleteFromList()
        {
            string format = "Введіть номер учня для видалення: ";
            System.Console.Write(format);
            int value = UserInput.userChoice();
            value -= 1;
            //---
            for (int i = 0; i < numberOfBuhgalters; ++i)
            {
                if (i == value)
                    buhgalterArray[i].clearData();

            }
            return true;
        }
        //--
        public bool modifyList()
        {
            string format = "Введіть номер учня для редагування: ";
            System.Console.Write(format);
            //--
            int value = UserInput.userChoice();
            Buhgalter tmp = new Buhgalter();
            //-----------------------
            string format1 = "Введiть iмя: ";
            System.Console.Write(format1);
            string name1 = System.Console.ReadLine();
            tmp.Name = name1;
            //--
            string format2 = "Введiть прiзвище: ";
            System.Console.Write(format2);
            string name2 = System.Console.ReadLine();
            tmp.Surname = name2;
            //--
            string format3 = "Введiть по-батьковi: ";
            System.Console.Write(format3);
            string name3 = System.Console.ReadLine();
            tmp.ThirdName = name3;
            //--
            string format4 = "Введiть зарплату: ";
            System.Console.Write(format4);
            decimal val = (decimal)UserInput.userChoice();
            tmp.Salary = val;
            //---------------------
            for (int i = 0; i < numberOfBuhgalters; ++i)
            {
                if (i == value)
                    buhgalterArray[i] = new Buhgalter(tmp);

            }
            return true;
        }
        //--
        void drawList()
        {
            System.Console.Clear();
            System.Console.WriteLine("┌─────────────────────────────────────────┐");
            for (int i = 0; i < 5; ++i)
            {
                System.Console.Write("│ ");
                System.Console.Write("{0}", i + 1);
                System.Console.Write(" ");
                System.Console.Write(buhgalterArray[i].ThirdName);
                System.Console.Write("\t");
                System.Console.Write(buhgalterArray[i].Surname);
                System.Console.Write("\t");
                System.Console.Write(buhgalterArray[i].Name);
                System.Console.Write("\t");
                System.Console.Write(buhgalterArray[i].Salary);
                System.Console.Write("\t│ \n");
            }
            System.Console.WriteLine("└─────────────────────────────────────────┘");
            System.Console.ReadKey();
        }
        //---
        void menu()
        {
            System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
            System.Console.BackgroundColor = System.ConsoleColor.Gray;
            System.Console.Clear();
            System.Console.WriteLine("┌───────────────────────────────────────────┐");
            System.Console.WriteLine("│Додати бухгалтерa до списку      <{0}>       │", (int)menuChoice.one);
            System.Console.WriteLine("│Видалити бухгалтерa зi списку    <{0}>       │", (int)menuChoice.two);
            System.Console.WriteLine("│Редагувати данi про бухгалтерa   <{0}>       │", (int)menuChoice.three);
            System.Console.WriteLine("│Вивести список бухгалтерiв       <{0}>       │", (int)menuChoice.four);
            System.Console.WriteLine("│Вихiд                            <{0}>       │", (int)menuChoice.exit);
            System.Console.WriteLine("└───────────────────────────────────────────┘");
            System.Console.Write("  Оберiть пункт меню: ");
        }
        void setChoice()
        {
            switch (UserInput.userChoice())
            {
                case (int)menuChoice.exit:
                    {
                        exitApp();
                    } break;
                case (int)menuChoice.one:
                    {
                        addToList();
                    } break;
                case (int)menuChoice.two:
                    {
                        deleteFromList();
                    } break;
                case (int)menuChoice.three:
                    {
                        modifyList();
                    } break;
                case (int)menuChoice.four:
                    {
                        drawList();
                    } break;
                default:
                    {
                        System.Console.WriteLine("Hmm..");
                    } break;
            }
        }
        void exitApp()
        {
            System.Console.WriteLine("Good bye");
            System.Console.ReadKey();
            exit = false;
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
    //---------------
    class UserInput
    {
        public static int userChoice()
        {
            ///---- get user input and check it
            string s = System.Console.ReadLine();
            int res = 99;
            try
            {
                res = int.Parse(s);
            }
            catch (ArgumentNullException e)
            {
                System.Console.WriteLine("Bad input!!!!!!");
                res = 99;
            }
            catch (FormatException e)
            {
                System.Console.WriteLine("Bad input!!!!!!");
                res = 99;
            }
            catch (OverflowException e)
            {
                System.Console.WriteLine("Bad input!!!!!!");
                res = 99;
            }
            //finally {                
            //    //System.Console.Clear();
            //    //System.Console.ReadKey();
            //}
            return res;
        }
    }
    //---------------
    class Application
    {
        bool exit = true;
        enum menuChoice
        {
            one = 1, two = 2, three = 3, four = 4, five = 5, exit = 0
        };
        void menu()
        {
            System.Console.ForegroundColor = System.ConsoleColor.DarkBlue;
            System.Console.BackgroundColor = System.ConsoleColor.Gray;
            System.Console.Clear();
            System.Console.WriteLine("┌──────────────────────────────────────┐");
            System.Console.WriteLine("│Список Учнiв               <{0}>        │", (int)menuChoice.one);
            System.Console.WriteLine("│Список Вчителiв            <{0}>        │", (int)menuChoice.two);
            System.Console.WriteLine("│Список Бухгалтерiв         <{0}>        │", (int)menuChoice.three);
            System.Console.WriteLine("│Вихiд                      <{0}>        │", (int)menuChoice.exit);
            System.Console.WriteLine("└──────────────────────────────────────┘");
            System.Console.Write("  Оберiть пункт меню: ");
        }
        void setChoice()
        {
            switch (UserInput.userChoice())
            {
                case (int)menuChoice.exit:
                    {
                        exitApp();
                    } break;
                case (int)menuChoice.one:
                    {
                        PupilList myPup = new PupilList(10);
                        myPup.run();
                    } break;
                case (int)menuChoice.two:
                    {
                        TeacherList myTeach = new TeacherList(10);
                        myTeach.run();
                    } break;
                case (int)menuChoice.three:
                    {
                        BuhgalterList myBuh = new BuhgalterList(10);
                        myBuh.run();
                    } break;
                default:
                    {
                        System.Console.WriteLine("Hmm..");
                    } break;
            }
        }
        void exitApp()
        {
            System.Console.WriteLine("Good bye");
            System.Console.ReadKey();
            exit = false;
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
}
