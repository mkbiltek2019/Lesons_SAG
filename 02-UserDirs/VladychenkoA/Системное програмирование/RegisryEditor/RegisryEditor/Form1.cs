using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegisryEditor
{
    public partial class Form1 : Form
    {
        private RegistryKey registryKey;
        public Form1()
        {
           
            InitializeComponent();
        }
         
        public void GetRegistry()
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.Text = registryKey.GetValueNames().ToString();
            //treeView1.Text= registryKey.GetSubKeyNames().ToString();
        }
    }
}
