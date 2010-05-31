using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdventureWorksManger.AdventureWorksLTDataSetTableAdapters;

namespace AdventureWorksManger
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            this.adventureWorksLTDataSet.InitVars();
            InitializeAdapters();
        }
        
        private void mainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'adventureWorksLTDataSet.Customer' table. You can move, or remove it, as needed.
           // this.customerTableAdapter.Fill(this.adventureWorksLTDataSet.Customer);
            FillAdapters();
            LoadTableNameIntoComboBox();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            UpdateCustomer();
        }

        private void tableNameToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGridViewWithData();
        }
        
    }
}
