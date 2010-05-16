using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;

namespace ConnectionTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }

        private void buttonSQL_Click(object sender, EventArgs e)
        {
            
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.InitialCatalog = "_Library"; //Задаём InitialCatalog
            builder.IntegratedSecurity = true;   //Задаём режим проверки подлинности
            builder.DataSource = "(local)";      //Задаём сервер

            SqlConnection connection = new SqlConnection();//Создаём объекn Connection
            connection.ConnectionString = builder.ConnectionString;

            try
            {
                connection.Open();      //Выполняем соединение c сервером
                SqlCommand command = new SqlCommand(  //Создаём объект Command
                    @"CREATE TABLE tbFaculties(Id INT IDENTITY,
                    NAME VARCHAR(10))", connection);

                command.ExecuteNonQuery(); //Выполняем запрос

                connection.Close();  //Закрываем соединение
            }

            catch (System.Data.Common.DbException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        private void buttonOleDb_Click(object sender, EventArgs e)
        {
            /* Создаём соединение */
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;data source=d:\library.mdb";

            try
            {
                connection.Open(); //выполняем соединение

                OleDbCommand command = new OleDbCommand(  //Создаём объект Command
                   @"CREATE TABLE tbFaculties(Id COUNTER,
                    NAME VARCHAR(10))", connection);

                command.ExecuteNonQuery(); //Выполняем запрос
                connection.Close(); 
            }

            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void buttonOdbc_Click(object sender, EventArgs e)
        {
            /* Создаём Command */
            OdbcCommand comm = new OdbcCommand();
            /* и под него соединение (не забудте создать DSN с именем _Test)*/
            comm.Connection = new OdbcConnection("Dsn=_Test;");
            
            try
            {
                //в свойство  CommandText вносим наш SQL запрос
                comm.CommandText =
                    @"CREATE TABLE tbFaculties(Id INT PRIMARY KEY, NAME VARCHAR(10))";

                comm.Connection.Open(); //выполняем соединение
                comm.ExecuteNonQuery(); //выполняем запрос
                comm.Connection.Close();//отсоединяемся
            }

            catch (System.Data.Common.DbException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        private void buttonOracle_Click(object sender, EventArgs e)
        {
            try
            { 
                  
                OracleConnection conn = new OracleConnection(
                            "Data Source=Oracle9i; Integrated Security=yes;");

                OracleCommand command = new OracleCommand(  //Создаём объект Command
                     @"CREATE TABLE tbFaculties(Id INT PRIMARY KEY,
                    NAME VARCHAR(10))", conn);

                command.ExecuteNonQuery(); //Выполняем запрос

                conn.Close();  //Закрываем соединение
            }

            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
