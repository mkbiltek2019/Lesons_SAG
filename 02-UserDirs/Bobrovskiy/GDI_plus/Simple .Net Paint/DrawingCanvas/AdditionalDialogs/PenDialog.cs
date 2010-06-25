using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DrawingCanvas.AdditionalDialogs
{
    public partial class PenDialog : Form
    {
        public int PenSize
        {
            get; 
            set;
        }

        public LineCap PenEndLineStyle
        {
            get; 
            set;
        }

        public PenDialog(int p, LineCap lineCap)
        {
            InitializeComponent();
            
            penSizeNumericUpDown.Value = p;

            switch (lineCap)
            {
                case LineCap.AnchorMask:
                    {
                        penStyleNumericUpDown.Value = 1;
                    }
                    break;
                case LineCap.ArrowAnchor:
                    {
                        penStyleNumericUpDown.Value = 2;
                    }
                    break;
                case LineCap.Custom:
                    {
                        penStyleNumericUpDown.Value = 3;
                    }
                    break;
                case LineCap.DiamondAnchor:
                    {
                        penStyleNumericUpDown.Value = 4;
                    }
                    break;
                case LineCap.Flat:
                    {
                        penStyleNumericUpDown.Value = 5;
                    }
                    break;
                case LineCap.NoAnchor:
                    {
                        penStyleNumericUpDown.Value = 6;
                    }
                    break;
                case LineCap.Round:
                    {
                        penStyleNumericUpDown.Value = 7;
                    }
                    break;
                case LineCap.Square:
                    {
                        penStyleNumericUpDown.Value = 8;
                    }
                    break;
                case LineCap.SquareAnchor:
                    {
                        penStyleNumericUpDown.Value = 9;
                    }
                    break;
                case LineCap.Triangle:
                    {
                        penStyleNumericUpDown.Value = 10;
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PenSize = (int)penSizeNumericUpDown.Value;
            
            switch((int)penStyleNumericUpDown.Value)
            {
                case 1:
                    {
                        PenEndLineStyle = LineCap.AnchorMask;
                    }
                    break;
                case 2:
                    {
                        PenEndLineStyle = LineCap.ArrowAnchor;
                    }
                    break;
                case 3:
                    {
                        PenEndLineStyle = LineCap.Custom;
                    }
                    break;
                case 4:
                    {
                        PenEndLineStyle = LineCap.DiamondAnchor;
                    }
                    break;
                case 5:
                    {
                        PenEndLineStyle = LineCap.Flat;
                    }
                    break;
                case 6:
                    {
                        PenEndLineStyle = LineCap.NoAnchor;
                    }
                    break;
                case 7:
                    {
                        PenEndLineStyle = LineCap.Round;
                    }
                    break;
                case 8:
                    {
                        PenEndLineStyle = LineCap.Square;
                    }
                    break;
                case 9:
                    {
                        PenEndLineStyle = LineCap.SquareAnchor;
                    }
                    break;
                case 10:
                    {
                        PenEndLineStyle = LineCap.Triangle;
                    }
                    break;
            }

            Close();
        }

        
    }
}
