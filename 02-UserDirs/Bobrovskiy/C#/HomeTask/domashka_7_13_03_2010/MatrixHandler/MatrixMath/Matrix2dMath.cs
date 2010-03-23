using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using MatrixHandler.MyMatrix;

namespace MatrixHandler.MatrixMath
{
    public class Matrix2dMath
    {
        private double positive = 1.0;
        private double negative = -1.0;
        private double zero = 0.0;

        public MatrixOfDouble<double> MultiplyMatrix(MatrixOfDouble<double> leftMatrix, MatrixOfDouble<double> rightMatrix)
        {
            MatrixOfDouble<double> result = new MatrixOfDouble<double>(leftMatrix.ColCount, rightMatrix.RowCount);

            if (leftMatrix.ColCount == rightMatrix.RowCount)
            {
                for (int i = 0; i < leftMatrix.RowCount; i++)
                {
                    for (int j = 0; j < rightMatrix.ColCount; j++)
                    {
                        double tmp = 0;
                        for (int k = 0; k < leftMatrix.RowCount; k++)
                        {
                            tmp += leftMatrix[i, k] * rightMatrix[k, j];                            
                        }
                            result[i, j] = tmp;
                    }
                }
            }

            return result;
        }

        public MatrixOfDouble<double> MultiplyMatrixByNumber(double number, MatrixOfDouble<double> matrix)
        {
            MatrixOfDouble<double> result = new MatrixOfDouble<double>(matrix.RowCount, matrix.ColCount);

            for (int row = 0; row < matrix.RowCount; row++)
            {
                for (int col = 0; col < matrix.ColCount; col++)
                {
                    result[row, col] = (number * matrix[row, col]);
                }
            }

            return result;
        }

        public MatrixOfDouble<double> DivideMatrixByNumber(MatrixOfDouble<double> matrix, double number)
        {
            MatrixOfDouble<double> result = new MatrixOfDouble<double>(matrix.RowCount, matrix.ColCount);

            if (number != zero)
            {
                result = MultiplyMatrixByNumber(positive / number, matrix);
            }

            return result;
        }

        public MatrixOfDouble<double> AddTwoMatrix(MatrixOfDouble<double> left, MatrixOfDouble<double> right)
        {
            //matrix must have the same dimention
            MatrixOfDouble<double> result = new MatrixOfDouble<double>(left.RowCount, left.ColCount);

            if ((left.RowCount == right.RowCount) && (left.ColCount == right.ColCount))
            {
                for (int row = 0; row < left.RowCount; row++)
                {
                    for (int col = 0; col < left.ColCount; col++)
                    {
                        result[row, col] = left[row, col] + right[row, col];
                    }
                }
            }

            return result;
        }

        public MatrixOfDouble<double> SubtractTwoMatrix(MatrixOfDouble<double> left, MatrixOfDouble<double> right)
        {
            return AddTwoMatrix(left, MultiplyMatrixByNumber(negative, right));
        }

        public MatrixOfDouble<double> MatrixTransposition(MatrixOfDouble<double> matrix)
        {
            MatrixOfDouble<double> result = new MatrixOfDouble<double>(matrix.ColCount, matrix.RowCount);
            //check !!!!!!!!!!
            for (int row = 0; row < matrix.RowCount; row++)
            {
                for (int col = 0; col < matrix.ColCount; col++)
                {
                    result[col, row] = matrix[row, col];
                }
            }
            return result;
        }

        public MatrixOfDouble<double> CreateRandomMatrix(int rowCount, int colCount)
        {
            MatrixOfDouble<double> temp = new MatrixOfDouble<double>(rowCount, colCount);
            
            Random r = new Random((int)DateTime.Now.Ticks);
            Thread.Sleep(5);

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    temp[i, j] = r.Next(6);// r.NextDouble() + r.Next(6);
                }
            }

            return temp;
        }

        public MatrixOfDouble<double> InitializeWithArray(double[,] array2d, int rowCount, int colCount)
        {
            MatrixOfDouble<double> temp = new MatrixOfDouble<double>(rowCount, colCount);

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    temp[i, j] = array2d[i, j];
                }
            }
            return temp;
        }
    }
}
