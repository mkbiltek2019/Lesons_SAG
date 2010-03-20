using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrawFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = string.Empty;
            string color = string.Empty;
            Console.Write("Enter color:");
            color = Console.ReadLine();
            Console.Write("Enter figure <Triangle,Rectangle,Circle>:");
            figure = Console.ReadLine();
            Draw.DrawFigure(color, figure);
            
        }
    }
}
