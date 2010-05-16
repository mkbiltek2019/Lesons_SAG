using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;


namespace RoundButton
{
    public partial class RoundButton: Button
    {
        Brush[] clList; 
        // Внешнее представление элемента управления меняется
        // в зависимости от состояния элемента. Это состояние
        // зависит от конкретных событий, происходящих с элементом
        // управления. 
        // Внешний вид элемента управления определяется значением
        // переменной indexB, которая меняет значение в рамках
        // переопределяемых обработчиков событий. 

        int indexB;

        public RoundButton(): base()
        {
            indexB = 0;
            clList = new Brush[] { Brushes.Red,
                Brushes.Pink, Brushes.Yellow, Brushes.Blue };
        }
        // Код, управляющий изменением внешнего вида элемента.
        // Сюда передается управление в результате выполнения метода
        // Refresh(). 
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(10, 10, 50, 50);
            Region reg = new Region(gp);
            // Свойству Region присваивается новое значение – новый регион! 
            this.Region = reg;
            e.Graphics.FillRegion(clList[indexB],reg);
        }

        protected override void OnClick(EventArgs e)
        {
            indexB = 0;
            this.Refresh();
            base.OnClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            indexB = 1;
            this.Refresh();
            base.OnMouseDown(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            indexB = 0;
            this.Refresh();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            indexB = 0;
            this.Refresh();
            base.OnLostFocus(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            indexB = 2;
            this.Refresh();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            indexB = 3;
            this.Refresh();
            base.OnMouseLeave(e);
        }
    }
}
