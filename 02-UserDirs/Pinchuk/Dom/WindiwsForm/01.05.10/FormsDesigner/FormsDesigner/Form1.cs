using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormsDesigner
{
    public partial class Form1 : Form
    {
       List<Button> buttonList =new List<Button>();
        List<CheckBox> checkBoxList = new List<CheckBox>();
        List<RadioButton> radioButtonList = new List<RadioButton>();
        List<Label> labelList = new List<Label>();
        List<GroupBox> groupBoxList = new List<GroupBox>();
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButtonOn_Click(object sender, EventArgs e)
        {
            foreach (ToolStripButton itemButton in toolStrip1.Items)
            {
                if(itemButton.Text == sender.ToString())
                    itemButton.Checked = true;
                else
                    itemButton.Checked = false;
            }
        }
        private void splitContainer1_Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (ToolStripButton itemButton in toolStrip1.Items)
            {
                if (itemButton.Checked)
                {
                    switch (itemButton.Text)
                    {
                        case "Button":
                            AddControlButton();
                            break;
                        case "RadioButton":
                            AddControlRadioButto();
                            break;
                        case "CheckBox":
                            AddControlCheckBox();
                            break;
                        case "Label":
                            AddControlLabel();
                            break;
                        case "GroupBox":
                            AddControlGrouBox();
                            break;

                    }
                }
            }
            
        }
        private void AddControlButton()
        {
            buttonList.Add(new Button());
            buttonList[buttonList.Count - 1].Name = String.Format("button{0}", buttonList.Count);
            buttonList[buttonList.Count - 1].Text = String.Format("button{0}", buttonList.Count);
            buttonList[buttonList.Count - 1].Location =PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y-65));
            splitContainer1.Panel1.Controls.Add(buttonList[buttonList.Count - 1]);
            //PropertyGrigSelectedObject(buttonList[buttonList.Count - 1]);
            AddComboBox(buttonList[buttonList.Count - 1]);

           
        }
        private void AddControlRadioButto()
        {
            radioButtonList.Add(new RadioButton());
            radioButtonList[radioButtonList.Count - 1].Name = String.Format("RadioButton{0}", radioButtonList.Count);
            radioButtonList[radioButtonList.Count - 1].Text = String.Format("RadioButton{0}", radioButtonList.Count);
            radioButtonList[radioButtonList.Count - 1].Location = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y - 65));
            splitContainer1.Panel1.Controls.Add(radioButtonList[radioButtonList.Count - 1]);
            //PropertyGrigSelectedObject(radioButtonList[radioButtonList.Count - 1]);
            AddComboBox(radioButtonList[radioButtonList.Count - 1]);
        }
        private void AddControlCheckBox()
        {
            checkBoxList.Add(new CheckBox());
            checkBoxList[checkBoxList.Count - 1].Name = String.Format("CheckBox{0}", checkBoxList.Count);
            checkBoxList[checkBoxList.Count - 1].Text = String.Format("CheckBox{0}", checkBoxList.Count);
            checkBoxList[checkBoxList.Count - 1].Location = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y - 65));
            splitContainer1.Panel1.Controls.Add(checkBoxList[checkBoxList.Count - 1]);
            //PropertyGrigSelectedObject(checkBoxList[checkBoxList.Count - 1]);
            AddComboBox(checkBoxList[checkBoxList.Count - 1]);
        }
        private void AddControlLabel()
        {
            labelList.Add(new Label());
            labelList[labelList.Count - 1].Name = String.Format("Label{0}", labelList.Count);
            labelList[labelList.Count - 1].Text = String.Format("Label{0}", labelList.Count);
            labelList[labelList.Count - 1].Location = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y - 65));
            splitContainer1.Panel1.Controls.Add(labelList[labelList.Count - 1]);
            //PropertyGrigSelectedObject(labelList[labelList.Count - 1]);
            AddComboBox(labelList[labelList.Count - 1]);
        }
        private void AddControlGrouBox()
        {
            groupBoxList.Add(new GroupBox());
            groupBoxList[groupBoxList.Count - 1].Name = String.Format("GroupBox{0}", groupBoxList.Count);
            groupBoxList[groupBoxList.Count - 1].Text = String.Format("GroupBox{0}", groupBoxList.Count);
            groupBoxList[groupBoxList.Count - 1].Location = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y - 65));
            splitContainer1.Panel1.Controls.Add(groupBoxList[groupBoxList.Count - 1]);
           // PropertyGrigSelectedObject(groupBoxList[groupBoxList.Count - 1]);
            AddComboBox(groupBoxList[groupBoxList.Count - 1]);
        }
        private void PropertyGrigSelectedObject(Control control)
        {
            propertyGrid1.SelectedObject = control;
        }
        private void AddComboBox(Control control)
        {
            comboBox1.Items.Add(control.Name);
            comboBox1.SelectedIndex = comboBox1.FindString(control.Name);
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Control control = (Control) sender;
           

            foreach (Control controlCollection in splitContainer1.Panel1.Controls)
            {
                if (String.Equals(controlCollection.Text,control.Text) )
                {
                    PropertyGrigSelectedObject(controlCollection);
                }  
                
            }
            
        }
    }
}
