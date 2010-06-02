using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AdventureWorksManger
{
    public partial class mainForm
    {
        private AdventureWorksTableManager tableManager;
        private readonly static byte defaultCapacity = 15;
        private List<string> tableCaption = new List<string>(defaultCapacity);
        private List<string> tableHaderList = new List<string>(defaultCapacity);

        private class TableNames
        {
            public const string Address = "Address";
            public const string BuildVersion = "BuildVersion";
            public const string Customer = "Customer";
            public const string CustomerAddress = "CustomerAddress";
            public const string ErrorLog = "ErrorLog";
            public const string Product = "Product";
            public const string ProductCategory = "ProductCategory";
            public const string ProductDescription = "ProductDescription";
            public const string ProductModel = "ProductModel";
            public const string ProductModelProductDescription = "ProductModelProductDescription";
            public const string SalesOrderDetail = "SalesOrderDetail";
            public const string SalesOrderHeader = "SalesOrderHeader";

            public static readonly string[] AddressCaption = new string[] { "Ідентифікатор", "Адреса1", "Адреса2", 
                                                                             "Місто", "Провінція", "Регіон", "Поштовий код",
                                                                             "Унікальний ідентифікатор", "Дата" };

        } ;

        private void FillAdapters()
        {
            this.customerTableAdapter.Fill(this.adventureWorksLTDataSet.Customer);
            this.addressTableAdapter.Fill(this.adventureWorksLTDataSet.Address);
            this.salesOrderHeaderTableAdapter.Fill(this.adventureWorksLTDataSet.SalesOrderHeader);
            this.salesOrderDetailTableAdapter.Fill(this.adventureWorksLTDataSet.SalesOrderDetail);
            this.buildVersionTableAdapter.Fill(this.adventureWorksLTDataSet.BuildVersion);
            this.customerAddressTableAdapter.Fill(this.adventureWorksLTDataSet.CustomerAddress);
            this.productTableAdapter.Fill(this.adventureWorksLTDataSet.Product);
            this.productModelProductDescriptionTableAdapter.Fill(this.adventureWorksLTDataSet.ProductModelProductDescription);
            this.productModelTableAdapter.Fill(this.adventureWorksLTDataSet.ProductModel);
            this.productDescriptionTableAdapter.Fill(this.adventureWorksLTDataSet.ProductDescription);
            this.productCategoryTableAdapter.Fill(this.adventureWorksLTDataSet.ProductCategory);
            this.errorLogTableAdapter.Fill(this.adventureWorksLTDataSet.ErrorLog);
        }

        private void UpdateCurrentTable()
        {
            switch (this.bindingSource.DataMember)
            {
                case TableNames.Customer:
                    {
                        tableManager.Update(customerTableAdapter.Update,
                                               adventureWorksLTDataSet);
                    } break;
                case TableNames.Address:
                    {
                        tableManager.Update(addressTableAdapter.Update,
                                               adventureWorksLTDataSet);
                        tableCaption.AddRange(TableNames.AddressCaption);
                    } break;
                case TableNames.SalesOrderHeader:
                    {
                        tableManager.Update(salesOrderHeaderTableAdapter.Update,
                                               adventureWorksLTDataSet);
                    } break;
                case TableNames.SalesOrderDetail:
                    {
                        tableManager.Update(salesOrderDetailTableAdapter.Update,
                                               adventureWorksLTDataSet);
                    } break;
                case TableNames.BuildVersion:
                    {
                        tableManager.Update(buildVersionTableAdapter.Update,
                                               adventureWorksLTDataSet);
                    } break;
                case TableNames.CustomerAddress:
                    {
                        tableManager.Update(customerAddressTableAdapter.Update,
                                               adventureWorksLTDataSet);
                    } break;
                case TableNames.Product:
                    {
                        tableManager.Update(productTableAdapter.Update,
                                               adventureWorksLTDataSet);
                    } break;
                case TableNames.ProductCategory:
                    {
                        tableManager.Update(this.productCategoryTableAdapter.Update,
                                               adventureWorksLTDataSet);
                    } break;
                case TableNames.ProductDescription:
                    {
                        tableManager.Update(this.productDescriptionTableAdapter.Update,
                                               adventureWorksLTDataSet);
                    } break;
                case TableNames.ProductModel:
                    {
                        tableManager.Update(this.productModelTableAdapter.Update,
                                               adventureWorksLTDataSet);
                    } break;
                case TableNames.ProductModelProductDescription:
                    {
                        tableManager.Update(this.productModelProductDescriptionTableAdapter.Update,
                                               adventureWorksLTDataSet);
                    } break;
                case TableNames.ErrorLog:
                    {
                        tableManager.Update(this.errorLogTableAdapter.Update,
                                               adventureWorksLTDataSet);
                    } break;
            }
        }

        private void LoadTableNameIntoComboBox()
        {
            for (int i = 0; i < this.adventureWorksLTDataSet.Tables.Count; i++)
            {
                this.tableNameToolStripComboBox.Items.Add(
                    this.adventureWorksLTDataSet.Tables[i].TableName);
            }
        }

        private void FillGridViewWithData()
        {
            ControlsDataBinding();
            this.orderByToolStripComboBox.Items.Clear();
            this.orderByToolStripComboBox.Text = string.Empty;
            tableHaderList.Clear();
            tableCaption.Clear();
            this.dataGridView.Columns.Clear();

            tableManager = new AdventureWorksTableManager(this.bindingSource.DataMember);
            UpdateCurrentTable();//before tableManager must be created

            DataColumnCollection columnCollection =
                  tableManager.ExtractDataColumnCollection(bindingSource.DataSource).Columns;

            for (int i = 0; i < columnCollection.Count; i++)
            {
                DataGridViewColumn gridColumn = new DataGridViewColumn(new DataGridViewTextBoxCell());

                if (tableCaption.Count > 0)
                {
                    gridColumn.HeaderText = tableCaption[i];
                    this.orderByToolStripComboBox.Items.Add(gridColumn.HeaderText);
                    tableHaderList.Add(columnCollection[i].ColumnName); 
                }
                else
                {
                    gridColumn.HeaderText = columnCollection[i].ColumnName;
                    tableHaderList.Add(columnCollection[i].ColumnName);
                    this.orderByToolStripComboBox.Items.Add(gridColumn.HeaderText);
                }

                gridColumn.DataPropertyName = columnCollection[i].ColumnName; //fill gridview cell with data

                this.dataGridView.Columns.Add(gridColumn);
            }

        }

        private void ControlsDataBinding()
        {
            this.bindingSource.Sort = string.Empty;
            this.bindingSource.AllowNew = true;
            this.bindingSource.DataSource = this.adventureWorksLTDataSet;
            this.bindingSource.DataMember = this.tableNameToolStripComboBox.SelectedItem.ToString();

            this.bindingNavigator.BindingSource = this.bindingSource;

            this.dataGridView.DataSource = this.bindingSource;
        }

    }

}
