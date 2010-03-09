using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;

using Helpers.Console;

namespace Helpers.MyXmlReaderSpace
{
    public class MyXmlReader
    {
        private string fileName = string.Empty;

        public MyXmlReader(string xmFileName)
        {
            fileName = xmFileName;
        }

        public ArrayList ReadFile()
        {
            ArrayList itemArray = new ArrayList();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            XmlReader reader = XmlReader.Create(fileName, settings);

            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    if (reader.IsEmptyElement)
                    {
                        continue;
                    }
                    else
                    {
                        if (reader.HasAttributes)
                        {
                            bool value = true;
                            if (reader.GetAttribute("visiable") == "false") { value = false; }
                            else { value = true; }

                            ConsoleMenuItem temp = new ConsoleMenuItem(reader.GetAttribute("description"), reader.GetAttribute("key"), value, null);
                            itemArray.Add(temp);
                        }
                    }
                }
            }

            reader.Close();
            return itemArray;
        }
    }
}
