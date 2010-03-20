using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ASCIITank
{
    class Program
    {
        static void Main(string[] args)
        {
            const  int shootLength = 50;
            ASCIITank tank = new ASCIITank();
            bool exit = false;

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.Clear();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        tank.Move(MoveDirection.Backward);
                        break;
                    case ConsoleKey.RightArrow:
                        tank.Move(MoveDirection.Forward);
                        break;
                    case ConsoleKey.Enter:
                        tank.Draw();
                        Munition bullet = new Munition(tank.Top, tank.Left, tank.CurentDirection, shootLength);
                        tank.Fire(new MunitionHandler(bullet.Moove));
                        break;
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                    default:
                        tank.Draw();
                        break;
                }

            } while (!exit);
        }
    }

    public enum MoveDirection
    {
        Forward,
        Backward
    }

    public interface IDrawable
    {
        int Top
        {
            get;
        }
        int Left
        {
            get;
        }

        void Draw();
    }

    public abstract class MilitariMachine
    {
        public MoveDirection CurentDirection
        {
            get;
            set;
        }

        public virtual void Move()
        {
            Move(CurentDirection);
        }

        public abstract void Move(MoveDirection direction);
        public abstract void Fire();
    }

    public abstract class Tank : MilitariMachine
    {
        public override void Move(MoveDirection direction) { }

        public override void Fire() { }
    }

    public delegate void MunitionHandler();

    public delegate void DrawHandler(Munition munition);

    public class Munition : IDrawable
    {
        private string munitionForwardImageText = @"■■►";
        private string munitionBackwardImageText = @"◄■■";
        private const int topMargin = 2;
        private const int leftMargin = 14;
        private const int backwardMargin = 6;

        public Munition(int tankTop, int tankLeft, MoveDirection direction, int shootLength)
        {
            Top = tankTop + topMargin;
            Left = tankLeft + leftMargin;

            CurentDirection = direction;
            ShootLength = shootLength;
        }

        public void Moove()
        {
            switch (CurentDirection) // korect draw in backward direction
            {
                case MoveDirection.Backward:
                    Left = Left - leftMargin - backwardMargin;
                    break;
            }

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
                Thread.Sleep(100);
                if ((Left < Console.WindowWidth) && (Top < Console.WindowHeight) && (Top > 0) && (Left > 0))
                {
                    Console.CursorLeft = Left;
                    Console.CursorTop = Top;
                }
                else
                {
                    break;
                }

                Draw();
            }
        }

        public void Fire()
        {
        }

        #region IDrawable Members

        public int Top
        {
            get;
            set;
        }

        public int ShootLength
        {
            get;
            set;
        }

        public int Left
        {
            get;
            set;
        }

        public MoveDirection CurentDirection
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(munitionTextImage);

        }

        #endregion
    }

    public class ASCIITank : Tank, IDrawable
    {
        private string[] tankForwardImageTextLines = new string[] {
            @" |            ",
            @" |/----\      ",
            @" /  453 \====(",
            @" ========     ",             
            @"(0o0o0o0o0)   "};
        private string[] tankBackwardImageTextLines = new string[] {
            @"            |  ",
            @"      /----\|  ",
            @")====/  453 \  ",
            @"     ========  ",             
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
            switch (direction)
            {
                case MoveDirection.Backward:
                    Left--;
                    break;
                case MoveDirection.Forward:
                    Left++;
                    break;
            }

            CurentDirection = direction;
            Draw();
        }

        public void Fire(MunitionHandler munitionHandler)
        {
            munitionHandler.Invoke();
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
                Console.CursorLeft = Left;
                Console.CursorTop = Top + currentLine;
                Console.WriteLine(tankTextImageLines[currentLine]);
            }
        }

        #endregion
    }

}