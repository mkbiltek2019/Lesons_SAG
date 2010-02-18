using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TankDrawer
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

        public static void HideCursor()
        {
            System.Console.CursorVisible = false;
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

        protected void SetCursorPosition(int x, int y)
        {
            ConsoleWrapper.SetCursorLeft(x);
            ConsoleWrapper.SetCursorTop(y);
        }

        public void Draw(int x, int y, ConsoleColor figureColor)
        {
        }

        protected void SetFigureColor(ConsoleWrapper.Color simbolsColor, ConsoleWrapper.Color backgroundColor)
        {
            ConsoleWrapper.SetBackgroundColor(backgroundColor);
            ConsoleWrapper.SetTextColor(simbolsColor);
        }

        protected void Wait(int waitTime)
        {
            Thread.Sleep(waitTime);
        }
    }

    class ConsoleSquare : ConsoleFigure
    {
        public readonly int Width = 1;
        public readonly int Heigth = 1;

        public ConsoleSquare(int width, int height)
        {
            Width = width;
            Heigth = height;
        }

        public void DrawSquare(int x, int y, ConsoleWrapper.Color figureColor)
        {
            SetFigureColor(figureColor, figureColor);

            int prevTop = ConsoleWrapper.GetCursorTop();
            int prevLeft = ConsoleWrapper.GetCursorLeft();

            for (int i = 0; i < this.Width; ++i)
            {
                for (int j = 0; j < this.Heigth; ++j)
                {
                    ConsoleWrapper.Write("♦");
                }
                ConsoleWrapper.SetCursorTop(ConsoleWrapper.GetCursorTop() + 1);
                ConsoleWrapper.SetCursorLeft(prevLeft);
            }
        }

        public static void DrawSquare(int left, int top, int width, int height, ConsoleWrapper.Color figureColor)
        {
            ConsoleSquare mySquare = new ConsoleSquare(height, width);
            mySquare.DrawSquare(left, top, figureColor);
        }

    };

    class ConsoleTank
    {
        private enum Sizes { tankWidth = 4, tankHeight = 7, basePositionX = 40, basePositionY = 40 };
        private enum MooveSpeed { level1 = 1, level2 = 2, level3 = 3, level4 = 4 };
        private enum Direction { up = 1, down = 2, left = 3, right = 4 };
        private int curDirection = 1;

        private void SetBaseTankPosition()
        {
            SetCursorPosition((int)Sizes.basePositionX, (int)Sizes.basePositionY);
        }

        public void SetCursorPosition(int x, int y)
        {
            ConsoleWrapper.SetCursorLeft(x);
            ConsoleWrapper.SetCursorTop(y);
        }

        private void DrawClearTank(int left, int top)
        {
            ConsoleSquare.DrawSquare(left - 1, top - 1, 7, 7, ConsoleWrapper.Color.Gray);
            SetCursorPosition(left, top);
        }

        private void DrawColoredTankUp(int left, int top)
        {
            ConsoleSquare.DrawSquare(left, top, 5, 5, ConsoleWrapper.Color.Red);
            SetCursorPosition(left, top + 1);
            ConsoleSquare.DrawSquare(left, top, 1, 4, ConsoleWrapper.Color.DarkGreen);
            SetCursorPosition(left + 4, top + 1);
            ConsoleSquare.DrawSquare(left, top, 1, 4, ConsoleWrapper.Color.DarkGreen);
            SetCursorPosition(left + 2, top);
            ConsoleSquare.DrawSquare(left, top, 1, 3, ConsoleWrapper.Color.DarkGreen);
            SetCursorPosition(left + 1, top + 2);
            ConsoleSquare.DrawSquare(left, top, 3, 2, ConsoleWrapper.Color.DarkBlue);
            SetCursorPosition(left, top);
        }

        private void DrawColoredTankDown(int left, int top)
        {
            ConsoleSquare.DrawSquare(left, top, 5, 5, ConsoleWrapper.Color.Red);
            SetCursorPosition(left, top);
            ConsoleSquare.DrawSquare(left, top, 1, 4, ConsoleWrapper.Color.DarkGreen);
            SetCursorPosition(left + 4, top);
            ConsoleSquare.DrawSquare(left, top, 1, 4, ConsoleWrapper.Color.DarkGreen);
            SetCursorPosition(left + 2, top + 2);
            ConsoleSquare.DrawSquare(left, top, 1, 3, ConsoleWrapper.Color.DarkGreen);
            SetCursorPosition(left + 1, top + 1);
            ConsoleSquare.DrawSquare(left, top, 3, 2, ConsoleWrapper.Color.DarkBlue);
            SetCursorPosition(left, top);
        }

        private void DrawColoredTankRight(int left, int top)
        {
            ConsoleSquare.DrawSquare(left, top, 7, 5, ConsoleWrapper.Color.Red);
            SetCursorPosition(left, top);
            ConsoleSquare.DrawSquare(left, top, 5, 1, ConsoleWrapper.Color.DarkGreen);
            SetCursorPosition(left, top + 4);
            ConsoleSquare.DrawSquare(left, top, 5, 1, ConsoleWrapper.Color.DarkGreen);
            SetCursorPosition(left + 2, top + 2);
            ConsoleSquare.DrawSquare(left, top, 5, 1, ConsoleWrapper.Color.DarkGreen);
            SetCursorPosition(left + 1, top + 1);
            ConsoleSquare.DrawSquare(left, top, 3, 3, ConsoleWrapper.Color.DarkBlue);
            SetCursorPosition(left, top);
        }

        private void DrawColoredTankLeft(int left, int top)
        {
            ConsoleSquare.DrawSquare(left, top, 7, 5, ConsoleWrapper.Color.Red);
            SetCursorPosition(left + 2, top);
            ConsoleSquare.DrawSquare(left, top, 5, 1, ConsoleWrapper.Color.DarkGreen);
            SetCursorPosition(left + 2, top + 4);
            ConsoleSquare.DrawSquare(left, top, 5, 1, ConsoleWrapper.Color.DarkGreen);
            SetCursorPosition(left, top + 2);
            ConsoleSquare.DrawSquare(left, top, 5, 1, ConsoleWrapper.Color.DarkGreen);
            SetCursorPosition(left + 3, top + 1);
            ConsoleSquare.DrawSquare(left, top, 3, 3, ConsoleWrapper.Color.DarkBlue);
            SetCursorPosition(left, top);
        }

        private void DrawTank(int dir, int left, int top)
        {
            switch ((Direction)dir)
            {
                case Direction.up:
                    {
                        DrawColoredTankUp(left, top);
                    } break;
                case Direction.down:
                    {
                        DrawColoredTankDown(left, top);
                    } break;
                case Direction.left:
                    {
                        DrawColoredTankLeft(left, top);
                    } break;
                case Direction.right:
                    {
                        DrawColoredTankRight(left, top);
                    } break;
            }

        }

        private void SetColor(ConsoleWrapper.Color textColor, ConsoleWrapper.Color backgroundColor)
        {
            ConsoleWrapper.SetTextColor(textColor);
            ConsoleWrapper.SetBackgroundColor(backgroundColor);
        }

        private void SetDefaultColors()
        {
            SetColor(ConsoleWrapper.Color.DarkBlue, ConsoleWrapper.Color.Gray);
        }

        private void MooveTank(string key, int side)
        {
            const int border = 70;
            const int one = 1;

            switch (key)
            {
                case "W":
                    {
                        curDirection = (int)Direction.up;
                        if (ConsoleWrapper.GetCursorTop() >= side)
                            ConsoleWrapper.SetCursorTop(ConsoleWrapper.GetCursorTop() - one);
                    } break;
                case "S":
                    {
                        curDirection = (int)Direction.down;
                        if (ConsoleWrapper.GetCursorTop() < (border - side))
                            ConsoleWrapper.SetCursorTop(ConsoleWrapper.GetCursorTop() + one);
                    } break;
                case "A":
                    {
                        curDirection = (int)Direction.left;
                        if (ConsoleWrapper.GetCursorLeft() > one)
                            ConsoleWrapper.SetCursorLeft(ConsoleWrapper.GetCursorLeft() - one);
                    } break;
                case "D":
                    {
                        curDirection = (int)Direction.right;
                        if (ConsoleWrapper.GetCursorLeft() < (border + one))
                            ConsoleWrapper.SetCursorLeft(ConsoleWrapper.GetCursorLeft() + one);
                    } break;
            }
        }

        public void Draw()
        {
            ConsoleWrapper.ClearConsole();
            ConsoleKeyInfo cki;
            SetDefaultColors();
            int side = (int)Sizes.tankWidth;
            ConsoleWrapper.ClearConsole();
            string key = string.Empty;
            ConsoleWrapper.Write("Для виходу натиснiть (ESC) керування (W,S,A,D) ");

            SetBaseTankPosition();
            ConsoleWrapper.HideCursor();

            do
            {
                cki = ConsoleWrapper.ReadKey(true);
                key = cki.Key.ToString();
                int prevLeft1 = ConsoleWrapper.GetCursorLeft();
                int prevTop1 = ConsoleWrapper.GetCursorTop();
                DrawClearTank(prevLeft1, prevTop1);
                ConsoleWrapper.SetCursorTop(prevTop1);

                MooveTank(key, side);

                int prevLeft = ConsoleWrapper.GetCursorLeft();
                int prevTop = ConsoleWrapper.GetCursorTop();
                DrawTank(curDirection, prevLeft, prevTop);
                ConsoleWrapper.SetCursorTop(prevTop);

            } while (key != "Escape");

            ConsoleWrapper.ReadKey();
        }
    }
}