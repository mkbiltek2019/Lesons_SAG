using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MatrixOperations
{
    // представляет операцию преобразования 
    public enum MatrixOperations
    {
        Reset,
        Rotate,
        RotateAt,
        Scale,
        Shear,
        Translate
    }

    public partial class Form1 : Form
    {
        private  Graphics g;
        private  MatrixOperations mxOperation = MatrixOperations.Reset;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // обработаем перечисление и вызовем соответствующий метод преобразования
            switch (mxOperation)
            {
                case MatrixOperations.Rotate:
                    MatrixRotate();
                    break;
                case MatrixOperations.Scale:
                    MatrixScale();
                    break;
                case MatrixOperations.Reset:
                    MatrixReset();
                    break;
                case MatrixOperations.Shear:
                    MatrixShear();
                    break;
                case MatrixOperations.Translate:
                    MatrixTranslate();
                    break;
                default:
                    MatrixReset();
                    break;
            }

        }

        #region ClickEvents
        private void mnuRotate_Click(object sender, EventArgs e)
        {
            mxOperation = MatrixOperations.Rotate;
            this.Invalidate();
        }

        private void mnuScale_Click(object sender, EventArgs e)
        {
            mxOperation = MatrixOperations.Scale;
            this.Invalidate();
        }

        private void mnuShear_Click(object sender, EventArgs e)
        {
            mxOperation = MatrixOperations.Shear;
            this.Invalidate();
        }

        private void mnuTranslate_Click(object sender, EventArgs e)
        {
            mxOperation = MatrixOperations.Translate;
            this.Invalidate();
        }

        private void mnuItemReset_Click(object sender, EventArgs e)
        {
            mxOperation = MatrixOperations.Reset;
            this.Invalidate();
        }
        #endregion

        #region  TransformationMethods
        private void MatrixReset()
        {
            if (g != null)
            {
                // сбрасываем преобразования в матрице
                g.Transform.Reset();
            }
        }

        private void MatrixTranslate()
        {
            g = this.CreateGraphics();
            g.FillRectangle(Brushes.Blue, 60, 60, 110, 40);
            // Создаем матрицу
            Matrix X = new Matrix();
            // Применяем перемещение
            X.Translate(40.0f, 80.0f, MatrixOrder.Append);
            g.Transform = X;
            g.FillRectangle(Brushes.Blue, 60, 60, 110, 40);
        }

        private void MatrixShear()
        {
            g = this.CreateGraphics();
            g.FillRectangle(Brushes.Blue, 60, 60, 110, 40);
            // Создаем матрицу
            Matrix X = new Matrix();
            // Применяем Сдвиг
            X.Shear(0.3f, 0.5f, MatrixOrder.Append);
            g.Transform = X;
            g.FillRectangle(Brushes.Blue, 60, 60, 110, 40);
        }

        private void MatrixScale()
        {
            g = this.CreateGraphics();
            g.FillRectangle(Brushes.Blue, 60, 60, 110, 40);
            // Создаем матрицу
            Matrix X = new Matrix();
            // Применяем масштабирование
            X.Scale(1.5f, 1.9f, MatrixOrder.Append);
            g.Transform = X;
            g.FillRectangle(Brushes.Blue, 60, 60, 110, 40);
        }

        private void MatrixRotate()
        {
            g = this.CreateGraphics();
            g.FillRectangle(Brushes.Blue, 60, 60, 110, 40);
            // Создаем матрицу
            Matrix X = new Matrix();
            // Вращаем на 25 градусов матрицу
            X.Rotate(25, MatrixOrder.Append);
            g.Transform = X;
            g.FillRectangle(Brushes.Blue, 60, 60, 110, 40);
        }
        #endregion

    }
}
