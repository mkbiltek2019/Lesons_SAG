using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownloadManager.NET
{
    class Download
    {
        private string _fileName;
        private Int64 _fileSize;
        private Int64 _completed;
        private int _progress;
        private DateTime _left;
        private double _speed;
        private DateTime _begin;
        private string _status;
        private string _urlDownlad;

        public string FileName
        {
            set { _fileName = value; }
            get { return _fileName; }
        }
        public Int64 FileSize
        {
            set { _fileSize = value; }
            get { return _fileSize; }
        }
        public Int64 Completed
        {
            set { _completed = value; }
            get { return _completed; }
        }
        public int Progress
        {
            set { _progress = value; }
            get { return _progress; }
        }
        public DateTime Left
        {
            set { _left = value; }
            get { return _left; }
        }
        public double Speed
        {
            set { _speed = value; }
            get { return _speed; }
        }
        public DateTime Begin
        {
            set { _begin = value; }
            get { return _begin; }
        }
        public string Status
        {
            set { _status = value; }
            get { return _status; }
        }
        public string UrlDwnload
        {
            set { _urlDownlad = value; }
            get { return _urlDownlad; }
        }
    }
}
