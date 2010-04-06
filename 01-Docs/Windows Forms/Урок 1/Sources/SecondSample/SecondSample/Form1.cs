using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SecondSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private String CoordinatesToString(MouseEventArgs e)
        {
            return "Координаты мыши: х=" + e.X.ToString() + "; y=" + e.Y.ToString();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //отображение текущих координат мыши в заголовке окна
            Text = CoordinatesToString(e);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //определим какую кнопку мыши нажал пользователь
            String message = "";
            if (e.Button == MouseButtons.Right)
            {
                message = "Вы нажали правую кнопку мыши.";
            }
            if (e.Button == MouseButtons.Left)
            {
                message = "Вы нажали левую кнопку мыши.";
            }
            message += "\n" + CoordinatesToString(e);

            //выведем сообщение в диалоговое окно
            String caption = "Клик мыши";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
