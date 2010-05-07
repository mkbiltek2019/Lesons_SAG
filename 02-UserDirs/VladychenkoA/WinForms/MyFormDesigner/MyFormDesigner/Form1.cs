using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyFormDesigner
{
    public partial class Form1 : Form
    {
        private Control _designerControl;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _designerControl = new Button();
            ////DoDragDrop(_designerControl, AllowDrop);
            ////splitContainer1.Panel1.Controls.Add(_designerControl);
            propertyGrid1.SelectedObject = _designerControl;
        }

        private void splitContainer1_Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void toolStripButton1_MouseDown(object sender, MouseEventArgs e)
        {
            //_designerControl = new Button();
            //propertyGrid1.SelectedObject = _designerControl;
            if(!Equals(_designerControl, null)  )
            toolStripButton1.DoDragDrop( _designerControl, DragDropEffects.Copy);
        }

      

        private void splitContainer1_Panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

       
    }
}
