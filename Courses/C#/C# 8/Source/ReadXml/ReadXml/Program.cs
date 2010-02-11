using System;
using System.Xml;
class MyApp
{
    static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("..//..//..//..//Cars.xml");
        XmlNodeList nodes = doc.GetElementsByTagName("Car");
        foreach (XmlNode node in nodes)
        {
            Console.WriteLine("{0} {1}", node["Manufactured"].InnerText,
            node["Model"].InnerText);
        }
    }
}
