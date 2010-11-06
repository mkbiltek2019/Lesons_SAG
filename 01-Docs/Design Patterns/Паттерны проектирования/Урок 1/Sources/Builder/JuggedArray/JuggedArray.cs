using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuggedArray
{
    public class JuggedArray
    {
        private double[][] array;
        public JuggedArray(double[][] array)
        {
            this.array = array;
        }
        public double this [int row, int col]
        {
            get
            {
                return array[row][col]; 
            }
            set
            {
                array[row][col] = value;
            }
        }
        public int RowCount()
        {
            return array.Length;
        }
        public int RowSize(int row)
        {
            return array[row].Length;
        }
    }
}
