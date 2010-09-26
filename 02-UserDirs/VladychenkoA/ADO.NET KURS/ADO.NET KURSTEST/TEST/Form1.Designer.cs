namespace TEST
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label iDLabel;
            System.Windows.Forms.Label dateLabel;
            System.Windows.Forms.Label priceLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label numberUNITLabel;
            System.Windows.Forms.Label letterCodeLabel;
            System.Windows.Forms.Label digCodeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.exchange_Rates_NBUDataSet = new TEST.Exchange_Rates_NBUDataSet();
            this.currencyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.currencyTableAdapter = new TEST.Exchange_Rates_NBUDataSetTableAdapters.CurrencyTableAdapter();
            this.tableAdapterManager = new TEST.Exchange_Rates_NBUDataSetTableAdapters.TableAdapterManager();
            this.ratesTableAdapter = new TEST.Exchange_Rates_NBUDataSetTableAdapters.RatesTableAdapter();
            this.currencyBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.currencyBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.iDTextBox = new System.Windows.Forms.TextBox();
            this.ratesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.numberUNITTextBox = new System.Windows.Forms.TextBox();
            this.letterCodeTextBox = new System.Windows.Forms.TextBox();
            this.digCodeTextBox = new System.Windows.Forms.TextBox();
            this.currencyDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratesDataGridView = new System.Windows.Forms.DataGridView();
            this.tableAdapterManager1 = new TEST.Exchange_Rates_NBUDataSetTableAdapters.TableAdapterManager();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.absoluteChangeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relativeChangeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            iDLabel = new System.Windows.Forms.Label();
            dateLabel = new System.Windows.Forms.Label();
            priceLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            numberUNITLabel = new System.Windows.Forms.Label();
            letterCodeLabel = new System.Windows.Forms.Label();
            digCodeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.exchange_Rates_NBUDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingNavigator)).BeginInit();
            this.currencyBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // iDLabel
            // 
            iDLabel.AutoSize = true;
            iDLabel.Location = new System.Drawing.Point(9, 47);
            iDLabel.Name = "iDLabel";
            iDLabel.Size = new System.Drawing.Size(21, 13);
            iDLabel.TabIndex = 2;
            iDLabel.Text = "ID:";
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new System.Drawing.Point(9, 85);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new System.Drawing.Size(33, 13);
            dateLabel.TabIndex = 4;
            dateLabel.Text = "Date:";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new System.Drawing.Point(12, 150);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new System.Drawing.Size(34, 13);
            priceLabel.TabIndex = 6;
            priceLabel.Text = "Price:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(9, 118);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 8;
            nameLabel.Text = "Name:";
            // 
            // numberUNITLabel
            // 
            numberUNITLabel.AutoSize = true;
            numberUNITLabel.Location = new System.Drawing.Point(12, 188);
            numberUNITLabel.Name = "numberUNITLabel";
            numberUNITLabel.Size = new System.Drawing.Size(76, 13);
            numberUNITLabel.TabIndex = 10;
            numberUNITLabel.Text = "Number UNIT:";
            // 
            // letterCodeLabel
            // 
            letterCodeLabel.AutoSize = true;
            letterCodeLabel.Location = new System.Drawing.Point(12, 226);
            letterCodeLabel.Name = "letterCodeLabel";
            letterCodeLabel.Size = new System.Drawing.Size(65, 13);
            letterCodeLabel.TabIndex = 12;
            letterCodeLabel.Text = "Letter Code:";
            // 
            // digCodeLabel
            // 
            digCodeLabel.AutoSize = true;
            digCodeLabel.Location = new System.Drawing.Point(12, 269);
            digCodeLabel.Name = "digCodeLabel";
            digCodeLabel.Size = new System.Drawing.Size(54, 13);
            digCodeLabel.TabIndex = 14;
            digCodeLabel.Text = "Dig Code:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // exchange_Rates_NBUDataSet
            // 
            this.exchange_Rates_NBUDataSet.DataSetName = "Exchange_Rates_NBUDataSet";
            this.exchange_Rates_NBUDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // currencyBindingSource
            // 
            this.currencyBindingSource.DataMember = "Currency";
            this.currencyBindingSource.DataSource = this.exchange_Rates_NBUDataSet;
            // 
            // currencyTableAdapter
            // 
            this.currencyTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CurrencyTableAdapter = this.currencyTableAdapter;
            this.tableAdapterManager.RatesTableAdapter = this.ratesTableAdapter;
            this.tableAdapterManager.UpdateOrder = TEST.Exchange_Rates_NBUDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // ratesTableAdapter
            // 
            this.ratesTableAdapter.ClearBeforeFill = true;
            // 
            // currencyBindingNavigator
            // 
            this.currencyBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.currencyBindingNavigator.BindingSource = this.currencyBindingSource;
            this.currencyBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.currencyBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.currencyBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.currencyBindingNavigatorSaveItem});
            this.currencyBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.currencyBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.currencyBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.currencyBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.currencyBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.currencyBindingNavigator.Name = "currencyBindingNavigator";
            this.currencyBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.currencyBindingNavigator.Size = new System.Drawing.Size(829, 25);
            this.currencyBindingNavigator.TabIndex = 1;
            this.currencyBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // currencyBindingNavigatorSaveItem
            // 
            this.currencyBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.currencyBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("currencyBindingNavigatorSaveItem.Image")));
            this.currencyBindingNavigatorSaveItem.Name = "currencyBindingNavigatorSaveItem";
            this.currencyBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.currencyBindingNavigatorSaveItem.Text = "Save Data";
            this.currencyBindingNavigatorSaveItem.Click += new System.EventHandler(this.currencyBindingNavigatorSaveItem_Click);
            // 
            // iDTextBox
            // 
            this.iDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currencyBindingSource, "ID", true));
            this.iDTextBox.Location = new System.Drawing.Point(62, 44);
            this.iDTextBox.Name = "iDTextBox";
            this.iDTextBox.Size = new System.Drawing.Size(100, 20);
            this.iDTextBox.TabIndex = 3;
            // 
            // ratesBindingSource
            // 
            this.ratesBindingSource.DataMember = "FK_Rates_Currency";
            this.ratesBindingSource.DataSource = this.currencyBindingSource;
            // 
            // dateDateTimePicker
            // 
            this.dateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.ratesBindingSource, "Date", true));
            this.dateDateTimePicker.Location = new System.Drawing.Point(62, 79);
            this.dateDateTimePicker.Name = "dateDateTimePicker";
            this.dateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateDateTimePicker.TabIndex = 5;
            // 
            // priceTextBox
            // 
            this.priceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ratesBindingSource, "Price", true));
            this.priceTextBox.Location = new System.Drawing.Point(62, 150);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(100, 20);
            this.priceTextBox.TabIndex = 7;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currencyBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(62, 115);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(200, 20);
            this.nameTextBox.TabIndex = 9;
            // 
            // numberUNITTextBox
            // 
            this.numberUNITTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currencyBindingSource, "NumberUNIT", true));
            this.numberUNITTextBox.Location = new System.Drawing.Point(94, 185);
            this.numberUNITTextBox.Name = "numberUNITTextBox";
            this.numberUNITTextBox.Size = new System.Drawing.Size(100, 20);
            this.numberUNITTextBox.TabIndex = 11;
            // 
            // letterCodeTextBox
            // 
            this.letterCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currencyBindingSource, "LetterCode", true));
            this.letterCodeTextBox.Location = new System.Drawing.Point(95, 223);
            this.letterCodeTextBox.Name = "letterCodeTextBox";
            this.letterCodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.letterCodeTextBox.TabIndex = 13;
            // 
            // digCodeTextBox
            // 
            this.digCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currencyBindingSource, "DigCode", true));
            this.digCodeTextBox.Location = new System.Drawing.Point(94, 266);
            this.digCodeTextBox.Name = "digCodeTextBox";
            this.digCodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.digCodeTextBox.TabIndex = 15;
            // 
            // currencyDataGridView
            // 
            this.currencyDataGridView.AutoGenerateColumns = false;
            this.currencyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currencyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.currencyDataGridView.DataSource = this.currencyBindingSource;
            this.currencyDataGridView.Location = new System.Drawing.Point(279, 28);
            this.currencyDataGridView.Name = "currencyDataGridView";
            this.currencyDataGridView.Size = new System.Drawing.Size(542, 220);
            this.currencyDataGridView.TabIndex = 16;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DigCode";
            this.dataGridViewTextBoxColumn3.HeaderText = "DigCode";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "LetterCode";
            this.dataGridViewTextBoxColumn4.HeaderText = "LetterCode";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NumberUNIT";
            this.dataGridViewTextBoxColumn5.HeaderText = "NumberUNIT";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // ratesDataGridView
            // 
            this.ratesDataGridView.AutoGenerateColumns = false;
            this.ratesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ratesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn,
            this.currencyDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.absoluteChangeDataGridViewTextBoxColumn,
            this.relativeChangeDataGridViewTextBoxColumn});
            this.ratesDataGridView.DataSource = this.ratesBindingSource;
            this.ratesDataGridView.Location = new System.Drawing.Point(279, 266);
            this.ratesDataGridView.Name = "ratesDataGridView";
            this.ratesDataGridView.Size = new System.Drawing.Size(540, 220);
            this.ratesDataGridView.TabIndex = 17;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.CurrencyTableAdapter = null;
            this.tableAdapterManager1.RatesTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = TEST.Exchange_Rates_NBUDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // currencyDataGridViewTextBoxColumn
            // 
            this.currencyDataGridViewTextBoxColumn.DataPropertyName = "Currency";
            this.currencyDataGridViewTextBoxColumn.HeaderText = "Currency";
            this.currencyDataGridViewTextBoxColumn.Name = "currencyDataGridViewTextBoxColumn";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            // 
            // absoluteChangeDataGridViewTextBoxColumn
            // 
            this.absoluteChangeDataGridViewTextBoxColumn.DataPropertyName = "AbsoluteChange";
            this.absoluteChangeDataGridViewTextBoxColumn.HeaderText = "AbsoluteChange";
            this.absoluteChangeDataGridViewTextBoxColumn.Name = "absoluteChangeDataGridViewTextBoxColumn";
            // 
            // relativeChangeDataGridViewTextBoxColumn
            // 
            this.relativeChangeDataGridViewTextBoxColumn.DataPropertyName = "RelativeChange";
            this.relativeChangeDataGridViewTextBoxColumn.HeaderText = "RelativeChange";
            this.relativeChangeDataGridViewTextBoxColumn.Name = "relativeChangeDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 510);
            this.Controls.Add(this.ratesDataGridView);
            this.Controls.Add(this.currencyDataGridView);
            this.Controls.Add(digCodeLabel);
            this.Controls.Add(this.digCodeTextBox);
            this.Controls.Add(letterCodeLabel);
            this.Controls.Add(this.letterCodeTextBox);
            this.Controls.Add(numberUNITLabel);
            this.Controls.Add(this.numberUNITTextBox);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(priceLabel);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(dateLabel);
            this.Controls.Add(this.dateDateTimePicker);
            this.Controls.Add(iDLabel);
            this.Controls.Add(this.iDTextBox);
            this.Controls.Add(this.currencyBindingNavigator);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exchange_Rates_NBUDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingNavigator)).EndInit();
            this.currencyBindingNavigator.ResumeLayout(false);
            this.currencyBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Exchange_Rates_NBUDataSet exchange_Rates_NBUDataSet;
        private System.Windows.Forms.BindingSource currencyBindingSource;
        private Exchange_Rates_NBUDataSetTableAdapters.CurrencyTableAdapter currencyTableAdapter;
        private Exchange_Rates_NBUDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator currencyBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton currencyBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox iDTextBox;
        private Exchange_Rates_NBUDataSetTableAdapters.RatesTableAdapter ratesTableAdapter;
        private System.Windows.Forms.BindingSource ratesBindingSource;
        private System.Windows.Forms.DateTimePicker dateDateTimePicker;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox numberUNITTextBox;
        private System.Windows.Forms.TextBox letterCodeTextBox;
        private System.Windows.Forms.TextBox digCodeTextBox;
        private System.Windows.Forms.DataGridView currencyDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridView ratesDataGridView;
        private Exchange_Rates_NBUDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn absoluteChangeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relativeChangeDataGridViewTextBoxColumn;
    }
}

