using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace mp3Collader.DataAccess
{
    class MadiaLibraryManager
    {
        //public IEnumerable<User> GetAllUsersWithPaging( string name, 
        //                                                string phone, 
        //                                                string address, 
        //                                                int pageNumber, 
        //                                                int pageSize)
        //{
        //    using (SqlConnection connection = DBConnectionFactory.GetConnection())
        //    {
        //        connection.Open();
        //        using (SqlCommand command = new SqlCommand("[User.GetAllWithPaging]", connection))
        //        {
        //            command.CommandType = System.Data.CommandType.StoredProcedure;

        //            command.Parameters.AddWithValue("@name", name);
        //            command.Parameters.AddWithValue("@phone", phone);
        //            command.Parameters.AddWithValue("@address", address);
        //            command.Parameters.AddWithValue("@pageNumber", pageNumber);
        //            command.Parameters.AddWithValue("@pageSize", pageSize);

        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    yield return new User()
        //                    {
        //                        ID = Convert.ToInt32(reader["ID"]),
        //                        Name = Convert.ToString(reader["Name"]),
        //                        Phone = Convert.ToString(reader["Phone"]),
        //                        Address = Convert.ToString(reader["Address"])
        //                    };
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
