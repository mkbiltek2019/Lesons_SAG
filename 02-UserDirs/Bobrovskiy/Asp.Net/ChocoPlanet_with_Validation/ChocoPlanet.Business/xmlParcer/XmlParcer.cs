using System;
using System.Data;
using System.IO;

namespace ChocoPlanet.Business.xmlParcer
{
    public class ChocoReader
    {
        public DataSet LoadDatasetFromXml(string xmlFileName)
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
                {
                    fs.Close();
                }
            }

            return ds;
        }

    }
}
