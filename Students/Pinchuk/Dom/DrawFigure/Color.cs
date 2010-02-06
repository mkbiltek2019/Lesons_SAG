using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrawFigure
{
    class Color:Figura
    {/*
        Black   Черный цвет. 
      * DarkBlue Темно-синий цвет. 
      * DarkGreen Темно-зеленый цвет. 
      * DarkCyan Темно-бирюзовый цвет (темный сине-зеленый). 
      * DarkRed Темно-красный цвет. 
      * DarkMagenta Темно-пурпурный цвет (темный пурпурно-красный). 
      * DarkYellow Темно-желтый цвет (коричнево-желтый). 
      * Gray Серый цвет. 
      * DarkGray Темно-серый цвет. 
      * Blue Синий цвет. 
      * Green Зеленый цвет. 
      * Cyan Бирюзовый цвет (сине-зеленый). 
      * Red Красный цвет. 
      * Magenta Пурпурный цвет (пурпурно-красный). 
      * Yellow Желтый цвет. 
      * White Белый цвет. */
        static public void SetColor(string str)
        {
            try
            {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), str);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

    }
}
