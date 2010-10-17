using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;
using System.Reflection;
using RegistryViewMegaControl.Dialogs;
using RegistryViewMegaControl.Logger;

namespace RegistryViewMegaControl
{
    public partial class RegistryViewControl : UserControl
    {
        //TODO: registry key remove

        public string FullPath
        {
            get;
            set;
        }

        private const int openedFolderImageIndex = 1;
        private const int closedFolderImageIndex = 0;
       
        private const char registryKeySpliter = '\\';
        private List<RegistryKey> registryRoots = new List<RegistryKey>();

        private DataTable dataTable = null;
        private TreeNode selectedTreeNode = null;
        //private RegistryKey tempRegistryKey = null;

        public RegistryViewControl()
        {
            InitializeComponent();

            dataTable = new DataTable("RegistryTable");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Type");
            dataTable.Columns.Add("Value");
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 280;

            //  Generate();
        }

        public void AddRegistryEntry()
        {
            AddRegistryEntryDialDialog dialog = new AddRegistryEntryDialDialog(this.RegistryTreeView.SelectedNode.FullPath);
            dialog.ShowDialog();

            string registryKeyName = dialog.RegistryKeyName;
            object registryKeyValue = dialog.RegistryKeyValue;
            object registryKeyType = dialog.RegistryKeyType;
            RegistryKey addMultibytestring = GetRegistryKey(this.RegistryTreeView.SelectedNode.FullPath);

            addMultibytestring.SetValue(registryKeyName, registryKeyValue, (RegistryValueKind)registryKeyType);

            DataRow dataRow = dataTable.NewRow();
            dataRow[0] = registryKeyName;
            dataRow[1] = registryKeyType;
            dataRow[2] = registryKeyValue;
            dataTable.Rows.Add(dataRow);
        }

        public void CreateRegistrySubKey()
        {
            AddRegistryEntryDialDialog dialog = new AddRegistryEntryDialDialog(this.RegistryTreeView.SelectedNode.FullPath);
            dialog.ShowDialog();

            string registryKeyName = dialog.RegistryKeyName;

            RegistryKey currentRegistryKey = GetRegistryKey(this.RegistryTreeView.SelectedNode.FullPath);

            RegistryTreeView.BeginUpdate();

            RegistryKey rg = currentRegistryKey.CreateSubKey(registryKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);

            selectedTreeNode.Nodes.Add(registryKeyName);
            RegistryTreeView.Refresh();
            RegistryTreeView.EndUpdate();

        }

        public void RemoveRegistryEntry()
        {
            //TODO: Split this method by two to delete registryKey and delete registryValue
            if (MessageBox.Show(
                   "Do you realy want to delete registry key and all it's data!",
                   "Attention!!!", 
                   MessageBoxButtons.OKCancel, 
                   MessageBoxIcon.Warning) == DialogResult.OK)
            {
                RegistryKey childKey = GetRegistryKey(this.RegistryTreeView.SelectedNode.FullPath);
                RegistryKey parentKey = GetRegistryKey(this.RegistryTreeView.SelectedNode.Parent.FullPath);

                if (childKey!=null)
                {
                    if (parentKey.SubKeyCount != 0) 
                    {
                        parentKey.DeleteSubKey(this.RegistryTreeView.SelectedNode.Text); 
                    }
                    else 
                    {
                        childKey.DeleteSubKeyTree(this.RegistryTreeView.SelectedNode.Text);
                    }

                    this.RegistryTreeView.SelectedNode.Remove();
                }
                else
                {
                    string valueName = this.dataGridView1.SelectedCells[0].Value.ToString();
                    childKey.DeleteValue(valueName);
                }
            }
           
        }

        public void Generate()
        {
            FillRegistryRoots();
            UpdateTree();
        }

