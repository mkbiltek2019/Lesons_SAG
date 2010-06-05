using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MediaLibrary.Business;

namespace MediaLibraryClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(trackListNameTextBox.Text))
            {
                errorProvider.SetError(trackListNameTextBox, "Name cannot be empty");
                return;
            }

            TrackList trackList = new TrackList()
            {
                Name = trackListNameTextBox.Text
            };

            trackList.Save();
        }

        private void button1_Validating(object sender, CancelEventArgs e)
        {
            
        }
    }
}
