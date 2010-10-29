using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Dairy.DataAccess.DataProvider;

namespace Instance.DataProvider
{
    public interface IDataProvider<TResultTable> where TResultTable : new()
    {
        Database CurrentDatabaseInstance
        {          
            set;
        }    

        IEnumerable<TResultTable> Run(StoredProcedure storedProcedure);
    }
}
