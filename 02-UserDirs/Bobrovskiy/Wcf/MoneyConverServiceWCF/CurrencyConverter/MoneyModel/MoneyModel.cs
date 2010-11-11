using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyConverServiceWCF.MMoneyModel
{
    public class MoneyModel
    {
        public int ISOID
        {
            get; 
            set;
        }

        public string CharacterCode
        {
            get; 
            set;
        }

        public double CurrencyCount
        {
            get; 
            set;
        }

        public string CurrencyName
        {
            get; 
            set;
        }

        public double CurrencyCource
        {
            get; 
            set;
        }
    }
}