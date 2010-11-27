using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.ServiceModel;
using MoneyConverServiceWCF.DownloadManager;
using MoneyConverServiceWCF.MMoneyModel;
using MoneyConverServiceWCF.Parser;

namespace AppWithStandAloneServerAndClient.WCF_Server.Service
{
    public class MoneyConverter : IMoneyConverter
    {
        private List<MoneyModel> currentList = new List<MoneyModel>();
        private MainDownloadManager downloadManager = new MainDownloadManager();
        private SiteParser parser = new SiteParser();

        private const string serverError = "Service work unproperly!!!";

        public MoneyConverter()
        {
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                downloadManager.Download();
                currentList = parser.ParseFileFromLocalStore();
            }
            catch
            {
                throw new FaultException<ServiceFault>(new ServiceFault(serverError));
            }

        }

        public CurrencyList GetCurrentcyList()
        {
            CurrencyList currencyList = null;

            if (currentList != null)
            {
                currencyList = new CurrencyList();

                foreach (MoneyModel moneyModel in currentList)
                {
                    currencyList.Add(moneyModel.CharacterCode);
                }
            }
            else
            {
                throw new FaultException<ServiceFault>(new ServiceFault(serverError));
            }

            return currencyList;
        }

        public double Convert(string fromCurrencyCode, string toCurrencyCode, double amount, DateTime date)
        {
            Initialize();

            double currentCourse = 0;
            double result = 0;

            if (currentList != null)
            {
                foreach (MoneyModel moneyModel in currentList)
                {
                    if (moneyModel.CharacterCode == fromCurrencyCode)
                    {
                        currentCourse = moneyModel.CurrencyCource / moneyModel.CurrencyCount;
                        result = currentCourse * amount;
                        break;
                    }
                }
            }
            else
            {
                throw new FaultException<ServiceFault>(new ServiceFault(serverError));
            }
            return result;
        }
    }
}
