using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Dairy.MyDataInstance
{
    public class SimpleParameterMapper : IParameterMapper
    {
        public void AssignParameters(DbCommand command, object[] parameterValues)
        {
            if (parameterValues != null)
            {
                foreach (ParameterItem parameterValue in parameterValues)
                {
                    DbParameter parameter = command.CreateParameter();
                    parameter.ParameterName = parameterValue.ParameterName;
                    parameter.Value = parameterValue.ParameterValue;
                    command.Parameters.Add(parameter);
                }
            }
        }
    }

}
