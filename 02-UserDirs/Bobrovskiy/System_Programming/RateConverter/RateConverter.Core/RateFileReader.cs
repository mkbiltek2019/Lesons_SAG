using System;
using System.Collections.Generic;
using System.Text;

namespace RateConverter.Core
{
    public class RateFileReader
    {
        public List<RateItem> Read(string fileName)
        {
            List<RateItem> listRateItem = new List<RateItem>();
            string[] lines = null;

            try
            {
              lines = System.IO.File.ReadAllLines(fileName, 
                                            Encoding.Default);  
            }
             catch(Exception e)
            {
                LogManager.Instance.PutMessage("RateFileReader.Read:> Error: " + e.Message);
            }

            listRateItem.Add(new RateItem()
                                 {
                                     Bank = lines[0],
                                     Currency = lines[1],
                                     Date = Convert.ToDateTime(lines[2]),
                                     Value = Convert.ToDecimal(lines[3]),
                                 });
           
            return listRateItem;
        }
    }
}
