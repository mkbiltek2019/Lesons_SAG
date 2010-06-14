using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToSql.Model;
using System.Data.Linq;

namespace LinqToSql.Business
{
    public class CustomerController
    {
        private List<Customer> customers;
        public List<Customer> Customers
        {
            get
            {
                if (customers == null)
                    customers = GetAllCustomers();

                return customers;
            }
            set
            {
                customers = value;
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return DataContextFactory<AdventureWorksDataContext>.DataContext.Customers.ToList();
        }

        public void Save(Customer newCustomer)
        {
            DataContextFactory<AdventureWorksDataContext>.DataContext.Customers.InsertOnSubmit(newCustomer);
            DataContextFactory<AdventureWorksDataContext>.DataContext.SubmitChanges();
        }

        public void Update(Customer updateCustomer)
        {
            Customer newAddress =
                DataContextFactory<AdventureWorksDataContext>
                .DataContext
                .Customers
                .Single(p => p.CustomerID == updateCustomer.CustomerID);

            newAddress.Title = updateCustomer.Title;
            newAddress.FirstName = updateCustomer.FirstName;
            newAddress.LastName = updateCustomer.LastName;
            newAddress.MiddleName = updateCustomer.MiddleName;
            newAddress.NameStyle = updateCustomer.NameStyle;
            newAddress.CompanyName = updateCustomer.CompanyName;
            newAddress.Suffix = updateCustomer.Suffix;
            newAddress.SalesPerson = updateCustomer.SalesPerson;
            newAddress.EmailAddress = updateCustomer.EmailAddress;
            newAddress.PasswordHash = updateCustomer.PasswordHash;
            newAddress.PasswordSalt = updateCustomer.PasswordSalt;
            newAddress.rowguid = updateCustomer.rowguid;
            newAddress.ModifiedDate = updateCustomer.ModifiedDate;
           
            DataContextFactory<AdventureWorksDataContext>.DataContext.SubmitChanges();
        }
    }
}
