namespace Cars
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
            this.lBus = new System.Windows.Forms.Label();
            this.lTruck = new System.Windows.Forms.Label();
            this.bUp = new System.Windows.Forms.Button();
            this.bDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lBus
            // 
            this.lBus.AccessibleRole = System.Windows.Forms.AccessibleRole.SplitButton;
            this.lBus.AutoSize = true;
            this.lBus.Location = new System.Drawing.Point(13, 13);
            this.lBus.Name = "lBus";
            this.lBus.Size = new System.Drawing.Size(137, 13);
            this.lBus.TabIndex = 0;
            this.lBus.Text = "Количество пассажиров: ";
            // 
            // lTruck
            // 
            this.lTruck.AutoSize = true;
            this.lTruck.Location = new System.Drawing.Point(13, 41);
            this.lTruck.Name = "lTruck";
            this.lTruck.Size = new System.Drawing.Size(36, 13);
            this.lTruck.TabIndex = 1;
            this.lTruck.Text = "Груз: ";
            // 
            // bUp
            // 
            this.bUp.Location = new System.Drawing.Point(136, 35);
            this.bUp.Name = "bUp";
            this.bUp.Size = new System.Drawing.Size(67, 25);
            this.bUp.TabIndex = 3;
            this.bUp.Text = "Погрузка";
            this.bUp.UseVisualStyleBackColor = true;
            this.bUp.Click += new System.EventHandler(this.bUp_Click);
            // 
            // bDown
            // 
            this.bDown.Location = new System.Drawing.Point(209, 35);
            this.bDown.Name = "bDown";
            this.bDown.Size = new System.Drawing.Size(71, 25);
            this.bDown.TabIndex = 3;
            this.bDown.Text = "Разгрузка";
            this.bDown.UseVisualStyleBackColor = true;
            this.bDown.Click += new System.EventHandler(this.bDown_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 74);
            this.Controls.Add(this.bDown);
            this.Controls.Add(this.bUp);
            this.Controls.Add(this.lTruck);
            this.Controls.Add(this.lBus);
            this.Name = "Form1";
            this.Text = "Гараж";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lBus;
        private System.Windows.Forms.Label lTruck;
        private System.Windows.Forms.Button bUp;
        private System.Windows.Forms.Button bDown;
    }
}

