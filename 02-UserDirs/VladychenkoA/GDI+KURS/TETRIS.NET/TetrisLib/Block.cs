using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TetrisLib
{
    public delegate void SquareStoppedEventHandler();
    public delegate void SquareMoveEventHandler(Point newLoc);
   
    public class Block : GameItem
    {
        public event SquareStoppedEventHandler squareStopped;
        public event SquareMoveEventHandler squareMove;
        Square[] squares;
        Color[] backColors = new Color[] { Color.Red, Color.Blue, Color.Red, Color.Yellow, Color.Green, Color.White, Color.Black, Color.DarkMagenta };
        Color[] foreColors = new Color[] { Color.Purple, Color.LightBlue, Color.Yellow, Color.Red, Color.LightGreen, Color.Black, Color.White, Color.Tomato };
        BlockType type;
        readonly int squareSize;
        Rotation rotation = Rotation.Nort;
        bool stopped = false;

        public Block(Point location, BlockType type)
        {
            this.location = location;
            this.squareSize = GameField.SquareSize;
            squares = new Square[4];
            this.type = type;
            CreateSquares();
        }

        public Block(Point location)
        {
            this.location = location;
            this.squareSize = GameField.SquareSize;
            squares = new Square[4];
            Randomize();
        }



        #region methods

        public void Randomize()
        {
            Random r = new Random();
            int next = r.Next(7);
            if (next == 7)
                next = 6;
            type = (BlockType)next;
            this.CreateSquares();
        }

        private void CreateSquares()
        {
            squares[0] = new Square(foreColors[(int)type], backColors[(int)type], new Size(squareSize, squareSize));
            squares[1] = new Square(foreColors[(int)type], backColors[(int)type], new Size(squareSize, squareSize));
            squares[2] = new Square(foreColors[(int)type], backColors[(int)type], new Size(squareSize, squareSize));
            squares[3] = new Square(foreColors[(int)type], backColors[(int)type], new Size(squareSize, squareSize));

           switch (type)
            {

                case BlockType.J:
                    squares[0].Location = this.location;
                    squares[1].Location = UpOne();
                    squares[2].Location = DownOne();
                    squares[3].Location = LeftOneDownOne();
                    break;
                case BlockType.L:
                    squares[0].Location = this.location;
                    squares[1].Location = UpOne();
                    squares[2].Location = DownOne();
                    squares[3].Location = RightOneDownOne();
                    break;
                case BlockType.Z:
                    squares[0].Location = this.location;
                    squares[1].Location = LeftOne();
                    squares[2].Location = DownOne();
                    squares[3].Location = RightOneDownOne();
                    break;
                case BlockType.SQUARE:
                    squares[0].Location = this.location;
                    squares[1].Location = RightOne();
                    squares[2].Location = DownOne();
                    squares[3].Location = RightOneDownOne();
                    break;
                case BlockType.T:
                    squares[0].Location = this.location;
                    squares[1].Location = RightOne();
                    squares[2].Location = LeftOne();
                    squares[3].Location = DownOne();
                    break;
                case BlockType.S:
                    squares[0].Location = this.location;
                    squares[1].Location = RightOne();
                    squares[2].Location = DownOne();
                    squares[3].Location = LeftOneDownOne();
                    break;
                case BlockType.LINE:
                    squares[0].Location = this.location;
                    squares[1].Location = UpOne();
                    squares[2].Location = DownOne();
                    squares[3].Location = DownTwo();
                    break;
            }
        }

        public bool Down()
        {
            if (GameField.IsEmpty(this.squares, Direction.Down, squareSize))
            {
                Hide(GameField.Field);
                foreach (Square square in squares)
                {
                    square.Location = new Point(square.Location.X, square.Location.Y + squareSize);
                }
                this.location = squares[0].Location;
                Show(GameField.Field);
                if (this.squareMove != null)
                    squareMove(squares[0].Location);

                return true;
            }
            else
            {
                GameField.StopSquare(this.squares);
                if (this.squareStopped != null)
                    squareStopped();

                stopped = true;
                return false;
            }
        }

        public bool Right()
        {
            if (GameField.IsEmpty(this.squares, Direction.Right, squareSize))
            {
                Hide(GameField.Field);
                foreach (Square square in squares)
                {
                    square.Location = new Point(square.Location.X + squareSize, square.Location.Y);

                }
                this.location = squares[0].Location;
                Show(GameField.Field);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Left()
        {
            if (GameField.IsEmpty(this.squares, Direction.Left, squareSize))
            {
                Hide(GameField.Field);
                foreach (Square square in squares)
                {
                    square.Location = new Point(square.Location.X - squareSize, square.Location.Y);
                }
                this.location = squares[0].Location;
                Show(GameField.Field);
                return true;
            }
            else
                return false;
        }

        private void RotateJ(Rotation rot)
        {
            switch (rot)
            {
                case Rotation.Nort:
                    squares[0].Location = this.location;
                    squares[1].Location = UpOne();
                    squares[2].Location = DownOne();
                    squares[3].Location = LeftOneDownOne();
                    break;
                case Rotation.East:
                    squares[0].Location = this.location;
                    squares[1].Location = RightOne();
                    squares[2].Location = LeftOne();
                    squares[3].Location = LeftOneUpOne();
                    break;
                case Rotation.South:
                    squares[0].Location = this.location;
                    squares[1].Location = UpOne();
                    squares[2].Location = UpOneRightOne();
                    squares[3].Location = DownOne();
                    break;
                case Rotation.West:
                    squares[0].Location = this.location;
                    squares[1].Location = LeftOne();
                    squares[2].Location = RightOne();
                    squares[3].Location = RightOneDownOne();
                    break;
            }
        }

        private void RotateL(Rotation rot)
        {
            switch (rot)
            {
                case Rotation.Nort:
                    squares[0].Location = this.location;
                    squares[1].Location = UpOne();
                    squares[2].Location = DownOne();
                    squares[3].Location = RightOneDownOne();
                    break;
                case Rotation.East:
                    squares[0].Location = this.location;
                    squares[1].Location = RightOne();
                    squares[2].Location = LeftOne();
                    squares[3].Location = LeftOneDownOne();
                    break;
                case Rotation.South:
                    squares[0].Location = this.location;
                    squares[1].Location = UpOne();
                    squares[2].Location = UpOneLeftOne();
                    squares[3].Location = DownOne();
                    break;
                case Rotation.West:
                    squares[0].Location = this.location;
                    squares[1].Location = LeftOne();
                    squares[2].Location = RightOne();
                    squares[3].Location = UpOneRightOne();
                    break;
            }
        }

        private void RotateZ(Rotation rot)
        {
            switch (rot)
            {
                case Rotation.Nort:
                    squares[0].Location = this.location;
                    squares[1].Location = UpOne();
                    squares[2].Location = UpOneLeftOne();
                    squares[3].Location = RightOne();
                    break;
                case Rotation.East:
                    squares[0].Location = this.location;
                    squares[1].Location = RightOne();
                    squares[2].Location = UpOneRightOne();
                    squares[3].Location = DownOne();
                    break;
                case Rotation.South:
                    squares[0].Location = this.location;
                    squares[1].Location = UpOne();
                    squares[2].Location = UpOneLeftOne();
                    squares[3].Location = RightOne();
                    break;
                case Rotation.West:
                    squares[0].Location = this.location;
                    squares[1].Location = RightOne();
                    squares[2].Location = UpOneRightOne();
                    squares[3].Location = DownOne();
                    break;
            }
        }

        private void RotateS(Rotation rot)
        {
            switch (rot)
            {
                case Rotation.Nort:
                    squares[0].Location = this.location;
                    squares[1].Location = RightOne();
                    squares[2].Location = DownOne();
                    squares[3].Location = LeftOneDownOne();
                    break;
                case Rotation.East:
                    squares[0].Location = this.location;
                    squares[1].Location = LeftOne();
                    squares[2].Location = UpOneLeftOne();
                    squares[3].Location = DownOne();
                    break;
                case Rotation.South:
                    squares[0].Location = this.location;
                    squares[1].Location = RightOne();
                    squares[2].Location = DownOne();
                    squares[3].Location = LeftOneDownOne();
                    break;
                case Rotation.West:
                    squares[0].Location = this.location;
                    squares[1].Location = LeftOne();
                    squares[2].Location = UpOneLeftOne();
                    squares[3].Location = DownOne();
                    break;
            }
        }

        private void RotateT(Rotation rot)
        {
            switch (rot)
            {
                case Rotation.Nort:
                    squares[0].Location = this.location;
                    squares[1].Location = RightOne();
                    squares[2].Location = LeftOne();
                    squares[3].Location = DownOne();
                    break;
                case Rotation.East:
                    squares[0].Location = this.location;
                    squares[1].Location = UpOne();
                    squares[2].Location = DownOne();
                    squares[3].Location = LeftOne();
                    break;
                case Rotation.South:
                    squares[0].Location = this.location;
                    squares[1].Location = RightOne();
                    squares[2].Location = LeftOne();
                    squares[3].Location = UpOne();
                    break;
                case Rotation.West:
                    squares[0].Location = this.location;
                    squares[1].Location = UpOne();
                    squares[2].Location = DownOne();
                    squares[3].Location = RightOne();
                    break;
            }
        }

        private void RotateLine(Rotation rot)
        {
            switch (rot)
            {
                case Rotation.Nort:
                    squares[0].Location = this.location;
                    squares[1].Location = UpOne();
                    squares[2].Location = DownOne();
                    squares[3].Location = DownTwo();
                    break;
                case Rotation.East:
                    squares[0].Location = this.location;
                    squares[1].Location = LeftOne();
                    squares[2].Location = RightOne();
                    squares[3].Location = RightTwo();
                    break;
                case Rotation.South:
                    squares[0].Location = this.location;
                    squares[1].Location = UpOne();
                    squares[2].Location = DownOne();
                    squares[3].Location = DownTwo();
                    break;
                case Rotation.West:
                    squares[0].Location = this.location;
                    squares[1].Location = LeftOne();
                    squares[2].Location = RightOne();
                    squares[3].Location = RightTwo();
                    break;
            }
        }



        public void Rotate()
        {
            if (!stopped)
            {
                Point old1 = squares[0].Location;
                Point old2 = squares[1].Location;
                Point old3 = squares[2].Location;
                Point old4 = squares[3].Location;
                Rotation oldRot = this.rotation;

                Hide(GameField.Field);

               int newRot = 0;
                if ((newRot = ((int)rotation) + 1) > 4)
                {
                    newRot = 1;
                }
                rotation = (Rotation)newRot;

                switch (type)
                {
                    case BlockType.J:
                        RotateJ(rotation);
                        Revert(old1, old2, old3, old4, oldRot);
                        break;
                    case BlockType.L:
                        RotateL(rotation);
                        Revert(old1, old2, old3, old4, oldRot);
                        break;
                    case BlockType.Z:
                        RotateZ(rotation);
                        Revert(old1, old2, old3, old4, oldRot);
                        break;
                    case BlockType.SQUARE:
                        break;
                    case BlockType.T:
                        RotateT(rotation);
                        Revert(old1, old2, old3, old4, oldRot);
                        break;
                    case BlockType.S:
                        RotateS(rotation);
                        Revert(old1, old2, old3, old4, oldRot);
                        break;
                    case BlockType.LINE:
                        RotateLine(rotation);
                        Revert(old1, old2, old3, old4, oldRot);
                        break;
                }

                Show(GameField.Field);
            }

        }

       
        private void Revert(Point old1, Point old2, Point old3, Point old4, Rotation oldRot)
        {
            if (!GameField.IsEmpty(this.squares))
            {
                squares[0].Location = old1;
                squares[1].Location = old2;
                squares[2].Location = old3;
                squares[3].Location = old4;
                this.rotation = oldRot;
            }
        }

        public void Show(IntPtr hwnd)
        {
            Graphics surface = Graphics.FromHwnd(hwnd);
            foreach (Square square in squares)
            {
                square.Show(hwnd);
            }
        }

        public void Hide(IntPtr hwnd)
        {
            Graphics surface = Graphics.FromHwnd(hwnd);
            foreach (Square square in squares)
            {
                square.Hide(hwnd);
            }

        }

        private Point UpOne()
        {
            return new Point(this.location.X, this.location.Y - squareSize);
        }

        private Point UpOneRightOne()
        {
            return new Point(this.location.X + squareSize, this.location.Y - squareSize);
        }

        private Point UpOneLeftOne()
        {
            return new Point(this.location.X - squareSize, this.location.Y - squareSize);
        }

        private Point DownOne()
        {
            return new Point(this.location.X, this.location.Y + squareSize);
        }

        private Point DownTwo()
        {
            return new Point(this.location.X, this.location.Y + (squareSize * 2));
        }

        Point DownTwoRightOne()
        {
            return new Point(this.location.X + squareSize, this.location.Y + (squareSize * 2));
        }

        Point DownTwoLeftOne()
        {
            return new Point(this.location.X - squareSize, this.location.Y + (squareSize * 2));
        }

        private Point DownThree()
        {
            return new Point(this.location.X, this.location.Y + (squareSize * 3));
        }

        private Point RightOne()
        {
            return new Point(this.location.X + squareSize, this.location.Y);
        }

        private Point RightTwo()
        {
            return new Point(this.location.X + (squareSize * 2), this.location.Y);
        }

        private Point RightThree()
        {
            return new Point(this.location.X + (squareSize * 3), this.location.Y);
        }

        private Point RightOneDownOne()
        {
            return new Point(this.location.X + squareSize, this.location.Y + squareSize);
        }

        private Point RightTwoDownOne()
        {
            return new Point(this.location.X + (squareSize * 2), this.location.Y + squareSize);
        }

        private Point LeftOne()
        {
            return new Point(this.location.X - squareSize, this.location.Y);
        }

        private Point LeftTwo()
        {
            return new Point(this.location.X - (squareSize * 2), this.location.Y);
        }

        private Point LeftThree()
        {
            return new Point(this.location.X - (squareSize * 3), this.location.Y);
        }

        Point LeftOneDownOne()
        {
            return new Point(this.location.X - squareSize, this.location.Y + squareSize);
        }

        Point LeftOneUpOne()
        {
            return new Point(this.location.X - squareSize, this.location.Y - squareSize);
        }

        Point LeftTwoDownOne()
        {
            return new Point(this.location.X - (squareSize * 2), this.location.Y + squareSize);
        }


        #endregion

        #region properties

        public int Top
        {
            get
            {
                return Math.Min(Math.Min(squares[0].Location.Y, squares[1].Location.Y), Math.Min(squares[2].Location.Y, squares[3].Location.Y));
            }
        }

        public Rotation CurrentRotation
        {
            get
            {
                return this.rotation;
            }
        }
        public Square SquareOne
        {
            get { return squares[0]; }
        }

        public Square SquareTwo
        {
            get { return squares[1]; }
        }

        public Square SquareThree
        {
            get { return squares[2]; }
        }

        public Square SquareFour
        {
            get { return squares[3]; }
        }

        public BlockType BlkType
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
                this.CreateSquares();
            }
        }
        #endregion
    }
}
