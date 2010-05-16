namespace Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LeftAlignment = new TextAlignmentControl.TextAlignmentControl();
            this.MiddleAlignment = new TextAlignmentControl.TextAlignmentControl();
            this.RightAlignment = new TextAlignmentControl.TextAlignmentControl();
            this.SuspendLayout();
            // 
            // LeftAlignment
            // 
            this.LeftAlignment.BackColor = System.Drawing.Color.LightGray;
            this.LeftAlignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LeftAlignment.Location = new System.Drawing.Point(80, 168);
            this.LeftAlignment.Name = "LeftAlignment";
            this.LeftAlignment.Size = new System.Drawing.Size(129, 49);
            this.LeftAlignment.TabIndex = 2;
            this.LeftAlignment.Text = "Left Alignment";
            this.LeftAlignment.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MiddleAlignment
            // 
            this.MiddleAlignment.BackColor = System.Drawing.Color.LightGray;
            this.MiddleAlignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MiddleAlignment.Location = new System.Drawing.Point(80, 102);
            this.MiddleAlignment.Name = "MiddleAlignment";
            this.MiddleAlignment.Size = new System.Drawing.Size(129, 51);
            this.MiddleAlignment.TabIndex = 1;
            this.MiddleAlignment.Text = "Middle Alignment";
            this.MiddleAlignment.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RightAlignment
            // 
            this.RightAlignment.BackColor = System.Drawing.Color.LightGray;
            this.RightAlignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RightAlignment.Location = new System.Drawing.Point(80, 38);
            this.RightAlignment.Name = "RightAlignment";
            this.RightAlignment.Size = new System.Drawing.Size(129, 48);
            this.RightAlignment.TabIndex = 0;
            this.RightAlignment.Text = "Right Alignment";
            this.RightAlignment.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.LeftAlignment);
            this.Controls.Add(this.MiddleAlignment);
            this.Controls.Add(this.RightAlignment);
            this.Name = "Form1";
            this.Text = "Custom Controls";
            this.ResumeLayout(false);

        }

        #endregion

        private TextAlignmentControl.TextAlignmentControl RightAlignment;
        private TextAlignmentControl.TextAlignmentControl MiddleAlignment;
        private TextAlignmentControl.TextAlignmentControl LeftAlignment;
    }
}

