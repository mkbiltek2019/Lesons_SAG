using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using MoneyConvertClient.Interfaces;
using MoneyConvertClient.ServiceReference;

namespace MoneyConvertClient.Manager
{
    public class ProxyManager : IProxyManager
    {
        public event Action<IMoneyConverter> ConverterMethod = null;

        public void ExecuteOperation()
        {
            MoneyConverterClient wcfClient = new MoneyConverterClient();

            try
            {
                ConverterMethod.Invoke(wcfClient);
                wcfClient.Close();
            }
            catch (TimeoutException timeout)
            {
                // Handle the timeout exception.
                wcfClient.Abort();
            }
            catch (CommunicationException commException)
            {
                // Handle the communication exception.
                wcfClient.Abort();
            }

        }
    }
    
}
