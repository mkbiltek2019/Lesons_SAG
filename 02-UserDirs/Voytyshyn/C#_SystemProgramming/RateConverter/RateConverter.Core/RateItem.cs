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
        private DateTime date;
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

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
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
            this.date = data;
            this.value = value;
        } 

        #endregion
    }
}
