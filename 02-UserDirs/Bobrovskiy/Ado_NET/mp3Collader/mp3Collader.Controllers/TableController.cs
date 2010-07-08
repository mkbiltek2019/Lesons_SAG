using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using AudioFileTagger;
using Model;
using mp3Collader.DataAccess;

namespace mp3Collader.Controllers
{
    public enum TableList
    {
        Artist,
        Path,
        Album,
        Genre,
        Bitrate,
        Title,
        FileName
    }

    public class TableController
    {
        private List<Model.ResultTable> resultList = new List<ResultTable>();

        public List<Model.ResultTable> ResultList
        {
            get
            {
                return resultList;
            }
        }

        private int InsertValueByTableName(string Value, TableList tableName)
        {
            int result = 0;
            using (SqlConnection connection = DBConnectionFactory.GetConnection())
            {
                connection.Open();

                SqlCommand insertCommand = null;
                switch (tableName)
                {
                    case TableList.Artist:
                        {
                            insertCommand = new SqlCommand(@"ArtistInsert_SP", connection);
                        }
                        break;
                    case TableList.Album:
                        {
                            insertCommand = new SqlCommand(@"AlbumInsert_SP", connection);
                        }
                        break;
                    case TableList.Bitrate:
                        {
                            insertCommand = new SqlCommand(@"BitrateInsert_SP", connection);
                        }
                        break;
                    case TableList.Genre:
                        {
                            insertCommand = new SqlCommand(@"GenreInsert_SP", connection);
                        }
                        break;
                    case TableList.Path:
                        {
                            insertCommand = new SqlCommand(@"PathInsert_SP", connection);
                        }
                        break;
                }
                if (insertCommand != null)
                {
                    insertCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter returnValue = new SqlParameter("@return_value", null);
                    insertCommand.Parameters.Add(returnValue);
                    returnValue.Direction = ParameterDirection.ReturnValue;

                    SqlParameter nameParameter = new SqlParameter("@ValueToInsert", Value);
                    insertCommand.Parameters.Add(nameParameter);
                    nameParameter.Direction = ParameterDirection.Input;

                    int affectedRows = (int)insertCommand.ExecuteNonQuery();
                    result = Convert.ToInt32(returnValue.Value);
                }
            }

            return result;
        }

        public void Insert(FileInfo fileInfo, AudioFileInfo audioFileInfo)
        {
            using (SqlConnection connection = DBConnectionFactory.GetConnection())
            {
                connection.Open();

                using (SqlCommand insertCommand = new SqlCommand(@"TrackInsert_SP", connection))
                {
                    insertCommand.CommandType = CommandType.StoredProcedure;

                    #region satelite table values

                    int result1 = InsertValueByTableName(fileInfo.DirectoryName, TableList.Path);
                    SqlParameter PathID = new SqlParameter("@PathID", result1);
                    insertCommand.Parameters.Add(PathID);
                    PathID.Direction = ParameterDirection.Input;

                    int result2 = InsertValueByTableName(audioFileInfo.Artist, TableList.Artist);
                    SqlParameter ArtistID = new SqlParameter("@ArtistID", result2);
                    insertCommand.Parameters.Add(ArtistID);
                    ArtistID.Direction = ParameterDirection.Input;

                    int result3 = InsertValueByTableName(audioFileInfo.Album, TableList.Album);
                    SqlParameter AlbumID = new SqlParameter("@AlbumID", result3);
                    insertCommand.Parameters.Add(AlbumID);
                    AlbumID.Direction = ParameterDirection.Input;

                    int result4 = InsertValueByTableName(audioFileInfo.Genre, TableList.Genre);
                    SqlParameter GenreID = new SqlParameter("@GenreID", result4);
                    insertCommand.Parameters.Add(GenreID);
                    GenreID.Direction = ParameterDirection.Input;

                    int result5 = InsertValueByTableName(audioFileInfo.Bitrate, TableList.Bitrate);
                    SqlParameter BitrateID = new SqlParameter("@BitrateID", result5);
                    insertCommand.Parameters.Add(BitrateID);
                    BitrateID.Direction = ParameterDirection.Input;

                    #endregion

                    SqlParameter TrackTitle = new SqlParameter("@TrackTitle", audioFileInfo.Title);
                    insertCommand.Parameters.Add(TrackTitle);
                    TrackTitle.Direction = ParameterDirection.Input;

                    SqlParameter FileName = new SqlParameter("@FileName", fileInfo.Name);
                    insertCommand.Parameters.Add(FileName);
                    FileName.Direction = ParameterDirection.Input;

                    SqlParameter FileSize = new SqlParameter("@FileSize", fileInfo.Length);
                    insertCommand.Parameters.Add(FileSize);
                    FileSize.Direction = ParameterDirection.Input;

                    string newName = audioFileInfo.Artist + "_" + audioFileInfo.Title;
                    SqlParameter NewFileName = new SqlParameter("@NewFileName", newName);
                    insertCommand.Parameters.Add(NewFileName);
                    NewFileName.Direction = ParameterDirection.Input;

                    int affectedRows = (int)insertCommand.ExecuteNonQuery();
                }
            }
        }

