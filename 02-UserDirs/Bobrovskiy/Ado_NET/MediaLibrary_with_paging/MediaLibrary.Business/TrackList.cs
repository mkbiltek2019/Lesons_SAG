using System.Data.SqlClient;
using MediaLibrary.Resources;

namespace MediaLibrary.Business
{
    public class TrackList
    {
        public int? ID { get; set; }
        public string Name { get; set; }

        public int Save()
        {
            return ID == null ? Insert() : Update();
        }

        private int Update()
        {
            int affectedRows = 0;
            using (var connection =
                new SqlConnection(MediaLibraryResource.connectionString))
            {
                connection.Open();

                SqlCommand insertCommand = new SqlCommand(@"
                    UPDATE [MediaLibrary].[dbo].[TrackList]
                    SET [Name] = @Name
                    WHERE [ID]=@SelectedID", connection);
                SqlParameter selectedIDParameter = new SqlParameter("@SelectedID", ID);
                insertCommand.Parameters.Add(selectedIDParameter);
                SqlParameter nameParameter = new SqlParameter("@Name", Name);
                insertCommand.Parameters.Add(nameParameter);

                affectedRows = insertCommand.ExecuteNonQuery();
            }

            return affectedRows;
        }

        private int Insert()
        {
            int affectedRows = 0;
            using (var connection =
                new SqlConnection(MediaLibraryResource.connectionString))
            {
                connection.Open();

                SqlCommand insertCommand = new SqlCommand(@"
                    INSERT INTO [MediaLibrary].[dbo].[TrackList]
                    ([Name])
                    VALUES
                    (@Name)", connection);
                SqlParameter nameParameter = new SqlParameter("@Name", Name);
                insertCommand.Parameters.Add(nameParameter);

                affectedRows = insertCommand.ExecuteNonQuery();
            }

            return affectedRows;

        }
    }
}
