using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace dom_2_2
{
    class ConsoleFigure
    {
        public int X
        {
            get;
            set;
        }
        public int Y
        {
            get;
            set;
        }
        public string FigureDescription
        {
            get;
            set;
        }
        protected void setCursorPosition(int x, int y)
        {
            System.Console.CursorLeft = x;
            System.Console.CursorTop = y;
        }
        public void draw(int x, int y, ConsoleColor figureColor)
        {
            setCursorPosition(x, y);
            setFigureColor(figureColor, figureColor);
            System.Console.Write("*");
            System.Console.CursorLeft = X;
            System.Console.CursorTop = Y;
            restoreConsoleColor();
        }
        protected void setFigureColor(ConsoleColor simbolsColor, ConsoleColor backgroundColor)
        {
            System.Console.ForegroundColor = simbolsColor;
            System.Console.BackgroundColor = backgroundColor;
        }
        protected void restoreConsoleColor() {
            System.Console.ResetColor();
        }
        protected void wait(int waitTime){
            Thread.Sleep(waitTime);
        }
    }
    //---
    class ConsoleSquare : ConsoleFigure 
    {
        public readonly int Width = 1;
        public readonly int Heigth = 1;

        public ConsoleSquare(int width, int height) {
            this.Width = width;
            this.Heigth = height;
        }

        public void drawSquare(int x, int y, ConsoleColor figureColor)
        {
            setCursorPosition(x, y);
            setFigureColor(figureColor, figureColor);

            int prevTop = System.Console.CursorTop;
            int prevLeft = System.Console.CursorLeft;            

            for (int i = 0; i < this.Width; ++i)
            {
                for (int j = 0; j < this.Heigth; ++j)
                {
                    System.Console.Write("♦");
                }                
                System.Console.CursorTop += 1;
                System.Console.CursorLeft = prevLeft;               
            }
            
            restoreConsoleColor();
        }

        public static void drawSquare(int left, int top, int width, int height,ConsoleColor figureColor) {
            ConsoleSquare mySquare = new ConsoleSquare(height, width);
            mySquare.drawSquare(left, top, figureColor);
        }

    };
    //--
    class ConsoleCircle : ConsoleFigure
    {         
        public readonly int circleRadius = 1;

        public ConsoleCircle(int radius) {
           circleRadius =  radius;
        }

        public void drawCircle(int circleCenterX, int circleCenterY, ConsoleColor figureColor)
        {
            setCursorPosition(circleCenterX, circleCenterY);
            setFigureColor(figureColor, figureColor);

            double theta = 0, increment = 0, xF = 0, pi = 3.14159;
            int x = 0, xN = 0, yN = 0;
            //--
            increment = 0.8 / (double)(circleRadius);

            for (theta = 0; theta <= pi / 2; theta += increment)
            {
                xF = (double)circleRadius * Math.Cos(theta);

                xN = (int)(xF * 2 / 1);

                yN = (int)(circleRadius * Math.Sin(theta) + 0.5);

                x = circleCenterX - xN;

                while (x <= circleCenterX + xN)
                {
                    setCursorPosition(x, circleCenterY - yN);
                    System.Console.Write("♦");

                    setCursorPosition(x++, circleCenterY + yN);
                    System.Console.Write("♦");
                }//while
            }//for              
 
            restoreConsoleColor();
        }

        public static void drawCircle(int circleCenterX, int circleCenterY, int radius, ConsoleColor figureColor)
        {
            ConsoleCircle myCircle = new ConsoleCircle(radius);
            myCircle.drawCircle(circleCenterX, circleCenterY, figureColor);
        }

    };
    //--
    class ConsoleTriangle : ConsoleFigure
    {
        public readonly int triangleHeight = 1;

        public ConsoleTriangle(int height)
         {
             triangleHeight = height;
        }

        public void drawTriangle(int xPos, int yPos, ConsoleColor figureColor)
        {
            setCursorPosition(xPos, yPos);
            setFigureColor(figureColor, figureColor);

            int x = 0, y = 0;
            for (y = yPos; y < yPos + triangleHeight; y++)
            {
                int incr = y - yPos;
                for (x = xPos - incr; x <= xPos + incr; x++)
                {
                    setCursorPosition(x, y);
                    System.Console.Write("♦");

                }//for
            }//for

            restoreConsoleColor();
        }

        public static void drawTriangle(int xPos, int yPos, int height, ConsoleColor figureColor) {
            ConsoleTriangle myTrian = new ConsoleTriangle(height);
            myTrian.drawTriangle(xPos, yPos, figureColor);
        }
    }

}
