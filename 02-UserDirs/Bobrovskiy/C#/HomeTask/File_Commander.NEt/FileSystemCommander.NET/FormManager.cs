using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Helper;
using System.Management;

namespace FileSystemCommander.NET
{
    public partial class MainForm
    {
        private void ListPanel_OnMouseDoubleClick(object sender, MouseEventArgs e, FileListPanel fileListPanel)
        {
            ListViewItem item = (ListViewItem)sender;
            if (item != null)
            {
                fileListPanel.NavigateInFolderListAndOpenFile(item.Text);
            }

            SetFolderPath();
        }

        private void ListPanel_OnMouseUp(object sender, MouseEventArgs e, FileListPanel fileListPanel, string text)
        {
            ShowContextMenu(sender, e, text);
            if (e.Button == MouseButtons.Right)
            {
                fileListPanel.LoadDirectoryAndFileDataToList();
            }
        }

        private void ShowContextMenu(object sender, MouseEventArgs e, string Path)
        {
            ListViewItem item = (ListViewItem)sender;
            if (e.Button == MouseButtons.Right)
            {
                if (item != null)
                {
                    ShellContextMenu scm = new ShellContextMenu();
                    FileInfo[] files = new FileInfo[1];
                    files[0] = new FileInfo(Path + "\\" + item.Text);
                    scm.ShowContextMenu(files, MousePosition);
                }
                else
                {
                    ShellContextMenu scm = new ShellContextMenu();
                    DirectoryInfo info = new DirectoryInfo(Path);
                    try
                    {
                        if (info.Exists)
                        {
                            scm.ShowContextMenu((info).GetDirectories(), MousePosition);
                        }
                    }
                    catch (Exception s)
                    {
                    }

                }
            }

        }

        private void BindEventsToFileListPanel()
        {
            rightFileListPanel.MouseUp += new MouseEventHandler(fileListPanel1_MouseUp);
            rightFileListPanel.MouseDoubleClick += new MouseEventHandler(fileListPanel1_MouseDoubleClick);

            #region right listview
            //// drag and drop
            //rightFileListPanel.MouseMove += new MouseEventHandler(rightFileListPanel_MouseMove);
            //rightFileListPanel.DragEnter += new DragEventHandler(rightFileListPanel_DragEnter);
            //rightFileListPanel.DragDrop += new DragEventHandler(rightFileListPanel_DragDrop);
            //rightFileListPanel.MouseDown += new MouseEventHandler(rightFileListPanel_MouseDown);
            ////-----------
            #endregion

            leftFileListPanel.MouseDoubleClick += new MouseEventHandler(fileListPanel2_MouseDoubleClick);
            leftFileListPanel.MouseUp += new MouseEventHandler(fileListPanel2_MouseUp);

             #region left list view
            ////drag and drop
            //leftFileListPanel.MouseMove += new MouseEventHandler(leftFileListPanel_MouseMove);
            //leftFileListPanel.DragEnter += new DragEventHandler(leftFileListPanel_DragEnter);
            //leftFileListPanel.DragDrop += new DragEventHandler(leftFileListPanel_DragDrop);
            //leftFileListPanel.MouseDown += new MouseEventHandler(leftFileListPanel_MouseDown);
            ////-------
            #endregion
        }

        #region rightFileListPanel

        //void rightFileListPanel_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (!rightFileListPanelMouseDown)
        //    {
        //        return;
        //    }
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        return;
        //    }

        //    if (sender == null)
        //    {
        //        return;
        //    }

        //    rightFileListPanel.DoDragDrop(((ListViewItem)sender).Text, DragDropEffects.Copy);
        //}

        //void rightFileListPanel_DragEnter(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.Text))
        //        e.Effect = DragDropEffects.Copy;
        //    else
        //        e.Effect = DragDropEffects.None;
        //}

        //void rightFileListPanel_DragDrop(object sender, DragEventArgs e)
        //{
        //    ListViewItem item = (ListViewItem)sender;

        //    if (item != null)
        //    {
        //        rightFileListPanel.AddDirectoryToList(item.Text,
        //        rightFileListPanel.GetCurrentFolderPath());
        //    }


        //    //leftFileListPanel.LoadDirectoryAndFileDataToList();
        //    //rightFileListPanel.LoadDirectoryAndFileDataToList();

        //    leftFileListPanelMouseDown = false;
        //    rightFileListPanelMouseDown = false;
        //}

        //void rightFileListPanel_MouseDown(object sender, MouseEventArgs e)
        //{
        //    rightFileListPanelMouseDown = true;
        //}

       #endregion

        #region leftFileListPanel

        //void leftFileListPanel_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        return;
        //    }

        //    if (!leftFileListPanelMouseDown)
        //    {
        //        return;
        //    }
           
        //        if (sender == null)
        //        {
        //            return;
        //        }
               
        //    leftFileListPanel.DoDragDrop(((ListViewItem)sender).Text, DragDropEffects.Copy);
               
            

        //}

        //void leftFileListPanel_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        leftFileListPanelMouseDown = true;
        //    }
        //    else
        //    {
        //        leftFileListPanelMouseDown = false;
        //    }
        //}

        //void leftFileListPanel_DragDrop(object sender, DragEventArgs e)
        //{
        //    ListViewItem item = (ListViewItem)sender;
        //    if (item != null)
        //    {
        //        leftFileListPanel.AddDirectoryToList(item.Text,
        //                                             leftFileListPanel.GetCurrentFolderPath());
        //    }

