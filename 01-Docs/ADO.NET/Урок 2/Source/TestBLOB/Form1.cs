using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {


        SqlConnection conn;
        public Form1()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Jpeg Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                try
                {

                    Bitmap myBmp = new Bitmap(dlg.FileName);

                    Image.GetThumbnailImageAbort myCallBack = new Image.GetThumbnailImageAbort(ThumbnailCallBack);
                    Image imgPreview = myBmp.GetThumbnailImage(200, 200, myCallBack, IntPtr.Zero);

                    MemoryStream ms = new MemoryStream();
                    imgPreview.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                    ms.Flush();
                    ms.Seek(0, SeekOrigin.Begin);

                    BinaryReader br=new BinaryReader(ms);

                    byte[] image = br.ReadBytes((int)ms.Length);

                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandText = @"INSERT INTO tbImages (Path, ImgPreView) VALUES (@Path, @Image)";
                    comm.Parameters.Add("@Path", SqlDbType.NChar, 260).Value = dlg.FileName;
                    comm.Parameters.Add("@Image", SqlDbType.Image, image.Length).Value = image;

                    comm.ExecuteNonQuery();

                    ms.Close();             

                   
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally 
                {
                   

                }
            }
        }

        public bool ThumbnailCallBack()
        {
            return false;
        }

        private void FillComboBox()
        {
            try
            {
                listView1.Items.Clear();

                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = @"SELECT Id, Path FROM tbImages";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem Item =listView1.Items.Add(Path.GetFileName(reader.GetString(reader.GetOrdinal("Path"))));
                    Item.Tag=(object)reader.GetInt32(reader.GetOrdinal("Id"));
                    
                }

                reader.Close();




            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection("Data Source=(local); Initial Catalog=TestBlob; Integrated Security=SSPI;");
                    //"user id=Image;Pwd=Image;server=127.0.0.1;packet size=4096;initial catalog=TestBlob");
                conn.Open();

                FillComboBox();


            }
            catch (SqlException ex)
            {
                MessageBox.Show("Невозможно установить соединение с сервером: " + ex.Message);
                this.Close();
            }
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count < 1)
                return;

            try
            {
                int id = (int)listView1.SelectedItems[0].Tag;

                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;//conn.CreateCommand();

                comm.CommandText = @"SELECT ImgPreView FROM tbImages WHERE Id=" + id.ToString();

                SqlDataReader reader = comm.ExecuteReader();

                MemoryStream ms = new MemoryStream();
                int buffSize = 100;

                byte[] buffer = new byte[buffSize];
                

                while (reader.Read())
                {
                    int retval;
                    int startIndex = 0;
                    

                    while (true)
                    {
                        retval = (int)reader.GetBytes(0, startIndex, buffer, 0, buffSize);
                        if (retval <1) break;
                        
                        ms.Write(buffer, 0, retval);
                        ms.Flush();
                        startIndex += retval;

                    } 

                }

                if (ms.Length < 1) return;

                pictureBox1.Image = Image.FromStream(ms);
                ms.Close();

                reader.Close();
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
