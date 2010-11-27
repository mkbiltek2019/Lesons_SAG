using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using MoneyConvertClient.ServiceReference;

namespace MoneyConvertClient.Classes.ProxyThreadWorker
{
    public class ProxyWorker<TSource>where TSource : ClientBase<IMoneyConverter>, IMoneyConverter,new()
    {
        public event Action<string> DoReport = null;
        public event Action<TSource, object> DoAction = null;

        private TSource wcfClient;
        private object sync = new object();
        private Thread thread = null;

        private object someObject = null;

        private const string processingMessage = "Processing.";
        private const string doneMessage = "Finished.";
        private const string timeErrorMessage = "Timeout error.";
        private const string communicationErrorMessage = "Communication error.";
        private const string anknownErrorMessage = "Anknown error.";

        private string passwd = string.Empty;
        private string login = string.Empty;

        public string Login
        {
            set
            {
                login = value; 
            }
        }

        public string Password
        {
            set
            {
                passwd = value;
            }
        }

        public ProxyWorker(object currentObject)
        {
            someObject = currentObject;
            thread = new Thread(new ThreadStart(DoWork));
            thread.Priority = ThreadPriority.Highest;
        }

        public void Start()
        {
            try
            {
                thread.Start();
                ReportErrorState(processingMessage);
            }
            finally
            {
                ReportErrorState(doneMessage);
            }
        }

        private void DoWork()
        {
            lock (sync)
            {
                try
                {
                    wcfClient = new TSource();
                    wcfClient.ClientCredentials.UserName.UserName = login;
                    wcfClient.ClientCredentials.UserName.Password = passwd;

                    wcfClient.Open();

                    DoConcreteWork(wcfClient);

                    wcfClient.Close();
                }
                catch (TimeoutException timeout)
                {
                    ReportErrorState(timeErrorMessage);
                    wcfClient.Abort();
                }
                catch (CommunicationException commException)
                {
                    ReportErrorState(communicationErrorMessage);
                    wcfClient.Abort();
                }
                catch(Exception exception)
                {
                    ReportErrorState(anknownErrorMessage);
                    wcfClient.Abort();
                }
            }
        }
        
        private void ReportErrorState(string errorState)
        {
            DoReport.Invoke(errorState); 
        }

        private void DoConcreteWork(TSource currentWcfClient)
        {
            DoAction.Invoke(currentWcfClient, someObject); 
        }

    }
}
