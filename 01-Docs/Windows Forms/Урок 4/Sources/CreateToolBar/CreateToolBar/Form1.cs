using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CreateToolBar
{
    public partial class Form1 : Form
    {
        ToolBar tBar;
        ImageList list;
        public Form1()
        {
            InitializeComponent();
            list = new ImageList();
            list.ImageSize = new Size(50, 50);
            list.Images.Add(new Bitmap("open.bmp"));
            list.Images.Add(new Bitmap("save.bmp"));
            list.Images.Add(new Bitmap("exit.bmp"));

            tBar = new ToolBar();
                        
            tBar.ImageList = list; //привяжем список картинок к тулбару
            ToolBarButton toolBarButton1 = new ToolBarButton();
            ToolBarButton toolBarButton2 = new ToolBarButton();
            ToolBarButton toolBarButton3 = new ToolBarButton();
            ToolBarButton separator = new ToolBarButton();
            separator.Style = ToolBarButtonStyle.Separator;

            toolBarButton1.ImageIndex = 0; //Open
            toolBarButton2.ImageIndex = 1;// save
            toolBarButton3.ImageIndex = 2; //exit

            tBar.Buttons.Add(toolBarButton1);
            tBar.Buttons.Add(separator);
            tBar.Buttons.Add(toolBarButton2);
            tBar.Buttons.Add(separator);
            tBar.Buttons.Add(toolBarButton3);

            tBar.Appearance = ToolBarAppearance.Flat;
            tBar.BorderStyle = BorderStyle.Fixed3D;
            tBar.ButtonClick += new ToolBarButtonClickEventHandler(tBar_ButtonClick); 
            
            this.Controls.Add(tBar);
            
        }

        void tBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            OpenFileDialog f1;
            SaveFileDialog f2;
            switch (e.Button.ImageIndex)
            {
                case 0:
                    
                    f1 = new OpenFileDialog();
                    if (f1.ShowDialog() == DialogResult.OK)
                    {
                       StreamReader r= File.OpenText(f1.FileName);
                       textBox1.Text = r.ReadToEnd();
                    }
                    break;
                case 1:
                    f2 = new SaveFileDialog();
                    if (f2.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter w = new StreamWriter(f2.FileName);
                        w.WriteLine(textBox1.Text);
                        w.Close();
                    }
                    break;
                case 2: Close(); break;
            }
        }
    }
}
