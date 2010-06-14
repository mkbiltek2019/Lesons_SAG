using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToSql.Model;

namespace LinqToSql.Business
{
    public class CustomerAddressController
    {
        private List<CustomerAddress> customerAddresses;
        public List<CustomerAddress> CustomerAddresses
        {
            get
            {
                if (customerAddresses == null)
                    customerAddresses = GetAllCustomerAddresses();

                return customerAddresses;
            }
            set
            {
                customerAddresses = value;
            }
        }

        private List<CustomerAddress> GetAllCustomerAddresses()
        {
            throw new NotImplementedException();
        }

        public void Save(CustomerAddress customerAddress)
        {
            DataContextFactory<AdventureWorksDataContext>.DataContext.CustomerAddresses.InsertOnSubmit(customerAddress);
            DataContextFactory<AdventureWorksDataContext>.DataContext.SubmitChanges();
        }
    }
}
