using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using AudioFileTagger;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Model;
using mp3Collader.DataAccess;
using System.Data.Odbc;
using mp3Collader.Instance;

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
        FileName,
        Track
    }

    public class Resources
    {
        public Hashtable CreateInsertSPList()
        {
            Hashtable spList = new Hashtable();

            spList.Add(TableList.Artist, @"ArtistInsert_SP");
            spList.Add(TableList.Album, @"AlbumInsert_SP");
            spList.Add(TableList.Bitrate, @"BitrateInsert_SP");
            spList.Add(TableList.Genre, @"GenreInsert_SP");
            spList.Add(TableList.Path, @"PathInsert_SP");
            spList.Add(TableList.Track, @"TrackInsert_SP");

            return spList;
        }

        public Hashtable CreateQueryStringList()
        {
            Hashtable spList = new Hashtable();

            spList.Add(TableList.Artist, @"SELECT [Name] FROM [MediaLibrary].[dbo].[Artist]");
            spList.Add(TableList.Album, @"SELECT [Name] FROM [MediaLibrary].[dbo].[Album]");
            spList.Add(TableList.Genre, @"SELECT [Name] FROM [MediaLibrary].[dbo].[Genre]");
            spList.Add(TableList.Title, @"SELECT [TrackTitle] FROM [MediaLibrary].[dbo].[Track]");
            spList.Add(TableList.FileName, @"SELECT [FileName] FROM [MediaLibrary].[dbo].[Track]");

            return spList;
        }

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

        private int InsertValueByTableName(string value, TableList tableName)
        {
            Database database = (new DbFactory()).CreateDatabase();

            string spName = ((new Resources()).CreateInsertSPList())[tableName].ToString();

            ExecuteStoredProcWithParam executeStoredProcWithParam = new ExecuteStoredProcWithParam(database, spName);

            executeStoredProcWithParam.AddInParameter(database, value, "ValueToInsert");
            executeStoredProcWithParam.AddOutParameter(database, "return_value");
            executeStoredProcWithParam.ExecuteSpSetResultValue(database, "return_value");

            return executeStoredProcWithParam.resultValue;
        }

        public void Insert(FileInfo fileInfo, AudioFileInfo audioFileInfo)
        {
            Database database = (new DbFactory()).CreateDatabase();

            string spName = ((new Resources()).CreateInsertSPList())[TableList.Track].ToString();

            ExecuteStoredProcWithParam executeStoredProcWithParam = new ExecuteStoredProcWithParam(database, spName);

            executeStoredProcWithParam.AddInParameter(database,
                InsertValueByTableName(fileInfo.DirectoryName, TableList.Path),
                "PathID");

            executeStoredProcWithParam.AddInParameter(database,
                InsertValueByTableName(audioFileInfo.Artist, TableList.Artist),
                "ArtistID");

            executeStoredProcWithParam.AddInParameter(database,
                InsertValueByTableName(audioFileInfo.Album, TableList.Album),
                "AlbumID");

            executeStoredProcWithParam.AddInParameter(database,
                InsertValueByTableName(audioFileInfo.Genre, TableList.Genre),
                "GenreID");

            executeStoredProcWithParam.AddInParameter(database,
                InsertValueByTableName(audioFileInfo.Bitrate, TableList.Bitrate),
                "BitrateID");

            executeStoredProcWithParam.AddInParameter(database,
              audioFileInfo.Title,
              "TrackTitle");

            executeStoredProcWithParam.AddInParameter(database,
              fileInfo.Name,
              "FileName");

            executeStoredProcWithParam.AddInParameter(database,
              fileInfo.Length,
              "FileSize");

            string newName = string.Empty;

            if (string.IsNullOrEmpty(audioFileInfo.Artist) && string.IsNullOrEmpty(audioFileInfo.Title))
            {
                newName = fileInfo.Name;
            }   else
            {
                newName = audioFileInfo.Artist + "_" + audioFileInfo.Title;
            }
           
            executeStoredProcWithParam.AddInParameter(database,
              newName,
              "NewFileName");

            executeStoredProcWithParam.AddOutParameter(database, "return_value");
            executeStoredProcWithParam.ExecuteSpSetResultValue(database, "return_value");

        }

        public IList GetListByTableName(TableList tableName)
        {
            IList nameList = null;

            Database database = (new DbFactory()).CreateDatabase();

            IDataProvider<ResultTable> resultTableProvider;
            IDataProvider<SimpleTable> simpleTableProvider; 

            string parameter = "Name";

            switch (tableName)
            {
                case TableList.Title:
                    {
                        parameter = "TrackTitle";
                    } break;
                case TableList.FileName:
                    {
                        parameter = "FileName";
                    } break;

            }

            if ((tableName == TableList.Title) || (tableName == TableList.FileName))
            {
                resultTableProvider =
                              new DataProviderWithSynchronouseAccessor<ResultTable>();

                resultTableProvider.SqlQueryString = (new Resources().CreateQueryStringList())[tableName].ToString();

                nameList = resultTableProvider.GetDataFromSqlQueryStringAccessor(database).ToList();

            }else
            {
                simpleTableProvider = 
                            new DataProviderWithSynchronouseAccessor<SimpleTable>();
                
                simpleTableProvider.SqlQueryString = (new Resources().CreateQueryStringList())[tableName].ToString();

                nameList = simpleTableProvider.GetDataFromSqlQueryStringAccessor(database).ToList();
            } 

            return nameList;
        }

        public void ClearDataBase()
        {
            Database database = (new DbFactory()).CreateDatabase();

            string spName = @"TrancateDataBase_SP";

            ExecuteStoredProcWithParam executeStoredProcWithParam = new ExecuteStoredProcWithParam(database, spName);

            executeStoredProcWithParam.AddOutParameter(database, "return_value");
            executeStoredProcWithParam.ExecuteSpSetResultValue(database, "return_value");

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
