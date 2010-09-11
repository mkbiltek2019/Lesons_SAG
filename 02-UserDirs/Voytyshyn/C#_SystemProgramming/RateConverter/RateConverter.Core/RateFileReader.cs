using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RateConverter.Core
{
    public class RateFileReader
    {
        private RateItem ParseRateItemLine(string line)
        {
            RateItem rateItem = new RateItem();
            string temp = null;
            int r = 0;
            for (int i = 0; i < line.Length; i++)
            {

                if (i < 7 && line[i].ToString().ToLower() != " ")
                    temp += line[i];

                if (i < 7 && line[i].ToString().ToLower() == " ")
                {
                    r = i;
                    break;
                }
                rateItem.Currency = temp;
            }

            temp = null;
            for (int i = r + 2; i < line.Length; i++)
            {
                if (i > r && line[i].ToString().ToLower() != " ")
                    temp += line[i];
                if (i > r && line[i].ToString().ToLower() == " ")
                {
                    r = i;
                    break;
                }
                rateItem.Bank = temp;
            }
            temp = null;
            for (int i = r + 2; i < line.Length; i++)
            {
                if (i > r && line[i].ToString().ToLower() != " ")
                    temp += line[i];
                if (i > r && line[i].ToString().ToLower() == " ")
                {
                    r = i;
                    break;
                }
                rateItem.Date = Convert.ToDateTime( temp);
            }
            temp = null;
            for (int i = r + 1; i < line.Length; i++)
            {
                if (i > r && line[i].ToString().ToLower() != " ")
                    temp += line[i];
                if (i > r && line[i].ToString().ToLower() == " ")
                {
                    r = i;
                    break;
                }
                rateItem.Value = Convert.ToInt32(temp);
            }
            return rateItem;
        }

        public List<RateItem> Read(string fileName)
        {
            List<RateItem> listRateItem = new List<RateItem>();

            string[] lines = System.IO.File.ReadAllLines(fileName);

           
            foreach (string line in lines)
            {
                listRateItem.Add(ParseRateItemLine(line));                
            }
            return listRateItem;
        }
    }
}
