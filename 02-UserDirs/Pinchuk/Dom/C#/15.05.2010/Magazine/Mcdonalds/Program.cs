using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Console;
using XmlReader;
namespace Mcdonalds
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerControler managerControler =new ManagerControler();
            Storehouse storehouse = new Storehouse();

            storehouse.mainMenu.PrintMenu();
            

        }
    }
}
