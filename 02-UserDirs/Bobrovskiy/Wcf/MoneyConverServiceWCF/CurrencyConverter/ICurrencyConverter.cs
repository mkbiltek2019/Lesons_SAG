using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace CurrencyConverter
{
    [ServiceContract]
    public interface ICurrencyConverter
    {
        [OperationContract]
        double Convert(string fromCurrencyCode, string toCurrencyCode, double amount, DateTime date);
        
        [OperationContract]
        CurrencyList GetCurrentcyList();
    }
   
    [CollectionDataContract]
    public class CurrencyList: List<string>
    {
    }

}
