using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormsPlusDataBase
{
    public partial class Form1 : Form
    {
        private int identifier = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'adventureWorksLTDataSet.Customer' table. You can move, or remove it, as needed.
            this.TableAdapter.Fill(this.adventureWorksLTDataSet.Customer);

        }

        private void CategoryPicture_Click(object sender, EventArgs e)
        {
            if (identifier != 1)
            {
                identifier = 1;
                CategoryPicture.Image = FormsPlusDataBase.Properties.Resources.Category;
                CustomerPicture.Image = FormsPlusDataBase.Properties.Resources.Customer_new;
                SalesPicture.Image = FormsPlusDataBase.Properties.Resources.Sales_new;
                ProductPicture.Image = FormsPlusDataBase.Properties.Resources.Product_new;
                string TableName = "ProductCategory";
                MydataGridView.Columns.Clear();
                MyBindingSource.DataMember = TableName;
                DataTable MyDataTable = ((DataSet)MyBindingSource.DataSource).Tables[TableName];
                foreach (DataColumn column in MyDataTable.Columns)
                {
                    DataGridViewColumn GridColumn = new DataGridViewColumn();
                    GridColumn.HeaderText = column.ColumnName;
                    GridColumn.DataPropertyName = column.ColumnName;
                    GridColumn.CellTemplate = new DataGridViewTextBoxCell();
                    MydataGridView.Columns.Add(GridColumn);
                }
            }
        }

        private void ProductPicture_Click(object sender, EventArgs e)
        {
            if (identifier != 2)
            {
                identifier = 2;
                CategoryPicture.Image = FormsPlusDataBase.Properties.Resources.Category_new;
                CustomerPicture.Image = FormsPlusDataBase.Properties.Resources.Customer_new;
                SalesPicture.Image = FormsPlusDataBase.Properties.Resources.Sales_new;
                ProductPicture.Image = FormsPlusDataBase.Properties.Resources.Product;
                string TableName = "Product";
                MydataGridView.Columns.Clear();
                MyBindingSource.DataMember = TableName;
                DataTable MyDataTable = ((DataSet)MyBindingSource.DataSource).Tables[TableName];
                foreach (DataColumn column in MyDataTable.Columns)
                {
                    DataGridViewColumn GridColumn = new DataGridViewColumn();
                    GridColumn.HeaderText = column.ColumnName;
                    GridColumn.DataPropertyName = column.ColumnName;
                    GridColumn.CellTemplate = new DataGridViewTextBoxCell();
                    MydataGridView.Columns.Add(GridColumn);
                }
            }
        }

        private void CustomerPicture_Click(object sender, EventArgs e)
        {
            if (identifier != 0)
            {
                identifier = 0;
                CategoryPicture.Image = FormsPlusDataBase.Properties.Resources.Category_new;
                CustomerPicture.Image = FormsPlusDataBase.Properties.Resources.Customer;
                SalesPicture.Image = FormsPlusDataBase.Properties.Resources.Sales_new;
                ProductPicture.Image = FormsPlusDataBase.Properties.Resources.Product_new;
                string TableName = "Customer";
                MydataGridView.Columns.Clear();
                MyBindingSource.DataMember = TableName;
                DataTable MyDataTable = ((DataSet)MyBindingSource.DataSource).Tables[TableName];
                foreach (DataColumn column in MyDataTable.Columns)
                {
                    DataGridViewColumn GridColumn = new DataGridViewColumn();
                    GridColumn.HeaderText = column.ColumnName;
                    GridColumn.DataPropertyName = column.ColumnName;
                    GridColumn.CellTemplate = new DataGridViewTextBoxCell();
                    MydataGridView.Columns.Add(GridColumn);
                }
            }
        }

        private void SalesPicture_Click(object sender, EventArgs e)
        {
            if (identifier != 3)
            {
                identifier = 3;
                CategoryPicture.Image = FormsPlusDataBase.Properties.Resources.Category_new;
                CustomerPicture.Image = FormsPlusDataBase.Properties.Resources.Customer_new;
                SalesPicture.Image = FormsPlusDataBase.Properties.Resources.Sales;
                ProductPicture.Image = FormsPlusDataBase.Properties.Resources.Product_new;

                

               
                MydataGridView.Columns.Clear();
                string TabName = "SalesOrderDetail";
                MyBindingSource.DataMember = ((DataSet)MyBindingSource.DataSource).Tables[3].TableName;
                //MyBindingSource.DataMember = TabName;
                DataTable table = ((DataSet)MyBindingSource.DataSource).Tables[TabName];

                MydataGridView.DataSource = table;
                foreach (DataColumn column in table.Columns)
                {
                    DataGridViewColumn gridColumn = new DataGridViewColumn();
                    gridColumn.HeaderText = column.ColumnName;
                    gridColumn.DataPropertyName = column.ColumnName;
                    gridColumn.CellTemplate = new DataGridViewTextBoxCell();

                    MydataGridView.Columns.Add(gridColumn);
                    
                }
                
            }
        }

        private void MyBindingSource_DataMemberChanged(object sender, EventArgs e)
        {
            
        }

       

       
    }
}
