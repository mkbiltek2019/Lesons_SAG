using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;

using Helpers.Console;
using Helpers.MyProduct;
using Helpers.MyFood;
using Helpers.MyBeverage;

namespace Helpers.MyXmlReaderSpace
{
    public class MyXmlReader
    {
        private string fileName = string.Empty;

        public MyXmlReader(string xmFileName)
        {
            fileName = xmFileName;
        }

        public ArrayList ReadXmlMenuFileWithSpecificFormatAndReturnListOfMenuItems()
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

        public ArrayList ReadProductListFromXmlFileWithSpecificFormatAndReturnItLikeArray(Products productType)
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
                            Product temp = null;

                            switch (productType)
                            {
                                case Products.Food:
                                    {
                                        temp = new Food(reader.GetAttribute("name"),
                                                                reader.GetAttribute("price"),
                                                                reader.GetAttribute("volume"));

                                    } break;
                                case Products.Beverage:
                                    {
                                        temp = new Beverage(reader.GetAttribute("name"),
                                                                reader.GetAttribute("price"),
                                                                reader.GetAttribute("volume"));
                                    } break;
                            }
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
