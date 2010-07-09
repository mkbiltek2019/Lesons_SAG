using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;

namespace TetrisLib
{
    public class GameField
    {
        static Color _background;
        static IntPtr _display;
        public static ObjectBoard _board = new ObjectBoard();
        public const int SquareSize = 10;
        public const int FieldBottomBound = 310;
        public const int FieldLeftBound = -10;
        public const int FieldRightBound = 160;
        public const int FieldTopBound = -50;
        public const int Slots = 16;


        static GameField()
        {
            Redraw();
        }

        public static void Initialize()
        {
            _board = new ObjectBoard();
            _display = IntPtr.Zero;
        }

        public static Color BackColor
        {
            get { return _background; }
            set { _background = value; }
        }

        public static IntPtr Field
        {
            get { return _display; }
            set { _display = value; }
        }

        public static bool IsEmpty(Square[] block)
        {
            foreach (Square square in block)
            {
                if (_board.Lines[square.Location.Y].IndexIsFull(square.Location.X))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsEmpty(Square[] block, Direction direction, int size)
        {
            try
            {
                switch (direction)
                {
                    case Direction.Left:
                        foreach (Square square in block)
                        {

                            if (_board.Lines[square.Location.Y].IndexIsFull(square.Location.X - size) || !IsEmpty(block))
                            {
                                return false;
                            }

                        }
                        break;
                    case Direction.Right:
                        foreach (Square square in block)
                        {

                            if (_board.Lines[square.Location.Y].IndexIsFull(square.Location.X + size) || !IsEmpty(block))
                            {
                                return false;
                            }

                        }
                        break;
                    case Direction.Down:
                       
                        foreach (Square square in block)
                        {

                            if (_board.Lines[square.Location.Y + size].IndexIsFull(square.Location.X))
                            {
                                return false;
                            }
                        }
                        break;
                }

                return true;
            }
            catch (Exception e)
            {
                string str = e.StackTrace;
                return false;
            }
        }

        public static void StopSquare(Square[] block)
        {
            foreach (Square square in block)
            {
                string name = string.Format("[{0}.{1}]", square.Location.X, square.Location.Y);
                if (!_board.Lines[square.Location.Y].IndexIsFull(square.Location.X))
                {
                    _board.Lines[square.Location.Y].AddSquare(square.Location.X, square);
                }
            }

        }

        public static int CheckLines()
        {
            int count = 0;
            for (int rank = GameField.FieldBottomBound - GameField.SquareSize; rank >= 0; rank -= GameField.SquareSize)
            {
                Line line = _board.Lines[rank];
                if (line.LineIsFull)
                {
                    _board.DemoteHigherLines(rank);
                    count++;
                }
            }
            Redraw();
            return count;
        }

        public static void Redraw()
        {
            Graphics surface = Graphics.FromHwnd(GameField.Field);
            surface.Clear(Color.White);
            foreach (Line line in _board.Lines)
            {
                foreach (Square square in line)
                {
                    square.Show(GameField.Field);
                }
            }
        }

        public static void Reset()
        {
            _board = new ObjectBoard();
        }

        public static ObjectBoard Board
        {
            get
            {
                return _board;
            }
        }

    }

    public class Line
    {
        SortedList squares = new SortedList();
        bool isFull = false;
        int id;

        public Line(int index)
        {
            this.id = index;
        }

        public void AddSquare(int index, Square square)
        {
            if (!squares.ContainsKey(index))
            {
                squares.Add(index, square);
                if (squares.Count == GameField.Slots + 2)
                    this.isFull = true;
            }
        }

        public Square this[int index]
        {
            get
            {
                return (Square)squares[index];
            }
        }

        public int SquareCount
        {
            get
            {
                return squares.Count;
            }
        }

        public bool IndexIsFull(int index)
        {
            if (squares.Contains(index))
                return true;
            else
                return false;
        }

        public bool LineIsFull
        {
            get
            {
                return this.isFull;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return squares.Values.GetEnumerator();
        }

        public void Lower()
        {
            foreach (Square sqr in this)
            {
                sqr.Down();
            }
        }

        public void RemoveSquare(int index)
        {
            squares.Remove(index);
        }


    }

    public class ObjectBoardLinesCollection
    {
        SortedList lines = new SortedList();

        public ObjectBoardLinesCollection(int bottom, int top)
        {

            for (int line = GameField.FieldTopBound; line <= GameField.FieldBottomBound; line += GameField.SquareSize)
            {
                lines.Add(line, new Line(line));
            }

            for (int x = GameField.FieldLeftBound; x < GameField.FieldRightBound; x += GameField.SquareSize)
            {

                this[bottom].AddSquare(x, new Square(Color.FromArgb(0, Color.Red), Color.FromArgb(0, Color.Red), new Size(30, 30)));
            }

           for (int x = GameField.FieldLeftBound; x < GameField.FieldRightBound; x += GameField.SquareSize)
            {

                this[top].AddSquare(x, new Square(Color.FromArgb(0, Color.Red), Color.FromArgb(0, Color.Red), new Size(30, 30)));
            }
        }


        public Line this[int line]
        {
            get
            {
                return (Line)lines[line];
            }
            set
            {
                lines[line] = value;
            }
        }

        public void ResetLine(int rank)
        {
            lines[rank] = new Line(rank);
        }

        public IEnumerator GetEnumerator()
        {
            return lines.Values.GetEnumerator();
        }
    }

    public class ObjectBoard
    {
        ObjectBoardLinesCollection lines = new ObjectBoardLinesCollection(GameField.FieldBottomBound, GameField.FieldTopBound);

        internal ObjectBoard()
        {

           for (int y = GameField.FieldTopBound; y < GameField.FieldBottomBound; y += GameField.SquareSize)
            {

                lines[y].AddSquare(GameField.FieldLeftBound, new Square(Color.FromArgb(0, Color.Red), Color.FromArgb(0, Color.Red), new Size(GameField.SquareSize, GameField.SquareSize)));
                lines[y].AddSquare(GameField.FieldRightBound, new Square(Color.FromArgb(0, Color.Red), Color.FromArgb(0, Color.Red), new Size(GameField.SquareSize, GameField.SquareSize)));
            }
        }

        public ObjectBoardLinesCollection Lines
        {
            get
            {
                return this.lines;
            }
        }

        public void DemoteHigherLines(int index)
        {
            for (int rank = index; rank >= 0; rank -= GameField.SquareSize)
            {
                int newRank = 0;
                if ((newRank = rank - GameField.SquareSize) >= 0)
                {
                    lines[rank] = null;
                    lines[rank] = lines[newRank];
                    lines[rank].Lower();
                }
            }
        }


    }
   
}
