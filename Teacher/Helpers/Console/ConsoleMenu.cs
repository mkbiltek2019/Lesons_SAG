using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Helpers.Abstraction;
using System.Collections;


namespace Helpers.Console
{
    public class ConsoleMenu : IMenu
    {
        #region ConsoleMenuItem definition

        public class ConsoleMenuItem
        {
            #region Properties

            public string Description
            {
                get;
                set;
            }
            
            public string Key
            {
                get;
                set;
            }

            public bool Visible
            {
                get;
                set;
            }

            #endregion

            #region Constructors 

            public ConsoleMenuItem() :
                this(string.Empty, string.Empty, false)
            { }

            public ConsoleMenuItem(string description, string key, bool visible)
            {
                Description = description;
                Key = key;
                Visible = visible;
            }

            #endregion

            #region Overrides

            public override string ToString()
            {
                return string.Format("{0}. {1}", Key, Description);
            }

            #endregion
        }

        #endregion


        #region Private Fields

        private ConsoleMenuItem[] menuItems;

        #endregion

        #region Properties

        public ConsoleMenuItem[] MenuItems
        {
            get { return menuItems; }
        }

        public ConsoleMenuItem SelectedMenuItem
        {
            get
            {
                return menuItems[SelectedIndex];
            }
        }

        private int selectedIndex;
        private int SelectedIndex
        {
            get
            {
                if (selectedIndex >= menuItems.Length)
                {
                    selectedIndex = 0;
                }
                if (selectedIndex < 0)
                {
                    selectedIndex = menuItems.Length - 1;
                }

                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
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

        public ConsoleMenu(ConsoleMenuItem[] menuItems)
        {
            this.menuItems = menuItems;
        }

        #endregion

        #region Methods

        public void Display()
        {
            while (true)
            {
                WriteOutMenuItems();
                ConsoleKeyInfo pressedKeyInfo = System.Console.ReadKey(true);
                // Как заставить это работать? Закомментрованый код менять нельзя.
                //switch (pressedKeyInfo.Key)
                //{
                //    case NextMenuItemKey:
                //        SelectedIndex++;
                //        break;
                //    case PreviousMenuItemKey:
                //        SelectedIndex--;
                //        break;
                //    case SelectMenuItemKey:
                //        throw new NotImplementedException();
                //        break;
                //    default:
                //}

                if (pressedKeyInfo.Key == NextMenuItemKey)
                    SelectedIndex++;
                else if (pressedKeyInfo.Key == PreviousMenuItemKey)
                    SelectedIndex--;
                else if (pressedKeyInfo.Key == SelectMenuItemKey)
                    throw new NotImplementedException();
                else System.Console.WriteLine(
                    "Incorrect input.Use keys:\n{0} for next menu item\n{1} for previous menu item\n{2} for selection", 
                    NextMenuItemKey, 
                    PreviousMenuItemKey, 
                    SelectMenuItemKey);
            }
        }

        private void WriteOutMenuItems()
        {
            foreach (ConsoleMenuItem menuItem in menuItems)
            {
                if (menuItem.Visible)
                {
                    System.Console.WriteLine(menuItem);
                }
            }
        }

        #endregion
    }
}
