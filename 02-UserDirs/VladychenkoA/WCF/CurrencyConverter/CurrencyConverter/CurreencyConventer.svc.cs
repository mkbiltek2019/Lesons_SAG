using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace CurrencyConverter
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    public class CurrencyConverter : ICurrencyConverter
    {
        private string str = "http://tables.finance.ua/ru/currency/official/~/1/2011/01/24/USD/UAH/1/+/0";
        
        public CurrencyList GetCurrentcyList()
        {
            CurrencyList currencyList = new CurrencyList();
            List<Currency> courrencyList = new List<Currency>();
            Currency currency = new Currency();
            courrencyList = currency.ReadHtmlSite(str);
            foreach (Currency cur in courrencyList)
            {
                currencyList.Add(cur.LetterCode);
            }
           
            return currencyList;
        }
        public double Convert(string fromCurrencyCode, string toCurrencyCode, double amount, DateTime date)
        {
            double result = 0;
            string str2 = date.Year.ToString();
            string str3 = date.Month.ToString();
            string str4 = date.Day.ToString();
            string str1 = "http://tables.finance.ua/ru/currency/official/~/1/" + str2 + "/"+ str3 + "/"+ str4 + "/USD/UAH/1/+/0";
            
            List<Currency> courrencyList = new List<Currency>();
            Currency currency = new Currency();
            courrencyList = currency.ReadHtmlSite(str1);
            foreach (Currency cur in courrencyList)
            {
                if(Equals( cur.LetterCode, fromCurrencyCode) )
                {
                    result = (cur.Number/cur.NumberUnit)*amount;
                }
            }
            return result;
        }


        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        
    }
}
