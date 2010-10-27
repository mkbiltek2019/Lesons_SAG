using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BrightIdeasSoftware;
using System.Xml;
using MessageFormatter.xmlParser;

namespace MessageFormatter
{
    public partial class ImageListBox : UserControl
    {
        private object sync = new object();
        ActiveUserParser userParser = new ActiveUserParser();        
        
        public ImageListBox()
        {
            InitializeComponent();
            olvData.CellEditActivation = ObjectListView.CellEditActivateMode.None;
            this.olvData.RowHeight = 50;            
        }

        public void AddUserToFile(string userName, string smileName)
        {
            lock (sync)
            {
                userParser.Add(userName, smileName);
            }
        }

        public void LoadDataFromFile()
        {
            lock (sync)
            {             
                this.olvData.DataSource = userParser.DataSource;
             }
        }

    }
}
