using System;
using System.Xml;
class MyApp
{
    static void Main()
    {     
        XmlTextWriter writer = null;
        try
        {
	        writer = new XmlTextWriter ("Cars.xml", System.Text.Encoding.Unicode);
	        writer.Formatting = Formatting.Indented;
	        writer.WriteStartDocument ();
	        writer.WriteStartElement ("Cars");
	        writer.WriteStartElement ("Car");
	        writer.WriteAttributeString ("Image", "MyCar.jpeg");
	        writer.WriteElementString ("Manufactured", "La Hispano Suiza de Automovils");
	        writer.WriteElementString ("Model", "Alfonso");
	        writer.WriteElementString ("Year", "1912");
	        writer.WriteElementString ("Color", "Black");
	        writer.WriteElementString ("Speed", "130");
	        writer.WriteEndElement ();
	        writer.WriteEndElement ();
        }

        finally
        {
	        if (writer != null)
		        writer.Close ();
        }
    }
}

