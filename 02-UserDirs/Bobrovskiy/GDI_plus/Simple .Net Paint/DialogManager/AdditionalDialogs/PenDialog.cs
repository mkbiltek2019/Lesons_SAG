using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DialogManger.AdditionalDialogs
{
    public partial class PenDialog : Form
    {
        public Color PenColor
        {
            get; 
            set;
        }

        public int PenStrength
        {
            get; 
            set;
        }

        public int PenLength
        {
            get;
            set;
        }

        public LineCap PenStartLineStyle
        {
            get; 
            set;
        }

        public LineCap PenEndLineStyle
        {
            get;
            set;
        }

        public bool SolidPen
        {
            get; 
            set;
        }

        public PenDialog(int strength, int length, 
                         LineCap startLineCap, LineCap endLineCap, Color penColor, bool solid)
        {
            InitializeComponent();
            penStrengthNumericUpDown.Value = strength;
            penWidthNumericUpDown.Value = length;

           // this.penStartDomainUpDown.Text = startLineCap.ToString();
            //this.penEndDomainUpDown.Text = endLineCap.ToString();
            if(solid)
            {
                this.solidPenCheckBox.Checked = true;
            }   else
            {
                this.solidPenCheckBox.Checked = false;
            }

            PenColor = penColor;

            this.colorButton.BackColor = penColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PenStrength = (int)penStrengthNumericUpDown.Value;
            PenLength = (int) penWidthNumericUpDown.Value;
            if ((this.penStartDomainUpDown.SelectedItem != null) && 
                (this.penStartDomainUpDown.SelectedItem != null))
            {
               PenStartLineStyle = (LineCap) (this.penStartDomainUpDown.SelectedItem);
               PenEndLineStyle = (LineCap)(this.penEndDomainUpDown.SelectedItem);
            } 

            if(this.solidPenCheckBox.Checked)
            {
                SolidPen = true;
            }else
            {
                SolidPen = false;
            }

            Close();
        }

        private void CreateLineCapList()
        {
          this.penStartDomainUpDown.Items.Add(LineCap.AnchorMask);
          this.penStartDomainUpDown.Items.Add(LineCap.ArrowAnchor);
          this.penStartDomainUpDown.Items.Add(LineCap.Custom);
          this.penStartDomainUpDown.Items.Add(LineCap.DiamondAnchor);
          this.penStartDomainUpDown.Items.Add(LineCap.Flat);
          this.penStartDomainUpDown.Items.Add(LineCap.NoAnchor);
          this.penStartDomainUpDown.Items.Add(LineCap.Round);
          this.penStartDomainUpDown.Items.Add(LineCap.RoundAnchor);
          this.penStartDomainUpDown.Items.Add(LineCap.Square);
          this.penStartDomainUpDown.Items.Add(LineCap.SquareAnchor);
          this.penStartDomainUpDown.Items.Add(LineCap.Triangle);

          this.penEndDomainUpDown.Items.Add(LineCap.AnchorMask);
          this.penEndDomainUpDown.Items.Add(LineCap.ArrowAnchor);
          this.penEndDomainUpDown.Items.Add(LineCap.Custom);
          this.penEndDomainUpDown.Items.Add(LineCap.DiamondAnchor);
          this.penEndDomainUpDown.Items.Add(LineCap.Flat);
          this.penEndDomainUpDown.Items.Add(LineCap.NoAnchor);
          this.penEndDomainUpDown.Items.Add(LineCap.Round);
          this.penEndDomainUpDown.Items.Add(LineCap.RoundAnchor);
          this.penEndDomainUpDown.Items.Add(LineCap.Square);
          this.penEndDomainUpDown.Items.Add(LineCap.SquareAnchor);
          this.penEndDomainUpDown.Items.Add(LineCap.Triangle);
        }

        private void PenDialog_Load(object sender, EventArgs e)
        {
            CreateLineCapList();
        }
    }
}
