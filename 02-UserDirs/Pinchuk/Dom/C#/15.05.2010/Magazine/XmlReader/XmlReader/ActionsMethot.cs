using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Console;

namespace XmlReader
{
    public class ActionsMethot
    {
        public bool NextLevelMenu(ConsoleMenu consoleMenu)
        {

            string stringKey = string.Format("{0}.", consoleMenu.MenuItems[consoleMenu.SelectedIndex].Key);
            for (int i = 0; i < consoleMenu.MenuItems.Count; i++)
            {
                consoleMenu.MenuItems[i].Visible = false;
                if (consoleMenu.MenuItems[i].Key.Remove(consoleMenu.MenuItems[i].Key.Count() - 1) == stringKey)
                    consoleMenu.MenuItems[i].Visible = true;
            }
            return true;
        }

        public bool PrevLevelMenu(ConsoleMenu consoleMenu)
        {
            string thisActivString = consoleMenu.MenuItems[consoleMenu.SelectedIndex].Key;
            string stringKey = string.Format("{0}",
                consoleMenu.MenuItems[consoleMenu.SelectedIndex].Key.Remove(consoleMenu.MenuItems[consoleMenu.SelectedIndex].Key.Count() - 2));
            for (int i = 0; i < consoleMenu.MenuItems.Count; i++)
            {
                consoleMenu.MenuItems[i].Visible = false;
                if ((stringKey.Length == consoleMenu.MenuItems[i].Key.Length) && (thisActivString[0] == consoleMenu.MenuItems[i].Key[0]))
                    consoleMenu.MenuItems[i].Visible = true;
            }
            return true;
        }
        public bool MainMenu(ConsoleMenu consoleMenu)
        {
            for (int i = 0; i < consoleMenu.MenuItems.Count; i++)
            {
                consoleMenu.MenuItems[i].Visible = false;
                if ((1 == consoleMenu.MenuItems[i].Key.Length))
                    consoleMenu.MenuItems[i].Visible = true;
            }

            return true;
        }
        public bool Print(ConsoleMenu consoleMenu)
        {
            Console.Clear();
            Console.WriteLine("Print");
            Console.ReadKey();
            return true;
        }
        public bool Exit(ConsoleMenu consoleMenu)
        {
            Console.Clear();
            return false;
        }

    }
}
