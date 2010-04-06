using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShablonMenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            menuStripEnglish.Visible = false;
            button1.Text = "English";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.CompareTo("English") == 0)
            {
                button1.Text = "Русский";
                menuStripEnglish.Visible = true;
                menuStripRussian.Visible = false;
                this.MainMenuStrip = menuStripEnglish;
            }
            else
            {
                button1.Text = "English";
                menuStripEnglish.Visible = false;
                menuStripRussian.Visible = true;
                this.MainMenuStrip = menuStripRussian;
            }
        }
    }
}
