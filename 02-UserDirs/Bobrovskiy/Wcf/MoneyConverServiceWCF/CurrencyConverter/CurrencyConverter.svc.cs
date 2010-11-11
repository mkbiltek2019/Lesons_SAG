using System;
using System.Collections.Generic;
using MoneyConverServiceWCF.DownloadManager;
using MoneyConverServiceWCF.MMoneyModel;
using MoneyConverServiceWCF.Parser;

namespace CurrencyConverter
{
    public class CurrencyConverterService : ICurrencyConverter
    {
        private List<MoneyModel> currentList = new List<MoneyModel>();
        private MainDownloadManager downloadManager = new MainDownloadManager();
        private SiteParser parser = new SiteParser();

        public CurrencyConverterService()
        {
            Initialize();
        }

        private void Initialize()
        {
            downloadManager.Download();
            currentList = parser.ParseFileFromLocalStore();
        }

        public CurrencyList GetCurrentcyList()
        {
            CurrencyList currencyList = new CurrencyList();

            foreach (MoneyModel moneyModel in currentList)
            {
                currencyList.Add(moneyModel.CharacterCode);
            }

            return currencyList;
        }

        public double Convert(string fromCurrencyCode, string toCurrencyCode, double amount, DateTime date)
        {
            Initialize();

            double currentCourse = 0;
            double result = 0;

            foreach (MoneyModel moneyModel in currentList)
            {
                if (moneyModel.CharacterCode == fromCurrencyCode)
                {
                    currentCourse = moneyModel.CurrencyCource / moneyModel.CurrencyCount;
                    result = currentCourse * amount;
                    break;
                }
            }

            return result;
        }
    }
}
