using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace RegionOperations
{
    // представляет операцию над регионом
    public enum RegionOperations
    {
        Complement,
        Intersect,
        Union,
        Exclude,
        Xor,
        No

    }

    public partial class Form1 : Form
    {
        private Graphics g;
        private RegionOperations rgnOperation = RegionOperations.No;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawRegionOperations();
        }

        private void DrawRegionOperations()
        {
            g = this.CreateGraphics();
            // Создаем два прямоугольника
            Rectangle rect1 = new Rectangle(100, 100, 120, 120);
            Rectangle rect2 = new Rectangle(70, 70, 120, 120);
            // Создаем два региона
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            // рисуем прямоугольники
            g.DrawRectangle(Pens.Green, rect1);
            g.DrawRectangle(Pens.Black, rect2);

            // обработаем перечисление и вызовем соответствующий метод
            switch (rgnOperation)
            {
                case RegionOperations.Union:
                    rgn1.Union(rgn2);
                    break;
                case RegionOperations.Complement:
                    rgn1.Complement(rgn2);
                    break;
                case RegionOperations.Intersect:
                    rgn1.Intersect(rgn2);
                    break;
                case RegionOperations.Exclude:
                    rgn1.Exclude(rgn2);
                    break;
                case RegionOperations.Xor:
                    rgn1.Xor(rgn2);
                    break;
                default:
                    break;
            }
            // Рисуем регион
            g.FillRegion(Brushes.Blue, rgn1);
            g.Dispose();
        }

        #region ClickEvents
        private void mnuComplement_Click(object sender, EventArgs e)
        {
            rgnOperation = RegionOperations.Complement;
            this.Invalidate();
        }

        private void mnuIntersect_Click(object sender, EventArgs e)
        {
            rgnOperation = RegionOperations.Intersect;
            this.Invalidate();
        }

        private void mnuUnion_Click(object sender, EventArgs e)
        {
            rgnOperation = RegionOperations.Union;
            this.Invalidate();
        }

        private void mnuExlude_Click(object sender, EventArgs e)
        {
            rgnOperation = RegionOperations.Exclude;
            this.Invalidate();
        }

        private void mnuXor_Click(object sender, EventArgs e)
        {
            rgnOperation = RegionOperations.Xor;
            this.Invalidate();
        }

        #endregion

    }
}
