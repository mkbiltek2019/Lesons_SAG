using System.Xml.Linq;

namespace HooksInDotNET.LinqToXml
{
    public class KeyboardHookXmlParser
    {
        private readonly string rootElement = "windows";
        private readonly string xmlFileName = "keyBoardHook.xml";
        private readonly string childElement = "window";
        private readonly string childElementAttribute = "name";

        private XDocument xDocument = null;

        public KeyboardHookXmlParser()
        {
            xDocument = new XDocument(new XElement(rootElement));
            Save();
        }

        private void Save()
        {
            lock (this)
            {
                xDocument.Save(xmlFileName);
            }
        }

        public void Add(string windowTitle, string content)
        {
            XElement current = null;

            if (xDocument != null)
            {
                current = new XElement(childElement, 
                          new XAttribute(childElementAttribute, windowTitle), 
                          content);

                xDocument.Element(rootElement).Add(current);
            }

            Save();
        }
    }
}
