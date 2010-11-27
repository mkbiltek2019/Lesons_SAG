using System;
using System.Collections.Generic;
using System.ServiceModel;
using AppWithStandAloneServerAndClient.WCF_Server.Service;
using Background;

namespace AppWithStandAloneServerAndClient.WCF_Server
{
    public class ServiceManager : IWCFServise 
    {
        private ServiceHost service = new ServiceHost(typeof(MoneyConverter));
        private BackgroundMethodExecutor background = new BackgroundMethodExecutor();

        public void Start()
        {
            background.Method = service.Open;
           //service.Open();
            background.RunWorkerAsync();
        }

        public void Stop()
        {
            background.CancelAsync();
            service.Close();
        }

        public ServiceData GetData()
        {
            ServiceData serviceData = new ServiceData();

            serviceData.State = service.State.ToString();
            serviceData.Name = service.Description.Name;
            serviceData.NameSpace = service.Description.Namespace;
            serviceData.Type = service.Description.ServiceType.ToString();

            List<string> collection = new List<string>();
            foreach (Uri address in service.BaseAddresses)
            {
               collection.Add(address.AbsoluteUri);
            }
            serviceData.AddressesCollection = collection;

            List<string> collection2 = new List<string>();
            foreach (var address in service.Description.Endpoints)
            {
               collection2.Add(address.Name);
            }
            serviceData.BindingCollection = collection2;

            return serviceData;
        }
    }
}
