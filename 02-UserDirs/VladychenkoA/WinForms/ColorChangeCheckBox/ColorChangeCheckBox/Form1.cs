using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColorChangeCheckBox
{
    public partial class Form1 : Form
    {
        protected enum ColorComponents
        {
            Red,
            Green,
            Blue,
            None
        }
        #region Color Change Logics

        private void ChangePreviewPaneBackColr(Color color)
        {
            groupBoxPreviewColor.BackColor = color;
        }

        private Color GetColorWithComponentExclusion(ColorComponents colorComponentToExclude)
        {
            int red = (int)redNumericUpDown.Value;
            int green = (int)greenNumericUpDown.Value;
            int blue = (int)blueNumericUpDown.Value;

            switch (colorComponentToExclude)
            {
                case ColorComponents.Red:
                    red = 0;
                    break;
                case ColorComponents.Green:
                    green = 0;
                    break;
                case ColorComponents.Blue:
                    blue = 0;
                    break;
                case ColorComponents.None:
                    break;
            }
            return Color.FromArgb(red, green, blue);
        }

        #endregion

        #region Cnstructors

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region Behaviours

        private void ColorComponentControlValue_ValueChanged(object sender, EventArgs e)
        {
            doNotExcludeColorComponentsCheckBox.Checked = true;
            SynchronizeColorComponentControlsValues(sender as Control);

            ChangePreviewPaneBackColr(
                GetColorWithComponentExclusion(ColorComponents.None));

            redToolTip.SetToolTip(redTrackBar, redTrackBar.Value.ToString());
            greenToolTip.SetToolTip(greenTrackBar, greenTrackBar.Value.ToString());
            blueToolTip.SetToolTip(blueTrackBar, blueTrackBar.Value.ToString());

            redToolStripStatusLabel.Text = "Красный " + redTrackBar.Value;
            greenToolStripStatusLabel.Text = "Зелёный " + greenTrackBar.Value;
            blueToolStripStatusLabel.Text = "Синий " + blueTrackBar.Value;

            notifyIcon1.ShowBalloonTip(5000, "ColorChangeCheckBox", "Работает", ToolTipIcon.Info);
            //toolStripProgressBar1.Text = ((Convert.ToInt32(redTrackBar) +
            //                               Convert.ToInt32(greenTrackBar) + 
            //                               Convert.ToInt32(blueTrackBar))/100).ToString ();
        }

        private void SynchronizeColorComponentControlsValues(Control sender)
        {
            if (sender is TrackBar)
            {
                redNumericUpDown.Value = redTrackBar.Value;
                greenNumericUpDown.Value = greenTrackBar.Value;
                blueNumericUpDown.Value = blueTrackBar.Value;
            }
            else
            {
                redTrackBar.Value = (int)redNumericUpDown.Value;
                greenTrackBar.Value = (int)greenNumericUpDown.Value;
                blueTrackBar.Value = (int)blueNumericUpDown.Value;
            }
        }

        private void redCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChangePreviewPaneBackColr(
                GetColorWithComponentExclusion(ColorComponents.Red));
        }

        private void greenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChangePreviewPaneBackColr(
                GetColorWithComponentExclusion(ColorComponents.Green));
        }

        private void blueCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChangePreviewPaneBackColr(
                GetColorWithComponentExclusion(ColorComponents.Blue));
        }

        private void doNotExcludeColorComponentsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChangePreviewPaneBackColr(
                GetColorWithComponentExclusion(ColorComponents.None));
        }


        #endregion

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void abutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (Equals(WindowState, FormWindowState.Minimized))
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(5000, "ColorChangeCheckBox", "Свернуто в трей", ToolTipIcon.Info);
            }

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            //notifyIcon1.ShowBalloonTip(5000, "ColorChangeCheckBox", "Свернуто в трей", ToolTipIcon.Info);
        }

        private void enabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void disabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(5000, "ColorChangeCheckBox", "Свернуто в трей", ToolTipIcon.Info);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (Equals(WindowState, FormWindowState.Minimized))
            {
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }
    }
}
