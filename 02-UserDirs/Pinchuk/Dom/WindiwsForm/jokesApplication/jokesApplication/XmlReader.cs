using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace jokesApplication
{
    class XmlReader
    {
        public string FileName { get; set; }
        private XDocument xDocument;
        private List<XElement> xElements;

        public XmlReader(string filename)
        {
            FileName = filename;
            xElements =new List<XElement>();
            xDocument = XDocument.Load(FileName);
            xElements = xDocument.Root.Elements().ToList();
        }
        public XElement  GetJoks()
        {
            Random random =new Random();
            XElement xElement=null;
            if (xElements.Count!=0)
            {
                int index = random.Next(0, xElements.Count);
                xElement = xElements[index];
                xElements.RemoveAt(index); 
            }
            return xElement;
        }
    }
}
