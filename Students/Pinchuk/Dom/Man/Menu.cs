using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Man
{
   class Menu
    {
        public string[] MainMenu {get;set;}
        public int ShowMenu(  string [] str, string title)
        {
            int select = 0;
            int dySelect = 0;
            ConsoleKeyInfo keyPress;
            do
            {
                Console.WriteLine("\n     - {0} -\n   ",title);
                for (int i = 0; i < str.Length; i++)
                {
                    if (i == select)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.WriteLine(str[i]);
                    Console.ResetColor();
                }
                keyPress = Console.ReadKey(false);
                switch (keyPress.Key)
                {   
                    case ConsoleKey.UpArrow:
                        dySelect = -1;
                        break;
                    case ConsoleKey.DownArrow:
                        dySelect = 1;
                        break;
                    default:
                        dySelect = 0;
                        break;
                }
                select += dySelect;
                if (select > str.Length-1)
                {
                    select = 0;
                }
                if (select < 0)
                {
                    select = str.Length-1;
                }
                Console.Clear();
            } while (keyPress.Key!=ConsoleKey.Enter);
            if (select==str.Length-1)
            {
                select = -1;
            }
            return select; 
        }
       public void Wait()
       {
           Console.Write("Press any key...");
           Console.ReadKey();
       }
       static public int SubMenu(Man mainMan,Menu subMenu, string str, int exitMainMenu)
       {
           switch (subMenu.ShowMenu(subMenu.MainMenu, str))
           {
               case -1:
                   exitMainMenu = -1;
                   break;
               case 0:
                   mainMan.CreateListStudent(mainMan,str);
                   break;
               case 1:
                   mainMan.Edit(mainMan,str);
                   break;
               case 2:
                   Print.PrintInfo(mainMan, str);
                   break;
               case 3:
                   mainMan.DelIndex(mainMan, str);
                   break;
               case 4:
                   switch (str)
                   {
                       case "STUDENT":
                           mainMan.ListStudent.Clear();
                           break;
                       case "TEACHER":
                           mainMan.ListTeacher.Clear();
                           break;
                       case "ACCOUNTANT":
                           mainMan.ListAccountant.Clear();
                           break;
                       default:
                           break;
                   }
                   Print.Proces("DELETE");
                   break;
               default:
                   break;
           }

           return exitMainMenu;
       }
    }
}
