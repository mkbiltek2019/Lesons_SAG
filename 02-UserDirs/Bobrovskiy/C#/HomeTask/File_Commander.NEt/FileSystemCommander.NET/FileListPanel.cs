using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Helper;
using System.Diagnostics;
using Helper.IconHelper;
using Helper;

namespace FileSystemCommander.NET
{
    public partial class FileListPanel : UserControl
    {
        public event MouseEventHandler MouseDown;
        public event MouseEventHandler MouseUp;
        public event MouseEventHandler MouseDoubleClick;
        public event MouseEventHandler MouseMove;

        public event DragEventHandler DragDrop;
        public event DragEventHandler DragEnter;

        private DirectoryFileList directoryFileList;

        private List<FileInfo> fileInfo;
        private List<DirectoryInfo> directory;
        
        public List<string> GetDiskDriverList()
        {
            return new List<string>(System.IO.Directory.GetLogicalDrives());
        }

        public string GetCurrentFolderPath()
        {
            return directoryFileList.CurrentDirectory.FullName;
        }

        public void SetCurrentFolderPath(string directory)
        {
            directoryFileList.CurrentDirectory = new DirectoryInfo(directory);
        }


        #region Methods for folder navigation and file opening

        public string BuildFullName(string name)
        {
            return directoryFileList.CurrentDirectory.FullName + @"\" + name;
        }

        private void LoadListOfDirectoryAndFileAndSetCurrentDirectory(DirectoryInfo directory)
        {
            directoryFileList.CurrentDirectory = directory;
            LoadDirectoryAndFileDataToList();
        }

        private void OpenFileByFullName(string fullFileName)
        {
            ProcessStartInfo psi = new ProcessStartInfo(fullFileName);
            psi.UseShellExecute = true;
            psi.ErrorDialog = true;
            Process.Start(psi);
        }

        public void NavigateInFolderListAndOpenFile(string listItem)
        {
            if ((new FileInfo(BuildFullName(listItem))).Exists)
            { //we have some file
                OpenFileByFullName(BuildFullName(listItem));
                return;
            }
            else
            { //we have some folder
                if ((directoryFileList.parent == listItem))
                {//move up
                    if ((directoryFileList.CurrentDirectory.Root.FullName == directoryFileList.CurrentDirectory.FullName))
                    {// if we now in the root directory
                        return;
                    }
                    //move up
                    LoadListOfDirectoryAndFileAndSetCurrentDirectory(directoryFileList.CurrentDirectory.Parent);
                }
                else
                { //move into
                    LoadListOfDirectoryAndFileAndSetCurrentDirectory(new DirectoryInfo(BuildFullName(listItem)));
                }
            }
        }

        #endregion


        #region Methods for directory and file list building

        public void LoadDirectoryAndFileDataToList()
        {
            mainListView.Items.Clear();

            BuildDirectoryListWithIcons();

            BuildFileListWithIcons();
        }

        private void BuildFileListWithIcons()
        {
            fileInfo = directoryFileList.GetFileList();
            mainListView.Cursor = Cursors.WaitCursor;

            for (int i = 0; i < fileInfo.Count; i++)
            {
                smallImageList.Images.Add(fileInfo[i].Name,
                                          IconReader.GetFileIcon(fileInfo[i].FullName,
                                          IconReader.IconSize.Small, false));
                bigImageList.Images.Add(fileInfo[i].Name,
                                        IconReader.GetFileIcon(fileInfo[i].FullName,
                                        IconReader.IconSize.Large, false));

                mainListView.Items.Add(new ListViewItem(new string[]
                                                             {
                                                                 fileInfo[i].Name,
                                                                 fileInfo[i].Length.ToString(),
                                                                 fileInfo[i].LastWriteTime.ToString(),
                                                                 fileInfo[i].LastAccessTime.ToString()
                                                             }, fileInfo[i].Name));
            }

            mainListView.Cursor = Cursors.Default;
        }

        private void BuildDirectoryListWithIcons()
        {
            try
            {
                mainListView.Cursor = Cursors.WaitCursor;
                directory = directoryFileList.GetDirectoryList();

                for (int i = 0; i < directory.Count; i++)
                {
                    if (directory[i].Name == "--")
                    {
                        SetFolderIcon(directory[i], IconReader.FolderType.Closed);
                    }
                    else
                    {
                        SetFolderIcon(directory[i], IconReader.FolderType.Open);
                    }

                    mainListView.Items.Add(new ListViewItem(new string[]
                                                                 {
                                                                     directory[i].Name,
                                                                     "<DIR>",
                                                                     directory[i].LastWriteTime.ToString(),
                                                                     directory[i].LastAccessTime.ToString()
                                                                 }, directory[i].Name));
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                mainListView.Cursor = Cursors.Default;
            }
        }

        private void SetFolderIcon(DirectoryInfo directory, IconReader.FolderType type)
        {
            smallImageList.Images.Add(directory.Name,
                                      IconReader.GetFolderIcon(IconReader.IconSize.Small, type));
            bigImageList.Images.Add(directory.Name,
                                    IconReader.GetFolderIcon(IconReader.IconSize.Large, type));
        }

        #endregion

        public FileListPanel(DirectoryInfo inititalDirectory)
        {
            InitializeComponent();

            directoryFileList = new DirectoryFileList(inititalDirectory);

            LoadDirectoryAndFileDataToList();
        }

        public FileListPanel()
            : this(new DirectoryInfo(Environment.CurrentDirectory))
        {
        }

        public View View
        {
            get
            {
                return mainListView.View;
            }
            set
            {
                mainListView.View = value;
            }
        }

        private void mainListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MouseDoubleClick != null && e.Button == MouseButtons.Left)
            {
                MouseDoubleClick.Invoke(mainListView.GetItemAt(e.X, e.Y), e);
            }
        }

        private void mainListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (MouseUp != null)
            {
                MouseUp.Invoke(mainListView.GetItemAt(e.X, e.Y), e);
            }
        }

        private void mainListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseDown != null && (e.Button == MouseButtons.Left))
            {
                MouseDown.Invoke(mainListView.GetItemAt(e.X, e.Y), e);
            }
        }

        private void mainListView_DragDrop(object sender, DragEventArgs e)
        {
            if (DragDrop != null)
            {
                DragDrop.Invoke(mainListView.GetItemAt(e.X, e.Y), e);
            }
        }

        private void mainListView_DragEnter(object sender, DragEventArgs e)
        {
            if (DragEnter != null)
            {
                DragEnter.Invoke(mainListView.GetItemAt(e.X, e.Y), e);
            }
        }

        private void mainListView_MouseMove(object sender, MouseEventArgs e)
        {
            if ((MouseMove != null) && 
                (e.Button == System.Windows.Forms.MouseButtons.Left) && 
                (e.Button != System.Windows.Forms.MouseButtons.Right))
            {
                MouseMove.Invoke(mainListView.GetItemAt(e.X, e.Y), e);
            }
        }

    }
}
