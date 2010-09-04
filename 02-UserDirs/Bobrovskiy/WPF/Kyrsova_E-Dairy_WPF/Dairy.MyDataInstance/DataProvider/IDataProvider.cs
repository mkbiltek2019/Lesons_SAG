using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Instance.DataProvider
{
    public interface IDataProvider<TResultTable> where TResultTable : new()
    {
        string StoredProcedureName
        {
            get;
            set;
        }

        Database CurrentDatabaseInstance
        {
            get; 
            set;
        }    

        object[] DatabaseParameterValue
        {
            get;
            set;
        }

        IEnumerable<TResultTable> Run();
    }
}
