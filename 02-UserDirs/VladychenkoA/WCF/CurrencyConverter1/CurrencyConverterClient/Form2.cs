using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CurrencyConverter
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form2_Paint);
            this.StartPosition = FormStartPosition.Manual;
            DesktopLocation = new Point(SystemInformation.PrimaryMonitorSize.Width - Size.Width - 5,
                SystemInformation.WorkingArea.Height - Size.Height - 5);
            toolTip1.SetToolTip(this,"Операция завешена");
        }

        public void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics= e.Graphics;
             Rectangle rect = new Rectangle(5, 5, 25, 25);
             graphics.DrawIcon(Icon, rect);
            graphics.DrawString("CurrencyConverterWithWCF", new Font("Arial", 11), System.Drawing.Brushes.Black, new PointF(30, 15));
            graphics.DrawString("Операция успешно", new Font("Arial", 10), System.Drawing.Brushes.Blue, new PointF(53, 35));
            graphics.DrawString("     завешена", new Font("Arial", 10), System.Drawing.Brushes.Blue, new PointF(53, 49));
            Image bitmap = new Bitmap(@"D:\Учебная\13НС-1СПр\02-UserDirs\VladychenkoA\Смайлики\Smilies_1000\Smilies\1.gif");
            graphics.DrawImage(bitmap, new PointF(24, 35));
            graphics.DrawLine(new Pen(Brushes.Blue, 3), 0, 0, Size.Width, 0);
            graphics.DrawLine(new Pen(Brushes.Blue, 3), 0, 0, 0, Size.Height);
            graphics.DrawLine(new Pen(Brushes.Blue, 3), 0, Size.Height - 1, Size.Width, Size.Height - 1);
            graphics.DrawLine(new Pen(Brushes.Blue, 3), Size.Width - 1, 0, Size.Width - 1, Size.Height);
            //graphics.Dispose();
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}