        private void FillRegistryRoots()
        {
            registryRoots.Add(Registry.CurrentUser);
            registryRoots.Add(Registry.ClassesRoot);
            registryRoots.Add(Registry.Users);
            registryRoots.Add(Registry.CurrentConfig);
            registryRoots.Add(Registry.LocalMachine);
        }
        private void ReadRegistry(TreeNode Node, string Key, string[] SubKeys, RegistryKey rootKey)
        {
            string TotaalPad = Key;
            if (TotaalPad.Length > 0)
            {
                TotaalPad += registryKeySpliter;
            }

            foreach (string key in SubKeys)
            {
                //get a list of the next level sub keys 
                TreeNode node = new TreeNode(key, closedFolderImageIndex, openedFolderImageIndex);
                string[] subKeys = new string[0];

                try
                {
                    subKeys = rootKey.OpenSubKey(TotaalPad + key,
                                    RegistryKeyPermissionCheck.ReadWriteSubTree,
                                    RegistryRights.FullControl).GetSubKeyNames();
                }
                catch
                {
                    LogManager.Instance.PutMessage("Error1. Can't access to registry key: " + key);
                }

                if (subKeys.Length > 0)
                {
                    this.ReadRegistry(node, TotaalPad + key, subKeys, rootKey);
                }

                node.Name = node.Text;
                Node.Nodes.Add(node);
            }

        }

        private void Do()
        {
            foreach (RegistryKey item in registryRoots)
            {              
                ThreadPool.QueueUserWorkItem(new WaitCallback(Fill), item);
            }
        }

        private void UpdateTree()
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            Thread t = new Thread(new ThreadStart(Do));
            t.Priority = ThreadPriority.Highest;
            t.Start();            
        }

        private void Fill(object o)
        {
            lock (sync)
            {
                RegistryKey key = (RegistryKey)o;
                TreeNode currentUserNode = CreateTreeNode(key);

                AddAsync(currentUserNode);
            }            
        }

        private object sync = new object();

        public delegate void FillTreeDelegate(TreeNode currentUserNode);

        private void AddAsync(TreeNode currentUserNode)
        {
            BeginInvoke(new FillTreeDelegate(AddNodeToTreeView), currentUserNode);
        }

        private void AddNodeToTreeView(TreeNode currentUserNode)
        {
            RegistryTreeView.Nodes.Add(currentUserNode);
        }

        private TreeNode CreateTreeNode(RegistryKey item)
        {
            TreeNode currentUserNode = new TreeNode(item.Name, closedFolderImageIndex, openedFolderImageIndex);
            string[] currentUserSubKeys = item.GetSubKeyNames();

            this.ReadRegistry(currentUserNode, string.Empty, currentUserSubKeys, item);

            return currentUserNode;
        }

        private void RegistryTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                this.fullPathToKeyTextBox.Text = e.Node.FullPath;
                string[] stringValuesCollection = null;

                selectedTreeNode = e.Node;

                dataTable.Rows.Clear();

                RegistryKey registryKey = GetRegistryKey(selectedTreeNode.FullPath);

                if (registryKey != null)
                {
                    stringValuesCollection = registryKey.GetValueNames();
                    FillGrid(stringValuesCollection, registryKey);
                }

            }
        }

        private RegistryKey GetRegistryKey(string fullPath)
        {
            string[] keyList = fullPath.Split(registryKeySpliter);
            RegistryKey rootKey = null;

            foreach (RegistryKey item in registryRoots)
            {
                if (item.Name == keyList[0])
                {
                    rootKey = item;
                }
            }

            RegistryKey registryKey = rootKey;
            for (int i = 1; i < keyList.Length; i++)
            {
                try
                {
                    registryKey = registryKey.OpenSubKey(keyList[i], true);
                }
                catch
                {
                    LogManager.Instance.PutMessage("Error2. Can't access to registry key: " + registryKey);
                }
            }
            return registryKey;
        }

        private void FillGrid(string[] str, RegistryKey rg)
        {
            DataRow dataRow = null;
            for (int i = 0; i < str.Length; i++)
            {
                dataRow = dataTable.NewRow();
                dataRow[0] = str[i];
                string valueKind = string.Format("{0}", rg.GetValueKind(str[i]));
                dataRow[1] = valueKind;

                string kegistryKeyValue = string.Empty;
                switch (valueKind)
                {
                    case "String":
                    case "MultiString":
                    case "DWord":
                        {
                            kegistryKeyValue = rg.GetValue(str[i]).ToString();
                        }
                        break;
                    case "Binary":
                        {
                            byte[] bytes = (byte[])rg.GetValue(str[i]);
                            kegistryKeyValue = BitConverter.ToString(bytes);
                        }
                        break;
                }
                dataRow[2] = kegistryKeyValue;

                dataTable.Rows.Add(dataRow);
            }

            dataGridView1.DataSource = dataTable;
        }

        private void RegistryTreeView_Click(object sender, EventArgs e)
        {
            selectedTreeNode = this.RegistryTreeView.SelectedNode;
        }

    }
}