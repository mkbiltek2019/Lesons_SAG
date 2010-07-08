using System.IO;
using HundredMilesSoftware.UltraID3Lib;

namespace AudioFileTagger
{
    public class AudioFileInfo
    {
        public string Artist
        {
            get;
            set;
        }

        public string Album
        {
            get;
            set;
        }

        public string Genre
        {
            get;
            set;
        }

        public string Bitrate
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }
        
        public AudioFileInfo()
        {
            Artist = "Artist";
            Album = "Album";
            Genre = "Genre";
            Bitrate = "Bitrate";
            Title = "Title";

        }

        public void GetInfo(FileInfo audioFile)
        {
            UltraID3 lib = new UltraID3();
            lib.Read(audioFile.FullName);
            Artist = lib.Artist;
            Album = lib.Album;
            Genre = lib.Genre;
            Bitrate = lib.FirstMPEGFrameInfo.Bitrate.ToString();
            Title = lib.Title;
        }
    }
}
