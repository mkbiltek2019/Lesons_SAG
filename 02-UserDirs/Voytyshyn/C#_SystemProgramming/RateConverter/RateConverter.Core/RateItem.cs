using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RateConverter.Core
{
    public class RateItem
    {
        #region Field

        private string currency;
        private string bank;
        private DateTime data;
        private decimal value; 

        #endregion


        #region Members

        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        public string Bank
        {
            get { return bank; }
            set { bank = value; }
        }

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        public decimal Value
        {
            get { return value; }
            set { this.value = value; }
        } 

        #endregion

        #region Constructors

        public RateItem()
        {
            
        }

        public RateItem(string currency, string bank, DateTime data, decimal value)
        {
            this.currency = currency;
            this.bank = bank;
            this.data = data;
            this.value = value;
        } 

        #endregion
    }
}
