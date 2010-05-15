using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileSystemCommander.NET
{
    public partial class FileListPanel : UserControl
    {
        public event MouseEventHandler MouseDown;

        List<DirectoryInfo> directories;
        List<FileInfo> files;
        private DirectoryInfo currentDirectory;

        public DirectoryInfo CurrentDirectory
        {
            get { return currentDirectory; }
            set { currentDirectory = value; }
        }

        public FileListPanel(DirectoryInfo inititalDirectory)
        {
            InitializeComponent();

            CurrentDirectory = inititalDirectory;

            comboBox1.Items.AddRange(new object[]
                {
                    View.Details, 
                    View.LargeIcon, 
                    View.List, 
                    View.SmallIcon, 
                    View.Tile
                });

            // TODO: Refactor this ASAP!!!
            #region Needs refactoring
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
                listView1.Items.Add(new ListViewItem(new string[] { directory.Name, string.Empty }));
            }

            foreach (FileInfo file in files)
            {
                Icon icon = Icon.ExtractAssociatedIcon(file.FullName);
                smallImageList.Images.Add(file.Name, icon);
                bigImageList.Images.Add(file.Name, icon);
                listView1.Items.Add(new ListViewItem(new string[] { file.Name, file.Length.ToString() }, file.Name));
            } 
            #endregion
        }

        public FileListPanel()
            : this(new DirectoryInfo(Environment.CurrentDirectory))
        { }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.View = (View)comboBox1.SelectedItem;
        }

        public View View 
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

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if(MouseDown != null)
                MouseDown.Invoke(sender, e);
        }
    }
}
