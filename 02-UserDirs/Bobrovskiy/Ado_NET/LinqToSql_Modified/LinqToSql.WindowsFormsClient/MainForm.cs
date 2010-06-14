using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LinqToSql.Business;
using LinqToSql.Model;

namespace LinqToSql.WindowsFormsClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void loadDataButton_Click(object sender, EventArgs e)
        {
            customersDataGridView.DataSource = (new CustomerController()).Customers;
            customerFilterComboBox.DataSource = customersDataGridView.DataSource;
        }

        private void saveCustomerAddressButton_Click(object sender, EventArgs e)
        {
            Address newAddress = new Address()
            {
                AddressLine1 = addressLine1TextBox.Text,
                AddressLine2 = addressLine2TextBox.Text,
                City = cityTextBox.Text,
                CountryRegion = countryRegionTextBox.Text,
                PostalCode = postalCodeTextBox.Text,
                ModifiedDate = DateTime.Now,
                rowguid = Guid.NewGuid(),
                StateProvince = stateProvinceTextBox.Text
            };

            (new AddressController()).Save(newAddress);

            CustomerAddress newCustomerAddress = new CustomerAddress()
                {
                    AddressType = addressTypeTextBox.Text,
                    CustomerID = (int)customerFilterComboBox.SelectedValue,
                    AddressID = newAddress.AddressID,
                    ModifiedDate = DateTime.Now,
                    rowguid = Guid.NewGuid()
                };

            (new CustomerAddressController()).Save(newCustomerAddress);
        }

        private void customerFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customerFilterComboBox.SelectedValue != null)
            {
                customerAddressesDataGridView.DataSource =
                    (new AddressController()).GetAddressesByCustomer((int)customerFilterComboBox.SelectedValue);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //customer
            int rowIndex = customersDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);

            if (rowIndex > -1)
            {
                List<string> cellList = new List<string>();

                for (int i = 0; i < customersDataGridView.Rows[rowIndex].Cells.Count; i++)
                {
                    if (customersDataGridView.Rows[rowIndex].Cells[i].Value != null)
                    {
                        cellList.Add(customersDataGridView.Rows[rowIndex].Cells[i].Value.ToString());
                    }
                    else
                    {
                        cellList.Add(string.Empty);
                    }
                    
                }

                int index = 0;
                if (int.TryParse(cellList[0], out index))
                {
                    foreach (var customer in (new CustomerController()).Customers)
                    {
                        if (customer.CustomerID == index)
                        {
                            EditCustomerData editCustomerData =
                                 new EditCustomerData(customer);
                            editCustomerData.ShowDialog();
                        }
                    } 
                }
            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {  //address
            int rowIndex = customerAddressesDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);

            if (rowIndex > -1)
            {
                List<string> cellList = new List<string>();

                for (int i = 0; i < customerAddressesDataGridView.Rows[rowIndex].Cells.Count; i++)
                {
                    if (customerAddressesDataGridView.Rows[rowIndex].Cells[i].Value != null)
                    {
                        cellList.Add(customerAddressesDataGridView.Rows[rowIndex].Cells[i].Value.ToString());
                    }
                    else
                    {
                        cellList.Add(string.Empty);
                    }
                }

                int index = 0;
                if (int.TryParse(cellList[0], out index))
                {
                    foreach (var adress in (new AddressController()).Addresses)
                    {
                        if (adress.AddressID == index)
                        {
                            EditAddressData editAddressData = new EditAddressData(adress);
                            editAddressData.ShowDialog();
                        }
                    }
                }
            }
        }

    }

}
