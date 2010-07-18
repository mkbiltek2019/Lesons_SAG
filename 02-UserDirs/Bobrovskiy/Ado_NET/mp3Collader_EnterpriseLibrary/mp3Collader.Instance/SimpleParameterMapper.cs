using System;
using System.Data.Common;
using System.Data.Odbc;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace mp3Collader.Instance
{
    public class SimpleParameterMapper : IParameterMapper
    {
        public void AssignParameters(DbCommand command, object[] parameterValues)
        {
            foreach (object parameterValue in parameterValues)
            {
              command.Parameters.Add(parameterValue);
            } 
        }
    }

}
