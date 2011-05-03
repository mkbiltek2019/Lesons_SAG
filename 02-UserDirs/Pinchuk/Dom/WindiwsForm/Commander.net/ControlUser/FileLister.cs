using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlUser
{
    public delegate void ActionDoubleClickHendler();
    public partial class FileLister : UserControl
    {
        private string directoryCurentPath;
        DirectoryInfo directoryPath;


        public View ViewFileListe
        {
            get { return curentDirectorylistView.View; }
            set { curentDirectorylistView.View = value; }
        }


        public bool FocusedPanel
        {
            get { return curentDirectorylistView.Focused; }

        }
        

        public FileLister()
        {
            InitializeComponent();
            ReadAllDrives(logicDiskList);
            directoryCurentPath = (logicDiskList.Items[0] as ToolStripButton).ToolTipText;
            directoryPath = new DirectoryInfo(directoryCurentPath);
            (logicDiskList.Items[0] as ToolStripButton).Checked = true;
            RefreshFileSystemList(directoryCurentPath);
            PathCurentDirectory.Text = directoryCurentPath;
            
        }


        private void ReadAllDrives(ToolStrip disklList)
        {
            disklList.Items.Clear();

            foreach (var driveInfo in DriveInfo.GetDrives())
            {
                ToolStripButton newBtn = new ToolStripButton();
                if (driveInfo.IsReady)
                {
                    newBtn.Text = driveInfo.Name;
                    newBtn.ToolTipText = driveInfo.Name;
                    newBtn.Image = GetIconDriveType(driveInfo.DriveType);
                    newBtn.Click += new System.EventHandler(this.newBtn_Click);
                    newBtn.CheckOnClick = true;
                    disklList.Items.Add(newBtn);
                }

            }
        }


        private Image GetIconDriveType(DriveType driveType)
        {
            Image iconImage = Properties.Resource.Alert;
            switch (driveType)
            {
                case DriveType.Fixed:
                    iconImage = Properties.Resource.HDD;
                    break;
                case DriveType.CDRom:
                    iconImage = Properties.Resource.DVD;
                    break;
                case DriveType.Removable:
                    iconImage = Properties.Resource.USB;
                    break;
            }
            return iconImage;
        }


        private void newBtn_Click(object sender, EventArgs e)
        {
            SwitchButton(sender);
            directoryCurentPath = (sender as ToolStripButton).ToolTipText;
            directoryPath =new DirectoryInfo(Path.Combine(directoryCurentPath) ); 
            RefreshFileSystemList(directoryCurentPath);
        }


        private void RefreshFileSystemList(string directoryCurentPath)
        {
            curentDirectorylistView.Items.Clear();
            curentDirectorylistView.Items.AddRange(GetListContentDirectory(directoryCurentPath).ToArray());
            curentDirectorylistView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }


        private void SwitchButton(object sender)
        {
            foreach (ToolStripButton itemButton in logicDiskList.Items)
            {
                if (itemButton.Text == sender.ToString())
                    itemButton.Checked = true;
                else
                    itemButton.Checked = false;
            }
        }


        private void CurentDirectorylistView_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            (curentDirectorylistView.FocusedItem.Tag as ActionDouvleHendler).Invoke();
            RefreshFileSystemList(directoryCurentPath);
        }


        private IEnumerable<ClasFile> GetListCurrentDirectory(string dir)
        {
            foreach (DirectoryInfo directoryInfo in new DirectoryInfo(dir).GetDirectories().AsEnumerable())
                yield return GetDirectories(directoryInfo);
            foreach (FileInfo fileInfo in new DirectoryInfo(dir).GetFiles().AsEnumerable())
                yield return GetFiles(fileInfo);
        }


        private ClasFile GetDirectories(DirectoryInfo directoryInfo)
        {
            SHFILEINFO infoIcons = ShellGetFileInfo.GetFileInfo(directoryInfo.FullName);
            return new ClasFile()
            {
                Name = directoryInfo.Name,
                IconFile = Icon.FromHandle(infoIcons.hIcon),
                ExtensionFile = "<DIR>",
                Action = OpenDirectory
            };
        }


        private void OpenDirectory()
        {
            directoryPath = new DirectoryInfo(Path.Combine(directoryCurentPath, curentDirectorylistView.FocusedItem.Text));
            directoryCurentPath = directoryPath.FullName;
        }


        private void OpenFile()
        {
            try
            {
                Process.Start(Path.Combine(directoryPath.FullName, curentDirectorylistView.SelectedItems[0].Text));
            }
            catch (Win32Exception)
            {
                MessageBox.Show("No program is associated with the selected file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
            }
            
        }


        private void OpenParentDirectory()
        {
            directoryCurentPath = directoryPath.Parent.FullName;
            directoryPath = new DirectoryInfo(directoryCurentPath);
        }


        private ClasFile GetFiles(FileInfo directoryInfo)
        {
            SHFILEINFO infoIcons = ShellGetFileInfo.GetFileInfo(directoryInfo.FullName);
            return new ClasFile()
            {
                Name = directoryInfo.Name,
                IconFile = Icon.FromHandle(infoIcons.hIcon),
                Size = GetSizeFile(directoryInfo),
                ExtensionFile = directoryInfo.Extension,
                Action = OpenFile,

            };

        }


        private IEnumerable<ListViewItem> GetListContentDirectory(string dir)
        {
            if (dir != directoryPath.Root.ToString())
            {
                smallImageList.Images.Add("[..]", Properties.Resource.arrowUp);
                bigImageList.Images.Add("[..]", Properties.Resource.arrowUp);
                yield return new ListViewItem("[..]", "[..]") { Tag = (new ClasFile() { Action = OpenParentDirectory }).Action };
            }

            foreach (ClasFile file in GetListCurrentDirectory(dir))
            {
                smallImageList.Images.Add(file.Name, file.IconFile);
                bigImageList.Images.Add(file.Name, file.IconFile);
                yield return new ListViewItem(new string[]
                                                       {
                                                           file.Name,
                                                           file.ExtensionFile,
                                                           file.Size,

                                                       },
                                                       file.Name) { Tag = file.Action };
            }

        }


        private string GetSizeFile(FileInfo directoryInfo)
        {
            string ResultString;
            Int64 diskSpaceKB = directoryInfo.Length / 1024;
            Int64 diskSpaceMB = diskSpaceKB / 1024;
            Int64 diskSpaceGB = diskSpaceMB / 1024;

            ResultString = diskSpaceGB.ToString() + " Гб";

            if (diskSpaceGB < 1)
                ResultString = diskSpaceMB.ToString() + " Mб";

            if (diskSpaceMB < 1)
                ResultString = diskSpaceKB.ToString() + " Кб";

            if (diskSpaceKB < 1)
                ResultString = directoryInfo.Length.ToString() + " Кб";

            return ResultString;
        }


        private void curentDirectorylistView_Leave(object sender, EventArgs e)
        {
            PathCurentDirectory.ResetBackColor();
            PathCurentDirectory.ResetForeColor();
        }


        private void curentDirectorylistView_Enter(object sender, EventArgs e)
        {
            PathCurentDirectory.BackColor = Color.DarkBlue;
            PathCurentDirectory.ForeColor = Color.White;
        }


        private void curentDirectorylistView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ShellContextMenu shellMenu = new ShellContextMenu();

                FileInfo fileInfo = new FileInfo(Path.Combine(directoryCurentPath, curentDirectorylistView.SelectedItems[0].Text));
                shellMenu.ShowContextMenu(new[] { fileInfo }, PointToScreen(new Point(e.X, e.Y)));
            }
        }
    }
}