        // //   leftFileListPanel.LoadDirectoryAndFileDataToList();
        //  //  rightFileListPanel.LoadDirectoryAndFileDataToList();

        //    leftFileListPanelMouseDown = false;
        //    rightFileListPanelMouseDown = false;
        //}

        //void leftFileListPanel_DragEnter(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.Text))
        //    {
        //        e.Effect = DragDropEffects.Copy;
        //    }
        //    else
        //    {
        //        e.Effect = DragDropEffects.None;
        //    }
        //}

        #endregion


        private void SetFolderPath()
        {
            FilePath2TextBox.Text = rightFileListPanel.GetCurrentFolderPath();
            FilePathTextBox.Text = leftFileListPanel.GetCurrentFolderPath();
        }


        #region View List settings

        private void SetLeftFileListPanelViewSettings(View style)
        {
            leftFileListPanel.View = style;
        }

        private void SetRightFileListPanelViewSettings(View style)
        {
            rightFileListPanel.View = style;
        }

        #endregion


        #region Logical disk tool bar build

        public enum DriveType : int
        {
            Unknown = 0,
            NoRoot = 1,
            Removable = 2,
            Localdisk = 3,
            Network = 4,
            CD = 5,
            RAMDrive = 6
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetDriveType(string lpRootPathName);

        public void queryDisk()
        {
            //--------------This need WMI ------------------------
            //        This is great, but it only works when user inserts or ejects the CD-ROM?
            //Is there any way to check whether the CD-ROM is already in CD Drive or
            //--------------------------------------
            //drivetype=5

            SelectQuery query =
                new SelectQuery("select volumename, volumeserialnumber from win32_logicaldisk where drivetype=5");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            foreach (ManagementObject mo in searcher.Get())
            {
                if ((mo["volumename"] != null) || (mo["volumeserialnumber"] != null))
                {
                    //Console.WriteLine("{0} - {1} ",mo["volumename"]
                    //mo["volumeserialnumber"])
                    //    ;
                    MessageBox.Show("CD-ROM is already in CD Drive");
                }
            }

        }

        private void BuildDriverToolStrip(List<string> driverLetterList, ToolStrip toolStrip)
        { // add disk buttons to panel
            toolStrip.Items.Clear();

            foreach (string driverLetter in driverLetterList)
            {
                ToolStripButton button = new ToolStripButton();
                button.BackgroundImageLayout = ImageLayout.Center;
                button.Font = new System.Drawing.Font("Tahoma",
                             9.75F, System.Drawing.FontStyle.Bold,
                             System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                button.Size = new System.Drawing.Size(toolStrip.Size.Width, toolStrip.Size.Width);
                button.Text = driverLetter.Split(new char[] { ':', '\\' }, 2)[0]; //extract driver letter
                button.AutoToolTip = false;

                button.ToolTipText = Enum.GetName(typeof(DriveType), GetDriveType(driverLetter));
                button.Image = GetDriverImageByDriverLetter(driverLetter);
                button.MouseUp += new MouseEventHandler(ToolStripButton_MouseUp);
                toolStrip.Items.Add(button);
            }

        }

        private System.Drawing.Image GetDriverImageByDriverLetter(string driverLetter)
        {
            switch ((DriveType)GetDriveType(driverLetter))
            {
                case DriveType.CD:
                    {
                        return Properties.Resources.CD_Drive;
                    }
                case DriveType.Localdisk:
                    {
                        return Properties.Resources.Hard_Drive;
                    }
                case DriveType.Network:
                    {
                        return Properties.Resources.Hard_Drive;
                    }
                case DriveType.NoRoot:
                    {
                        return Properties.Resources.Hard_Drive;
                    }
                case DriveType.RAMDrive:
                    {
                        return Properties.Resources.flash_drive;
                    }
                case DriveType.Removable:
                    {
                        return Properties.Resources.flash_drive;
                    }
                case DriveType.Unknown:
                    {
                        return Properties.Resources.UnknownDrive;
                    }
            }

            return Properties.Resources.Hard_Drive;
        }

        private void ToolStripButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                OnLeftRightPanelToolButtonClick(sender);
            }

        }

        private void OnLeftRightPanelToolButtonClick(object sender)
        { //change logical disk
            if (((ToolStripButton)sender).GetCurrentParent() == rightDiskToolStrip)
            {
                FilePath2TextBox.Text = ((ToolStripButton)sender).Text + ":\\";
                rightFileListPanel.SetCurrentFolderPath(FilePath2TextBox.Text);
                rightFileListPanel.LoadDirectoryAndFileDataToList();
                rightFileListPanel.Update();
            }

            if (((ToolStripButton)sender).GetCurrentParent() == leftDiskToolStrip)
            {
                FilePathTextBox.Text = ((ToolStripButton)sender).Text + ":\\";
                leftFileListPanel.SetCurrentFolderPath(FilePathTextBox.Text);
                leftFileListPanel.LoadDirectoryAndFileDataToList();
                leftFileListPanel.Update();
            }
        }

        private void RefreshDiskList()
        {
            BuildDriverToolStrip(rightFileListPanel.GetDiskDriverList(), this.rightDiskToolStrip);
            BuildDriverToolStrip(leftFileListPanel.GetDiskDriverList(), this.leftDiskToolStrip);
        }

        #endregion

    }
}
