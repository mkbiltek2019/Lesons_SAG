using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SimplePhoneBook
{
    public partial class Form1 : Form
    {
        OleDbConnection connection=null;
       
        public Form1()
        {
            InitializeComponent();
        }



        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                AddDataInDatabase(f.textBoxName.Text, f.textBoxSurname.Text, f.textBoxEMaill.Text, f.textBoxPhone.Text);
            }
        }

        internal void AddDataInDatabase(String Name, String Surname, String EMail, String Phone)
        {
            try
            {
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = String.Format(
                        @"INSERT INTO tbPhones (Name, Surname, EMail, Phone)
                            VALUES ('{0}', '{1}', '{2}', '{3}')",
                        Name, Surname, EMail, Phone);
                command.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdatePhone(int Id, String Phone)
        {
            try
            {
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = String.Format(
                        @"UPDATE tbPhones SET Phone={0} WHERE Id={1}",
                        Id, Phone);
                command.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateName(int Id, String Name, String Surname)
        {
            try
            {
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = String.Format(
                        @"UPDATE tbPhones SET Name={1}, Surname={2} WHERE Id={0}",
                        Id, Name, Surname);
                command.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        private void UpdateMail(int Id, String EMail)
        {
            try
            {
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = String.Format(
                        @"UPDATE tbPhones SET EMail={1} WHERE Id={0}",
                        Id, EMail);
                command.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteDataInDatabase(int Id)
        {
            try
            {
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = String.Format(
                        @"DELETE FROM tbPhones WHERE Id= {0}", Id);
                command.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

               
        private void ReadData()
        {
            try
            {
                OleDbCommand comm = connection.CreateCommand();
                comm.CommandText = @"SELECT Id,
                Name, Surname, EMail, Phone
                FROM tbPhones";

                OleDbDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = listView1.Items.Add(new ListViewItem());
                    item.Text = reader.GetString(reader.GetOrdinal("Name"));
                    item.SubItems.Add(reader.GetString(reader.GetOrdinal("Surname")));
                    item.SubItems.Add(reader.GetString(reader.GetOrdinal("EMail")));
                    item.SubItems.Add(reader.GetString(reader.GetOrdinal("Phone")));
                   
                }
                reader.Close();
                
            }
            catch(OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
        private int GetRowCount()
        {            
            try
            {
                OleDbCommand comm = connection.CreateCommand();
                comm.CommandText = @"SELECT COUNT(*) FROM tbPhones";

                return (int)comm.ExecuteScalar();
            }
            catch(OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection();
           
            connection.ConnectionString =
                @"Provider= Microsoft.ACE.OLEDB.12.0;
                data source=SimplePhoneBook.accdb;
                Persist Security Info=False";
            try
            {
                connection.Open();


                ReadData();



            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(connection.State==ConnectionState.Open)
                connection.Close();
        }

       
    }
}
