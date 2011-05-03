namespace jokesApplication
{
    partial class JokesShow
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
            this.btnOk = new System.Windows.Forms.Button();
            this.gbTitle = new System.Windows.Forms.GroupBox();
            this.lbJokes = new System.Windows.Forms.Label();
            this.rbnBoring = new System.Windows.Forms.RadioButton();
            this.rbnFuny = new System.Windows.Forms.RadioButton();
            this.gbTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(82, 202);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(230, 29);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // gbTitle
            // 
            this.gbTitle.Controls.Add(this.lbJokes);
            this.gbTitle.Controls.Add(this.rbnBoring);
            this.gbTitle.Controls.Add(this.rbnFuny);
            this.gbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTitle.Location = new System.Drawing.Point(10, 10);
            this.gbTitle.Name = "gbTitle";
            this.gbTitle.Size = new System.Drawing.Size(375, 186);
            this.gbTitle.TabIndex = 1;
            this.gbTitle.TabStop = false;
            this.gbTitle.Text = "Жарт";
            // 
            // lbJokes
            // 
            this.lbJokes.AutoSize = true;
            this.lbJokes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbJokes.Location = new System.Drawing.Point(3, 16);
            this.lbJokes.Name = "lbJokes";
            this.lbJokes.Size = new System.Drawing.Size(35, 13);
            this.lbJokes.TabIndex = 2;
            this.lbJokes.Text = "label1";
            // 
            // rbnBoring
            // 
            this.rbnBoring.AutoSize = true;
            this.rbnBoring.Location = new System.Drawing.Point(220, 163);
            this.rbnBoring.Name = "rbnBoring";
            this.rbnBoring.Size = new System.Drawing.Size(62, 17);
            this.rbnBoring.TabIndex = 1;
            this.rbnBoring.TabStop = true;
            this.rbnBoring.Text = "Нудний";
            this.rbnBoring.UseVisualStyleBackColor = true;
            // 
            // rbnFuny
            // 
            this.rbnFuny.AutoSize = true;
            this.rbnFuny.Location = new System.Drawing.Point(86, 163);
            this.rbnFuny.Name = "rbnFuny";
            this.rbnFuny.Size = new System.Drawing.Size(68, 17);
            this.rbnFuny.TabIndex = 0;
            this.rbnFuny.TabStop = true;
            this.rbnFuny.Text = "Смішний";
            this.rbnFuny.UseVisualStyleBackColor = true;
            // 
            // JokesShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 244);
            this.Controls.Add(this.gbTitle);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "JokesShow";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "JokesShow";
            this.Load += new System.EventHandler(this.JokesShow_Load);
            this.gbTitle.ResumeLayout(false);
            this.gbTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox gbTitle;
        private System.Windows.Forms.RadioButton rbnBoring;
        private System.Windows.Forms.RadioButton rbnFuny;
        private System.Windows.Forms.Label lbJokes;
    }
}