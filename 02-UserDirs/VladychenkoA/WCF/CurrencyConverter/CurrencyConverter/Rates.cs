using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CurrencyConverter
{
    class Rates
    {
        [DllImport("user32.dll")]
        public static extern int MessageBeep(uint BeepType);
        private string _name;
        private int _currency;
        private DateTime _date;
        private string _price;
        private string _absoluteChange;
        private string _relativeChange;

        #region Properties
        public int? Id { set; get; }
        public string Name { set { _name = value; } get { return _name; } }
        public DateTime Date { set { _date = value; } get { return _date; } }
        public int Currency { set { _currency = value; } get { return _currency; } }
        public string Price { set { _price = value; } get { return _price; } }
        public string AbsoluteChange { set { _absoluteChange = value; } get { return _absoluteChange; } }
        public string RelativeChange { set { _relativeChange = value; } get { return _relativeChange; } }
        public ArrayList ArrayListRates = new ArrayList();
        #endregion

        #region Metods

        public int Save()
        {
            return Id == null ? Insert() : Update();
        }

        private int Update()
        {
            throw new NotImplementedException();
        }

        private void Beep()
        {
            
        }

        private int Insert()
        {
            int affectedRows = 0;

            using (var connection =
                new SqlConnection(@"Server=АЛЕКСАНДР-ПК\SQLEXPRESS;Initial Catalog=Exchange Rates NBU;Integrated Security=True;"))
            {
                connection.Open();

                SqlCommand insertCommand = new SqlCommand(
                    @"INSERT INTO [Exchange Rates NBU].[dbo].[Rates]
                    
                    VALUES
                    (@Date,@Currency,@Price,@AbsoluteChange,@RelativeChange)", connection);

                SqlParameter nameParametr = new SqlParameter("@Date", Date);
                insertCommand.Parameters.Add(nameParametr);
                SqlParameter nameParametr1 = new SqlParameter("@Currency", Currency);
                insertCommand.Parameters.Add(nameParametr1);
                SqlParameter nameParametr2 = new SqlParameter("@Price", Price);
                insertCommand.Parameters.Add(nameParametr2);
                SqlParameter nameParametr3 = new SqlParameter("@AbsoluteChange", AbsoluteChange);
                insertCommand.Parameters.Add(nameParametr3);
                SqlParameter nameParametr4 = new SqlParameter("@RelativeChange", RelativeChange);
                insertCommand.Parameters.Add(nameParametr4);

                affectedRows = insertCommand.ExecuteNonQuery();
                
                connection.Close();
            }

            return affectedRows;
        }

        public void ArrayLiistRatesPrint(ArrayList rates)
        {
            foreach (Rates rate in rates)
            {
                rate.Print();
                Console.WriteLine();
            }
            MessageBeep(0x00000000);
        }
        public void SaveAll(ArrayList rates)
         {
            foreach (Rates rate in rates)
            {
                rate.Save();
            }
            MessageBeep(0x00000040);
         }

        public void Print()
        {
            Console.Write(" {0} ", _currency);
            Console.Write(_name);
            Console.Write(" ");
            Console.Write(_date);
            Console.Write(" ");
            Console.Write(" {0} ",_price);
            Console.Write(" {0} ", _absoluteChange);
            Console.Write(" {0} ", _relativeChange);
        }

        public void ReadFile(DateTime date)
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Учебная\13НС-1СПр\02-UserDirs\VladychenkoA\ADO.NET KURS\InsertRates\данные\30072010.txt", Encoding.GetEncoding(1251));
            int r = 0;
            int count = 1;
            foreach (string line in lines)
            {
                Rates rates = new Rates();
                string temp = null;
                rates._date = date.Date;
                rates._currency = count;
                count += 1;
                for (int i =  0 ; i < line.Length; i++)
                {
                    //if(i > 18 && line[i].ToString().ToLower() != " ")
                    //{
                        
                    //}
                    temp += line[i];
                    if(i > 1 && line[i-1].ToString().ToLower() == " " && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    rates._name = temp;
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    temp += line[i];
                    if (line[i - 1].ToString().ToLower() == " " && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    rates._price = temp;
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    temp += line[i];
                    if (line[i - 1].ToString().ToLower() == " " && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    rates._absoluteChange = temp;
                }
                temp = null;
                for (int i = r + 1; i < line.Length; i++)
                {
                    temp += line[i];
                    if (line[i - 1].ToString().ToLower() == " " && line[i].ToString().ToLower() == " ")
                    {
                        r = i;
                        break;
                    }
                    rates._relativeChange = temp;
                }
                ArrayListRates.Add(rates);
            }
        }

        #endregion

    }
}
