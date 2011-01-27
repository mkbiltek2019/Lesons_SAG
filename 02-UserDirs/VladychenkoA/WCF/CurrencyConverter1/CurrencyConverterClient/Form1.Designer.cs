namespace CurrencyConverter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.date = new System.Windows.Forms.Label();
            this.dateBox = new System.Windows.Forms.TextBox();
            this.currencyComboBox = new System.Windows.Forms.ComboBox();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.labelNumber = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.buttonChange = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.textBoxResault = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(4, 4);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Location = new System.Drawing.Point(180, 22);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(33, 13);
            this.date.TabIndex = 1;
            this.date.Text = "Дата";
            // 
            // dateBox
            // 
            this.dateBox.Location = new System.Drawing.Point(257, 22);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(129, 20);
            this.dateBox.TabIndex = 2;
            this.dateBox.Text = "Выберите дату";
            // 
            // currencyComboBox
            // 
            this.currencyComboBox.FormattingEnabled = true;
            this.currencyComboBox.Location = new System.Drawing.Point(257, 62);
            this.currencyComboBox.Name = "currencyComboBox";
            this.currencyComboBox.Size = new System.Drawing.Size(129, 21);
            this.currencyComboBox.TabIndex = 3;
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.Location = new System.Drawing.Point(180, 65);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(45, 13);
            this.labelCurrency.TabIndex = 4;
            this.labelCurrency.Text = "Валюта";
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(180, 104);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(66, 13);
            this.labelNumber.TabIndex = 5;
            this.labelNumber.Text = "Количество";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(257, 102);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(129, 20);
            this.numericUpDown1.TabIndex = 6;
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(284, 143);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(75, 23);
            this.buttonChange.TabIndex = 7;
            this.buttonChange.Text = "Обменять";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(180, 181);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(70, 13);
            this.labelResult.TabIndex = 8;
            this.labelResult.Text = "Вы получите";
            // 
            // textBoxResault
            // 
            this.textBoxResault.Location = new System.Drawing.Point(257, 181);
            this.textBoxResault.Name = "textBoxResault";
            this.textBoxResault.Size = new System.Drawing.Size(129, 20);
            this.textBoxResault.TabIndex = 9;
            this.textBoxResault.Text = "Результат операции";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 216);
            this.Controls.Add(this.textBoxResault);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.labelCurrency);
            this.Controls.Add(this.currencyComboBox);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.date);
            this.Controls.Add(this.monthCalendar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CurrencyConverterWithWCF";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.TextBox dateBox;
        private System.Windows.Forms.ComboBox currencyComboBox;
        private System.Windows.Forms.Label labelCurrency;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.TextBox textBoxResault;
    }
}

