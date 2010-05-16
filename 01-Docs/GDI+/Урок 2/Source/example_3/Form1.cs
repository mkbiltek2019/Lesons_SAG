using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace example_3
{
    public partial class Form1 : Form
    {
        private Random random = new Random();

        //  Кисть, которой рисуем
        private SolidBrush sldBrush = new SolidBrush(Color.Indigo);

        public Form1()
        {
            InitializeComponent();
        }

        private void stmiFont_Click(object sender, EventArgs e)
        {
            FontDialog fDialog = new FontDialog();
            if (fDialog.ShowDialog()== DialogResult.OK)
            {
                Font font = fDialog.Font;
                DrawStr(font, "Строка выведена шрифтом " + font.Name);
            }
        }

        private void DrawStr(Font font, String str)
        {
            // Инициализируем Graphics формы
            Graphics g = this.CreateGraphics();

            // Очищаем 
            //g.Clear(this.BackColor);

            // Генерируем случайные координаты, куда будет выведена строка
            int x = random.Next(10, 200);
            int y = random.Next(10, 400);

            // Выводим строку на форму
            g.DrawString(str, font, sldBrush, x, y);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Font font = new Font("Comic Sans MS", 16, FontStyle.Italic);
            DrawStr(font, "Строка, которая будет выведена на форму");
        }

        private void tsmiClear_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
        }
    }
}
