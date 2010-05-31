
using System;
using System.Data;
using System.Windows.Forms;
using AdventureWorksManger.AdventureWorksLTDataSetTableAdapters;

namespace AdventureWorksManger
{
    public partial class mainForm
    {
        private AdventureWorksLTDataSetTableAdapters.CustomerTableAdapter customerTableAdapter;

        private void InitializeAdapters()
        {
            customerTableAdapter = new CustomerTableAdapter();
            customerTableAdapter.ClearBeforeFill = true;

        }
        private void FillAdapters()
        {
            this.customerTableAdapter.Fill(this.adventureWorksLTDataSet.Customer);
        }

        public enum Tables
        {
            Address,
            BuildVersion,
            Customer,
            CustomerAddress,
            ErrorLog,
            Product,
            ProductCategory,
            ProductDescription,
            ProductModel,
            ProductModelProductDescription,
            SalesOrderDetail,
            SalesOrderHeader,
        } ;

        private AdventureWorksCustomerManager customerManager;

        private void LoadTableNameIntoComboBox()
        {
            for (int i = 0; i < this.adventureWorksLTDataSet.Tables.Count; i++)
            {
                this.tableNameToolStripComboBox.Items.Add(
                    this.adventureWorksLTDataSet.Tables[i].TableName);
            }
        }

        private void UpdateCustomer()
        {
            if (customerManager!=null)
                customerManager.Update(this.adventureWorksLTDataSet, this.customerTableAdapter);
        }

        private void FillGridViewWithData()
        {
            GridViewDataBinding();

            this.dataGridView.Columns.Clear();

            if (this.bindingSource.DataMember == "Customer")
            {
                customerManager = new AdventureWorksCustomerManager(this.bindingSource.DataMember);
                FillGridByConcreteManager(customerManager);
            }

        }

        private void GridViewDataBinding()
        {
            this.bindingSource.AllowNew = false;
            this.bindingSource.DataMember = this.tableNameToolStripComboBox.SelectedItem.ToString();
            this.bindingSource.DataSource = this.adventureWorksLTDataSet;
            this.bindingSource.Position = 0;
            this.dataGridView.DataSource = this.adventureWorksLTDataSet;
            this.dataGridView.DataMember = this.tableNameToolStripComboBox.SelectedItem.ToString();

            this.bindingNavigator.BindingSource = this.bindingSource;
        }

        private void FillGridByConcreteManager(AdventureWorksAbstractManger concreteManager)
        {
            //using 
            AdventureWorksAbstractManger customerManager = concreteManager;
            {
               // customerManager.FillTableAdapter(adventureWorksLTDataSet);
                DataColumnCollection collection =
                    customerManager.ExtractDataColumnCollection(bindingSource.DataSource).Columns;

                for (int i = 0; i < collection.Count; i++)
                {
                    DataGridViewColumn gridColumn = new DataGridViewColumn();
                    gridColumn.HeaderText = collection[i].ColumnName;  //table  header modify !!!!!!!
                    gridColumn.DataPropertyName = collection[i].ColumnName; //fill gridview cell with data
                    gridColumn.CellTemplate = new DataGridViewTextBoxCell();

                    this.dataGridView.Columns.Add(gridColumn);
                }
            }
        }
    }
}
