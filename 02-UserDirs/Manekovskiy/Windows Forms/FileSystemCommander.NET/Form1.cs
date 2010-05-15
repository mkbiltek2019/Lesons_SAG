using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileSystemCommander.NET
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            fileListPanel1.MouseDown += new MouseEventHandler(fileListPanel1_MouseDown);
        }

        private void fileListPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            //listView1.GetItemAt(e.X, e.Y);
            
        }
    }
}
