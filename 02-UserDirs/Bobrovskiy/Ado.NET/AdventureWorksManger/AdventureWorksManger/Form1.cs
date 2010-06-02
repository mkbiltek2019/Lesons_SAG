using System;
using System.Windows.Forms;

namespace AdventureWorksManger
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            this.adventureWorksLTDataSet.InitVars();
        }
        
        private void mainForm_Load(object sender, EventArgs e)
        {
            FillAdapters();
            LoadTableNameIntoComboBox();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            UpdateCurrentTable();
        }

        private void tableNameToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGridViewWithData();
        }

        private void orderByToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bindingSource.Sort = tableHaderList[this.orderByToolStripComboBox.SelectedIndex];
        }
        
    }
}
