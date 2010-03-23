using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASCIITank
{
    class Program
    {
        static void Main(string[] args)
        {
            ASCIITank tank = new ASCIITank();

            bool exit = false;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.Clear();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow :
                        tank.Move(MoveDirection.Backward);
                        break;
                    case ConsoleKey.RightArrow :
                        tank.Move(MoveDirection.Forward);
                        break;
                    case ConsoleKey.Escape :
                        exit = true;
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
            Top = 0;
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