using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleFormDesigner
{
    public enum ListOfControls
    {
        Label = 1,
        Button = 2,
        GroupBox = 3,
        RadioButton = 4,
        CheckBox = 5
    }

    public partial class MainForm 
    {
        private int TopX
        {
            get;
            set;
        }

        private int TopY
        {
            get;
            set;
        }

        private int BottomX
        {
            get;
            set;
        }

        private int BottomY
        {
            get;
            set;
        }

        private int staticNumber = 0;
        private Control currentDesignerControl;
        private Point MousePoint;
        private Control.ControlCollection StaticsUnderPoint;
        private bool moove = false;
        private ArrayList ListOfControlsInComboBox = new ArrayList();

        private void CreateStatic(ListOfControls controlClassToCreate)
        {
            CreateControlByType(controlClassToCreate);

            Random myRand = new Random();
            
            currentDesignerControl.BackColor = Color.FromArgb(myRand.Next(0, 255), myRand.Next(0, 255), myRand.Next(0, 255));
            currentDesignerControl.ForeColor = Color.Black;
            currentDesignerControl.Location = new Point(TopX, TopY);
            currentDesignerControl.Name = "Control" + staticNumber;
            currentDesignerControl.Size = new Size(BottomX - TopX, BottomY - TopY);
            currentDesignerControl.TabIndex = 0;
            currentDesignerControl.Text = "Control " + staticNumber;
            currentDesignerControl.ContextMenuStrip = CurrentControlContextMenuStrip;
            ListOfControlsInComboBox.Add(currentDesignerControl);

            deleteToolStripMenuItem1.Click += new System.EventHandler(DeleteCurrentControl);
            propertiesToolStripMenuItem1.Click += new EventHandler(PropertiesToolStripMenuItem1_Click);
            currentDesignerControl.MouseUp += new MouseEventHandler(TempLabel_MouseUp);
            currentDesignerControl.MouseDown += new MouseEventHandler(CurrentControl_MouseDown);
            currentDesignerControl.MouseMove += new MouseEventHandler(CurrentControl_MouseMove);
            staticNumber++;

        }

        private void PropertiesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" " + currentDesignerControl.Name );
        }

        private void CreateControlByType(ListOfControls controlClassToCreate)
        {
            switch (controlClassToCreate)
            {
                case ListOfControls.Label:
                    {
                        currentDesignerControl = new Label();
                    }
                    break;
                case ListOfControls.Button:
                    {
                        currentDesignerControl = new Button();
                    }
                    break;
                case ListOfControls.CheckBox:
                    {
                        currentDesignerControl = new CheckBox();
                    }
                    break;
                case ListOfControls.RadioButton:
                    {
                        currentDesignerControl = new RadioButton();
                    }
                    break;
                case ListOfControls.GroupBox:
                    {
                        currentDesignerControl = new GroupBox();
                    }
                    break;
            }
        }

        private void CurrentControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (moove)
            {

                ((Control)sender).Location =
                            new Point(e.Location.X + ((Control)sender).Location.X,
                                      e.Location.Y + ((Control)sender).Location.Y);
            }
        }

        private void CurrentControl_MouseDown(object sender, MouseEventArgs e)
        {
            Control tmp = (Control)sender;
            MousePoint = new Point(e.Location.X + tmp.Left, e.Location.Y + tmp.Top);

            if (e.Button == MouseButtons.Left)
            {
                moove = true;
                currentDesignerControl = (Control)sender;
                MainPropertyGrid.SelectedObject = currentDesignerControl;
            }else

            if (e.Button == MouseButtons.Right)
            {
                CurrentControlContextMenuStrip.Show();
            }
        }

        private void DeleteCurrentControl(object sender, EventArgs e)
        {
            Control lab = FindStatic();
            lab.Visible = false;
            lab.Enabled = false;
            lab.Dispose();
        }

        private void TempLabel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moove = false;
            }
        }

        private Control FindStatic()
        {
            if (StaticsUnderPoint.Count > 0)
            {
                Control resControl = new Control();

                for (int i = 0; i < StaticsUnderPoint.Count; i++)
                {
                    Rectangle labelRect = new Rectangle(StaticsUnderPoint[i].Left,
                        StaticsUnderPoint[i].Top, StaticsUnderPoint[i].Width,
                        StaticsUnderPoint[i].Height);

                    if (labelRect.Contains(MousePoint))
                    {
                        resControl = (Control)StaticsUnderPoint[i];
                    }
                }

                return resControl;
            }

            return null;
        }

        private void SetControlParamsAndBindToPanelByControlClassName(ListOfControls controlType)
        {
            TopX = 100;
            TopY = 100;
            BottomX = 152;
            BottomY = 120;
            StaticsUnderPoint = SplitContainer.Panel1.Controls;
            CreateStatic(controlType);
            SplitContainer.Panel1.Controls.Add(currentDesignerControl);
            MainPropertyGrid.SelectedObject = currentDesignerControl;
            (currentDesignerControl).Update();

            for (int i = 0; i < ListOfControlsInComboBox.Count; i++ )
            {
                ControlsListComboBox.Items.Add(((Control)ListOfControlsInComboBox[i]).Name);
            }
        }
    }

}
