using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppWithStandAloneServerAndClient.WCF_Server
{
    interface IWCFServise
    {
        void Start();
        void Stop();
        ServiceData GetData();
    }
}
