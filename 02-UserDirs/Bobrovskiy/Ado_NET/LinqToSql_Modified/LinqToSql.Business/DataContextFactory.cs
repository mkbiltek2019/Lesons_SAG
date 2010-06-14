using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToSql.Business
{
    public static class DataContextFactory<DataContextType>
        where DataContextType : System.Data.Linq.DataContext, new()
    {
        private static DataContextType dataContextInstance;
        public static DataContextType DataContext
        {
            get
            {
                return dataContextInstance;
            }
        }

        static DataContextFactory()
        {
            dataContextInstance = new DataContextType();
        }
    }
}
