using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegisryEditor
{
    public partial class Form1 : Form
    {
        private RegistryKey registryKey;
        public Form1()
        {
           
            InitializeComponent();
        }
         
      private void Form1_Load(object sender, EventArgs e)
        {
            ReadRegistry();
        }

      private void ReadRegistry()
      {
          //HKEY_CLASSES_ROOT
          TreeNode rootNode = new TreeNode(Registry.ClassesRoot.Name, 0, 1);
          string[] rootSubKeys = Registry.ClassesRoot.GetSubKeyNames();
          foreach (string key in rootSubKeys)
          {
              //get a list of the third level sub keys and their values
              TreeNode node = new TreeNode(key, 0, 1);
              string[] subKeys = Registry.ClassesRoot.OpenSubKey(key).GetSubKeyNames();
              foreach (string subKeysKey in subKeys)
              {
                  TreeNode subKeyNode = new TreeNode(subKeysKey, 0, 1);
                  GetValuesAndData(Registry.ClassesRoot.OpenSubKey(key).OpenSubKey(subKeysKey),
                      subKeyNode);

                  node.Nodes.Add(subKeyNode);
              }

              //get the list of values in the second level sub key and their contents
              GetValuesAndData(Registry.ClassesRoot.OpenSubKey(key), node);

              rootNode.Nodes.Add(node);
          }
          treeView1.Nodes.Add(rootNode);


          //HKEY_CURRENT_CONFIG
          TreeNode configNode = new TreeNode(Registry.CurrentConfig.Name, 0, 1);
          string[] configSubKeys = Registry.CurrentConfig.GetSubKeyNames();
          foreach (string key in configSubKeys)
          {
              //get a list of the third level sub keys and their values
              TreeNode node = new TreeNode(key, 0, 1);
              string[] subKeys = Registry.CurrentConfig.OpenSubKey(key).GetSubKeyNames();
              foreach (string subKeysKey in subKeys)
              {
                  TreeNode subKeyNode = new TreeNode(subKeysKey, 0, 1);
                  GetValuesAndData(Registry.CurrentConfig.OpenSubKey(key).OpenSubKey(subKeysKey),
                      subKeyNode);

                  node.Nodes.Add(subKeyNode);
              }

              //get the list of values in the second level sub key and their contents
              GetValuesAndData(Registry.CurrentConfig.OpenSubKey(key), node);

              configNode.Nodes.Add(node);
          }
          treeView1.Nodes.Add(configNode);


          //HKEY_CURRENT_USER
          TreeNode currentUserNode = new TreeNode(Registry.CurrentUser.Name, 0, 1);
          string[] currentUserSubKeys = Registry.CurrentUser.GetSubKeyNames();
          foreach (string key in currentUserSubKeys)
          {
              //get a list of the third level sub keys and their values
              TreeNode node = new TreeNode(key, 0, 1);
              string[] subKeys = Registry.CurrentUser.OpenSubKey(key).GetSubKeyNames();
              foreach (string subKeysKey in subKeys)
              {
                  TreeNode subKeyNode = new TreeNode(subKeysKey, 0, 1);
                  GetValuesAndData(Registry.CurrentUser.OpenSubKey(key).OpenSubKey(subKeysKey),
                      subKeyNode);

                  node.Nodes.Add(subKeyNode);
              }

              //get the list of values in the second level sub key and their contents
              GetValuesAndData(Registry.CurrentUser.OpenSubKey(key), node);

              currentUserNode.Nodes.Add(node);
          }
          treeView1.Nodes.Add(currentUserNode);


          //HKEY_LOCAL_MACHINE
          TreeNode localMachineNode = new TreeNode(Registry.LocalMachine.Name);
          string[] localMachineSubKeys = Registry.LocalMachine.GetSubKeyNames();
          foreach (string key in localMachineSubKeys)
          {
              TreeNode node = new TreeNode(key, 0, 1);

              //a try/catch statement is needed here because some of the data is 
              //not available for all users
              try
              {
                  //get a list of the third level sub keys and their values
                  string[] subKeys = Registry.LocalMachine.OpenSubKey(key, false).GetSubKeyNames();
                  foreach (string subKeysKey in subKeys)
                  {
                      TreeNode subKeyNode = new TreeNode(subKeysKey, 0, 1);
                      GetValuesAndData(Registry.LocalMachine.OpenSubKey(key).OpenSubKey(subKeysKey),
                          subKeyNode);

                      //get the list of values in the second level sub key and their contents
                      GetValuesAndData(Registry.LocalMachine.OpenSubKey(key), node);

                      node.Nodes.Add(subKeyNode);
                  }
              }
              catch (Exception)
              {
                  //an exception is thrown if the user has no access to this subkey
                  //if this is the case, change the icon to show a dimmed folder
                  node.ImageIndex = 4;
                  node.SelectedImageIndex = 5;
              }

              localMachineNode.Nodes.Add(node);
          }
          treeView1.Nodes.Add(localMachineNode);


          //HKEY_USERS
          TreeNode usersNode = new TreeNode(Registry.Users.Name);
          string[] usersSubKeys = Registry.Users.GetSubKeyNames();
          foreach (string key in usersSubKeys)
          {
              TreeNode node = new TreeNode(key, 0, 1);

              //a try/catch statement is needed here because some of the data is 
              //not available for all users
              try
              {
                  //get a list of the third level sub keys and their values
                  string[] subKeys = Registry.Users.OpenSubKey(key).GetSubKeyNames();
                  foreach (string subKeysKey in subKeys)
                  {
                      TreeNode subKeyNode = new TreeNode(subKeysKey, 0, 1);
                      GetValuesAndData(Registry.Users.OpenSubKey(key).OpenSubKey(subKeysKey),
                          subKeyNode);

                      //get the list of values in the second level sub key and their contents
                      GetValuesAndData(Registry.Users.OpenSubKey(key), node);
                      node.Nodes.Add(subKeyNode);
                  }
              }
              catch (Exception)
              {
                  //an exception is thrown if the user has no access to this subkey
                  //if this is the case, change the icon to show a dimmed folder
                  node.ImageIndex = 4;
                  node.SelectedImageIndex = 5;
              }

              usersNode.Nodes.Add(node);
          }
          treeView1.Nodes.Add(usersNode);
      }
      private static void GetValuesAndData(RegistryKey registryKey, TreeNode node)
      {
          string[] values = registryKey.GetValueNames();
          foreach (string value in values)
          {
              object data = registryKey.GetValue(value);

              if (data != null)
              {
                  string stringData = data.ToString();

                  //if the data is too long, display the begining only
                  if (stringData.Length > 50)
                      stringData = stringData.Substring(0, 46) + " ...";

                  //Display the data of the value. The conditional operatore is
                  //needed because the default value has no name
                  node.Nodes.Add(value, (value == "" ? "Default" : value) +
                      ": " + stringData, 2, 2);
              }
              else
              {
                  //Display <empty> if the value is empty
                  node.Nodes.Add(value, (value == "" ? "Default" : value) +
                      ": <empty>", 2, 2);
              }
          }
      }
    }
}
