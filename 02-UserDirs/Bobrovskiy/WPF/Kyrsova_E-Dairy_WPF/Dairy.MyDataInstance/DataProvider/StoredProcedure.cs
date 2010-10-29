using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Dairy.MyDataInstance;

namespace Dairy.DataAccess.DataProvider
{
    public class StoredProcedure
    {
        private IParameterMapper parameterMapper = null;
        private string name = null;
        private List<ParameterItem> parameterValueCollection = null;

        public IParameterMapper ParameterMapper
        {
            get
            {
                if (parameterMapper == null)
                {
                    parameterMapper = new SimpleParameterMapper();
                }

                return parameterMapper;
            }
        }

        public List<ParameterItem> ParameterValueCollection
        {
            get
            {
                return parameterValueCollection;
            }
            set
            {
                parameterValueCollection = value;
            }
        }

        public object[] ParameterValues 
        {
            get 
            {
                object[] parameterValues =  new object[parameterValueCollection.Count];
                for (int i = 0; i < parameterValueCollection.Count; i++)
			    {
                    parameterValues[i] = parameterValueCollection[i];
			    }

                return parameterValues;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

    }
}
