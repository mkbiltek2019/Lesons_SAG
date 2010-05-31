using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureWorksManger.AdventureWorksLTDataSetTableAdapters;

namespace Helpers
{
    public class AdventureWorksCustomerManager : AdventureWorksAbstractManger
    {
        public override void FillTableAdapter()
        {
            try
            {
                this.customerTableAdapter.FillBy(this.adventureWorksLTDataSet.Customer);
            }
            catch (System.Exception ex)
            {
            }
        }
    }
}
