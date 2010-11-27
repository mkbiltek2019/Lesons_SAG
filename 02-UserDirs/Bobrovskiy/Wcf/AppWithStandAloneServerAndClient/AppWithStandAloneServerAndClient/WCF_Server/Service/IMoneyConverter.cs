using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.ServiceModel;

namespace AppWithStandAloneServerAndClient.WCF_Server.Service
{
    [ServiceContract(Namespace = "http://Bobrovskiy.MeneyConvertService")]
    interface IMoneyConverter
    {
        [OperationContract]
        [FaultContractAttribute(
         typeof(ServiceFault)
         )]
        double Convert(string fromCurrencyCode, string toCurrencyCode, double amount, DateTime date);

        [OperationContract]
        [FaultContractAttribute(
         typeof(ServiceFault)
         )]
      
        CurrencyList GetCurrentcyList();
    }

    [DataContractAttribute]
    public class ServiceFault
    {
        private string report;

        public ServiceFault(string message)
        {
            this.report = message;
        }

        [DataMemberAttribute]
        public string Messsage
        {
            get
            {
                return this.report;
            }
            set
            {
                this.report = value;
            }
        }
    }

    [CollectionDataContract]
    public class CurrencyList : List<string>
    {
    }

}
