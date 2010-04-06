namespace MDIExample
{
    partial class TextEditor
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
            this.tbxText = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEncoding = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenAsWindow1251 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenAsDOS866 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenAsКОИ8Р = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenAsКОИ8U = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenAsUnicode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenAsLittleEndian = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenAsBigEndian = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenAsUTF8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSaveAsWindows1251 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAsDOS866 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAsКОИ8Р = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAsКОИ8U = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAsUnicode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAsLittleEndian = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAsBigEndian = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsUTF8 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxText
            // 
            this.tbxText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxText.Location = new System.Drawing.Point(0, 24);
            this.tbxText.Multiline = true;
            this.tbxText.Name = "tbxText";
            this.tbxText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxText.Size = new System.Drawing.Size(784, 440);
            this.tbxText.TabIndex = 0;
            this.tbxText.TextChanged += new System.EventHandler(this.tbxText_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEdit,
            this.tsmiEncoding});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUndo,
            this.toolStripSeparator1,
            this.tsmiCut,
            this.tsmiCopy,
            this.tsmiPaste,
            this.tsmiDelete,
            this.toolStripSeparator2,
            this.tsmiSelectAll,
            this.tsmiTime});
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(39, 20);
            this.tsmiEdit.Text = "&Edit";
            // 
            // tsmiUndo
            // 
            this.tsmiUndo.Name = "tsmiUndo";
            this.tsmiUndo.Size = new System.Drawing.Size(130, 22);
            this.tsmiUndo.Text = "Undo";
            this.tsmiUndo.Click += new System.EventHandler(this.tsmiUndo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // tsmiCut
            // 
            this.tsmiCut.Name = "tsmiCut";
            this.tsmiCut.Size = new System.Drawing.Size(130, 22);
            this.tsmiCut.Text = "&Cut";
            this.tsmiCut.Click += new System.EventHandler(this.tsmiCut_Click);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(130, 22);
            this.tsmiCopy.Text = "&Copy";
            this.tsmiCopy.Click += new System.EventHandler(this.tsmiCopy_Click);
            // 
            // tsmiPaste
            // 
            this.tsmiPaste.Name = "tsmiPaste";
            this.tsmiPaste.Size = new System.Drawing.Size(130, 22);
            this.tsmiPaste.Text = "&Paste";
            this.tsmiPaste.Click += new System.EventHandler(this.tsmiPaste_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(130, 22);
            this.tsmiDelete.Text = "&Delete";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(127, 6);
            // 
            // tsmiSelectAll
            // 
            this.tsmiSelectAll.Name = "tsmiSelectAll";
            this.tsmiSelectAll.Size = new System.Drawing.Size(130, 22);
            this.tsmiSelectAll.Text = "&Select All";
            this.tsmiSelectAll.Click += new System.EventHandler(this.tsmiSelectAll_Click);
            // 
            // tsmiTime
            // 
            this.tsmiTime.Name = "tsmiTime";
            this.tsmiTime.Size = new System.Drawing.Size(130, 22);
            this.tsmiTime.Text = "&Time/Date";
            this.tsmiTime.Click += new System.EventHandler(this.tsmiTime_Click);
            // 
            // tsmiEncoding
            // 
            this.tsmiEncoding.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenAsWindow1251,
            this.tsmiOpenAsDOS866,
            this.tsmiOpenAsКОИ8Р,
            this.tsmiOpenAsКОИ8U,
            this.tsmiOpenAsUnicode,
            this.toolStripSeparator3,
            this.tsmiSaveAsWindows1251,
            this.tsmiSaveAsDOS866,
            this.tsmiSaveAsКОИ8Р,
            this.tsmiSaveAsКОИ8U,
            this.tsmiSaveAsUnicode});
            this.tsmiEncoding.Name = "tsmiEncoding";
            this.tsmiEncoding.Size = new System.Drawing.Size(69, 20);
            this.tsmiEncoding.Text = "&Encoding";
            // 
            // tsmiOpenAsWindow1251
            // 
            this.tsmiOpenAsWindow1251.Name = "tsmiOpenAsWindow1251";
            this.tsmiOpenAsWindow1251.Size = new System.Drawing.Size(198, 22);
            this.tsmiOpenAsWindow1251.Text = "&Open as Windows-1251";
            this.tsmiOpenAsWindow1251.Click += new System.EventHandler(this.tsmiOpenAsWindow1251_Click);
            // 
            // tsmiOpenAsDOS866
            // 
            this.tsmiOpenAsDOS866.Name = "tsmiOpenAsDOS866";
            this.tsmiOpenAsDOS866.Size = new System.Drawing.Size(198, 22);
            this.tsmiOpenAsDOS866.Text = "&Open as DOS-866";
            this.tsmiOpenAsDOS866.Click += new System.EventHandler(this.tsmiOpenAsDOS866_Click);
            // 
            // tsmiOpenAsКОИ8Р
            // 
            this.tsmiOpenAsКОИ8Р.Name = "tsmiOpenAsКОИ8Р";
            this.tsmiOpenAsКОИ8Р.Size = new System.Drawing.Size(198, 22);
            this.tsmiOpenAsКОИ8Р.Text = "&Open as КОИ8-Р";
            this.tsmiOpenAsКОИ8Р.Click += new System.EventHandler(this.tsmiOpenAsКОИ8Р_Click);
            // 
            // tsmiOpenAsКОИ8U
            // 
            this.tsmiOpenAsКОИ8U.Name = "tsmiOpenAsКОИ8U";
            this.tsmiOpenAsКОИ8U.Size = new System.Drawing.Size(198, 22);
            this.tsmiOpenAsКОИ8U.Text = "&Open as КОИ8-U";
            this.tsmiOpenAsКОИ8U.Click += new System.EventHandler(this.tsmiOpenAsКОИ8U_Click);
            // 
            // tsmiOpenAsUnicode
            // 
            this.tsmiOpenAsUnicode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenAsLittleEndian,
            this.tsmiOpenAsBigEndian,
            this.tsmiOpenAsUTF8});
            this.tsmiOpenAsUnicode.Name = "tsmiOpenAsUnicode";
            this.tsmiOpenAsUnicode.Size = new System.Drawing.Size(198, 22);
            this.tsmiOpenAsUnicode.Text = "&Open as Unicode";
            // 
            // tsmiOpenAsLittleEndian
            // 
            this.tsmiOpenAsLittleEndian.Name = "tsmiOpenAsLittleEndian";
            this.tsmiOpenAsLittleEndian.Size = new System.Drawing.Size(185, 22);
            this.tsmiOpenAsLittleEndian.Text = "&Open as Little endian";
            this.tsmiOpenAsLittleEndian.Click += new System.EventHandler(this.tsmiOpenAsLittleEndian_Click);
            // 
            // tsmiOpenAsBigEndian
            // 
            this.tsmiOpenAsBigEndian.Name = "tsmiOpenAsBigEndian";
            this.tsmiOpenAsBigEndian.Size = new System.Drawing.Size(185, 22);
            this.tsmiOpenAsBigEndian.Text = "&Open as Big endian";
            this.tsmiOpenAsBigEndian.Click += new System.EventHandler(this.tsmiOpenAsBigEndian_Click);
            // 
            // tsmiOpenAsUTF8
            // 
            this.tsmiOpenAsUTF8.Name = "tsmiOpenAsUTF8";
            this.tsmiOpenAsUTF8.Size = new System.Drawing.Size(185, 22);
            this.tsmiOpenAsUTF8.Text = "&Open as UTF8";
            this.tsmiOpenAsUTF8.Click += new System.EventHandler(this.tsmiOpenAsUTF8_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(195, 6);
            // 
            // tsmiSaveAsWindows1251
            // 
            this.tsmiSaveAsWindows1251.Name = "tsmiSaveAsWindows1251";
            this.tsmiSaveAsWindows1251.Size = new System.Drawing.Size(198, 22);
            this.tsmiSaveAsWindows1251.Text = "&Save as Windows-1251";
            this.tsmiSaveAsWindows1251.Click += new System.EventHandler(this.tsmiSaveAsWindows1251_Click);
            // 
            // tsmiSaveAsDOS866
            // 
            this.tsmiSaveAsDOS866.Name = "tsmiSaveAsDOS866";
            this.tsmiSaveAsDOS866.Size = new System.Drawing.Size(198, 22);
            this.tsmiSaveAsDOS866.Text = "&Save as DOS-866";
            this.tsmiSaveAsDOS866.Click += new System.EventHandler(this.tsmiSaveAsDOS866_Click);
            // 
            // tsmiSaveAsКОИ8Р
            // 
            this.tsmiSaveAsКОИ8Р.Name = "tsmiSaveAsКОИ8Р";
            this.tsmiSaveAsКОИ8Р.Size = new System.Drawing.Size(198, 22);
            this.tsmiSaveAsКОИ8Р.Text = "&Save as КОИ8-Р";
            this.tsmiSaveAsКОИ8Р.Click += new System.EventHandler(this.tsmiSaveAsКОИ8Р_Click);
            // 
            // tsmiSaveAsКОИ8U
            // 
            this.tsmiSaveAsКОИ8U.Name = "tsmiSaveAsКОИ8U";
            this.tsmiSaveAsКОИ8U.Size = new System.Drawing.Size(198, 22);
            this.tsmiSaveAsКОИ8U.Text = "&Save as КОИ8-U";
            this.tsmiSaveAsКОИ8U.Click += new System.EventHandler(this.tsmiSaveAsКОИ8U_Click);
            // 
            // tsmiSaveAsUnicode
            // 
            this.tsmiSaveAsUnicode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSaveAsLittleEndian,
            this.tsmiSaveAsBigEndian,
            this.SaveAsUTF8});
            this.tsmiSaveAsUnicode.Name = "tsmiSaveAsUnicode";
            this.tsmiSaveAsUnicode.Size = new System.Drawing.Size(198, 22);
            this.tsmiSaveAsUnicode.Text = "&Save as Unicode";
            // 
            // tsmiSaveAsLittleEndian
            // 
            this.tsmiSaveAsLittleEndian.Name = "tsmiSaveAsLittleEndian";
            this.tsmiSaveAsLittleEndian.Size = new System.Drawing.Size(180, 22);
            this.tsmiSaveAsLittleEndian.Text = "&Save as Little endian";
            this.tsmiSaveAsLittleEndian.Click += new System.EventHandler(this.tsmiSaveAsLittleEndian_Click);
            // 
            // tsmiSaveAsBigEndian
            // 
            this.tsmiSaveAsBigEndian.Name = "tsmiSaveAsBigEndian";
            this.tsmiSaveAsBigEndian.Size = new System.Drawing.Size(180, 22);
            this.tsmiSaveAsBigEndian.Text = "&Save as Big endian";
            this.tsmiSaveAsBigEndian.Click += new System.EventHandler(this.tsmiSaveAsBigEndian_Click);
            // 
            // SaveAsUTF8
            // 
            this.SaveAsUTF8.Name = "SaveAsUTF8";
            this.SaveAsUTF8.Size = new System.Drawing.Size(180, 22);
            this.SaveAsUTF8.Text = "&Save as UTF8";
            this.SaveAsUTF8.Click += new System.EventHandler(this.tsmiSaveAsUTF8_Click);
            // 
            // TextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 464);
            this.Controls.Add(this.tbxText);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TextEditor";
            this.Text = "TextEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ContentForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxText;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCut;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiTime;
        private System.Windows.Forms.ToolStripMenuItem tsmiEncoding;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenAsWindow1251;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenAsDOS866;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenAsКОИ8Р;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenAsКОИ8U;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenAsUnicode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAsWindows1251;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAsDOS866;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAsКОИ8Р;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAsКОИ8U;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAsUnicode;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenAsLittleEndian;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenAsBigEndian;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenAsUTF8;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAsLittleEndian;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAsBigEndian;
        private System.Windows.Forms.ToolStripMenuItem SaveAsUTF8;


    }
}