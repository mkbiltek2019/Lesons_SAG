using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using AdventureWorksManger.AdventureWorksLTDataSetTableAdapters;

namespace AdventureWorksManger
{
    public class AdventureWorksCustomerManager : AdventureWorksAbstractManger
    {
        public AdventureWorksCustomerManager(string tableName)
            : base(tableName)
        {
        }

        public void FillTableAdapter(AdventureWorksLTDataSet adventureWorksLTDataSet, CustomerTableAdapter customerTableAdapter)
        {
            try
            {
                customerTableAdapter.FillBy(adventureWorksLTDataSet.Customer);
            }
            catch (Exception ex)
            {
            }
        }

        public void Update(AdventureWorksLTDataSet adventureWorksLTDataSet, CustomerTableAdapter customerTableAdapter)
        {
           try
                {
                    customerTableAdapter.Update(adventureWorksLTDataSet.Customer);
                }
                catch (Exception ex)
                {
                  
                }
        }

       
    }
}
