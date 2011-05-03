using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControlUser;

namespace Commander.net
{
    public partial class FileManager : Form
    {
        public FileManager()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Icon = Properties.Resources.Floppy;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bidIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LeftPanel.FocusedPanel)
                LeftPanel.ViewFileListe = View.LargeIcon;
            if (RightPanel.FocusedPanel)
                RightPanel.ViewFileListe = View.LargeIcon;

        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LeftPanel.FocusedPanel)
                LeftPanel.ViewFileListe = View.SmallIcon;
            if (RightPanel.FocusedPanel)
                RightPanel.ViewFileListe = View.SmallIcon;
        }

        private void SwitchList_Click(object sender, EventArgs e)
        {
            SetView((sender as ToolStripMenuItem).Name, GetActivPanel());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SetView((sender as ToolStripButton).Text, GetActivPanel());
        }

        private static void SetView(string toolStripMenuItem, FileLister ActivPanel)
        {
            switch (toolStripMenuItem)
            {
                case "smallIcon":
                    ActivPanel.ViewFileListe = View.SmallIcon;
                    break;
                case "bigIcon":
                    ActivPanel.ViewFileListe = View.LargeIcon;
                    break;
                case "Details":
                    ActivPanel.ViewFileListe = View.Details;
                    break;
            }
        }

        

        private FileLister GetActivPanel()
        {
            FileLister ActivPanel = new FileLister() ;
            if (LeftPanel.FocusedPanel)
                ActivPanel=LeftPanel;
            if (RightPanel.FocusedPanel)
                ActivPanel =RightPanel;
            return ActivPanel;
        }

        
    }
}
