using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using LinqToSql.Business;
using LinqToSql.Model;

namespace LinqToSql.WindowsFormsClient
{
    public partial class EditCustomerData : Form
    {
        private Customer currentCustomer= null;

        public EditCustomerData()
        {
            InitializeComponent();
        }

        public EditCustomerData(Customer customer)
        {
            InitializeComponent();
            currentCustomer = customer;
            InitializeDataFields();
        }

        private void InitializeDataFields()
        {
            titleTextBox.Text = currentCustomer.Title;
            firstNameTextBox.Text = currentCustomer.FirstName;
            middleNameTextBox.Text = currentCustomer.MiddleName;
            lastNameTextBox.Text = currentCustomer.LastName;
            suffixTextBox.Text = currentCustomer.Suffix;
            companyNameTextBox.Text = currentCustomer.CompanyName;
            salesPersonTextBox.Text = currentCustomer.SalesPerson;
            emailAddressTextBox.Text = currentCustomer.EmailAddress;
            phoneTextBox.Text = currentCustomer.Phone;
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //save
            Customer newAddress = new Customer()
            {
                CustomerID = currentCustomer.CustomerID,
                Title = titleTextBox.Text,
                FirstName = firstNameTextBox.Text,
                MiddleName = middleNameTextBox.Text,
                LastName = lastNameTextBox.Text,
                Suffix = suffixTextBox.Text,
                CompanyName = companyNameTextBox.Text,
                SalesPerson = salesPersonTextBox.Text,
                EmailAddress = emailAddressTextBox.Text,
                Phone = phoneTextBox.Text,
                PasswordHash = currentCustomer.PasswordHash,
                PasswordSalt = currentCustomer.PasswordSalt,
                NameStyle = currentCustomer.NameStyle,
                rowguid = Guid.NewGuid(),
                ModifiedDate = DateTime.Now
            };

            (new CustomerController()).Update(newAddress);
        }
    }
}
