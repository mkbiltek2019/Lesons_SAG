using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using MoneyConverServiceWCF.DownloadManager;
using MoneyConverServiceWCF.MMoneyModel;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace MoneyConverServiceWCF.Parser
{
    public class SiteParser
    {
        private object sync = new object();

        public List<MoneyModel> ParseFileFromLocalStore()
        {
            lock (sync)
            {
                const string tableTag = "//table";
                const string tableRowTag = ".//tr";
                const string tableColTag = ".//td";
                const string tableId = "DataGrid1";

                string FileName = Resources.DestinationName;

                List<MoneyModel> courseList = new List<MoneyModel>();

                HtmlDocument doc = new HtmlDocument();

                doc.Load(FileName);

                if (doc != null)
                {
                    // Get all tables in the document
                    HtmlNodeCollection tables = doc.DocumentNode.SelectNodes(tableTag);
                    HtmlNodeCollection tablerows = null;

                    for (int i = 0; i < tables.Count; ++i)
                    {
                        if (tables[i].Id == tableId)
                        {
                            tablerows = tables[i].SelectNodes(tableRowTag);
                        }
                    }

                    //start from 1 to ignore table headers
                    for (int i = 1; i < tablerows.Count; ++i)
                    {
                        HtmlNodeCollection tablecolumns = tablerows[i].SelectNodes(tableColTag);

                        string ISOID1 = tablecolumns[0].InnerText;
                        string CharacterCode1 = tablecolumns[1].InnerText;
                        string CurrencyCount1 = tablecolumns[2].InnerText;
                        string CurrencyName1 = tablecolumns[3].InnerText;
                        string CurrencyCource1 = tablecolumns[4].InnerText;

                        MoneyModel tmp = new MoneyModel();

                        //UTF8Encoding utf8 = new UTF8Encoding();
                        
                        tmp.ISOID = Convert.ToInt32(ISOID1);
                        tmp.CharacterCode = CharacterCode1;
                        tmp.CurrencyCount = Convert.ToDouble(CurrencyCount1);
                        tmp.CurrencyName = CurrencyName1;
                        tmp.CurrencyCource = Convert.ToDouble(CurrencyCource1.Replace('.', ','));

                        courseList.Add(tmp);
                    }
                }

                return courseList;
            }
        }

    }
}