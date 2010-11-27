using System;
using System.ComponentModel;
using System.EnterpriseServices;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace MoneyConvertClient.Classes
{
    [Synchronization]
    public class AsyncOperationsController : ContextBoundObject
    {
        // this method runs on the background thread
        public void HandleServerNotificationCorrectly()
        {
            // RIGHT: switching threads asynchronously
            Invoker.BeginInvoke(AsyncOperation, null);

            // other code can continue to run here in the background

            // when this method completes, and the thread exits the
            // synchronization domain, the UI thread in the Refresh
            // method will be able enter this or any other synchronized object.
        }

        // have the main form injected into this property
        public ISynchronizeInvoke Invoker
        {
            get; 
            set;
        }

        // the view we want to refresh on server notification
        public Action AsyncOperation
        { 
            get; 
            set; 
        }

    }
}
