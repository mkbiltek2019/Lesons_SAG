using System.Data;
using System.Data.SqlClient;
using MediaLibrary.Resources;

namespace MediaLibraryClient
{
    public class MediaLibraryView
    {
        public object GetCustomizedViewByTableName(string tableName)
        {
            if (tableName != null)
            {
                DataSet DataSet = null;
                using (SqlDataAdapter DataAdapter = new SqlDataAdapter(
                                      MediaLibraryResource.GetCommand(tableName)
                                     , MediaLibraryResource.connectionString))
                {

                    using (DataSet = new DataSet())
                    {
                        DataAdapter.Fill(DataSet, tableName);
                    }
                }
                return DataSet.Tables[tableName].DefaultView;
            }

            return null;
        }

        public object GetCustomizedViewByPageNumber(string tableName, int pageNumber, int pageSize)
        { // Stored procedures have two parameters @PageSize,@PageIndex"

            DataSet dataSet = null;

            using (SqlConnection sqlConnection = new SqlConnection(MediaLibraryResource.connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = MediaLibraryResource.GetSPCommand(tableName);

                    #region good but it doesn't works . result query string does'nt constructed
                    // command.Parameters.Add - not integrate inputed value to SqlConnection property (command.CommandText)   
                    //command.Connection = sqlConnection;
                    //command.CommandType = CommandType.StoredProcedure;
                    // command.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int)).Value = pageSize;
                    // command.Parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int)).Value = pageNumber; 
                    #endregion

                    string result = string.Format(command.CommandText, pageSize, pageNumber); //bad but it works

                    using (SqlDataAdapter dataAdapter =
                            new SqlDataAdapter(result, sqlConnection))
                    { 
                        using (dataSet = new DataSet(tableName))
                        {
                            dataAdapter.Fill(dataSet, tableName);
                        } 
                    }
                } 
                return dataSet.Tables[tableName].DefaultView;
            }
        }
    }

    public class MediaLibraryViewFactory
    {
        public object GetMediaLibraryView(string tableName)
        {
            return new MediaLibraryView().GetCustomizedViewByTableName(tableName);
        }

        public object GetMediaLibraryView(string tableName, int pageNumber, int pageSize)
        {
            return new MediaLibraryView().GetCustomizedViewByPageNumber(tableName, pageNumber, pageSize);
        }
    }
}
