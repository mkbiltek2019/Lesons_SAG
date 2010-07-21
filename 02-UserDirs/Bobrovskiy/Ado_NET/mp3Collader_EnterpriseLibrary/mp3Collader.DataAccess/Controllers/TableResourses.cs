using System.Collections;

namespace mp3Collader.Controllers
{
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
            spList.Add(TableList.ClearDataBase, @"TrancateDataBase_SP");

            return spList;
        }

        public Hashtable CreateSelectSPList()
        {
            Hashtable spList = new Hashtable();

            spList.Add(TableList.Artist, @"SelectArtistName_SP");
            spList.Add(TableList.Album, @"SelectAlbumName_SP");
            spList.Add(TableList.Genre, @"SelectGenreName_SP");
            spList.Add(TableList.Title, @"SelectTrackTitleName_SP");
            spList.Add(TableList.FileName, @"SelectFileName_SP");
            spList.Add(TableList.Track, @"[dbo].[MediaLibrary.GetAllWithPaging]");

            return spList;
        }

    }

}
