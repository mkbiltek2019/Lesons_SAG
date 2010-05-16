using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TestDbParametr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetMessageButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxLogin.Text == "" || textBoxPwd.Text == "")
                {
                    textBoxLogin.Text = "Pupkin";
                    textBoxPwd.Text = "qwerty";
                }

                listView1.Items.Clear();

                SqlConnection connection = new SqlConnection(
                    "Data Source=(local); Initial Catalog=Messenger; Integrated Security=SSPI;");
                SqlCommand command=connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText="GetMessages";

                SqlParameter LoginParam = new SqlParameter();
                LoginParam.ParameterName="@login";
                LoginParam.SqlDbType=SqlDbType.VarChar;
                LoginParam.Direction=ParameterDirection.Input;
                LoginParam.Value=textBoxLogin.Text;

                SqlParameter PwdParam = new SqlParameter();
                PwdParam.ParameterName="@pwd";
                PwdParam.SqlDbType=SqlDbType.VarChar;
                PwdParam.Direction=ParameterDirection.Input;
                PwdParam.Value=textBoxPwd.Text;
              

                command.Parameters.Add(LoginParam);
                command.Parameters.Add(PwdParam);
               

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = listView1.Items.Add(new ListViewItem());
                    item.Text = reader.GetString(reader.GetOrdinal("Login"));
                    item.SubItems.Add(reader.GetString(reader.GetOrdinal("Message")));               
                
                }
                

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

          


        }

        private void GetMessageCountButton_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "" || textBoxPwd.Text == "")
            {
                textBoxLogin.Text = "Pupkin";
                textBoxPwd.Text = "qwerty";
            }


            SqlConnection connection = new SqlConnection(
                "Data Source=(local); Initial Catalog=Messenger; Integrated Security=SSPI;");
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetMessagesCount";

            SqlParameter LoginParam = new SqlParameter();
            LoginParam.ParameterName = "@login";
            LoginParam.SqlDbType = SqlDbType.VarChar;
            LoginParam.Direction = ParameterDirection.Input;
            LoginParam.Value = textBoxLogin.Text;

            SqlParameter PwdParam = new SqlParameter();
            PwdParam.ParameterName = "@pwd";
            PwdParam.SqlDbType = SqlDbType.VarChar;
            PwdParam.Direction = ParameterDirection.Input;
            PwdParam.Value = textBoxPwd.Text;

            SqlParameter CountParam = new SqlParameter();
            CountParam.ParameterName = "@counter";
            CountParam.SqlDbType = SqlDbType.Int;
            CountParam.Direction = ParameterDirection.Output;



            command.Parameters.Add(LoginParam);
            command.Parameters.Add(PwdParam);
            command.Parameters.Add(CountParam);

            connection.Open();

            
            command.ExecuteNonQuery();
            textBox1.Text = String.Format("{0} rows", CountParam.Value.ToString());
            connection.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
