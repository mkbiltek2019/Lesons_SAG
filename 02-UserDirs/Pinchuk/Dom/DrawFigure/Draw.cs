using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrawFigure
{
    class Draw:Figura
    {
        static public void DrawFigure(string color, string figure)
        {
            Color.SetColor(color);
        
            switch (figure)
            {
                case "Triangle":
                    Triangle();
                    break;
                case "Rectangle":
                    Rectangle();
                    break;
                case "Circle":
                    Circle();
                    break;
                default:
                    break;
            }
            Console.ResetColor();
        }
    }
}
