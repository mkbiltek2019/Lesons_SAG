using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace BeginExecuteNonQueryExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private delegate void DisplayInfoDelegate(string Text);

        private bool isExecuting;

        private SqlConnection connection;

        private static string GetConnectionString()
        {
            return "Data Source=(local);Integrated Security=SSPI;" +
                   "Initial Catalog=AdventureWorks; Asynchronous Processing=true";
        }

        private void DisplayStatus(string Text)
        {
            this.label1.Text = Text;
        }

        private void DisplayResults(string Text)
        {
            this.label2.Text = Text;
            DisplayStatus("Ready");
        }

        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (isExecuting)
            {
                MessageBox.Show(this, "Can't close the form until " +
                "the pending asynchronous command has completed. Please " +   "wait...");
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (isExecuting)
            {
                MessageBox.Show(this, "Already executing. Please wait until " +
                "the current query has completed.");
            }
            else
            {
                SqlCommand command = null;
                try
                {
                    DisplayResults("");
                    DisplayStatus("Connecting...");
                    connection = new SqlConnection(GetConnectionString());

                    string commandText =
                        "WAITFOR DELAY '0:0:05';" +
                        "UPDATE Production.Product " +
                        "SET ReorderPoint = ReorderPoint + 1 " +
                        "WHERE ReorderPoint Is Not Null;" +
                        "UPDATE Production.Product " +
                        "SET ReorderPoint = ReorderPoint - 1 " +
                        "WHERE ReorderPoint Is Not Null";


                    command = new SqlCommand(commandText, connection);
                    connection.Open();

                    DisplayStatus("Executing...");
                    isExecuting = true;
        
                    AsyncCallback callback = new AsyncCallback(HandleCallback);

                    command.BeginExecuteNonQuery(callback, command);

                }

                catch (Exception ex)
                {
                    isExecuting = false;
                    DisplayStatus(
                     string.Format("Ready (last error: {0})", ex.Message));
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void HandleCallback(IAsyncResult result)
        {
            try
            {
                SqlCommand command = (SqlCommand)result.AsyncState;
                int rowCount = command.EndExecuteNonQuery(result);
                string rowText = " rows affected.";
                if (rowCount == 1)
                {
                    rowText = " row affected.";
                }
                rowText = rowCount + rowText;

                DisplayInfoDelegate del =
                 new DisplayInfoDelegate(DisplayResults);
                this.Invoke(del, rowText);
            }
            catch (Exception ex)
            {
                this.Invoke(new DisplayInfoDelegate(DisplayStatus),
                String.Format("Ready(last error: {0}", ex.Message));
            }
            finally
            {
                isExecuting = false;
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.FormClosing += new System.Windows.Forms.
                FormClosingEventHandler(this.Form1_FormClosing);
        }
    }
}
