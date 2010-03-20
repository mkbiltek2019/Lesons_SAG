using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MatrixHandler.MyMatrix
{
    public class MatrixOfDouble<T>
    {
        private ArrayList matrix = new ArrayList();

        public MatrixOfDouble(int rowCount, int colCount)
        {
            matrix = new ArrayList(rowCount);

            for (int i = 0; i < rowCount; i++)
            {
                ArrayList tmp = new ArrayList(colCount);                
                matrix.Add(tmp);
            }
        }
        
        public T this[int i, int j]
        {
            get
            {
                ArrayList tmp = new ArrayList();
                tmp = (ArrayList)matrix[i];
                return (T)tmp[j];
            }

            set
            {
                ArrayList tmp = new ArrayList();
                tmp = (ArrayList)matrix[i];
                tmp.Insert(j, value);
                matrix[i] = tmp;
            }
        }

        public int RowCount
        {
            get 
            {
                return matrix.Count;
            }
           
        }

        public int ColCount
        {
            get
            {
                ArrayList tmp = new ArrayList();
                tmp = (ArrayList)matrix[0];
                return tmp.Count;
            }

            set
            {
                ColCount = value;
            }
        }               
    }
}
