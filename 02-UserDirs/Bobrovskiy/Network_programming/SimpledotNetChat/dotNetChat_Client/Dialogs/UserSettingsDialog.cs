using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dotNetChatClient.Dialogs
{
    public partial class UserSettingsDialog : Form
    {
        public UserSettingsDialog()
        {
            InitializeComponent();
        }

        public string SaveFileName
        {
            get;
            set;
        }

        public string ImagePath
        {
            get;
            set;
        }

        public string UserName
        {
            get 
            {
                return this.nameTextBox.Text;
            }            
        }

        private void selectImageButton_Click(object sender, EventArgs e)
        {
           ImagePath = SmileLoader.OpenSmile();
           SaveFileName = SmileLoader.saveFileName;
           this.selectedPictureBox.ImageLocation = ImagePath;
           Invalidate();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
