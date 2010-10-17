using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.MegaRegistryViewControl.Generate();
        }

        private void addRegistryKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //add registry key
            this.MegaRegistryViewControl.AddRegistryEntry();
        }

        private void deleteKeyOrParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //delete registry entry
            this.MegaRegistryViewControl.RemoveRegistryEntry();
        }

        private void createSubkeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MegaRegistryViewControl.CreateRegistrySubKey();
        }


    }
}
