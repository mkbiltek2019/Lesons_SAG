using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Helpers.Abstraction;
using System.Collections;


namespace Helpers.Console
{
    public delegate bool MenuFunctionHandler( ConsoleMenu consoleMenu );
    public class ConsoleMenu : IMenu
    {
        #region ConsoleMenuItem definition

        public class ConsoleMenuItem
        {
            #region Properties
            public MenuFunctionHandler Action { get; set; }
            public string Description { get; set; }
            public string Key { get; set; }
            public bool Visible { get; set; }

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

        public List<ConsoleMenuItem> MenuItems = new List<ConsoleMenuItem>();

        #endregion

        #region Properties


        public ConsoleMenuItem SelectedMenuItem
        {
            get { return MenuItems[SelectedIndex]; }
        }

        private int selectedIndex;
        public int SelectedIndex
        {
            get
            {
                if (selectedIndex > VisibleindexDown)
                {
                    selectedIndex = VisivbleIndexUp;
                }
                if (selectedIndex < VisivbleIndexUp)
                {
                    selectedIndex = VisibleindexDown;
                }
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;

            }
        }

        public ConsoleKey NextMenuItemKey { get; set; }
        public ConsoleKey PreviousMenuItemKey { get; set; }
        public ConsoleKey SelectMenuItemKey { get; set; }
        public int VisivbleIndexUp { get; set; }
        public int VisibleindexDown { get; set; }


        #endregion

        #region Constructors

        public ConsoleMenu(/*ConsoleMenuItem[] menuItems*/)
        {
            //this.MenuItems = MenuItems;
            NextMenuItemKey = ConsoleKey.DownArrow;
            PreviousMenuItemKey = ConsoleKey.UpArrow;
            SelectMenuItemKey = ConsoleKey.Enter;
        }

        #endregion

        #region Methods

        public void Display()
        {
            GetLimitMenu();
            while (true)
            {
                System.Console.Clear();
                WriteOutMenuItems();
                ConsoleKeyInfo pressedKeyInfo = System.Console.ReadKey(true);
                if (pressedKeyInfo.Key == NextMenuItemKey)
                {
                    SelectedIndex++;
                    if (!MenuItems[SelectedIndex].Visible)
                    {
                        while (!MenuItems[SelectedIndex].Visible)
                        {
                            SelectedIndex++;
                        }

                    }

                }

                else
                {
                    if (pressedKeyInfo.Key == PreviousMenuItemKey)
                    {
                        SelectedIndex--;

                        if (!MenuItems[SelectedIndex].Visible)
                        {
                            while (!MenuItems[SelectedIndex].Visible)
                            {
                                SelectedIndex--;
                            }

                        }
                    }


                    else if (pressedKeyInfo.Key == SelectMenuItemKey)
                    {

                        if (!MenuItems[SelectedIndex].Action(this))
                            break;

                        GetLimitMenu();
                        SelectedIndex = MenuItems.Count() + 1;
                    }

                    else
                    {
                        System.Console.Clear();
                        System.Console.WriteLine(
                           "Incorrect input.Use keys:\n{0} for next menu item\n{1} for previous menu item\n{2} for selection",
                           NextMenuItemKey,
                           PreviousMenuItemKey,
                           SelectMenuItemKey);
                        System.Console.WriteLine("Press any to continue..");
                        System.Console.ReadKey(true);
                    }
                }
            }
        }

        private void GetLimitMenu()
        {
            for (int i = 0; i < MenuItems.Count(); i++)
            {
                if (MenuItems[i].Visible)
                {
                    VisivbleIndexUp = i;
                    break;
                }
            }
            for (int i = MenuItems.Count() - 1; i > 0; i--)
            {
                if (MenuItems[i].Visible)
                {
                    VisibleindexDown = i;
                    break;
                }
            }
        }

        private void WriteOutMenuItems()
        {
            System.Console.Clear();
            int i = 0;
            foreach (ConsoleMenuItem menuItem in MenuItems)
            {
                System.Console.ForegroundColor = ConsoleColor.Green;

                if (menuItem.Visible)
                {
                    if (i == SelectedIndex)
                    {
                        System.Console.BackgroundColor = ConsoleColor.Blue;
                        // break;
                    }
                    System.Console.WriteLine(menuItem);
                    System.Console.ResetColor();

                } i++;
            }
        }
        #endregion
    }

}
