using System;
using System.Xml;
class MyApp
{
    static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("..//..//..//..//Cars.xml");
 
        //OutputNode (doc.DocumentElement);
       
        // Удалить первый элемент Cars
        XmlNode root = doc.DocumentElement;
        root.RemoveChild(root.FirstChild);
        // Создать узлы элементов.
        XmlNode bike = doc.CreateElement("Motorcycle");
        XmlNode elem1 = doc.CreateElement("Nanufactured");
        XmlNode elem2 = doc.CreateElement("Model");
        XmlNode elem3 = doc.CreateElement("Year");
        XmlNode elem4 = doc.CreateElement("Color");
        XmlNode elem5 = doc.CreateElement("Engine");
        // Создать текстовые узлы
        XmlNode text1 = doc.CreateTextNode("Harley-Davidson Motor Co. Inc.");
        XmlNode text2 = doc.CreateTextNode("Harley 20J");
        XmlNode text3 = doc.CreateTextNode("1920");
        XmlNode text4 = doc.CreateTextNode("Olive");
        XmlNode text5 = doc.CreateTextNode("37 HP");
        // Присоединить текстовые узлы к узлам элементов
        elem1.AppendChild(text1);
        elem2.AppendChild(text2);
        elem3.AppendChild(text3);
        elem4.AppendChild(text4);
        elem5.AppendChild(text5);
        // Присоединить узлы элементов к узлу bike
        bike.AppendChild(elem1);
        bike.AppendChild(elem2);
        bike.AppendChild(elem3);
        bike.AppendChild(elem4);
        bike.AppendChild(elem5);
        // Присоединить узел bike к корневому узлу
        root.AppendChild(bike);
        // Сохранить измененный документ
        doc.Save("Motorcycle.xml");

    }

    static void OutputNode(XmlNode node)
    {
        Console.WriteLine("Type={0}\tName={1}\tValue={2}", node.NodeType, node.Name, node.Value);
        if (node.HasChildNodes)
        {
            XmlNodeList children = node.ChildNodes;
            foreach (XmlNode child in children)
                OutputNode(child);
        }

    }

    //static void OutputNode (XmlNode node)
    //{
    //    Console.WriteLine ("Type={0}\tName={1}\tValue={2}",
    //    node.NodeType, node.Name, node.Value);
    //    if (node.Attributes != null)
    //    {
    //        foreach (XmlAttribute attr in node.Attributes)
    //            Console.WriteLine("Type= {0}\tName={1}\tValue={2}", 
    //            attr.NodeType, attr.Name, attr.Value);
    //    }
    //    if (node.HasChildNodes)
    //    {
    //        foreach (XmlNode child in node.ChildNodes)
    //            OutputNode (child);
    //    }
    //}



}