using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Update(Address updateAddress)
        {
            Address newAddress =
                DataContextFactory<AdventureWorksDataContext>
                .DataContext
                .Addresses
                .Single(p => p.AddressID == updateAddress.AddressID);
            
            newAddress.AddressLine1 = updateAddress.AddressLine1;
            newAddress.AddressLine2 = updateAddress.AddressLine2;
            newAddress.City = updateAddress.City;
            newAddress.CountryRegion = updateAddress.CountryRegion;
            newAddress.PostalCode = updateAddress.PostalCode;
            newAddress.ModifiedDate = updateAddress.ModifiedDate;
            newAddress.StateProvince = updateAddress.StateProvince;
            newAddress.rowguid = updateAddress.rowguid;

            DataContextFactory<AdventureWorksDataContext>.DataContext.SubmitChanges();
        }

    }
}
