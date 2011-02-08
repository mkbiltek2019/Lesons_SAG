using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace WpfDiary.NET
{
    [Serializable]
    class Task
    {
        [XmlAttribute("Date")]
        private string _date;
        [XmlAttribute("Title")]
        private string _title;
        [XmlAttribute("Content")]
        private string _content;
        [XmlAttribute("Status")]
        private string _status;
        [XmlAttribute("Comment")]
        private string _comment;

        public string Date
        {
            set { _date = value; }
            get { return _date; }
        }
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        public string Status
        {
            set { _status = value; }
            get { return _status; }
        }
        public string Comment
        {
            set { _comment = value; }
            get { return _comment; }
        }
        public Task()
        {
            _date =  "1.01.2010";
            _title = null;
            _content = null;
            _status = null;
            _comment = null;
        }
        public Task(string date, string title, string content, string status, string comment)
        {
            _date = date;
            _title = title;
            _content = content;
            _status = status;
            _comment = comment;
        }
      

        //public List<Task> List = new List<Task>();
    }
}
