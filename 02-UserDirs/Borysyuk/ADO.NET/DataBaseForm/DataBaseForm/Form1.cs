using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataBaseForm
{
    public partial class Form1 : Form
    {
        private int identifier=0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'adventureWorksLTDataSet.ProductCategory' table. You can move, or remove it, as needed.
            this.productCategoryTableAdapter.Fill(this.adventureWorksLTDataSet.ProductCategory);
            // TODO: This line of code loads data into the 'adventureWorksLTDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.adventureWorksLTDataSet.Customer);
            this.productTableAdapter.Fill(this.adventureWorksLTDataSet.Product);
        }

        private void CustomerPicture_Click(object sender, EventArgs e)
        {
            customerBindingSource.DataMember = "Product";
            if (identifier !=0)
            {
                
                identifier = 0;
                CustomerPicture.Image = DataBaseForm.Properties.Resources.Закат;
                //T
            }
        }

        private void ProductPicture_Click(object sender, EventArgs e)
        {
            identifier = 1;
            ProductPicture.Image = DataBaseForm.Properties.Resources.Закат;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //((DataSet)customerBindingSource.DataSource).Tables[0].Columns[0];
            //DataGridViewColumn column = new DataGridViewColumn()
            customerBindingSource.DataMember = ((DataSet)customerBindingSource.DataSource).Tables[1].TableName;

            dataGridView1.Columns.Clear();
            DataTable table = ((DataSet)customerBindingSource.DataSource).Tables[1];

            foreach (DataColumn column in table.Columns)
            {
                DataGridViewColumn gridColumn = new DataGridViewColumn();
                gridColumn.HeaderText = column.ColumnName;
                gridColumn.DataPropertyName = column.ColumnName;
                gridColumn.CellTemplate = new DataGridViewTextBoxCell();

                dataGridView1.Columns.Add(gridColumn);
            }


            //column.DataPropertyName = 
            //column.HeaderText = 
            //dataGridView1.Columns.Add();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //((DataSet)customerBindingSource.DataSource).Tables[0].Columns[0].Nam
            //dataGridView1.Columns[0].DataPropertyName
        }

        
    }
}
