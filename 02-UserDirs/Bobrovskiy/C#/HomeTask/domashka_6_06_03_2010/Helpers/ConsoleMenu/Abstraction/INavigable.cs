using System;

namespace Helpers.Abstraction
{
    public interface INavigationKeys
    {
        ConsoleKey NextMenuItemKey
        {
            get;
            set;
        }

        ConsoleKey PreviousMenuItemKey
        {
            get;
            set;
        }

        ConsoleKey SelectMenuItemKey
        {
            get;
            set;
        }
    }
}
