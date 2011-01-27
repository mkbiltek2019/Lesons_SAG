using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace CurrencyConverter
{
    [Serializable]
    class CurrencyCode
    {
        [XmlAttribute("Name")] 
        private string _name;
        public    string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        public CurrencyCode()
        {
            _name = "";
        }
        public CurrencyCode(string name)
        {
            _name = name;
        }
        public ArrayList CurrencyCodeArrayList = new ArrayList();
    }
    public class CurrencyCodeList
    {
        private ArrayList _currencyCodeList = new ArrayList();
        public ArrayList CurrencyCodeList()
        {
            return _currencyCodeList;
        }
    }
}
