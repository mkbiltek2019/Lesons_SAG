using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToSql.Model;

namespace LinqToSql.Business
{
    public class AddressController
    {
        private List<Address> addresses;
        public List<Address> Addresses
        {
            get
            {
                if (addresses == null)
                    addresses = GetAllAddresses();

                return addresses;
            }
        }

        public List<Address> GetAddressesByCustomer(int customerID)
        {
            return DataContextFactory<AdventureWorksDataContext>.DataContext
                .CustomerAddresses
                .Where(customerAddress => customerAddress.CustomerID == customerID)
                .Select(customerAddress => customerAddress.Address)
                .ToList();
        }
        
        public List<Address> GetAllAddresses()
        {
            return DataContextFactory<AdventureWorksDataContext>.DataContext
                .Addresses
                .ToList();
        }

        public void Save(Address newAddress)
        {
            DataContextFactory<AdventureWorksDataContext>.DataContext.Addresses.InsertOnSubmit(newAddress);
            DataContextFactory<AdventureWorksDataContext>.DataContext.SubmitChanges();
        }
    }
}
