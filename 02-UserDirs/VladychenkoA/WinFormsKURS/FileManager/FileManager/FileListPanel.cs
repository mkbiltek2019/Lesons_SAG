using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        }

        public void ShowList(string dir)
        {
            FileListView fileListView = new FileListView(dir);
            
          
            listView1 = fileListView.ListView;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.View = (View) comboBox1.SelectedItem;
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
    }
}
