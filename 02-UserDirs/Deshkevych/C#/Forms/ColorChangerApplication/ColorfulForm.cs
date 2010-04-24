using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColorChangerApplication
{
    public partial class ColorfulForm : Form
    {
        protected enum ColorComponents
        {
            Red,
            Green,
            Blue,
            None
        }


        #region Color Change Logics

        private void ChangePreviewPanelBackColor(Color color)
        {
            previewColorPanel.BackColor = color;
        }

        private Color GetColorWithComponentExclusion(ColorComponents colorComponentToExlude)
        {
            int red = (int)redNumericUpDown.Value;
            int green = (int)greenNumericUpDown.Value;
            int blue = (int)blueNumericUpDown.Value;

            switch (colorComponentToExlude)
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


        #region Constructors

        public ColorfulForm()
        {
            InitializeComponent();
        } 

        #endregion


        #region Behaviours

        private void ColorComponentControlValue_ValueChanged(object sender, EventArgs e)
        {
            doNotExcludeColorComponentsRadioButton.Checked = true;
            SynchronizeColorComponentControlsValues(sender as Control);

            ChangePreviewPanelBackColor(
                GetColorWithComponentExclusion(ColorComponents.None));
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

        private void redExculeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangePreviewPanelBackColor(
                GetColorWithComponentExclusion(ColorComponents.Red));
        }

        private void greenExludeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangePreviewPanelBackColor(
                GetColorWithComponentExclusion(ColorComponents.Green));
        }

        private void blueExcludeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangePreviewPanelBackColor(
                GetColorWithComponentExclusion(ColorComponents.Blue));
        }

        private void doNotExcludeColorComponentsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangePreviewPanelBackColor(
                GetColorWithComponentExclusion(ColorComponents.None));
        } 

        #endregion


        #region mainMenuStrip

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        } 

        #endregion
    }
}
