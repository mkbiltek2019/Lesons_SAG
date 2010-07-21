using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Model;

namespace MyBackgroundWorker
{
    public partial class SaveForm : Form
    {
        public SaveForm(List<ResultTable> fileList)
        {
            InitializeComponent();
            if (result != null)
            {
                result.Clear();
            }

            result = fileList;
        }

        private List<Model.ResultTable> result;
        private string folderPath = string.Empty;

        private void startSavingButton_Click(object sender, EventArgs e)
        {
            //progressBar.Style = ProgressBarStyle.Marquee;
            //if (!string.IsNullOrEmpty(folderPath))
            //{
            //    worker = (new Client()).GetBackGroundSorterWorker(result);
            //    worker.FolderPath = folderPath;
            //    worker.ProgressChanged += backgroundWorker_ProgressChanged;
            //    worker.RunWorkerAsync();
            //}
            //progressBar.Style = ProgressBarStyle.Continuous;

            foreach (Model.ResultTable res in result)
            {
                //store files
                string sourceFile = res.FullPath + @"\" + res.FileName;
                string destFile = folderPath + @"\" + res.NewName + @".mp3";
               // File.Move(sourceFile, destFile);
                try
                {
                    if (!File.Exists(sourceFile))
                    {
                        // This statement ensures that the file is created,
                        // but the handle is not kept.
                        using (FileStream fs = File.Create(sourceFile)) { }
                    }
                    // Ensure that the target does not exist.
                    if (File.Exists(destFile))
                    {
                       File.Delete(destFile); 
                    }
                    // Move the file.
                    File.Move(sourceFile, destFile);
                    // See if the original exists now.
                    if (File.Exists(sourceFile))
                    {
                        this.Text = "Error!!! File does'nt removed.";
                    }
                }
                catch (Exception ex)
                {
                    this.Text ="The process failed: {0}";
                }
            }

            this.Text = "Save process have ended. you can close the Form..";
        }

        private void selectFolder_Click(object sender, EventArgs e)
        {
            folderPath = GetFolderPath();
        }

        private string GetFolderPath()
        {
            string result = string.Empty;

            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.ShowDialog();
                result = dialog.SelectedPath;
            }

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
