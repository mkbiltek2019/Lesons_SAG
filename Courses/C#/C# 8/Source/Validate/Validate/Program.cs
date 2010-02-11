using System;
using System.Xml;
using System.Xml.Schema;
class MyApp
{
	static void Main (string[] args)
	{
		if (args.Length < 2) 
		{
			Console.WriteLine("Syntax; VALIDATE xmldoc schemadoc");
			return;
		}
		XmlValidatingReader reader = null;
		try
		 {
			XmlTextReader nvr = new XmlTextReader (args[0]);
			nvr.WhitespaceHandling = WhitespaceHandling.None;
			reader = new XmlValidatingReader (nvr);
			reader.Schemas.Add (GetTargetNamespace (args[1]), args[1]);
            reader.ValidationEventHandler += new ValidationEventHandler(OnValidationError);
			while (reader.Read ());
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		finally
		{
			if (reader != null)
				reader.Close();
		}
	}
	static void OnValidationError (object sender, ValidationEventArgs e)
	{
		Console.WriteLine (e.Message);
	}
	public static string GetTargetNamespace (string src)
	{
		XmlTextReader reader = null;
		try
		{
			reader = new XmlTextReader (src);
			reader.WhitespaceHandling = WhitespaceHandling.None;
			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Element &&
				reader.LocalName == "schema")
				{
					while (reader.MoveToNextAttribute ())
					{
						if (reader.Name == "targetNamespace")
							return reader.Value;
					}
				}
			}
			return "";
		}	
		finally 
		{
			if (reader != null)
				reader.Close ();
		}
	}
}
