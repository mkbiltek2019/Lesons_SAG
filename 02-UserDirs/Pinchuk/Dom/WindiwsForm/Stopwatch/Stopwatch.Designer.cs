namespace Stopwatch
{
    partial class Stopwatch
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btControlStopwatch = new System.Windows.Forms.Button();
            this.btStopwatchOptions = new System.Windows.Forms.Button();
            this.tabCircle = new System.Windows.Forms.TabControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbStopwatchResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btControlStopwatch
            // 
            this.btControlStopwatch.Location = new System.Drawing.Point(22, 226);
            this.btControlStopwatch.Name = "btControlStopwatch";
            this.btControlStopwatch.Size = new System.Drawing.Size(97, 23);
            this.btControlStopwatch.TabIndex = 0;
            this.btControlStopwatch.Text = "Старт";
            this.btControlStopwatch.UseVisualStyleBackColor = true;
            this.btControlStopwatch.Click += new System.EventHandler(this.TmStartClick);
            // 
            // btStopwatchOptions
            // 
            this.btStopwatchOptions.Location = new System.Drawing.Point(195, 226);
            this.btStopwatchOptions.Name = "btStopwatchOptions";
            this.btStopwatchOptions.Size = new System.Drawing.Size(97, 23);
            this.btStopwatchOptions.TabIndex = 1;
            this.btStopwatchOptions.Text = "Новий круг";
            this.btStopwatchOptions.UseVisualStyleBackColor = true;
            this.btStopwatchOptions.Visible = false;
            this.btStopwatchOptions.Click += new System.EventHandler(this.BtStopwatchOptionsClick);
            // 
            // tabCircle
            // 
            this.tabCircle.Location = new System.Drawing.Point(22, 109);
            this.tabCircle.Name = "tabCircle";
            this.tabCircle.SelectedIndex = 0;
            this.tabCircle.Size = new System.Drawing.Size(270, 100);
            this.tabCircle.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Stopwatch.Properties.Resources.ImgStopwatch;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 103);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lbStopwatchResult
            // 
            this.lbStopwatchResult.AutoSize = true;
            this.lbStopwatchResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStopwatchResult.Location = new System.Drawing.Point(97, 28);
            this.lbStopwatchResult.Name = "lbStopwatchResult";
            this.lbStopwatchResult.Size = new System.Drawing.Size(221, 44);
            this.lbStopwatchResult.TabIndex = 4;
            this.lbStopwatchResult.Text = "00:00:00:00";
            // 
            // Stopwatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 261);
            this.Controls.Add(this.lbStopwatchResult);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabCircle);
            this.Controls.Add(this.btStopwatchOptions);
            this.Controls.Add(this.btControlStopwatch);
            this.Name = "Stopwatch";
            this.Text = "Stopwatch";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btControlStopwatch;
        private System.Windows.Forms.Button btStopwatchOptions;
        private System.Windows.Forms.TabControl tabCircle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbStopwatchResult;
    }
}

