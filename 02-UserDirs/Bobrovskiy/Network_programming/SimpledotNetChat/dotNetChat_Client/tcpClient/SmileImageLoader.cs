using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dotNetChatClient
{
    public static class SmileLoader
    {
        public static string saveFileName = string.Empty;

        public static string OpenSmile()
        {
            string path = string.Empty;
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();

            openFileDialog1.DefaultExt = "*.gif";
            openFileDialog1.Filter = "gif files (*.gif)|*.gif";

            DialogResult result = openFileDialog1.ShowDialog();

            // OK button was pressed.
            if (result == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                saveFileName = openFileDialog1.SafeFileName;
            }

            return path;


        }

    }//class
}
