using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace InsertCurrency
{
    class Currency
    {
        private int number ;
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
        public int Number
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
