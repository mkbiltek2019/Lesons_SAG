using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Helpers.Abstraction;
using System.Collections;
using Helpers.CycleQueueDef;


namespace Helpers.Console
{
    public enum MenuResult
    {
        Proceed = 1,
        Exit = 0
    }

    public enum MyConsoleKeys
    {
        NextMenuItemKey = ConsoleKey.UpArrow,
        PreviousMenuItemKey = ConsoleKey.DownArrow,
        SelectMenuItemKey = ConsoleKey.Enter
    }

    public class MenuItemUniquityException : Exception
    {
        public MenuItemUniquityException()
            : base("Error. Menu Items must be unique.")
        {
        }
    }

    public class ConsoleMenu : IMenu, INavigationKeys
    {
        #region Private Fields

        private CycleQueue queueOfMenuIndex;
        private ArrayList menuItems = new ArrayList();
        private MenuFunctionHandler[] menuFunctionHandlers;
        private int selectedIndex;

        #endregion

        #region Properties

        private bool exit = true;

        private int SelectedIndex
        {
            get
            {
                if (selectedIndex >= menuItems.Count)
                {
                    selectedIndex = 0;
                }
                if (selectedIndex < 0)
                {
                    selectedIndex = menuItems.Count - 1;
                }

                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
            }
        }

        public ConsoleMenuItem SelectedMenuItem
        {
            get
            {
                return (ConsoleMenuItem)menuItems[SelectedIndex];
            }
        }

        public ConsoleKey NextMenuItemKey
        {
            get;
            set;
        }

        public ConsoleKey PreviousMenuItemKey
        {
            get;
            set;
        }

        public ConsoleKey SelectMenuItemKey
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        public ConsoleMenu(ArrayList menuItems)
        {
            this.menuItems = menuItems;
            CheckMenuItemsUniquity();
        }

        #endregion

        #region Methods

        private void CheckMenuItemsUniquity()
        {
            for (int i = 0; i < menuItems.Count - 1; i++)
            {
                for (int j = i + 1; j < menuItems.Count; j++)
                {
                    if (((ConsoleMenuItem)menuItems[i]).Key == (((ConsoleMenuItem)menuItems[j]).Key))
                    {
                        throw new MenuItemUniquityException();
                    }
                }
            }
        }

        private void GeatingShow()
        {
            System.Console.WriteLine("┌───────────────────────────────────────────┐");
            System.Console.WriteLine("│ Вiтаємо вас в закладi швидкого харчування │");
            System.Console.WriteLine("│              МАКДОНАЛЬДЗ                  │");
            System.Console.WriteLine("└───────────────────────────────────────────┘");
        }

        public MenuResult Display()
        {
            System.Console.CursorVisible = false;

            while (true)
            {                
                System.Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.Clear();
                System.Console.ForegroundColor = ConsoleColor.DarkBlue;
                GeatingShow();
                WriteOutMenuItems();
                MenuResult myRes = MenuResult.Proceed;
                ConsoleKeyInfo pressedKeyInfo = System.Console.ReadKey(true);

                switch ((MyConsoleKeys)pressedKeyInfo.Key)
                {
                    case MyConsoleKeys.NextMenuItemKey:
                        {
                            --SelectedIndex;
                        } break;
                    case MyConsoleKeys.PreviousMenuItemKey:
                        {
                            ++SelectedIndex;
                        } break;
                    case MyConsoleKeys.SelectMenuItemKey:
                        {
                            myRes = ((ConsoleMenuItem)menuItems[SelectedIndex]).Action();
                        } break;
                }

                if (myRes == MenuResult.Exit)
                {
                    break;
                }
            }

            return MenuResult.Proceed;
        }

        private void ColorizeMenuItem(int index)
        {
            if (index == SelectedIndex)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                System.Console.ForegroundColor = ConsoleColor.DarkBlue;
            }
        }

        private void WriteOutMenuItems()
        {
            int index = 0;

            foreach (ConsoleMenuItem menuItem in menuItems)
            {
                ColorizeMenuItem(index);

                if (menuItem.Visible)
                {
                    System.Console.WriteLine(menuItem);
                    ++index;
                }
            }
        }

        #endregion
    }
}
