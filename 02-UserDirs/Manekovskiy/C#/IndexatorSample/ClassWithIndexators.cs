using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndexatorSample
{
    public class ClassWithIndexators
    {
        private const int maxSize = 10;
        private int[] innerValues = new int[maxSize];
        private int[,] matrix = new int[maxSize, maxSize];


        public ClassWithIndexators()
        {
            Random random = new Random();
            for (int i = 0; i < maxSize; i++)
            {
                innerValues[i] = random.Next(byte.MinValue, byte.MaxValue);

                for (int j = 0; j < maxSize; j++)
                {
                    matrix[i, j] = random.Next(byte.MinValue, byte.MaxValue);
                }
            }
        }

        public int Length
        {
            get
            {
                return innerValues.Length;
            }
        }

        public int this[int index]
        {
            get
            {
                return innerValues[index];
            }
            set
            {
                innerValues[index] = value;
            }
        }

        public int this[int row, int column]
        {
            get
            {
                return matrix[row, column];
            }
        }

        public int this[string row, string column]
        {
            get
            {
                if (row == "first")
                {
                    return matrix[1, int.Parse(column)];
                }
                return matrix[int.Parse(row), int.Parse(column)];
            }
        }
    }
}
