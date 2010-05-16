using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MatrixMultiply
{
    public partial class Form1 : Form
    {
        Matrix X =
                  new Matrix(2.0f, 1.0f, 1.0f, 2.0f, 0.0f, 1.0f);
        Matrix Y =
                 new Matrix(0.0f, 1.0f, -2.0f, 0.0f, 2.0f, 0.0f);
        public Form1()
        {
            InitializeComponent();
            // инициализируем елементы Lebel
            InitializeLebels();
        }

        private void InitializeLebels()
        {
            string matrix1 = null;
            string matrix2 = null;
            // создаем новые временные матрицы
            Matrix m1 = new Matrix();
            m1 = X;
            Matrix m2 = new Matrix();
            m2 = Y;
            // производим чтение из матрицы
            for (int i = 0; i < m1.Elements.Length; i++)
            {
                matrix1 += m1.Elements[i].ToString();
                matrix1 += ", ";
            }
            lblMatrix1.Text = matrix1.Trim(' ', ',');
            // производим чтение из матрицы
            for (int i = 0; i < m2.Elements.Length; i++)
            {
                matrix2 += m2.Elements[i].ToString();
                matrix2 += ", ";
            }
            lblMatrix2.Text = matrix2.Trim(' ', ',');
        }

        private void mnuMultiply_Click(object sender, EventArgs e)
        {
            string matrix3 = null;
            X.Multiply(Y, MatrixOrder.Append);
            // производим чтение из матрицы
            for (int i = 0; i < X.Elements.Length; i++)
            {
                matrix3 += X.Elements[i].ToString();
                matrix3 += ", ";
            }
            lblMatrix3.Text = matrix3.Trim(' ',',');
        }
    }
}