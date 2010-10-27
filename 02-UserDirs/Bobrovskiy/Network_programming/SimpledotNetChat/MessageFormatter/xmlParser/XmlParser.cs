using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace MessageFormatter.xmlParser
{
    public class ActiveUserParser
    {
        private readonly string rootElement = "Data";
        private readonly string xmlFileName = "Person.xml";
        private readonly string childElement = "Person";
        private readonly string childElementUserName = "Name";
        private readonly string childElementSmileName = "SmileName";
        private const string smilePath = ".\\smiles\\";

        private XDocument xDocument = null;

        public BindingSource DataSource
        {
            get
            {
                DataSet ds = LoadDatasetFromXml();

                if (ds.Tables.Count > 0)
                {
                    return new BindingSource(ds, childElement);
                }

                return null;
            }
        }

        public ActiveUserParser()
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

        public void Add(string userName, string smileName)
        {
            XElement current = null;

            if (xDocument != null)
            {
                current = new XElement(childElement,
                              new XElement(childElementSmileName, smilePath + smileName),
                              new XElement(childElementUserName, userName)                              
                          );

                xDocument.Element(rootElement).Add(current);
            }

            Save();
        }

        public DataSet LoadDatasetFromXml()
        {
            DataSet ds = new DataSet();
            FileStream fs = null;

            try
            {
                fs = new FileStream(xmlFileName, FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(fs))
                {
                    ds.ReadXml(reader);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

            return ds;
        }

    }
}
