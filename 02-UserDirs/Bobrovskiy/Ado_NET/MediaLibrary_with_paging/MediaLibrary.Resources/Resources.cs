using System.Collections;

namespace MediaLibrary.Resources
{
    public enum TableNames
    {
        TrackList = 0,
        Track = 1,
        Singer = 2
    }

    public static class MediaLibraryResource
    {
        public static string connectionString =
                   @"Data Source=WINDA1;
                     Initial Catalog=MediaLibrary;
                     Integrated Security=True;
                     Pooling=False";

        #region select queries
        public static string trackListSelectCommand =
                                  @"SELECT 
                                       [ID]
                                      ,[Name] 
                                    FROM [MediaLibrary].[dbo].[TrackList]";
        public static string trackSelectCommand =
                                  @" SELECT [ID]
                                      ,[Name]
                                      ,[Number]
                                      ,[TrackListID]
                                      ,[SingerID]
                                  FROM [MediaLibrary].[dbo].[Track]";
        public static string singerSelectcommand =
                                  @" SELECT [ID]
                                          ,[Name]
                                      FROM [MediaLibrary].[dbo].[Singer]";
        #endregion

        public static string trackListPagingCommand =
                                @"EXECUTE [MediaLibrary].[dbo].[TrackList.GetAllWithPaging]
                                  {0},
                                  {1}";
        public static string trackPagingCommand =
                                @"EXECUTE [MediaLibrary].[dbo].[Track.GetAllWithPaging]
		                          {0},
		                          {1}";
        public static string singerPagingCommand =
                                @"EXECUTE [MediaLibrary].[dbo].[Singer.GetAllWithPaging]
                                  {0},
                                  {1}";
        #region methods for select query

        public static string GetCommand(string tableName)
        {
            return GetResult(FillHashTableBySelectCommands(), tableName);
        }

        private static Hashtable FillHashTableBySelectCommands()
        {
            Hashtable table = new Hashtable();
            table.Add(TableNames.TrackList.ToString(),
                      trackListSelectCommand);
            table.Add(TableNames.Track.ToString(),
                      trackSelectCommand);
            table.Add(TableNames.Singer.ToString(),
                      singerSelectcommand);
            return table;
        }

        #endregion

        private static string GetResult(Hashtable table, string tableName)
        {
            string result = string.Empty;
            foreach (DictionaryEntry tab in table)
            {
                if ((string)tab.Key == tableName)
                {
                    result = (string)tab.Value;
                    break;
                }
            }
            return result;
        }

        #region methods for stored procedure

        public static string GetSPCommand(string tableName)
        {
            return GetResult(FillHashTableBySPCommands(), tableName);
        }

        private static Hashtable FillHashTableBySPCommands()
        {
            Hashtable table = new Hashtable();
            table.Add(TableNames.TrackList.ToString(),
                      trackListPagingCommand);
            table.Add(TableNames.Track.ToString(),
                      trackPagingCommand);
            table.Add(TableNames.Singer.ToString(),
                      singerPagingCommand);
            return table;
        }

        #endregion
    }
}
