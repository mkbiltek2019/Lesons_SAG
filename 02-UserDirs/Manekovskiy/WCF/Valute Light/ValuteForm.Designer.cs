namespace Valute_Light
{
    partial class ValuteForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValuteForm));
            this.todayTomorrowCurrencyTable = new System.Windows.Forms.DataGridView();
            this.todayTomorrowIntIndexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.todayTomorrowStrIndexCloumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.todayTomorrowAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.todayTomorrowValuteNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.todayTomorrowCurrencyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radioTomorrow = new System.Windows.Forms.RadioButton();
            this.radioToday = new System.Windows.Forms.RadioButton();
            this.exprExchGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.exprExchValuteResult = new System.Windows.Forms.TextBox();
            this.exprExchValutePicker = new System.Windows.Forms.ComboBox();
            this.exprExchValuteAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.toolStripImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileImportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilePrintMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileCloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.importFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.exportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.todayTomorrowCurrencyTable)).BeginInit();
            this.exprExchGroupBox.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // todayTomorrowCurrencyTable
            // 
            this.todayTomorrowCurrencyTable.AllowUserToResizeColumns = false;
            this.todayTomorrowCurrencyTable.AllowUserToResizeRows = false;
            this.todayTomorrowCurrencyTable.ColumnHeadersHeight = 35;
            this.todayTomorrowCurrencyTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.todayTomorrowIntIndexColumn,
            this.todayTomorrowStrIndexCloumn,
            this.todayTomorrowAmountColumn,
            this.todayTomorrowValuteNameColumn,
            this.todayTomorrowCurrencyColumn});
            this.todayTomorrowCurrencyTable.Location = new System.Drawing.Point(216, 52);
            this.todayTomorrowCurrencyTable.Name = "todayTomorrowCurrencyTable";
            this.todayTomorrowCurrencyTable.RowHeadersVisible = false;
            this.todayTomorrowCurrencyTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.todayTomorrowCurrencyTable.Size = new System.Drawing.Size(400, 320);
            this.todayTomorrowCurrencyTable.TabIndex = 9;
            // 
            // todayTomorrowIntIndexColumn
            // 
            this.todayTomorrowIntIndexColumn.HeaderText = "Цифр. код";
            this.todayTomorrowIntIndexColumn.Name = "todayTomorrowIntIndexColumn";
            this.todayTomorrowIntIndexColumn.ReadOnly = true;
            this.todayTomorrowIntIndexColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.todayTomorrowIntIndexColumn.Width = 40;
            // 
            // todayTomorrowStrIndexCloumn
            // 
            this.todayTomorrowStrIndexCloumn.HeaderText = "Літерн. код";
            this.todayTomorrowStrIndexCloumn.Name = "todayTomorrowStrIndexCloumn";
            this.todayTomorrowStrIndexCloumn.ReadOnly = true;
            this.todayTomorrowStrIndexCloumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.todayTomorrowStrIndexCloumn.Width = 45;
            // 
            // todayTomorrowAmountColumn
            // 
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.todayTomorrowAmountColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.todayTomorrowAmountColumn.HeaderText = "К-сть одиниць";
            this.todayTomorrowAmountColumn.Name = "todayTomorrowAmountColumn";
            this.todayTomorrowAmountColumn.ReadOnly = true;
            this.todayTomorrowAmountColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.todayTomorrowAmountColumn.Width = 53;
            // 
            // todayTomorrowValuteNameColumn
            // 
            this.todayTomorrowValuteNameColumn.HeaderText = "Назва валюти";
            this.todayTomorrowValuteNameColumn.Name = "todayTomorrowValuteNameColumn";
            this.todayTomorrowValuteNameColumn.ReadOnly = true;
            this.todayTomorrowValuteNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.todayTomorrowValuteNameColumn.Width = 180;
            // 
            // todayTomorrowCurrencyColumn
            // 
            dataGridViewCellStyle2.Format = "C4";
            dataGridViewCellStyle2.NullValue = null;
            this.todayTomorrowCurrencyColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.todayTomorrowCurrencyColumn.HeaderText = "Курс";
            this.todayTomorrowCurrencyColumn.Name = "todayTomorrowCurrencyColumn";
            this.todayTomorrowCurrencyColumn.ReadOnly = true;
            this.todayTomorrowCurrencyColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.todayTomorrowCurrencyColumn.Width = 80;
            // 
            // radioTomorrow
            // 
            this.radioTomorrow.AutoSize = true;
            this.radioTomorrow.Location = new System.Drawing.Point(12, 73);
            this.radioTomorrow.Name = "radioTomorrow";
            this.radioTomorrow.Size = new System.Drawing.Size(112, 17);
            this.radioTomorrow.TabIndex = 8;
            this.radioTomorrow.Text = "Завтрашній курс ";
            this.radioTomorrow.UseVisualStyleBackColor = true;
            this.radioTomorrow.CheckedChanged += new System.EventHandler(this.RequestedDateChanged);
            // 
            // radioToday
            // 
            this.radioToday.AutoSize = true;
            this.radioToday.Checked = true;
            this.radioToday.Location = new System.Drawing.Point(12, 52);
            this.radioToday.Name = "radioToday";
            this.radioToday.Size = new System.Drawing.Size(120, 17);
            this.radioToday.TabIndex = 7;
            this.radioToday.TabStop = true;
            this.radioToday.Text = "Сьогоднішній курс ";
            this.radioToday.UseVisualStyleBackColor = true;
            this.radioToday.CheckedChanged += new System.EventHandler(this.RequestedDateChanged);
            // 
            // exprExchGroupBox
            // 
            this.exprExchGroupBox.Controls.Add(this.label1);
            this.exprExchGroupBox.Controls.Add(this.exprExchValuteResult);
            this.exprExchGroupBox.Controls.Add(this.exprExchValutePicker);
            this.exprExchGroupBox.Controls.Add(this.exprExchValuteAmount);
            this.exprExchGroupBox.Controls.Add(this.label4);
            this.exprExchGroupBox.Location = new System.Drawing.Point(10, 96);
            this.exprExchGroupBox.Name = "exprExchGroupBox";
            this.exprExchGroupBox.Size = new System.Drawing.Size(200, 99);
            this.exprExchGroupBox.TabIndex = 6;
            this.exprExchGroupBox.TabStop = false;
            this.exprExchGroupBox.Text = "Експрес розрахунок";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Результат:";
            // 
            // exprExchValuteResult
            // 
            this.exprExchValuteResult.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.exprExchValuteResult.Location = new System.Drawing.Point(65, 72);
            this.exprExchValuteResult.MaxLength = 20;
            this.exprExchValuteResult.Name = "exprExchValuteResult";
            this.exprExchValuteResult.ReadOnly = true;
            this.exprExchValuteResult.Size = new System.Drawing.Size(126, 20);
            this.exprExchValuteResult.TabIndex = 6;
            this.exprExchValuteResult.TextChanged += new System.EventHandler(this.AmountOrDateChanged);
            // 
            // exprExchValutePicker
            // 
            this.exprExchValutePicker.FormattingEnabled = true;
            this.exprExchValutePicker.Items.AddRange(new object[] {
            "австралійські долари",
            "азербайджанські манати",
            "англійські фунти стерлінгів",
            "білоруські рублі",
            "датські крони",
            "долари США",
            "естонські крони",
            "євро",
            "ісландські крони",
            "казахстанські тенге",
            "канадські долари",
            "латвійські лати",
            "литовські літи",
            "молдовські леї",
            "норвезькі крони",
            "польські злоти",
            "російські рублі",
            "сінгапурські долари",
            "словацькі крони",
            "СПЗ",
            "турецькі ліри",
            "туркменські манати",
            "угорські форинти",
            "узбецькі суми",
            "чеські крони",
            "шведські крони",
            "швейцарські франки",
            "юані женьміньбі(Китай)",
            "японські єни"});
            this.exprExchValutePicker.Location = new System.Drawing.Point(6, 19);
            this.exprExchValutePicker.Name = "exprExchValutePicker";
            this.exprExchValutePicker.Size = new System.Drawing.Size(185, 21);
            this.exprExchValutePicker.TabIndex = 5;
            this.exprExchValutePicker.Text = "Оберіть валюту";
            this.exprExchValutePicker.SelectedIndexChanged += new System.EventHandler(this.AmountOrDateChanged);
            // 
            // exprExchValuteAmount
            // 
            this.exprExchValuteAmount.Location = new System.Drawing.Point(65, 46);
            this.exprExchValuteAmount.MaxLength = 20;
            this.exprExchValuteAmount.Name = "exprExchValuteAmount";
            this.exprExchValuteAmount.Size = new System.Drawing.Size(126, 20);
            this.exprExchValuteAmount.TabIndex = 3;
            this.exprExchValuteAmount.TextChanged += new System.EventHandler(this.AmountOrDateChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Кількість:";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 375);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(630, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 15;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(171, 17);
            this.toolStripStatusLabel.Text = "Завантаження таблиці курсів ...";
            this.toolStripStatusLabel.Visible = false;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(23, 23);
            // 
            // toolbar
            // 
            this.toolbar.BackColor = System.Drawing.SystemColors.Control;
            this.toolbar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripImport,
            this.toolStripExport,
            this.toolStripPrint,
            this.toolStripSeparator1,
            this.toolStripRefresh});
            this.toolbar.Location = new System.Drawing.Point(0, 24);
            this.toolbar.Name = "toolbar";
            this.toolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolbar.Size = new System.Drawing.Size(630, 25);
            this.toolbar.TabIndex = 13;
            this.toolbar.Text = "toolStrip1";
            // 
            // toolStripImport
            // 
            this.toolStripImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripImport.Image = global::Valute_Light.Properties.Resources.folder_open_16;
            this.toolStripImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripImport.Name = "toolStripImport";
            this.toolStripImport.Size = new System.Drawing.Size(23, 22);
            this.toolStripImport.Text = "Імпорт в XML";
            this.toolStripImport.Click += new System.EventHandler(this.FileImportMenuItemClick);
            // 
            // toolStripExport
            // 
            this.toolStripExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripExport.Image = global::Valute_Light.Properties.Resources.save_16;
            this.toolStripExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExport.Name = "toolStripExport";
            this.toolStripExport.Size = new System.Drawing.Size(23, 22);
            this.toolStripExport.Text = "Експорт в XML";
            this.toolStripExport.Click += new System.EventHandler(this.FileExportMenuItemClick);
            // 
            // toolStripPrint
            // 
            this.toolStripPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPrint.Image = global::Valute_Light.Properties.Resources.print_16;
            this.toolStripPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPrint.Name = "toolStripPrint";
            this.toolStripPrint.Size = new System.Drawing.Size(23, 22);
            this.toolStripPrint.Text = "Друк";
            this.toolStripPrint.Click += new System.EventHandler(this.FilePrintMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripRefresh
            // 
            this.toolStripRefresh.Image = global::Valute_Light.Properties.Resources.refresh_document_16;
            this.toolStripRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRefresh.Name = "toolStripRefresh";
            this.toolStripRefresh.Size = new System.Drawing.Size(127, 22);
            this.toolStripRefresh.Text = "Завантажити курси";
            this.toolStripRefresh.Click += new System.EventHandler(this.RefreshClick);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.mainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.AboutMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mainMenu.Size = new System.Drawing.Size(630, 24);
            this.mainMenu.TabIndex = 14;
            this.mainMenu.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileImportMenuItem,
            this.FileExportMenuItem,
            this.FilePrintMenuItem,
            this.FileCloseMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.ShortcutKeyDisplayString = "";
            this.FileMenuItem.Size = new System.Drawing.Size(45, 20);
            this.FileMenuItem.Text = "Файл";
            // 
            // FileImportMenuItem
            // 
            this.FileImportMenuItem.Image = global::Valute_Light.Properties.Resources.folder_open_16;
            this.FileImportMenuItem.Name = "FileImportMenuItem";
            this.FileImportMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.FileImportMenuItem.Size = new System.Drawing.Size(195, 22);
            this.FileImportMenuItem.Text = "Імпорт з XML";
            this.FileImportMenuItem.Click += new System.EventHandler(this.FileImportMenuItemClick);
            // 
            // FileExportMenuItem
            // 
            this.FileExportMenuItem.Image = global::Valute_Light.Properties.Resources.save_16;
            this.FileExportMenuItem.Name = "FileExportMenuItem";
            this.FileExportMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.FileExportMenuItem.Size = new System.Drawing.Size(195, 22);
            this.FileExportMenuItem.Text = "Експорт в XML";
            this.FileExportMenuItem.Click += new System.EventHandler(this.FileExportMenuItemClick);
            // 
            // FilePrintMenuItem
            // 
            this.FilePrintMenuItem.Image = global::Valute_Light.Properties.Resources.print_16;
            this.FilePrintMenuItem.Name = "FilePrintMenuItem";
            this.FilePrintMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.FilePrintMenuItem.Size = new System.Drawing.Size(195, 22);
            this.FilePrintMenuItem.Text = "Друк ...";
            this.FilePrintMenuItem.Click += new System.EventHandler(this.FilePrintMenuItemClick);
            // 
            // FileCloseMenuItem
            // 
            this.FileCloseMenuItem.Name = "FileCloseMenuItem";
            this.FileCloseMenuItem.Size = new System.Drawing.Size(195, 22);
            this.FileCloseMenuItem.Text = "Вихід";
            this.FileCloseMenuItem.Click += new System.EventHandler(this.Exit);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(50, 20);
            this.AboutMenuItem.Text = "Про...";
            this.AboutMenuItem.Click += new System.EventHandler(this.ShowAboutBox);
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(463, 30);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(153, 13);
            this.linkLabel.TabIndex = 16;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "Головна сторінка сайта НБУ";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLinkClicked);
            // 
            // importFileDialog
            // 
            this.importFileDialog.Filter = "Файли XML|*.xml";
            this.importFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ImportXML);
            // 
            // exportFileDialog
            // 
            this.exportFileDialog.Filter = "Файли XML|*.xml";
            this.exportFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ExportXML);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // printDocument
            // 
            this.printDocument.DocumentName = "Currency Table";
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintPage);
            // 
            // ValuteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 397);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.todayTomorrowCurrencyTable);
            this.Controls.Add(this.radioTomorrow);
            this.Controls.Add(this.radioToday);
            this.Controls.Add(this.exprExchGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ValuteForm";
            this.Text = "Valute Light";
            ((System.ComponentModel.ISupportInitialize)(this.todayTomorrowCurrencyTable)).EndInit();
            this.exprExchGroupBox.ResumeLayout(false);
            this.exprExchGroupBox.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView todayTomorrowCurrencyTable;
        private System.Windows.Forms.RadioButton radioTomorrow;
        private System.Windows.Forms.RadioButton radioToday;
        private System.Windows.Forms.GroupBox exprExchGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox exprExchValuteResult;
        private System.Windows.Forms.ComboBox exprExchValutePicker;
        private System.Windows.Forms.TextBox exprExchValuteAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem допомогаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem допомогаToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem проToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem відкритиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem експортВXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem друкToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.ToolStripButton toolStripImport;
        private System.Windows.Forms.ToolStripButton toolStripExport;
        private System.Windows.Forms.ToolStripButton toolStripPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripRefresh;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileCloseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileImportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileExportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilePrintMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.OpenFileDialog importFileDialog;
        private System.Windows.Forms.SaveFileDialog exportFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn todayTomorrowIntIndexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn todayTomorrowStrIndexCloumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn todayTomorrowAmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn todayTomorrowValuteNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn todayTomorrowCurrencyColumn;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDocument;

    }
}

