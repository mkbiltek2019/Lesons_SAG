using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
    }
}
