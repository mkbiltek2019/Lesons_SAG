using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LinqToSql.Business;
using LinqToSql.Model;

namespace LinqToSql.WindowsFormsClient
{
    public partial class EditAddressData : Form
    {
        private Address currentAddress = null;

        public EditAddressData()
        {
            InitializeComponent();
        }

        public EditAddressData(Address address)
        {
            InitializeComponent();
            currentAddress = address;
            InitializeDataFields();
        }

        private void InitializeDataFields()
        {
            addressLine1TextBox.Text = currentAddress.AddressLine1;
            addressLine2TextBox.Text = currentAddress.AddressLine2;
            cityTextBox.Text = currentAddress.City;
            stateProvinceTextBox.Text = currentAddress.StateProvince;
            countryRegionTextBox.Text = currentAddress.CountryRegion;
            postalCodeTextBox.Text = currentAddress.PostalCode;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {   //save
            Address newAddress = new Address()
            {
                AddressID = currentAddress.AddressID,
                AddressLine1 = addressLine1TextBox.Text,
                AddressLine2 = addressLine2TextBox.Text,
                City = cityTextBox.Text,
                StateProvince = stateProvinceTextBox.Text, 
                CountryRegion = countryRegionTextBox.Text,
                PostalCode = postalCodeTextBox.Text,
                rowguid = Guid.NewGuid(),
                ModifiedDate = DateTime.Now
            };

            (new AddressController()).Update(newAddress);
        }
    }
}
