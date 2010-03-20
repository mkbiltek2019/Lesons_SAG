using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace dom_2_2
{
    public static class ConsoleWrapper
    {
        public enum Color
        {
            Black = 0, DarkBlue = 1, DarkGreen = 2,
            DarkCyan = 3, DarkRed = 4, DarkMagenta = 5,
            DarkYellow = 6, Gray = 7, DarkGray = 8,
            Blue = 9, Green = 10, Cyan = 11,
            Red = 12, Magenta = 13, Yellow = 14,
            White = 15,
        };

        private static int prevTop;
        private static int prevLeft;

        public static void SetCursorPosition(int left, int top)
        {
            prevTop = top;
            prevLeft = left;
            SetCursorTop(top);
            SetCursorLeft(left);
        }

        public static void SetCursorTop(int top)
        {
            System.Console.CursorTop = top;
        }

        public static void SetCursorLeft(int left)
        {
            System.Console.CursorLeft = left;
        }

        public static int GetCursorLeft()
        {
            return System.Console.CursorLeft;
        }

        public static int GetCursorTop()
        {
            return System.Console.CursorTop;
        }

        public static void RestoreCursorPosition()
        {
            System.Console.CursorLeft = prevLeft;
            System.Console.CursorTop = prevTop;
        }

        public static void RestoreCursorLeft()
        {
            System.Console.CursorLeft = prevLeft;
        }

        public static void RestoreCursorTop()
        {
            System.Console.CursorTop = prevTop;
        }

        public static void ClearConsole()
        {
            System.Console.Clear();
        }

        public static void WriteMenuLine(string formatedString, int value)
        {
            System.Console.WriteLine(formatedString, value);
        }

        public static void WriteMenuLine(string formatedString, int value1, int value2)
        {
            System.Console.WriteLine(formatedString, value1, value2);
        }

        public static void WriteMenuLine(string formatedString, string someText)
        {
            System.Console.WriteLine(formatedString, someText);
        }

        public static void WriteLine(string text)
        {
            System.Console.WriteLine(text);
        }

        public static void Write(string text)
        {
            System.Console.Write(text);
        }

        public static void Write(char ch)
        {
            System.Console.Write(ch);
        }

        public static void Write(string formatedString, int value1, int value2, int value3)
        {
            System.Console.Write(formatedString, value1, value2, value3);
        }

        public static void Write(int value)
        {
            System.Console.Write("{0}", value);
        }

        public static void ReadKey()
        {
            System.Console.ReadKey();
        }

        public static ConsoleKeyInfo ReadKey(bool value)
        {
            return System.Console.ReadKey(value);
        }

        public static string ReadLine()
        {
            return System.Console.ReadLine();
        }

        public static void SetColor(ConsoleWrapper.Color color)
        {
            SetTextColor(color);
            SetBackgroundColor(color);
        }

        public static void SetTextColor(ConsoleWrapper.Color color)
        {
            System.Console.ForegroundColor = (ConsoleColor)color;
        }

        public static void SetBackgroundColor(ConsoleWrapper.Color color)
        {
            System.Console.BackgroundColor = (ConsoleColor)color;
        }
    }

    public class ConsoleFigure
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

        protected ConsoleFigure()
        {
            FigureDescription = "Figure";
        }

        protected void SetCursorPosition(int x, int y)
        {
            ConsoleWrapper.SetCursorLeft(x);
            ConsoleWrapper.SetCursorTop(y);
            X = ConsoleWrapper.GetCursorLeft();
            Y = ConsoleWrapper.GetCursorTop();
        }

        public void Draw(int x, int y, ConsoleWrapper.Color figureColor)
        {          
        }

        public void SetFigureColor(ConsoleWrapper.Color figureColor)
        {
            ConsoleWrapper.SetColor(figureColor);
        }
    }

    public class ConsoleSquare : ConsoleFigure
    {
        public readonly int Width = 1;
        public readonly int Heigth = 1;
       
        public ConsoleSquare()
        {
            FigureDescription = "Console Square";
        }

        public ConsoleSquare(int width, int height)
        {
            Width = width;
            Heigth = height;
            FigureDescription = "Console Square";
        }

        public new void Draw(int x, int y, ConsoleWrapper.Color figureColor)
        {
            SetCursorPosition(x, y);
            SetFigureColor(figureColor);
            int prevTop = ConsoleWrapper.GetCursorTop();
            int prevLeft = ConsoleWrapper.GetCursorLeft();

            for (int i = 0; i < Width; ++i)
            {
                for (int j = 0; j < Heigth; ++j)
                {
                    ConsoleWrapper.Write("♦");
                }
                ConsoleWrapper.SetCursorTop(ConsoleWrapper.GetCursorTop() + 1);
                ConsoleWrapper.SetCursorLeft(prevLeft);
            }
        }

        public static void Draw(int left, int top, int width, int height, ConsoleWrapper.Color figureColor)
        {
            ConsoleSquare mySquare = new ConsoleSquare(height, width);
            mySquare.Draw(left, top, figureColor);
        }

    };

    public class ConsoleCircle : ConsoleFigure
    {
        public readonly int circleRadius = 1;

        public ConsoleCircle(int radius)
        {
            circleRadius = radius;
            FigureDescription = "Console Circle";
        }

        public new void Draw(int circleCenterX, int circleCenterY, ConsoleWrapper.Color figureColor)
        {
            SetCursorPosition(circleCenterX, circleCenterY);
            SetFigureColor(figureColor);
            double theta = 0;
            double increment = 0;
            double xF = 0;
            int x = 0;
            int xN = 0;
            int yN = 0;
            const float param = 0.8F;
            const int two = 2;
            const float half = 0.5F;
            increment = param / (double)(circleRadius);

            for (theta = 0; theta <= Math.PI / two; theta += increment)
            {
                xF = (double)circleRadius * Math.Cos(theta);
                xN = (int)(xF * two / 1);
                yN = (int)(circleRadius * Math.Sin(theta) + half);
                x = circleCenterX - xN;
                while (x <= circleCenterX + xN)
                {
                    SetCursorPosition(x, circleCenterY - yN);
                    ConsoleWrapper.Write("♦");
                    SetCursorPosition(x++, circleCenterY + yN);
                    ConsoleWrapper.Write("♦");
                }
            }
        }

        public static void Draw(int circleCenterX, int circleCenterY, int radius, ConsoleWrapper.Color figureColor)
        {
            ConsoleCircle myCircle = new ConsoleCircle(radius);
            myCircle.Draw(circleCenterX, circleCenterY, figureColor);
        }

    };

    public class ConsoleTriangle : ConsoleFigure
    {
        public readonly int triangleHeight = 1;

        public ConsoleTriangle(int height)
        {
            triangleHeight = height;
            FigureDescription = "Console Triangle";
        }

        public new void Draw(int xPos, int yPos, ConsoleWrapper.Color figureColor)
        {
            SetCursorPosition(xPos, yPos);
            SetFigureColor(figureColor);
            int x = 0;
            int y = 0;

            for (y = yPos; y < yPos + triangleHeight; ++y)
            {
                int incr = y - yPos;
                for (x = xPos - incr; x <= xPos + incr; ++x)
                {
                    SetCursorPosition(x, y);
                    ConsoleWrapper.Write("♦");
                }
            }            
        }

        public static void Draw(int xPos, int yPos, int height, ConsoleWrapper.Color figureColor)
        {
            ConsoleTriangle myTrian = new ConsoleTriangle(height);
            myTrian.Draw(xPos, yPos, figureColor);
        }
    }

}
