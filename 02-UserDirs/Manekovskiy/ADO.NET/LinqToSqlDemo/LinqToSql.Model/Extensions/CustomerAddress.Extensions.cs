#define MYPreprocessLabel

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace LinqToSql.Model
{
    public partial class AdventureWorksDataContext
	{
        partial void InsertCustomerAddress(CustomerAddress instance)
        {
#if TRACE
            Trace.WriteLine("Inserted new CustomerAddress instance");
#else
#endif

#if DEBUG
            string debugLogEntry = string.Format("Inserted new CustomerAddress instance with data:\n AddressLine1: {0}\n Customer FullName: {1}",
                instance.Address.AddressLine1, 
                instance.Customer.FullName);
            Debug.WriteLine(debugLogEntry, "Inserts");
#else
#endif
        }
	}
}
