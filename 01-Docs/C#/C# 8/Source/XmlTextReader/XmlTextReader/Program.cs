using System;
using System.Xml;
class MyApp
{
    static void Main()
    {
       
        XmlTextReader reader = null;
        try
        {
            reader = new XmlTextReader("..//..//..//..//Cars.xml");
            reader.WhitespaceHandling = WhitespaceHandling.None;
            while (reader.Read())
            {
                //Console.WriteLine("Type={0}\t\tName={1}\t\tValue={2}",
                //reader.NodeType, reader.Name, reader.Value);
                //if (reader.AttributeCount > 0)
                //{
                //    while (reader.MoveToNextAttribute())
                //    {
                //        Console.WriteLine("Type={0}\tName={1}\tValue={2}",
                //        reader.NodeType, reader.Name, reader.Value);
                //    }
                //}
                if (reader.NodeType == XmlNodeType.Element &&
                reader.Name == "Car" && reader.AttributeCount > 0)
                {
                    while (reader.MoveToNextAttribute())
                    {
                        if (reader.Name == "Image")
                        {
                            Console.WriteLine(reader.Value);
                            break;
                        }
                    }
                }
            }
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
    }
}