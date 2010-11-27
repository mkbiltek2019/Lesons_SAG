using System;

namespace MoneyConvertClient.Classes.Validation
{
    public class DataModelForConverter
    {
        public string SourceCurrency
        { 
            get;
            set;
        }

        public string DestinationCurrency
        { 
            get;
            set;
        }

        public double Amount
        { 
            get;
            set;
        }

        public DateTime Date
        { 
            get;
            set;
        }
    }
}
