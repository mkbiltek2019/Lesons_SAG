using System;
using System.Collections;

namespace MultyDimensionalIndexer
{

    public class A
    {
        private int[,] arr;
        private int rows, cols;

        public int Rows
        {
            get { return rows; }
        }

        public int Cols
        {
            get { return cols; }
        }

        public A(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            arr = new int[rows, cols];
        }

        public int this[int r, int c]
        {
            get { return arr[r, c]; }
            set { arr[r, c] = value; }

        }
    }
    public class Tester
    {
        static void Main()
        {
            A obj = new A(2, 3);


            for (int i = 0; i < obj.Rows; i++)
            {
                for (int j = 0; j < obj.Cols; j++)
                {
                    obj[i, j] = i + j;
                    Console.Write(obj[i, j].ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
