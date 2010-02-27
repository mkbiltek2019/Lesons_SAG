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

        private int selectedIndex = 0;
        private int SelectedIndex
        {
            get
            {
                //if (selectedIndex > menuItems.Length)
                //{
                //    selectedIndex = 0;
                //}
                //if (selectedIndex < 0)
                //{
                //    selectedIndex = menuItems.Length - 1;
                //}

                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
                if (selectedIndex > CountVisibleMenu - 1)
                {
                    selectedIndex = 0;
                }
                if (selectedIndex < 0)
                {
                    selectedIndex = CountVisibleMenu - 1;
                }
            }
        }

        public ConsoleKey NextMenuItemKey { get; set; }
        public ConsoleKey PreviousMenuItemKey { get; set; }
        public ConsoleKey SelectMenuItemKey { get; set; }
        private int countVisibleMenu;

        public int CountVisibleMenu
        {
            get
            {
                countVisibleMenu = 0;
                foreach (ConsoleMenuItem menuItem in menuItems)
                {
                    if (menuItem.Visible)
                    {
                        countVisibleMenu++;
                    }
                }
                return countVisibleMenu;
            }
            set { countVisibleMenu = value; }
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
                ActionDelegate action = new ActionDelegate(ActioMenu);
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
                    action();
                else
                {
                    System.Console.Clear();
                    System.Console.WriteLine(
                       "Incorrect input.Use keys:\n{0} for next menu item\n{1} for previous menu item\n{2} for selection",
                       NextMenuItemKey,
                       PreviousMenuItemKey,
                       SelectMenuItemKey);
                    System.Console.WriteLine("Press anu to continue..");
                    System.Console.ReadKey(true);
                }
            }
        }

        private void WriteOutMenuItems()
        {
            System.Console.Clear();
            int i = 0;
            foreach (ConsoleMenuItem menuItem in menuItems)
            {

                if (menuItem.Visible)
                {


                    if (i == selectedIndex)
                        System.Console.BackgroundColor = ConsoleColor.Blue;
                    System.Console.WriteLine(menuItem);
                    System.Console.ResetColor();
                    i++;

                }


            }
        }

        private void ActioMenu()
        {
            System.Console.Clear();
            switch (SelectedIndex)
            {
                case 0:
                    System.Console.WriteLine("case 0");
                    System.Console.ReadKey();

                    break;

                case 1:
                    System.Console.WriteLine("case 1");
                    System.Console.ReadKey();
                    break;
                case 3:
                    System.Console.WriteLine("case 3");
                    System.Console.ReadKey();
                    break;
                case 2:
                    System.Console.Write("New UP:");
                    ConsoleKeyInfo keyInfo = System.Console.ReadKey(true);
                    PreviousMenuItemKey = keyInfo.Key;
                    System.Console.Write("\nNew DOWN:");
                    keyInfo = (ConsoleKeyInfo)System.Console.ReadKey(true);
                    NextMenuItemKey = keyInfo.Key;
                    System.Console.WriteLine("\nPress anu to continue..");
                    System.Console.ReadKey(true);
                    break;
            }
            // System.Console.WriteLine("case 0");
        }

        #endregion

    }
    public delegate void ActionDelegate();

}
