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

        [Flags]
        private enum MultiColorComponents : byte
        {
            None = 0,  // 0000 //all unset
            Red = 1,   // 0001
            Green = 2, // 0010
            Blue = 4   // 0100
        };

        private MultiColorComponents currnetMultiColorComponentsState =
                                    MultiColorComponents.None;

        #region Constructors

        public ColorfulForm()
        {
            InitializeComponent();
        }

        #endregion


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
        
        private Color GetColorWithComponentExclusionComplex(MultiColorComponents colorComponentToExlude)
        {
            int red = (int)redNumericUpDown.Value;
            int green = (int)greenNumericUpDown.Value;
            int blue = (int)blueNumericUpDown.Value;

            SetUnsetBitsInMultiColorComponentState(colorComponentToExlude);

            if (ContainsClientState(currnetMultiColorComponentsState, MultiColorComponents.Red))
            {
                red = 0;
            }

            if (ContainsClientState(currnetMultiColorComponentsState, MultiColorComponents.Green))
            {
                green = 0;
            }

            if (ContainsClientState(currnetMultiColorComponentsState, MultiColorComponents.Blue))
            {
                blue = 0;
            }

            return Color.FromArgb(red, green, blue);
        }

        private static bool ContainsClientState(MultiColorComponents combined, MultiColorComponents checkagainst)
        {
            return ((combined & checkagainst) == checkagainst);
        }

        private void SetUnsetBitsInMultiColorComponentState(MultiColorComponents setUnsetColor)
        {
            if (ContainsClientState(currnetMultiColorComponentsState, setUnsetColor))
            {
                currnetMultiColorComponentsState &= ~setUnsetColor;
            }
            else
            {
                currnetMultiColorComponentsState |= setUnsetColor;
            }
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


        #region RadioButton handlers

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


        #region CheckBox handlers

        private void redCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            redTrackBar.Enabled = !((CheckBox)sender).Checked;
            redNumericUpDown.Enabled = !((CheckBox)sender).Checked;

            ChangePreviewPanelBackColor(
           GetColorWithComponentExclusionComplex(MultiColorComponents.Red));
        }

        private void greenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            greenTrackBar.Enabled = !((CheckBox)sender).Checked;
            greenNumericUpDown.Enabled = !((CheckBox)sender).Checked;

            ChangePreviewPanelBackColor(
                  GetColorWithComponentExclusionComplex(MultiColorComponents.Green));

        }

        private void blueCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            blueTrackBar.Enabled = !((CheckBox)sender).Checked;
            blueNumericUpDown.Enabled = !((CheckBox)sender).Checked;

            ChangePreviewPanelBackColor(
            GetColorWithComponentExclusionComplex(MultiColorComponents.Blue));
        }

        #endregion

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
