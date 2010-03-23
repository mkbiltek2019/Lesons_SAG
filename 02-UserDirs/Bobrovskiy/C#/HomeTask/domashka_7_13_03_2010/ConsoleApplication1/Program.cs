using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using MatrixHandler.MatrixMath;
using MatrixHandler.MyMatrix;
//------------------------------------
/* Завдання: Реалізувати клас матриця прямокутна, цілочисильна
 * 1) множення 2-х матриць
 * 2) множення матриці на число
 * 3) ділення матриці на число
 * 4) додати дві матриці
 * 5) відняти одну матрицю від іншої
 * 6) транспонувати матрицю
 * 7) описати індексатор
 */
//--------------------------------------

namespace ConsoleApplication1
{   
    class Program
    {
        public static void PrintMatrix(MatrixOfDouble<double> matrix)
        {
            System.Console.WriteLine("------------------------------------------------------------");
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColCount; j++)
                {
                    System.Console.Write("{0:F}\t", matrix[i, j]);
                }
                System.Console.Write("\n");
            }
            System.Console.WriteLine("------------------------------------------------------------");
        }

        static void Main(string[] args)
        {
            int rowCount = 3;
            int colCount = 3;

           // double[,] mm1 = new double[2, 2] { { 1, 3 }, { 1, 2 } };
           //  double[,] mm2 = new double[2, 3] { { 1, 2, 1}, { 3, 1, 0 } };

            double number = 5;
            Matrix2dMath matrixCalc = new Matrix2dMath();

            MatrixOfDouble<double> m1 = matrixCalc.CreateRandomMatrix(rowCount, colCount);//matrixCalc.InitializeWithArray(mm1, 2, 2);//
            MatrixOfDouble<double> m2 = matrixCalc.CreateRandomMatrix(rowCount, colCount);//matrixCalc.InitializeWithArray(mm2, 2, 3);//
            PrintMatrix(m1);
            PrintMatrix(m2);

            // System.Console.WriteLine("Sum of two matrix");
            // PrintMatrix(matrixCalc.AddTwoMatrix(m1, m2));

            //System.Console.WriteLine("divide matrix by number");
            //PrintMatrix(matrixCalc.DivideMatrixByNumber(m1, number));

            // System.Console.WriteLine("multiply matrix by number");
            //PrintMatrix(matrixCalc.MultiplyMatrixByNumber(number, m1));

            //System.Console.WriteLine("substract two matrix");
            //PrintMatrix(matrixCalc.SubtractTwoMatrix(m1, m2));

            // System.Console.WriteLine("Transpositioned matrix");
            // PrintMatrix(matrixCalc.MatrixTransposition(m2));
           
            System.Console.WriteLine("multiply two matrix");
            PrintMatrix(matrixCalc.MultiplyMatrix(m1, m2));

            System.Console.ReadKey();
        }
    }

}
