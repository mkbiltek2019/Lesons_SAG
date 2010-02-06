using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//----------------
/* Завдання
  На консолі намалювати кольоровий танк, маєрухатися і 
 * повертатися в різних напрямках
 */
namespace dom_2
{

    //---
    class Program
    {
        static void Main(string[] args)
        {
            //Tank myTank = new Tank();
            //myTank.draw();
            ConsoleTank myTank = new ConsoleTank();
            myTank.draw();
        }
    }
}
