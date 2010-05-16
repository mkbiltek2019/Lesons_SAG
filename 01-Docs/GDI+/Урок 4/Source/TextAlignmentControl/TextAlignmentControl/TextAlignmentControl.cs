using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextAlignmentControl
{
    public partial class TextAlignmentControl : Control
    {
        public TextAlignmentControl()
        {
            InitializeComponent();
        }

        // ContentAlignment is an enumeration defined in the System.Drawing
        // namespace that specifies the alignment of content on a drawing 
        // surface.
        private ContentAlignment alignmentValue = ContentAlignment.MiddleLeft;

        [
        Category("Alignment"),
        Description("Specifies the alignment of text.")
        ]
        public ContentAlignment TextAlignment 
        {

            get 
            {
                return alignmentValue;
            }
            set 
            {
                alignmentValue = value;

                // The Invalidate method invokes the OnPaint method
                Invalidate(); 
            }
        }

        protected override void OnPaint(PaintEventArgs e) 
        {   
            base.OnPaint(e);
            StringFormat style = new StringFormat();
            style.Alignment = StringAlignment.Near;
            switch (alignmentValue) 
            {
                case ContentAlignment.MiddleLeft:
                    style.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    style.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.MiddleCenter:
                    style.Alignment = StringAlignment.Center;
                    break;
            }

            // Call the DrawString method of the System.Drawing class to write   
            // text. Text and ClientRectangle are properties inherited from
            // Control.
            e.Graphics.DrawString(
                Text, 
                Font, 
                new SolidBrush(ForeColor), 
                ClientRectangle, style);

        } 
    }
}
