using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppWithStandAloneServerAndClient.WCF_Server
{
    public class ServiceData
    {
        public string State
        {
            get; 
            set;
        }

        public string Name
        {
            get; 
            set;
        }

        public string NameSpace
        {
            get; 
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public List<string> AddressesCollection
        {
            get; 
            set;
        }

        public List<string> BindingCollection
        {
            get;
            set;
        }
        
    }
}
