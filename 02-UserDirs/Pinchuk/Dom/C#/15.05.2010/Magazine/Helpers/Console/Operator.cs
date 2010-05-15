using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers.Console
{
    public class OperatorArray : ConsoleMenu.ConsoleMenuItem
    {
        static public bool ArrayRepl(ConsoleMenu.ConsoleMenuItem[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (i != j)
                    {
                        if (arr[i].Key == arr[j].Key)
                        {
                            return false;
                        }
                    }
                }

            }
            return true;
        }
    }
}
