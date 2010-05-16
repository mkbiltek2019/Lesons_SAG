using System.Drawing;
using System.Windows.Forms;

namespace example_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Cub.Create(g);
        }
    }
}
