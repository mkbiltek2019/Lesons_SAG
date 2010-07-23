using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileManager
{
    public partial class FileListPanel : UserControl
    {
        public event MouseEventHandler MouseDown;

        List<DirectoryInfo> directories;
        List<FileInfo> files;
        private DirectoryInfo currentDirectory;
        private string root;

        public DirectoryInfo CurrentDirectory
        {
            get { return currentDirectory; }
            set { currentDirectory = value; }
        }

        public FileListPanel()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new object[]
                                             {
                                                 View.Details,
                                                 View.LargeIcon,
                                                 View.List,
                                                 View.SmallIcon,
                                                 View.Tile
                                             });
            //ViewFileListPanel(@"c:\");
               
        }
        public void ViewFileListPanel(string root)
        {
            try
            {


                DirectoryInfo directoryInfo = new DirectoryInfo(root);
                CurrentDirectory = directoryInfo;

                listView1.Items.Clear();
                smallImageList.Images.Clear();
                bigImageList.Images.Clear();
                textBox1.Text = CurrentDirectory.ToString();

                

                string[] directoryNames = Directory.GetDirectories(CurrentDirectory.FullName);
                string[] fileNames = Directory.GetFiles(CurrentDirectory.FullName);

                directories = new List<DirectoryInfo>();
                files = new List<FileInfo>();

                foreach (string directoryName in directoryNames)
                {
                    directories.Add(new DirectoryInfo(directoryName));
                }

                foreach (string fileName in fileNames)
                {
                    files.Add(new FileInfo(fileName));
                }

                foreach (DirectoryInfo directory in directories)
                {
                    Icon icon = new Icon(this.GetType(), "Resources.2.ico");
                    smallImageList.Images.Add(icon);
                    bigImageList.Images.Add(icon);
                    listView1.Items.Add(
                        new ListViewItem(
                            new string[]
                                {
                                    directory.Name, string.Empty, directory.CreationTime.ToString(),
                                    directory.LastWriteTime.ToString()
                                }, 0));
                }

                foreach (FileInfo file in files)
                {
                    Icon icon = Icon.ExtractAssociatedIcon(file.FullName);

                    string iconKey = string.IsNullOrEmpty(file.Extension) ? file.Name : file.Extension;
                    if (!smallImageList.Images.ContainsKey(iconKey))
                    {
                        smallImageList.Images.Add(iconKey, icon);
                        bigImageList.Images.Add(iconKey, icon);
                    }

                    listView1.Items.Add(
                        new ListViewItem(
                            new string[]
                                {
                                    file.Name, file.Length.ToString(), file.CreationTime.ToString(),
                                    file.LastWriteTime.ToString()
                                }, iconKey));
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка. " + err.Message);
            }

        }

        private
        void comboBox1_SelectedIndexChanged
        (object sender, EventArgs e)
        {
            listView1.View = (View)comboBox1.SelectedItem;
        }

        public
            View
            View
        {
            get
            {
                return listView1.View;
            }
            set
            {
                listView1.View = value;
            }
        }

        private
            void listView1_MouseDown
            (object sender, MouseEventArgs e)
        {
            if (MouseDown != null)
                MouseDown.Invoke(sender, e);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewFileListPanel(@"c:\");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewFileListPanel(@"d:\");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = Directory.GetParent(textBox1.Text);
            if (dir == null)
                System.Media.SystemSounds.Asterisk.Play();
            else
            {
                textBox1.Text = dir.FullName;
                ViewFileListPanel(textBox1.Text);
            }

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string path = Path.Combine(CurrentDirectory.ToString(), listView1.SelectedItems[0].Text);
            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
                ViewFileListPanel(path);
            }
        }
      
     
    }
}