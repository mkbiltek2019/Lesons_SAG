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
    }
}