        public List<string> GetListByTableName(TableList tableName)
        {
            List<string> nameList = new List<string>();

            using (SqlConnection connection = DBConnectionFactory.GetConnection())
            {
                connection.Open();
                SqlCommand insertCommand = null;
                string sqlCommand = string.Empty;
                string parameter = "Name";

                switch (tableName)
                {
                    case TableList.Artist:
                        {
                            sqlCommand = @"SELECT [Name] FROM [MediaLibrary].[dbo].[Artist]";
                        }
                        break;
                    case TableList.Album:
                        {
                            sqlCommand = @"SELECT [Name] FROM [MediaLibrary].[dbo].[Album]";
                        }
                        break;
                    case TableList.Genre:
                        {
                            sqlCommand = @"SELECT [Name] FROM [MediaLibrary].[dbo].[Genre]";
                        }
                        break;
                    case TableList.Title:
                        {
                            sqlCommand = @"SELECT [TrackTitle] FROM [MediaLibrary].[dbo].[Track]";
                            parameter = "TrackTitle";
                        } break;
                    case TableList.FileName:
                        {
                            sqlCommand = @"SELECT [FileName] FROM [MediaLibrary].[dbo].[Track]";
                            parameter = "FileName";
                        } break;

                }

                using (insertCommand = new SqlCommand(sqlCommand, connection))
                {
                    insertCommand.CommandType = CommandType.Text;

                    using (SqlDataReader dataReader = insertCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            nameList.Add(dataReader[parameter].ToString());
                        }
                    }

                }
            }

            return nameList;
        }

        public void ClearDataBase()
        {
            using (SqlConnection connection = DBConnectionFactory.GetConnection())
            {
                connection.Open();

                using (SqlCommand insertCommand = new SqlCommand(@"TrancateDataBase_SP", connection))
                {
                    insertCommand.CommandType = CommandType.StoredProcedure;
                    int affectedRows = (int)insertCommand.ExecuteNonQuery();
                }
            }
        }

        public object GetCustomizedViewByTableName(
                                                    int pageSize,
                                                    int pageIndex,
                                                    string albumFilter,
                                                    string artistFilter,
                                                    string genreFilter,
                                                    string fileNameFilter)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = DBConnectionFactory.GetConnection())
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(@"[MediaLibrary.GetAllWithPaging]", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@PageSize", pageSize);
                sqlCommand.Parameters.AddWithValue("@PageIndex", pageIndex);
                sqlCommand.Parameters.AddWithValue("@Album", albumFilter);
                sqlCommand.Parameters.AddWithValue("@Artist", artistFilter);
                sqlCommand.Parameters.AddWithValue("@Genre", genreFilter);
                sqlCommand.Parameters.AddWithValue("@FileName", fileNameFilter);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                // create view list for dataGridView
               
                
                while (reader.Read())
                {   
                    int id = Convert.ToInt32(reader["TrackID"]);
                    string genre = Convert.ToString(reader["GenreName"]);
                    string albumName = Convert.ToString(reader["AlbumName"]);
                    string artistName = Convert.ToString(reader["ArtistName"]);
                    string pathName = Convert.ToString(reader["FullPath"]);
                    string bitrate = Convert.ToString(reader["Bitrate"]);
                    string fileSize = Convert.ToString(reader["FileSize"]);
                    string newFileName = Convert.ToString(reader["NewName"]);
                    string fileName = Convert.ToString(reader["FileName"]);
                    string trackTitle = Convert.ToString(reader["TrackTitle"]);

                    resultList.Add(new ResultTable()
                     {
                         GenreName = genre,
                         AlbumName = albumName,
                         ArtistName = artistName,
                         PathName = pathName,
                         Bitrate = bitrate,
                         FileSize = fileSize,
                         NewFileName = newFileName,
                         FileName = fileName,
                         TrackTitle = trackTitle
                     });
                }
 
                reader.Close();
                reader.Dispose();
                reader = sqlCommand.ExecuteReader();

               dt.Load(reader);
              

               return new DataView(dt); 
            } 

           
        }
    }
}
