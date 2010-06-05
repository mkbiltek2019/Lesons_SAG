using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace MediaLibrary.Business
{
    public class TrackList
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int Save()
        {
            int affectedRows = 0;
            using (var connection =
                new SqlConnection("Data Source=A1COMP10;Initial Catalog=13HS9_Manekovskiy_MediaLibrary;Integrated Security=True;Pooling=False"))
            {
                connection.Open();

                SqlCommand insertCommand = new SqlCommand(@"
                    INSERT INTO [13HS9_Manekovskiy_MediaLibrary].[dbo].[TrackList]
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
