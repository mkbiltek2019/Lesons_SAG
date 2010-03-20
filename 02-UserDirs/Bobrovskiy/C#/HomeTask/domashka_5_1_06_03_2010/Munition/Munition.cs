using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using MyASCIITank.MyIDrawable;
using MyASCIITank.MyTank;
using MyASCIITank.Colorize;

namespace MyASCIITank.MyMunition
{
    public delegate void MunitionHandler();

    public class Munition : IDrawable, IColorizedConsole
    {
        private string munitionForwardImageText = @"■■►";
        private string munitionBackwardImageText = @"◄■■";

        private const int topMargin = 2;
        private const int leftMargin = 14;
        private const int backwardMargin = 6;

        #region Munition Properties

        public int ShootLength
        {
            get;
            set;
        }

        public MoveDirection CurentDirection
        {
            get;
            set;
        }

        #endregion

        public Munition(int munitionTop, int munitionLeft, MoveDirection direction, int shootLength)
        {
            Top = munitionTop;
            Left = munitionLeft;
            CurentDirection = direction;
            ShootLength = shootLength;
        }

        public void Moove()
        {
            for (int i = 0; i < ShootLength; ++i)
            {
                switch (CurentDirection)
                {
                    case MoveDirection.Forward:
                        Left += i;
                        break;
                    case MoveDirection.Backward:
                        Left -= i;
                        break;
                }

                Top -= 1; //parabola

                if ((Left < Console.WindowWidth) && (Top < Console.WindowHeight) && (Top > 0) && (Left > 0))
                {
                    Console.CursorLeft = Left;
                    Console.CursorTop = Top;
                    Draw();
                }
                else
                {
                    ClearOut();
                    break;
                }

                Thread.Sleep(100);
                Console.CursorLeft -= munitionBackwardImageText.Length;
                ClearOut();
                Console.CursorLeft += munitionBackwardImageText.Length;
            }
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
            string munitionTextImage = string.Empty;
            switch (CurentDirection)
            {
                case MoveDirection.Forward:
                    munitionTextImage = munitionForwardImageText;
                    break;
                case MoveDirection.Backward:
                    munitionTextImage = munitionBackwardImageText;
                    break;
            }

            SetColor(ConsoleColor.DarkRed);
            Console.Write(munitionTextImage);
        }

        public void ClearOut()
        {
            string munitionTextImage = string.Empty;
            switch (CurentDirection)
            {
                case MoveDirection.Forward:
                    munitionTextImage = munitionForwardImageText;
                    break;
                case MoveDirection.Backward:
                    munitionTextImage = munitionBackwardImageText;
                    break;
            }

            SetColor(ConsoleColor.Gray);

            Console.Write(munitionTextImage);
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
