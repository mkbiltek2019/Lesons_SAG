using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using HtmlAgilityPack;

namespace CurrencyConverter
{
    class Currency
    {
        private double number ;
        private int numberUnit;
        private string name;
        private string digitalCode;
        private string lettersCode;

        #region Properties

        public int? ID
        {
            set;
            get;
        }
        public double Number
        {
            get { return number; }
            set { number = value; }
        }
        public int NumberUnit
        {
            set { numberUnit = value; }
            get { return numberUnit; }
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public string DigitalCode
        {
            set { digitalCode = value; }
            get { return digitalCode; }
        }
        public string LetterCode
        {
            set { lettersCode = value; }
            get { return lettersCode; }
        }

        #endregion
        public List<Currency> ReadHtmlSite(string address)
        {
            List<Currency> courrencyList = new List<Currency>();
            System.Net.WebRequest req = System.Net.WebRequest.Create(address);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string s = sr.ReadToEnd();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(s);
            if (doc != null)
            {
                HtmlNodeCollection tables = doc.DocumentNode.SelectNodes(@"/table");
                HtmlNodeCollection tablerows = null;
                for (int i = 0; i < tables.Count; ++i)
                {
                    if (tables[i].Id == "DataGrid1")
                    {
                        tablerows = tables[i].SelectNodes(@".tr");
                    }
                }
                for (int i = 1; i < tablerows.Count; ++i)
                {
                    HtmlNodeCollection tablecolumns = tablerows[i].SelectNodes(@"./td");

                    string DC = tablecolumns[0].InnerText;
                    string LC = tablecolumns[1].InnerText;
                    string NU = tablecolumns[2].InnerText;
                    string CurrencyName = tablecolumns[3].InnerText;
                    string CurrencyCource = tablecolumns[4].InnerText;

                    Currency tmp = new Currency();

                    tmp.DigitalCode = DC;
                    tmp.LetterCode = LC;
                    tmp.NumberUnit = System.Convert.ToInt32(NU);
                    tmp.Name = CurrencyName;
                    tmp.Number = System.Convert.ToDouble(CurrencyCource.Replace('.', ','));

                    courrencyList.Add(tmp);
                }

            }
            return courrencyList;
        }

        public int Save()
        {
            return ID == null ? Insert() : Update();
        }

        private int Update()
        {
            throw new NotImplementedException();
        }

        private int Insert()
        {
            int affectedRows = 0;

            using (var  connection =
                new SqlConnection(@"Server=АЛЕКСАНДР-ПК\SQLEXPRESS;Initial Catalog=Exchange Rates NBU;Integrated Security=True;"))
            {
                connection.Open();

                SqlCommand insertCommand = new SqlCommand(
                    @"
                    INSERT INTO [Exchange Rates NBU].[dbo].[Currency]
                    
                    VALUES
                    (@ID,@Name,@DigCode,@LetterCode,@NumberUNIT)", connection);

                SqlParameter nameParametr = new SqlParameter("@ID",Number);
                insertCommand.Parameters.Add(nameParametr);
                SqlParameter nameParametr1 = new SqlParameter("@Name",Name);
                insertCommand.Parameters.Add(nameParametr1);
                SqlParameter nameParametr2 = new SqlParameter("@DigCode",DigitalCode);
                insertCommand.Parameters.Add(nameParametr2);
                SqlParameter nameParametr3 = new SqlParameter("@LetterCode",LetterCode);
                insertCommand.Parameters.Add(nameParametr3);
                SqlParameter nameParametr4 = new SqlParameter("@NumberUNIT",NumberUnit);
                insertCommand.Parameters.Add(nameParametr4);

                affectedRows = insertCommand.ExecuteNonQuery();

                connection.Close();
            }
            
            return affectedRows;
        }
    }
}
