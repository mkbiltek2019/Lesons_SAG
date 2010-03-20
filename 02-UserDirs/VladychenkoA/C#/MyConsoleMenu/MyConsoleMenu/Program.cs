using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Helpers.Abstraction;
using Helpers.Console;
using Helpers.CircleQueueAndMenuItem;

namespace MyConsoleMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleMenu mainMenu = new ConsoleMenu(
                 new ConsoleMenuItem[] 
                {
                    new ConsoleMenuItem() { Key = "1", Description = "Print hello world", Visible = true },
                    new ConsoleMenuItem() { Key = "2", Description = "Print goodbye world", Visible = true },
                    new ConsoleMenuItem() { Key = "3", Description = "Exit from menu", Visible = true }
                }
            );

            mainMenu.NextMenuItemKey = ConsoleKey.DownArrow;
            mainMenu.PreviousMenuItemKey = ConsoleKey.UpArrow;
            mainMenu.SelectMenuItemKey = ConsoleKey.Enter;

            mainMenu.Display();
        }
    }
}
