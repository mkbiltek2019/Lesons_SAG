using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace WpfDiary.NET
{
    class ListTask
    {
        private List<Task> _taskList = new List<Task>();
        public List<Task> TaskList
        {
            set { _taskList = value; }
            get { return _taskList; }
        }
        public ListTask(Task task)
        {
            _taskList.Add(task);
        }
        public ListTask()
        {
           
        }
        public void Sort()
        {
            for (int i = 0; i < _taskList.Count; i++)
            {
                Task min = new Task();
                 min = _taskList[i];
                int indexMin = i;
                for (int j = i + 1; j < _taskList.Count; j++)
                {
                    if (Convert.ToDateTime( min.Date) > Convert.ToDateTime( _taskList[j].Date))
                    {
                        min = _taskList[j];
                        indexMin = j;
                    }
                }
                _taskList[indexMin] = _taskList[i];
                _taskList [i] = min;
            }
        }
        public void LoadXmlFile(string nameFile)
        {
            XElement list = XElement.Load(nameFile);

            IEnumerable<XElement> date =
                from element in list
                    .Elements("Task")
                    .Elements("Date")
                select element;

            IEnumerable<XElement> title =
                from element in list
                    .Elements("Task")
                    .Elements("Title")
                select element;

            IEnumerable<XElement> content =
                from element in list
                    .Elements("Task")
                    .Elements("Content")
                select element;

            IEnumerable<XElement> status = 
                from element in list
                    .Elements("Task")
                    .Elements("Status")
                select element;

            IEnumerable<XElement> comment =
                from element in list
                    .Elements("Task")
                    .Elements("Comment")
                select element;

            for (int i = 0; i < title.Count(); i++)
            {
                Task task = new Task(date.ElementAt(i).Value, title.ElementAt(i).Value,
                    content.ElementAt(i).Value, status.ElementAt(i).Value,comment.ElementAt(i).Value);
                _taskList.Add(task);
            }
        }
        public void WriteXmlFile(string fileName)
        {
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter(fileName, System.Text.Encoding.Default);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("Tasks");
                for (int i = 0; i < _taskList.Count; i++)
                {
                    Task task = new Task();
                    task = _taskList[i];
                    writer.WriteStartElement("Task");
                    writer.WriteElementString("Date", task.Date);
                    writer.WriteElementString("Title", task.Title);
                    writer.WriteElementString("Content", task.Content);
                    writer.WriteElementString("Status", task.Status);
                    writer.WriteElementString("Comment", task.Comment);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        public void Append(Task task1, string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNode root = doc.DocumentElement;
            //root.RemoveChild(root.LastChild);

            XmlNode task = doc.CreateElement("Task");
            XmlNode elem1 = doc.CreateElement("Date");
            XmlNode elem2 = doc.CreateElement("Title");
            XmlNode elem3 = doc.CreateElement("Content");
            XmlNode elem4 = doc.CreateElement("Status");
            XmlNode elem5 = doc.CreateElement("Comment");


            XmlNode text1 = doc.CreateTextNode(task1.Date);
            XmlNode text2 = doc.CreateTextNode(task1.Title);
            XmlNode text3 = doc.CreateTextNode(task1.Content);
            XmlNode text4 = doc.CreateTextNode(task1.Status);
            XmlNode text5 = doc.CreateTextNode(task1.Comment);

            elem1.AppendChild(text1);
            elem2.AppendChild(text2);
            elem3.AppendChild(text3);
            elem4.AppendChild(text4);
            elem5.AppendChild(text5);

            task.AppendChild(elem1);
            task.AppendChild(elem2);
            task.AppendChild(elem3);
            task.AppendChild(elem4);
            task.AppendChild(elem5);

            root.AppendChild(task);

            doc.Save(fileName);
        }

    }
}
