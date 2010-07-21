using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AudioFileTagger;
using Microsoft.Practices.EnterpriseLibrary.Data;

using Model;
using mp3Collader.DataAccess;
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
        Track,
        ClearDataBase
    }

    public class TableController
    {
        private List<ResultTable> resultList = new List<ResultTable>();

        public List<ResultTable> ResultList
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

            executeStoredProcWithParam.AddInParameter(database, value, @"ValueToInsert");
            executeStoredProcWithParam.AddOutParameter(database, @"return_value");

            return executeStoredProcWithParam.ExecuteSpSetResultValue(database, @"return_value");
        }

        public void Insert(FileInfo fileInfo, AudioFileInfo audioFileInfo)
        {
            Database database = (new DbFactory()).CreateDatabase();

            string spName = ((new Resources()).CreateInsertSPList())[TableList.Track].ToString();

            ExecuteStoredProcWithParam executeStoredProcWithParam = 
                    new ExecuteStoredProcWithParam(database, spName);

            executeStoredProcWithParam.AddInParameter(database,
                InsertValueByTableName(fileInfo.DirectoryName, TableList.Path),
                @"PathID");

            executeStoredProcWithParam.AddInParameter(database,
                InsertValueByTableName(audioFileInfo.Artist, TableList.Artist),
                @"ArtistID");

            executeStoredProcWithParam.AddInParameter(database,
                InsertValueByTableName(audioFileInfo.Album, TableList.Album),
                @"AlbumID");

            executeStoredProcWithParam.AddInParameter(database,
                InsertValueByTableName(audioFileInfo.Genre, TableList.Genre),
                @"GenreID");

            executeStoredProcWithParam.AddInParameter(database,
                InsertValueByTableName(audioFileInfo.Bitrate, TableList.Bitrate),
                @"BitrateID");

            executeStoredProcWithParam.AddInParameter(database,
              audioFileInfo.Title,
              @"TrackTitle");

            executeStoredProcWithParam.AddInParameter(database,
              fileInfo.Name,
              @"FileName");

            executeStoredProcWithParam.AddInParameter(database,
              fileInfo.Length,
              @"FileSize");

            string newName = string.Empty;

            if (string.IsNullOrEmpty(audioFileInfo.Artist) && string.IsNullOrEmpty(audioFileInfo.Title))
            {
                newName = fileInfo.Name;
            }
            else
            {
                newName = audioFileInfo.Artist + "_" + audioFileInfo.Title;
            }

            executeStoredProcWithParam.AddInParameter(database,
              newName,
              @"NewFileName");

            executeStoredProcWithParam.AddOutParameter(database, @"return_value");
            executeStoredProcWithParam.ExecuteSpSetResultValue(database, @"return_value");

        }

        public IList GetListByTableName(TableList tableName)
        {
            Database database = (new DbFactory()).CreateDatabase();

            IDataProvider<SimpleTable> resultTableProvider =
                new DataProviderWithSynchronouseAccessor<SimpleTable>();

            resultTableProvider.StoredProcedureName =
                (new Resources().CreateSelectSPList())[tableName].ToString();

            IRowMapper<SimpleTable> mapper = MapBuilder<SimpleTable>.MapAllProperties()
                              .MapByName(x => x.Name)
                              .Build();

            return resultTableProvider.GetDataFromStoredProcedureAccessor(database, null, mapper).ToList();
        }

        public void ClearDataBase()
        {
            Database database = (new DbFactory()).CreateDatabase();

            ExecuteStoredProcWithParam executeStoredProcWithParam =
                new ExecuteStoredProcWithParam(
                    database, 
                    (new Resources().CreateSelectSPList())[TableList.ClearDataBase].ToString());

            executeStoredProcWithParam.AddOutParameter(database, @"return_value");
            executeStoredProcWithParam.ExecuteSpSetResultValue(database, @"return_value");
        }

        public object GetCustomizedViewByTableName(
                                                    int pageSize,
                                                    int pageIndex,
                                                    string albumFilter,
                                                    string artistFilter,
                                                    string genreFilter,
                                                    string fileNameFilter)
        {
            Database database = (new DbFactory()).CreateDatabase();

            IDataProvider<ResultTable> resultTableProvider =
                new DataProviderWithSynchronouseAccessor<ResultTable>();

            resultTableProvider.StoredProcedureName =
                (new Resources().CreateSelectSPList())[TableList.Track].ToString();

            // - stored procedure parameter order is very important thing
            object[] myParameterList =
                     new object[]
                               {   new ParameterItem()
                                       {
                                         ParameterName  = "@Album", 
                                         ParameterValue  = albumFilter 
                                       }   ,
                                   new ParameterItem()
                                       {
                                         ParameterName  = "@Artist", 
                                         ParameterValue  = artistFilter
                                       }   , 
                                   new ParameterItem()
                                       {
                                         ParameterName = "@Genre", 
                                         ParameterValue = genreFilter  
                                       }   , 
                                   new ParameterItem()
                                       {
                                         ParameterName  = "@FileName", 
                                         ParameterValue  = fileNameFilter 
                                       },
                                   new ParameterItem()
                                       {
                                         ParameterName  = "@PageSize",
                                         ParameterValue  = pageSize 
                                       }   ,
                                   new ParameterItem()
                                       {
                                         ParameterName  = "@PageIndex", 
                                         ParameterValue  = pageIndex 
                                       }   
                                };

            resultTableProvider.DbParameterValues = myParameterList;

            IRowMapper<ResultTable> mapper = MapBuilder<ResultTable>.MapAllProperties()
                              .MapByName(x => x.AlbumName)
                              .MapByName(x => x.ArtistName)
                              .MapByName(x => x.Bitrate)
                              .MapByName(x => x.FileName)
                              .MapByName(x => x.FileSize)
                              .MapByName(x => x.GenreName)
                              .MapByName(x => x.NewName)
                              .MapByName(x => x.FullPath)
                              .MapByName(x => x.TrackTitle)
                              .Build();

            resultList =  resultTableProvider.GetDataFromStoredProcedureAccessor(database, myParameterList, mapper).ToList();
                       
            return resultList;     
        }
    }
}
