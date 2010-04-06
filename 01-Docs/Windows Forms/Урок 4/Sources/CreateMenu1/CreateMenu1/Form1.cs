using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CreateMenu1
{
    public partial class Form1 : Form
    {
        Color c;
        public Form1()
        {
            InitializeComponent();
            c = this.BackColor; //запомнили текущий цвет формы
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem it = (ToolStripMenuItem) sender;
            // если галочка стоит - меняем фон на красный
            if (it.Checked == true) 
            {
                this.BackColor = Color.Red;
            }
            else //меняем обратно фон на серый
            {
                this.BackColor = c;
            }
        }
    }
}
