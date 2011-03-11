using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using DownloadManager.NET.Properties;

namespace DownloadManager.NET
{
    public partial class Form2 : Form
    {
        public event EventHandler UrlChanged;
        private string _fileName;
        
        public Form2()
        {
            InitializeComponent();
            toolTip1.SetToolTip(button1," Выбор директории ");
            textBox1.Text = @"C:\Users\Александр\Загрузка";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Uri url = new Uri(textBox3.Text);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                response.Close();
                if (FileName(response) != string.Empty)
                    textBox2.Text = FileName(response);
                
            }
            catch
            {
                textBox2.Text = string.Empty;
                MessageBox.Show("Ошибка ответа сервера. \rПопробуйте  ещё раз.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        private string FileName(WebResponse response)
       {
            try
            {
                if (response is HttpWebResponse)
                {
                    FileInfo fileInfo = new FileInfo(textBox1.Text);
                    string disp = response.Headers["Content-Disposition"];
                    if (disp != null)
                    {
                        int index = disp.IndexOf("filename=");
                        if(index != -1)
                            fileInfo = new FileInfo(disp.Substring(index + 9));
                    }
                    _fileName = fileInfo.Name;
                }
            }
            catch (Exception)
            {

                return string.Empty;
            }
           return _fileName;
       }

      

        

       
    }
}
