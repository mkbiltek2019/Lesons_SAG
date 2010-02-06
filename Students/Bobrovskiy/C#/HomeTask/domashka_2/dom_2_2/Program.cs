using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* намалювати круг
 * розробити базовий клас фігура і унаслідувати від нього 
 * класи квадрат, круг, трикутник (усі фігури повинні задавати собі колір, координа, і вміли всебе малювати(виводити на консоль))    
 */
namespace dom_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConsoleSquare mySquare = new ConsoleSquare(5, 5);            
            //mySquare.drawSquare(10, 10, ConsoleColor.Red);
            ConsoleSquare.drawSquare(10, 9, 4, 7, ConsoleColor.Red);

            //ConsoleCircle myCircle = new ConsoleCircle(1);
            //myCircle.drawCircle(20, 20, ConsoleColor.DarkMagenta);
            ConsoleCircle.drawCircle(20, 10, 1, ConsoleColor.DarkMagenta);

            //ConsoleTriangle myTrian = new ConsoleTriangle(5);
            //myTrian.drawTriangle(25, 25, ConsoleColor.DarkGreen);

            ConsoleTriangle.drawTriangle(25, 25, 5, ConsoleColor.DarkGreen);

            Console.ReadKey();
        }
    }
}
