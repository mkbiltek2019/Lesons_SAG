using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication9.AdventureWorksLT2008DataSetTableAdapters;
using System.Data.Linq.SqlClient;

namespace WindowsFormsApplication9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (DataTable dataTable in adventureWorksLT2008DataSet.Tables)
                tabControl1.Controls.Add(new TabPage(){Name = dataTable.TableName,Text = dataTable.TableName});
            DataTable dataTableActiv =DataBasaManeger.GetTypeDateSet().Tables[tabControl1.TabPages[0].Text];
            adventureWorksLT2008DataSetBindingSource.DataSource = dataTableActiv;
            bindingNavigator1.BindingSource = adventureWorksLT2008DataSetBindingSource;
            dataGridView1.DataSource = adventureWorksLT2008DataSetBindingSource;
            foreach (DataColumn column in dataTableActiv.Columns)
                toolStripComboBox1.Items.Add(column.ColumnName);
            toolStripComboBox1.SelectedIndex = 0;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            DataTable dataTableSource = DataBasaManeger.GetTypeDateSet().Tables[e.TabPage.Text];
            adventureWorksLT2008DataSetBindingSource.DataSource = dataTableSource;
            bindingNavigator1.BindingSource = adventureWorksLT2008DataSetBindingSource;
            dataGridView1.DataSource = adventureWorksLT2008DataSetBindingSource;
            toolStripComboBox1.Items.Clear();
            foreach (DataColumn column in dataTableSource.Columns)
                toolStripComboBox1.Items.Add(column.ColumnName);
            toolStripComboBox1.SelectedIndex = 0;
        }
       
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            int dataTableSelectedIndex = tabControl1.SelectedIndex;
            DataTable dataTable = DataBasaManeger.GetTypeDateSet().Tables[dataTableSelectedIndex];
            DataView dataView = dataTable.AsDataView();
            dataView.RowFilter = string.Format("convert({0},System.String) LIKE '{1}%'", DataBasaManeger.EscapeLikeValue(toolStripComboBox1.Text), DataBasaManeger.EscapeLikeValue(toolStripTextBox1.Text));
            adventureWorksLT2008DataSetBindingSource.DataSource = dataView;
            bindingNavigator1.BindingSource = adventureWorksLT2008DataSetBindingSource;
            dataGridView1.DataSource = adventureWorksLT2008DataSetBindingSource;
        }
        

    }
}
