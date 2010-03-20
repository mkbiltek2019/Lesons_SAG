using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyASCIITank.MyTank;
using MyASCIITank.MyIDrawable;
using MyASCIITank.MyMunition;
using MyASCIITank.Colorize;

namespace MyASCIITank
{
    public class ASCIITank : Tank, IDrawable, IColorizedConsole
    {
        private string[] tankForwardImageTextLines = new string[] {
            @" |            ",
            @" |/----┐      ",
            @" /  453 \════(",
            @"═══════════   ",             
            @"(0o0o0o0o0)   "};
        private string[] tankBackwardImageTextLines = new string[] {
            @"            |  ",
            @"      ┌----\|  ",
            @")════/  453 \  ",
            @"    ═══════════",             
            @"    (0o0o0o0o0)"};

        public ASCIITank()
        {
            Top = 20;
            Left = 0;
            CurentDirection = MoveDirection.Forward;

            Draw();
        }

        public override void Move(MoveDirection direction)
        {
            CleanOut();

            switch (direction)
            {
                case MoveDirection.Backward:
                    if (Left > 0)
                        Left--;
                    break;
                case MoveDirection.Forward:
                    if (Left < (Console.WindowWidth - tankBackwardImageTextLines[0].Length) - 1)
                        Left++;
                    break;
            }

            CurentDirection = direction;
            Draw();
        }

        public void Fire(MunitionHandler munitionHandler)
        {
            munitionHandler.BeginInvoke(null, null);
        }

        #region IDrawable Members

        public int Top
        {
            get;
            set;
        }

        public int Left
        {
            get;
            set;
        }

        public void Draw()
        {
            string[] tankTextImageLines = new string[] { };
            switch (CurentDirection)
            {
                case MoveDirection.Forward:
                    tankTextImageLines = tankForwardImageTextLines;
                    break;
                case MoveDirection.Backward:
                    tankTextImageLines = tankBackwardImageTextLines;
                    break;
            }

            for (int currentLine = 0; currentLine < tankTextImageLines.Length; currentLine++)
            {
                SetColor(ConsoleColor.DarkGreen);

                Console.CursorLeft = Left;
                Console.CursorTop = Top + currentLine;
                Console.WriteLine(tankTextImageLines[currentLine]);
            }
        }

        public void CleanOut()
        {
            string[] tankTextImageLines = new string[] { };
            switch (CurentDirection)
            {
                case MoveDirection.Forward:
                    tankTextImageLines = tankForwardImageTextLines;
                    break;
                case MoveDirection.Backward:
                    tankTextImageLines = tankBackwardImageTextLines;
                    break;
            }

            for (int currentLine = 0; currentLine < tankTextImageLines.Length; currentLine++)
            {
                SetColor(ConsoleColor.Gray);

                Console.CursorLeft = Left;
                Console.CursorTop = Top + currentLine;
                Console.WriteLine(tankBackwardImageTextLines[currentLine]);
            }
        }

        #endregion

        #region IColorizedConsole members

        public void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        #endregion

    }
}
