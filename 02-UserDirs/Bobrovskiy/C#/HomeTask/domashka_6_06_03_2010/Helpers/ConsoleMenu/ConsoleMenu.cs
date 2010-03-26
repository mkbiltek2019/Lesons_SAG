using System;

using Helpers.Abstraction;
using System.Collections;
using Helpers.ConsoleMenu.Abstraction;

namespace Helpers.ConsoleMenu
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

        private readonly ArrayList _menuItems = new ArrayList();
        private int _selectedIndex;

        #endregion

        #region Properties

        private int SelectedIndex
        {
            get
            {
                if (_selectedIndex >= _menuItems.Count)
                {
                    _selectedIndex = 0;
                }
                if (_selectedIndex < 0)
                {
                    _selectedIndex = _menuItems.Count - 1;
                }

                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
            }
        }

        public ConsoleMenuItem SelectedMenuItem
        {
            get
            {
                return (ConsoleMenuItem)_menuItems[SelectedIndex];
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
            _menuItems = menuItems;
            CheckMenuItemsUniquity();
        }

        #endregion

        #region Methods

        private void CheckMenuItemsUniquity()
        {
            for (int i = 0; i < _menuItems.Count - 1; i++)
            {
                for (int j = i + 1; j < _menuItems.Count; j++)
                {
                    if (((ConsoleMenuItem)_menuItems[i]).Key == (((ConsoleMenuItem)_menuItems[j]).Key))
                    {
                        throw new MenuItemUniquityException();
                    }
                }
            }
        }

        private void GeatingShow()
        {
            Console.WriteLine("┌───────────────────────────────────────────┐");
            Console.WriteLine("│ Вiтаємо вас в закладi швидкого харчування │");
            Console.WriteLine("│              МАКДОНАЛЬДЗ                  │");
            Console.WriteLine("└───────────────────────────────────────────┘");
        }

        public MenuResult Display(string s)
        {
            Console.CursorVisible = false;

            while (true)
            {                
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                GeatingShow();
                WriteOutMenuItems();
                MenuResult myRes = MenuResult.Proceed;
                ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);

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
                            myRes = ((ConsoleMenuItem)_menuItems[SelectedIndex]).Action(string.Empty);
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
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }
        }

        private void WriteOutMenuItems()
        {
            int index = 0;

            foreach (ConsoleMenuItem menuItem in _menuItems)
            {
                ColorizeMenuItem(index);

                if (menuItem.Visible)
                {
                    Console.WriteLine(menuItem);
                    ++index;
                }
            }
        }

        #endregion
    }
}