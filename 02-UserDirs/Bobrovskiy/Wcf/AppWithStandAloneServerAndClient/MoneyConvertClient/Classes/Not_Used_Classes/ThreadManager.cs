using System;
using System.ServiceModel;
using System.Threading;
using MoneyConvertClient.Classes;
using MoneyConvertClient.ServiceReference;

namespace Classes.ThreadWrapper
{
    public class ThreadManager : IThreadManager
    {
        private Thread currentThread = null;
        private ThreadTerminator terminator = new ThreadTerminator();
        private Action<IMoneyConverter> method = null;
        private string jobComplete = "Done";
        private string jobCanceled = "Job Canceled";
        private string jobTimeout = "Job timeout";
        private string jobCommunicationException = "Job communication exception";
        private ThreadPriority recomendedPriority = ThreadPriority.Normal;

        private AsyncOperationsController asyncController = new AsyncOperationsController();

        public event Action<string> JobState = null;

        private object sync = new object();

        public ThreadManager(Action<IMoneyConverter> method)
        {
          //  asyncController.AsyncOperation = method;
           // asyncController.Invoker =;

            this.method = method;
            currentThread = new Thread(new ParameterizedThreadStart(DoWork));
        }

        public void Start()
        {
            currentThread.Start(terminator);
        }

        public void Stop()
        {
            terminator.Cancel();
        }

        private void DoWork(object currentTerminator)
        {
            ThreadTerminator localTerminator = (ThreadTerminator)currentTerminator;
            try
            {
               // while (true)
                {
                    localTerminator.ThrowIfCancellationRequested();

                    try
                    {
                        ExecuteOperation(localTerminator);
                    }
                    finally
                    {
                        /* any required cleanup */
                        JobState.Invoke(jobComplete);
                    }
                }

            }
            catch (OperationCanceledException)
            {
                // write log that operation 
                // execution have been canceled
                JobState.Invoke(jobCanceled);
            }
        }

        private void ExecuteOperation(ThreadTerminator currentTerminator)
        {
            lock(sync)
            {
                MoneyConverterClient wcfClient = new MoneyConverterClient();

                try
                {
                    wcfClient.Open();
                    method.Invoke(wcfClient);
                    wcfClient.Close();

                    currentTerminator.ThrowIfCancellationRequested();
                }
                catch (TimeoutException timeout)
                {
                    JobState.Invoke(jobTimeout);
                    wcfClient.Abort();
                }
                catch (CommunicationException commException)
                {
                    JobState.Invoke(jobCommunicationException);
                    wcfClient.Abort();
                }
            }
        }

    }
}
