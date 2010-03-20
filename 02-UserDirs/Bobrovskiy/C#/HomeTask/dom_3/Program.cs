using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleSimpleGraphicFigure;

namespace dom_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleRectangle myRect = new ConsoleRectangle();
            myRect.DrawFilledRectangle(15, 15, 3, 3, ConsoleColor.DarkGreen);
           
            ConsoleCircle myCircle = new ConsoleCircle();
            myCircle.drawCircle(10, 5, 1, ConsoleColor.DarkYellow);
            
            ConsoleTriangle myTri = new ConsoleTriangle();
            myTri.drawTriangle(20, 5, 5, ConsoleColor.DarkGreen);

            ConsoleWrapper.setCursorPosition(0, 30);
        }
    }
}
