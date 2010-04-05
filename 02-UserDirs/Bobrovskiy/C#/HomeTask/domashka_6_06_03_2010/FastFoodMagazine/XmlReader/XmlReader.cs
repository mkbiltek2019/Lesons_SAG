using System.Collections;
using System.Xml;
using FastFoodMagazine.MyProduct;
using FastFoodMagazine.MyProduct.Food;
using Helpers.ConsoleMenu;

namespace FastFoodMagazine.XmlReader
{
    public class MyXmlReader
    {
        private delegate System.Object ExtractHandler(System.Xml.XmlReader reader);
        private string fileName = string.Empty;

        public MyXmlReader(string xmFileName)
        {
            fileName = xmFileName;
        }

        private XmlReaderSettings XmlReaderCustomSettings()
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

            return settings;
        }

        private ArrayList ReadXmlFileWithSpecificFormat(ExtractHandler extractor)
        {
            ArrayList itemArray = new ArrayList();
            System.Xml.XmlReader reader = System.Xml.XmlReader.Create(fileName, XmlReaderCustomSettings());

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
                            itemArray.Add(extractor.Invoke(reader));
                        }
                    }
                }
            }

            reader.Close();
            return itemArray;
        }

        private System.Object ExtractMenuItem(System.Xml.XmlReader reader)
        {
            bool value = true;
            if (reader.GetAttribute("visiable") == "false") { value = false; }
            else { value = true; }

            return new ConsoleMenuItem(reader.GetAttribute("description"), reader.GetAttribute("key"), value, null);
        }

        private System.Object ExtractFoodOrBeverageData(System.Xml.XmlReader reader)
        {
            return new Product(reader.GetAttribute("name"),
                                        reader.GetAttribute("price"),
                                        reader.GetAttribute("volume"));
        }

        public ArrayList ReadMenuData()
        {
            return ReadXmlFileWithSpecificFormat(ExtractMenuItem);
        }

        public ArrayList ReadProductData()
        {
            return ReadXmlFileWithSpecificFormat(ExtractFoodOrBeverageData);
        }
    }
}