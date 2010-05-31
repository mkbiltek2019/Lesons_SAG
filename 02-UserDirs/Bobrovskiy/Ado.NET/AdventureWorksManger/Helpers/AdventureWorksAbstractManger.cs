using System.Data;

namespace Helpers
{
    public abstract class AdventureWorksAbstractManger
    {
        public string TableName
        {
            get;
            set;
        }

        public abstract void FillTableAdapter();

        public DataTable ExtractDataColumnCollection(object dataSource)
        {
            DataTable resultDataTable = null;

            using (DataTable dataTable = ((DataSet)dataSource).Tables[TableName])
            {
                resultDataTable = dataTable.Clone();
            }

            return resultDataTable;
        }
    }

}
