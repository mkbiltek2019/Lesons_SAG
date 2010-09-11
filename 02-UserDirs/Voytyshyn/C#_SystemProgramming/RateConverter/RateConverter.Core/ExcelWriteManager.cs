using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RateConverter.Core
{
    public class ExcelWriteManager
    {
        private static object sync = new object();

        private ExcelInstance singleExelInstance = null;

        public ExcelWriteManager(ExcelInstance singleExelInstance)
        {
            this.singleExelInstance = singleExelInstance;
        }

        public void Write(List<RateItem> rateItems)
        {            
            //singleExelInstance.Write(rateItems);
        }   
    }
}
