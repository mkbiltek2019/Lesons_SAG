namespace StopWatch
{
    partial class StopWatch
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
            this.components = new System.ComponentModel.Container();
            this.labelMinutes = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxDateTimeNow = new System.Windows.Forms.TextBox();
            this.labelSeconds = new System.Windows.Forms.Label();
            this.labelColon = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.timerStopWatch = new System.Windows.Forms.Timer(this.components);
            this.timerDateTimeNow = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelMinutes
            // 
            this.labelMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMinutes.ForeColor = System.Drawing.Color.Peru;
            this.labelMinutes.Location = new System.Drawing.Point(31, 30);
            this.labelMinutes.Name = "labelMinutes";
            this.labelMinutes.Size = new System.Drawing.Size(60, 40);
            this.labelMinutes.TabIndex = 0;
            this.labelMinutes.Text = "00";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(38, 81);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Пуск";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxDateTimeNow
            // 
            this.textBoxDateTimeNow.ForeColor = System.Drawing.Color.Red;
            this.textBoxDateTimeNow.Location = new System.Drawing.Point(78, 166);
            this.textBoxDateTimeNow.Name = "textBoxDateTimeNow";
            this.textBoxDateTimeNow.Size = new System.Drawing.Size(119, 20);
            this.textBoxDateTimeNow.TabIndex = 2;
            // 
            // labelSeconds
            // 
            this.labelSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSeconds.ForeColor = System.Drawing.Color.Peru;
            this.labelSeconds.Location = new System.Drawing.Point(119, 30);
            this.labelSeconds.Name = "labelSeconds";
            this.labelSeconds.Size = new System.Drawing.Size(60, 40);
            this.labelSeconds.TabIndex = 7;
            this.labelSeconds.Text = "00";
            // 
            // labelColon
            // 
            this.labelColon.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelColon.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelColon.ForeColor = System.Drawing.Color.Peru;
            this.labelColon.Location = new System.Drawing.Point(93, 30);
            this.labelColon.Name = "labelColon";
            this.labelColon.Size = new System.Drawing.Size(20, 40);
            this.labelColon.TabIndex = 4;
            this.labelColon.Text = ":";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(145, 81);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "Сброс";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // timerStopWatch
            // 
            this.timerStopWatch.Tick += new System.EventHandler(this.timerStopWatch_Tick);
            // 
            // timerDateTimeNow
            // 
            this.timerDateTimeNow.Tick += new System.EventHandler(this.timerDateTimeNow_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Текущее время";
            // 
            // StopWatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(251, 214);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.labelColon);
            this.Controls.Add(this.labelSeconds);
            this.Controls.Add(this.textBoxDateTimeNow);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelMinutes);
            this.Name = "StopWatch";
            this.Text = "StopWatch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMinutes;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxDateTimeNow;
       
        private System.Windows.Forms.Label labelColon;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Timer timerStopWatch;
        private System.Windows.Forms.Timer timerDateTimeNow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSeconds;
    }
}

