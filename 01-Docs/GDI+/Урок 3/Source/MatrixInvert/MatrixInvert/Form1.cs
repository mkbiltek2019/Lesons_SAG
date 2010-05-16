using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MatrixInvert
{
    public partial class Form1 : Form
    {
        Matrix X = new Matrix(1, 0, 3, 4, 0, 2);

        public Form1()
        {
            InitializeComponent();
            InitializeLebels();
        }

        private void InitializeLebels()
        {
            string matrix1 = null;
            // производим чтение из матрицы
            for (int i = 0; i < X.Elements.Length; i++)
            {
                matrix1 += X.Elements[i].ToString().Replace(',','.');
                matrix1 += ", ";
            }
            lblMatrix1.Text = matrix1.Trim(' ', ',');

        }

        private void mnuInvert_Click(object sender, EventArgs e)
        {
            // инвертируем Матрицу
            X.Invert();
            InitializeLebels();
        }
    }
}