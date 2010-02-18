using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace DreamAcademy
{
    #region Interface declaration
    interface IPrintable
    {
        void Print();
    }
    #endregion

    #region Menu enumerator
    enum MenuChoice
    {
        one = 1, two = 2, three = 3, four = 4, five = 5, exit = 0
    };
    #endregion

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

        public static int GetCursorLeft()
        {
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

        public static void ClearConsole()
        {
            System.Console.Clear();
        }

        public static void WriteMenuLine(string formatedString, int value)
        {
            System.Console.WriteLine(formatedString, value);
        }

        public static void WriteMenuLine(string formatedString, int value1, int value2)
        {
            System.Console.WriteLine(formatedString, value1, value2);
        }

        public static void WriteMenuLine(string formatedString, string someText)
        {
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
            System.Console.Write("{0}", value);
        }

        public static void Write(string formatedString, int value)
        {
            System.Console.Write(formatedString, value);
        }

        public static void ReadKey()
        {
            System.Console.ReadKey();
        }

        public static ConsoleKeyInfo ReadKey(bool value)
        {
            return System.Console.ReadKey(value);
        }

        public static string ReadLine()
        {
            return System.Console.ReadLine();
        }

        public static void SetColor(ConsoleWrapper.Color color)
        {
            SetTextColor(color);
            SetBackgroundColor(color);
        }

        public static void SetTextColor(ConsoleWrapper.Color color)
        {
            System.Console.ForegroundColor = (ConsoleColor)color;
        }

        public static void SetBackgroundColor(ConsoleWrapper.Color color)
        {
            System.Console.BackgroundColor = (ConsoleColor)color;
        }
    }
    
    public static class SafeIntegerRead
    {
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

    class Human : IPrintable
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

        public string BirthDay
        {
            get;
            set;
        }

        public Human(string name, string surname, string thirdname, string birthday)
        {
            Name = name;
            Surname = surname;
            ThirdName = thirdname;
            BirthDay = birthday;
        }

        public Human()
            : this(string.Empty, string.Empty, string.Empty, string.Empty)
        {

        }
        public virtual void Print() 
        {

        }
    }

    class Employee : Human
    {
        public float Salary
        {
            get;
            set;
        }

        public float Tax
        {
            get;
            set;
        }

        public Employee()
            : base(string.Empty, string.Empty, string.Empty, string.Empty)
        {
            Salary = 0;
            Tax = 0;
        }

        public Employee(string name, string surname, string thirdname, string birthday, float salary, float tax)
            : base(name, surname, thirdname, birthday)
        {
            Salary = salary;
            Tax = tax;
        }
    }

    class Pupil : Human
    {
        public int MiddleMark
        {
            get;
            set;
        }

        public Pupil()
            : base(string.Empty, string.Empty, string.Empty, string.Empty)
        {
            MiddleMark = 0;
        }

        public Pupil(Pupil curPupil)
            : base(curPupil.Name, curPupil.Surname, curPupil.ThirdName, curPupil.BirthDay)
        {
            this.BirthDay = curPupil.BirthDay;
        }
    }

    class Teacher : Employee
    {
        public Teacher()
            : base(string.Empty, string.Empty, string.Empty, string.Empty, 0, 0)
        {

        }

        public Teacher(Teacher curTeacher)
            : base(curTeacher.Name, curTeacher.Surname, curTeacher.ThirdName, curTeacher.BirthDay, curTeacher.Salary, curTeacher.Tax)
        {

        }
    }

    class Accountant : Employee
    {
        public Accountant()
            : base(string.Empty, string.Empty, string.Empty, string.Empty, 0, 0)
        {

        }

        public Accountant(Accountant curAccountant)
            : base(curAccountant.Name, curAccountant.Surname, curAccountant.ThirdName, curAccountant.BirthDay, curAccountant.Salary, curAccountant.Tax)
        {

        }
    }

    #region Interface IListManipulator
    interface IListManipulator
    {
        bool AddToList();
        bool DeleteFromList();
        bool ModifyList();
    }
    #endregion

    abstract class ListApplication : IListManipulator
    {
        public bool exit = true;
        public const int nameSurnameThirdnameLength = 14;
        public const int birthDayLength = 15;
        public const int indexLength = 3;
        public const int taxLenght = 3;

        public abstract void Menu();

        public abstract bool AddToList();

        public abstract bool DeleteFromList();

        public abstract bool ModifyList();

        public abstract void Print();

        public void ExitApp()
        {
            ConsoleWrapper.WriteLine("Good bye");
            ConsoleWrapper.ReadKey();
            exit = false;
        }

        public void MainApplication()
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
        
        public void SetChoice()
        {
            switch ((MenuChoice)SafeIntegerRead.UserChoice())
            {
                case MenuChoice.exit:
                    {
                        ExitApp();
                    } break;
                case MenuChoice.one:
                    {
                        AddToList();
                    } break;
                case MenuChoice.two:
                    {
                        DeleteFromList();
                    } break;
                case MenuChoice.three:
                    {
                        ConsoleWrapper.ClearConsole();
                        ModifyList();
                        ConsoleWrapper.ReadKey();
                    } break;
                case MenuChoice.four:
                    {
                        ConsoleWrapper.ClearConsole();
                        Print();
                        ConsoleWrapper.ReadKey();
                    } break;
                default:
                    {
                        ConsoleWrapper.WriteLine("Hmm..");
                    } break;
            }
        }

        public string SetWordLength(string word, int length)
        {
            string result = word;
            if (word.Length > length)
            {
                result = word.Remove(length);
            }
            if (word.Length < length)
            {
                StringBuilder str = new StringBuilder(result);
                while (str.Length < length)
                {
                    str.Append(" ");
                }
                result = str.ToString();
            }
            if (word.Length == length)
            {
                result = word;
            }
            return result;
        }

        public int GetNumberBySomeRequest(string text)
        {
            ConsoleWrapper.Write(text);
            int value = SafeIntegerRead.UserChoice();
            value = value - 1;//array start with zero
            return value;
        }
    }

    class PupilList : ListApplication
    {        
        private int numberOfPupils = 5;
        private Pupil[] pupilArray;       

        #region PupilList base methods

        public PupilList(int numOfPupils)
        {
            numberOfPupils = numOfPupils;
            pupilArray = new Pupil[numberOfPupils];
        }

        public override bool AddToList()
        {
            CreateBaseList();
            return true;
        }

        public override bool DeleteFromList()
        {
            string format = "Введiть номер учня для видалення: ";
            int value = GetNumberBySomeRequest(format);
            if ((value >= 0) && (value <= numberOfPupils))
            {
                Array.Clear(pupilArray, value, 1);
            }
            return true;
        }

        public override bool ModifyList()
        {
            bool state = false;
            string format = "Введіть номер учня для редагування: ";
            int value = GetNumberBySomeRequest(format);

            for (int i = 0; i < numberOfPupils; ++i)
            {
                if (i == value)
                {
                    PrintTableHeader();
                    PrintCurentPupilData(ref pupilArray[i], value + 1);
                    PrintTableBottomLine();
                    Pupil tmp = new Pupil();
                    tmp = GetPupilData();
                    pupilArray[i] = new Pupil(tmp);
                    state = true;
                }
            }
            return state;
        }

        public override void Print()
        {
            PrintTableHeader();
            for (int i = 0; i < numberOfPupils; ++i)
            {
                if (pupilArray[i] != null)
                {
                    PrintCurentPupilData(ref pupilArray[i], i + 1);
                }
            }
            PrintTableBottomLine();
        }

        public override void Menu()
        {
            ConsoleWrapper.SetBackgroundColor(ConsoleWrapper.Color.Gray);
            ConsoleWrapper.SetTextColor(ConsoleWrapper.Color.DarkBlue);
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.WriteLine("┌──────────────────────────────────────┐");
            ConsoleWrapper.WriteMenuLine("│Додати учня до списку         <{0}>     │", (int)MenuChoice.one);
            ConsoleWrapper.WriteMenuLine("│Видалити учня зi списку       <{0}>     │", (int)MenuChoice.two);
            ConsoleWrapper.WriteMenuLine("│Редагувати данi про учня      <{0}>     │", (int)MenuChoice.three);
            ConsoleWrapper.WriteMenuLine("│Вивести список учнiв          <{0}>     │", (int)MenuChoice.four);
            ConsoleWrapper.WriteMenuLine("│Вихiд                         <{0}>     │", (int)MenuChoice.exit);
            ConsoleWrapper.WriteLine("└──────────────────────────────────────┘");
            ConsoleWrapper.Write("  Оберiть пункт меню: ");
        }       

        #endregion

        #region PupilList private methods

        private void CreateBaseList()
        {
            string[] name = new string[] { "Василь", "Микола", "Петро", "Поля", "Ніна" };
            string[] surname = new string[] { "Пупкін", "Савчук", "Туркін", "Грищук", "Карпова" };
            string[] thirdname = new string[] { "Миколайович", "Васильович", "Дмитрович", "Генадіївна", "Агапівна" };
            int[] marks = new int[] { 3, 4, 5, 4, 4 };
            string[] dates = new string[] { "02.04.1997", "12.08.1998", "02.06.1999", "13.03.2000", "04.05.2001" };

            for (int i = 0; i < numberOfPupils; ++i)
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

        private void PrintTableHeader()
        {
            //--------------------------3--------14-------------14-------------14-------------15-------
            ConsoleWrapper.WriteLine("┌───┬──────────────┬──────────────┬──────────────┬───────────────┐");
            ConsoleWrapper.WriteLine("│ № │     Iмя      │   Прiзвище   │ По батьковi  │Дата народження│");
            ConsoleWrapper.WriteLine("├───┼──────────────┼──────────────┼──────────────┼───────────────┤");
        }

        private void PrintTableBottomLine()
        {
            //--------------------------3--------14-------------14-------------14-------------15-------
            ConsoleWrapper.WriteLine("└───┴──────────────┴──────────────┴──────────────┴───────────────┘");
        }

        private void PrintCurentPupilData(ref Pupil pupilData, int i)
        {
            if (pupilData != null)
            {
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(i.ToString(), indexLength));
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(pupilData.Name, nameSurnameThirdnameLength));
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(pupilData.Surname, nameSurnameThirdnameLength));
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(pupilData.ThirdName, nameSurnameThirdnameLength));
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(pupilData.BirthDay, birthDayLength));
                ConsoleWrapper.Write("│ \n");
            }
        }

        private Pupil GetPupilData()
        {
            Pupil tmp = new Pupil();
            string format1 = "Введiть iмя: ";
            ConsoleWrapper.Write(format1);
            tmp.Name = ConsoleWrapper.ReadLine();

            string format2 = "Введiть прiзвище: ";
            ConsoleWrapper.Write(format2);
            tmp.Surname = ConsoleWrapper.ReadLine();

            string format3 = "Введiть по-батьковi: ";
            ConsoleWrapper.Write(format3);
            tmp.ThirdName = ConsoleWrapper.ReadLine();

            string format4 = "Введiть дату народження: ";
            ConsoleWrapper.Write(format4);
            tmp.BirthDay = ConsoleWrapper.ReadLine();

            return tmp;
        }        
       
        #endregion       
    }

    class TeacherList : ListApplication
    {
        public readonly int numberOfTeacher = 5;
        private Teacher[] teacherArray;

        #region TeacherList private methods

        private void CreateBaseList()
        {
            string[] name = new string[] { "Василь", "Микола", "Петро", "Оля", "Ніна" };
            string[] surname = new string[] { "Пупкін", "Савчук", "Туркін", "Грищук", "Карпова" };
            string[] thirdname = new string[] { "Миколайович", "Васильович", "Дмитрович", "Генадіївна", "Агапівна" };
            float[] salary = new float[] { 3100, 4100, 5020, 4300, 4020 };
            float[] tax = new float[] { 20, 20, 30, 30, 20 };
            string[] dates = new string[] { "02.04.1997", "12.08.1998", "02.06.1999", "13.03.2000", "04.05.2001" };

            for (int i = 0; i < numberOfTeacher; ++i)
            {
                Teacher tmp = new Teacher();
                tmp.Name = name[i];
                tmp.Surname = surname[i];
                tmp.ThirdName = thirdname[i];
                tmp.BirthDay = dates[i];
                tmp.Salary = salary[i];
                tmp.Tax = tax[i];
                teacherArray[i] = new Teacher(tmp);
            }
        }

        private void PrintTableHeader()
        {
            //--------------------------3--------14-------------14-------------14-------------15----------7---------7---
            ConsoleWrapper.WriteLine("┌───┬────────┬──────────────┬──────────────┬───────────────┬────────┬────────┐");
            ConsoleWrapper.WriteLine("│ № │  Iмя   │   Прiзвище   │ По батьковi  │Дата народження│Зарплата│Податок │");
            ConsoleWrapper.WriteLine("├───┼────────┼──────────────┼──────────────┼───────────────┼────────┼────────┤");
        }

        private void PrintTableBottomLine()
        {
            //--------------------------3--------14-------------14-------------14-------------15----------7---------7---
            ConsoleWrapper.WriteLine("└───┴────────┴──────────────┴──────────────┴───────────────┴────────┴────────┘");
        }

        private void PrintCurentTeacherData(ref Teacher teacherData, int i)
        {
            const int nameValue = 8;
            if (teacherData != null)
            {
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(i.ToString(), indexLength));
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(teacherData.Name, nameValue));
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(teacherData.Surname, nameSurnameThirdnameLength));
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(teacherData.ThirdName, nameSurnameThirdnameLength));
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(teacherData.BirthDay, birthDayLength));
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(teacherData.Salary.ToString(), nameValue));
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(teacherData.Tax.ToString(), nameValue));
                ConsoleWrapper.Write("│ \n");
            }
        }

        private Teacher GetTeacherData()
        {
            Teacher tmp = new Teacher();

            string format1 = "Введiть iмя: ";
            ConsoleWrapper.Write(format1);
            tmp.Name = ConsoleWrapper.ReadLine();

            string format2 = "Введiть прiзвище: ";
            ConsoleWrapper.Write(format2);
            tmp.Surname = ConsoleWrapper.ReadLine();

            string format3 = "Введiть по-батьковi: ";
            ConsoleWrapper.Write(format3);
            tmp.ThirdName = ConsoleWrapper.ReadLine();

            string format4 = "Введiть дату народження: ";
            ConsoleWrapper.Write(format4);
            tmp.BirthDay = ConsoleWrapper.ReadLine();

            string format5 = "Введiть заробітну плату: ";
            ConsoleWrapper.Write(format5);
            tmp.Salary = float.Parse(ConsoleWrapper.ReadLine());

            string format6 = "Введiть податок: ";
            ConsoleWrapper.Write(format6);
            tmp.Tax = float.Parse(ConsoleWrapper.ReadLine());

            return tmp;
        }

        #endregion

        #region TeacherList public methods

        public TeacherList(int numOfTeacher)
        {
            numberOfTeacher = numOfTeacher;
            teacherArray = new Teacher[numberOfTeacher];
        }

        public override bool AddToList()
        {
            CreateBaseList();
            return true;
        }

        public override bool DeleteFromList()
        {
            string format = "Введiть номер вчителя для видалення: ";
            int value = GetNumberBySomeRequest(format);
            if ((value >= 0) && (value <= numberOfTeacher))
            {
                Array.Clear(teacherArray, value, 1);
            }

            return true;
        }

        public override bool ModifyList()
        {
            bool state = false;
            string format = "Введіть номер вчителя для редагування: ";
            int value = GetNumberBySomeRequest(format);

            for (int i = 0; i < numberOfTeacher; ++i)
            {
                if (i == value)
                {
                    PrintTableHeader();
                    PrintCurentTeacherData(ref teacherArray[i], value + 1);
                    PrintTableBottomLine();
                    Teacher tmp = new Teacher();
                    tmp = GetTeacherData();
                    teacherArray[i] = new Teacher(tmp);
                    state = true;
                }
            }
            return state;
        }

        public override void Print()
        {
            PrintTableHeader();
            for (int i = 0; i < numberOfTeacher; ++i)
            {
                if (teacherArray[i] != null)
                {
                    PrintCurentTeacherData(ref teacherArray[i], i + 1);
                }
            }
            PrintTableBottomLine();
        }

        public override void Menu()
        {
            ConsoleWrapper.SetBackgroundColor(ConsoleWrapper.Color.Gray);
            ConsoleWrapper.SetTextColor(ConsoleWrapper.Color.DarkBlue);
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.WriteLine("┌──────────────────────────────────────┐");
            ConsoleWrapper.WriteMenuLine("│Додати вчителя до списку      <{0}>     │", (int)MenuChoice.one);
            ConsoleWrapper.WriteMenuLine("│Видалити вчителя зi списку    <{0}>     │", (int)MenuChoice.two);
            ConsoleWrapper.WriteMenuLine("│Редагувати данi про вчителя   <{0}>     │", (int)MenuChoice.three);
            ConsoleWrapper.WriteMenuLine("│Вивести список вчителiв       <{0}>     │", (int)MenuChoice.four);
            ConsoleWrapper.WriteMenuLine("│Вихiд                         <{0}>     │", (int)MenuChoice.exit);
            ConsoleWrapper.WriteLine("└──────────────────────────────────────┘");
            ConsoleWrapper.Write("  Оберiть пункт меню: ");
        }

        #endregion        
    }

    class AccountantList : ListApplication
    {
        public readonly int numberOfAccountants = 5;
        private Accountant[] accountantArray;

        #region AccountantList private methods

        private void CreateBaseList()
        {
            string[] name = new string[] { "Василь", "Микола", "Петро", "Оля", "Ніна" };
            string[] surname = new string[] { "Пупкін", "Савчук", "Туркін", "Грищук", "Карпова" };
            string[] thirdname = new string[] { "Миколайович", "Васильович", "Дмитрович", "Генадіївна", "Агапівна" };
            float[] salary = new float[] { 3100, 4100, 5020, 4300, 4020 };
            float[] tax = new float[] { 20, 20, 30, 30, 20 };
            string[] dates = new string[] { "02.04.1997", "12.08.1998", "02.06.1999", "13.03.2000", "04.05.2001" };

            for (int i = 0; i < numberOfAccountants; ++i)
            {
                Accountant tmp = new Accountant();
                tmp.Name = name[i];
                tmp.Surname = surname[i];
                tmp.ThirdName = thirdname[i];
                tmp.BirthDay = dates[i];
                tmp.Salary = salary[i];
                tmp.Tax = tax[i];
                accountantArray[i] = new Accountant(tmp);
            }
        }

        private void PrintTableHeader()
        {
            //--------------------------3--------14-------------14-------------14-------------15----------7---------7---
            ConsoleWrapper.WriteLine("┌───┬────────┬──────────────┬──────────────┬───────────────┬────────┬────────┐");
            ConsoleWrapper.WriteLine("│ № │  Iмя   │   Прiзвище   │ По батьковi  │Дата народження│Зарплата│Податок │");
            ConsoleWrapper.WriteLine("├───┼────────┼──────────────┼──────────────┼───────────────┼────────┼────────┤");
        }

        private void PrintTableBottomLine()
        {
            //--------------------------3--------14-------------14-------------14-------------15----------7---------7---
            ConsoleWrapper.WriteLine("└───┴────────┴──────────────┴──────────────┴───────────────┴────────┴────────┘");
        }

        private void PrintCurentAccountantData(ref Accountant accountantData, int i)
        {
            const int nameValue = 8;
            if (accountantData != null)
            {
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(i.ToString(), indexLength));
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(accountantData.Name, nameValue));
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(accountantData.Surname, nameSurnameThirdnameLength));
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(accountantData.ThirdName, nameSurnameThirdnameLength));
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(accountantData.BirthDay, birthDayLength));
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(accountantData.Salary.ToString(), nameValue));
                ConsoleWrapper.Write("│");
                ConsoleWrapper.Write(SetWordLength(accountantData.Tax.ToString(), nameValue));
                ConsoleWrapper.Write("│ \n");
            }
        }

        private Accountant GetAccountantData()
        {
            Accountant tmp = new Accountant();

            string format1 = "Введiть iмя: ";
            ConsoleWrapper.Write(format1);
            tmp.Name = ConsoleWrapper.ReadLine();

            string format2 = "Введiть прiзвище: ";
            ConsoleWrapper.Write(format2);
            tmp.Surname = ConsoleWrapper.ReadLine();

            string format3 = "Введiть по-батьковi: ";
            ConsoleWrapper.Write(format3);
            tmp.ThirdName = ConsoleWrapper.ReadLine();

            string format4 = "Введiть дату народження: ";
            ConsoleWrapper.Write(format4);
            tmp.BirthDay = ConsoleWrapper.ReadLine();

            string format5 = "Введiть заробітну плату: ";
            ConsoleWrapper.Write(format5);
            tmp.Salary = float.Parse(ConsoleWrapper.ReadLine());

            string format6 = "Введiть податок: ";
            ConsoleWrapper.Write(format6);
            tmp.Tax = float.Parse(ConsoleWrapper.ReadLine());

            return tmp;
        }

        #endregion

        #region AccountantList public methods

        public AccountantList(int numOfAccountant)
        {
            numberOfAccountants = numOfAccountant;
            accountantArray = new Accountant[numberOfAccountants];
        }

        public override bool AddToList()
        {
            CreateBaseList();
            return true;
        }

        public override bool DeleteFromList()
        {
            string format = "Введiть номер бухгалтера для видалення: ";
            int value = GetNumberBySomeRequest(format);
            if ((value >= 0) && (value <= numberOfAccountants))
            {
                Array.Clear(accountantArray, value, 1);
            }

            return true;
        }

        public override bool ModifyList()
        {
            bool state = false;
            string format = "Введіть номер бухгалтера для редагування: ";
            int value = GetNumberBySomeRequest(format);

            for (int i = 0; i < numberOfAccountants; ++i)
            {
                if (i == value)
                {
                    PrintTableHeader();
                    PrintCurentAccountantData(ref accountantArray[i], value + 1);
                    PrintTableBottomLine();
                    Accountant tmp = new Accountant();
                    tmp = GetAccountantData();
                    accountantArray[i] = new Accountant(tmp);
                    state = true;
                }
            }
            return state;
        }

        public override void Print()
        {
            PrintTableHeader();
            for (int i = 0; i < numberOfAccountants; ++i)
            {
                if (accountantArray[i] != null)
                {
                    PrintCurentAccountantData(ref accountantArray[i], i + 1);
                }
            }
            PrintTableBottomLine();
        }

        public override void Menu()
        {
            ConsoleWrapper.SetBackgroundColor(ConsoleWrapper.Color.Gray);
            ConsoleWrapper.SetTextColor(ConsoleWrapper.Color.DarkBlue);
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.WriteLine("┌──────────────────────────────────────┐");
            ConsoleWrapper.WriteMenuLine("│Додати бухгалтера до списку      <{0}>     │", (int)MenuChoice.one);
            ConsoleWrapper.WriteMenuLine("│Видалити бухгалтера зi списку    <{0}>     │", (int)MenuChoice.two);
            ConsoleWrapper.WriteMenuLine("│Редагувати данi про бухгалтера   <{0}>     │", (int)MenuChoice.three);
            ConsoleWrapper.WriteMenuLine("│Вивести список бухгалтерiв       <{0}>     │", (int)MenuChoice.four);
            ConsoleWrapper.WriteMenuLine("│Вихiд                         <{0}>     │", (int)MenuChoice.exit);
            ConsoleWrapper.WriteLine("└──────────────────────────────────────┘");
            ConsoleWrapper.Write("  Оберiть пункт меню: ");
        }

        #endregion
    }
        
    class Application
    {
        private bool exit = true;
        const int numberOfPeople = 5;

        private void Menu()
        {
            ConsoleWrapper.SetBackgroundColor(ConsoleWrapper.Color.Gray);
            ConsoleWrapper.SetTextColor(ConsoleWrapper.Color.DarkBlue);
            ConsoleWrapper.ClearConsole();
            ConsoleWrapper.WriteLine("┌──────────────────────────────────────┐");
            ConsoleWrapper.WriteMenuLine("│Список Учнiв               <{0}>        │", (int)MenuChoice.one);
            ConsoleWrapper.WriteMenuLine("│Список Вчителiв            <{0}>        │", (int)MenuChoice.two);
            ConsoleWrapper.WriteMenuLine("│Список Бухгалтерiв         <{0}>        │", (int)MenuChoice.three);
            ConsoleWrapper.WriteMenuLine("│Вихiд                      <{0}>        │", (int)MenuChoice.exit);
            ConsoleWrapper.WriteLine("└──────────────────────────────────────┘");
            ConsoleWrapper.Write("  Оберiть пункт меню: ");
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
                        PupilList myPup = new PupilList(numberOfPeople);
                        myPup.Run();
                    } break;
                case MenuChoice.two:
                    {
                        TeacherList myTeach = new TeacherList(numberOfPeople);
                        myTeach.Run();
                    } break;
                case MenuChoice.three:
                    {
                        AccountantList myBuh = new AccountantList(numberOfPeople);
                        myBuh.Run();
                    } break;
                default:
                    {
                       ConsoleWrapper.WriteLine("Hmm..");
                    } break;
            }
        }

        private void ExitApp()
        {
            ConsoleWrapper.WriteLine("Good bye");
            ConsoleWrapper.ReadKey();
            exit = false;
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
    }

}
