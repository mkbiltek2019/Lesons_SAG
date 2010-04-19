using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Man
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 100;
            Menu consoleMenu = new Menu();
            consoleMenu.MainMenu = new string[] { "   Student   ", "   Teacher   ", "   Accountant   ", "   Print all   ","   Parse XML   ", "   Exit   " };
            Menu subMenu = new Menu();
            subMenu.MainMenu = new string[] { "   ADD   ", "   EDIT   ", "   PRINT   ", "   DELETE   ", "   DELETE ALL   ", "   <-BACK   " };
            int exitMainMenu = 0;
            Man mainMan = new Man();
            do
            {

                switch (consoleMenu.ShowMenu(consoleMenu.MainMenu, "MENU"))
                {
                    case -1:
                        exitMainMenu = -1;
                        break;
                    case 0:
                        do
                        {                            
                            exitMainMenu = Menu.SubMenu(mainMan, subMenu, "STUDENT", exitMainMenu);
                        } while (exitMainMenu != -1);
                        exitMainMenu = 0;
                        break;
                    case 1:
                        do
                        {
                            exitMainMenu = Menu.SubMenu(mainMan, subMenu, "TEACHER", exitMainMenu);
                        } while (exitMainMenu != -1);
                        exitMainMenu = 0;
                        break;
                    case 2:
                        do
                        {
                            exitMainMenu = Menu.SubMenu(mainMan, subMenu, "ACCOUNTANT", exitMainMenu);
                        } while (exitMainMenu != -1);
                        exitMainMenu = 0;
                        break;
                    case 3:
                        Print.PrintAll(mainMan);
                        break;
                    case 4:
                        ParseXML.CreateXML(mainMan);
                        break;
                    default:
                        break;
                }

            } while (exitMainMenu != -1);

        }
    }
}
