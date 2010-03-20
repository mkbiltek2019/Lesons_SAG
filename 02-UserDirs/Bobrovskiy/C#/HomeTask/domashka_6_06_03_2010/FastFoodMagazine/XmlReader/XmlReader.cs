using System.Collections;
using System.Xml;
using FastFoodMagazine.MyProduct;
using FastFoodMagazine.MyProduct.MyBeverage;
using FastFoodMagazine.MyProduct.Food;
using Helpers.ConsoleMenu;

namespace FastFoodMagazine.XmlReader
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
            System.Xml.XmlReader reader = System.Xml.XmlReader.Create(fileName, settings);

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
            System.Xml.XmlReader reader = System.Xml.XmlReader.Create(fileName, settings);

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
                            MyProduct.Product temp = null;

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