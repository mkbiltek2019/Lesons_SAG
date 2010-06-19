using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace InteractionWithJavascriptDemo
{
    public delegate void AddCompletedEventHandler(object sender, decimal result);

    [ComVisible(true)]
    public class Communicator
    {
        public event AddCompletedEventHandler OnResultReceived;

        public void ReturnResult(object input)
        {
            if(OnResultReceived != null)
                OnResultReceived.Invoke(this, decimal.Parse(input.ToString()));
        }
    }
}
