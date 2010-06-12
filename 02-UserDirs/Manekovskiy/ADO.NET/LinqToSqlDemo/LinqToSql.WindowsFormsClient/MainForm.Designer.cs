namespace LinqToSql.WindowsFormsClient
{
    partial class MainForm
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
            this.customersDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerControllerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loadDataButton = new System.Windows.Forms.Button();
            this.insertCustomerAddressGroupBox = new System.Windows.Forms.GroupBox();
            this.customerAddressesGroupBox = new System.Windows.Forms.GroupBox();
            this.postalCodeLabel = new System.Windows.Forms.Label();
            this.countryRegionLabel = new System.Windows.Forms.Label();
            this.stateProvinceLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.addressLine2Label = new System.Windows.Forms.Label();
            this.addressLine1label = new System.Windows.Forms.Label();
            this.postalCodeTextBox = new System.Windows.Forms.TextBox();
            this.countryRegionTextBox = new System.Windows.Forms.TextBox();
            this.stateProvinceTextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.addressLine2TextBox = new System.Windows.Forms.TextBox();
            this.addressLine1TextBox = new System.Windows.Forms.TextBox();
            this.customerAddressesDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.addressTypeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.customerFilterComboBox = new System.Windows.Forms.ComboBox();
            this.saveCustomerAddressButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerControllerBindingSource)).BeginInit();
            this.insertCustomerAddressGroupBox.SuspendLayout();
            this.customerAddressesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerAddressesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // customersDataGridView
            // 
            this.customersDataGridView.AutoGenerateColumns = false;
            this.customersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15});
            this.customersDataGridView.DataSource = this.customerControllerBindingSource;
            this.customersDataGridView.Location = new System.Drawing.Point(12, 12);
            this.customersDataGridView.Name = "customersDataGridView";
            this.customersDataGridView.Size = new System.Drawing.Size(756, 168);
            this.customersDataGridView.TabIndex = 0;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "NameStyle";
            this.dataGridViewCheckBoxColumn1.HeaderText = "NameStyle";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Title";
            this.dataGridViewTextBoxColumn2.HeaderText = "Title";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FirstName";
            this.dataGridViewTextBoxColumn3.HeaderText = "FirstName";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "MiddleName";
            this.dataGridViewTextBoxColumn4.HeaderText = "MiddleName";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "LastName";
            this.dataGridViewTextBoxColumn5.HeaderText = "LastName";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Suffix";
            this.dataGridViewTextBoxColumn6.HeaderText = "Suffix";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CompanyName";
            this.dataGridViewTextBoxColumn7.HeaderText = "CompanyName";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "SalesPerson";
            this.dataGridViewTextBoxColumn8.HeaderText = "SalesPerson";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "EmailAddress";
            this.dataGridViewTextBoxColumn9.HeaderText = "EmailAddress";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Phone";
            this.dataGridViewTextBoxColumn10.HeaderText = "Phone";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "PasswordHash";
            this.dataGridViewTextBoxColumn11.HeaderText = "PasswordHash";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "PasswordSalt";
            this.dataGridViewTextBoxColumn12.HeaderText = "PasswordSalt";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "rowguid";
            this.dataGridViewTextBoxColumn13.HeaderText = "rowguid";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "ModifiedDate";
            this.dataGridViewTextBoxColumn14.HeaderText = "ModifiedDate";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "IsDeleted";
            this.dataGridViewTextBoxColumn15.HeaderText = "IsDeleted";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // customerControllerBindingSource
            // 
            this.customerControllerBindingSource.DataMember = "Customers";
            this.customerControllerBindingSource.DataSource = typeof(LinqToSql.Business.CustomerController);
            // 
            // loadDataButton
            // 
            this.loadDataButton.Location = new System.Drawing.Point(621, 666);
            this.loadDataButton.Name = "loadDataButton";
            this.loadDataButton.Size = new System.Drawing.Size(147, 23);
            this.loadDataButton.TabIndex = 1;
            this.loadDataButton.Text = "Load Data";
            this.loadDataButton.UseVisualStyleBackColor = true;
            this.loadDataButton.Click += new System.EventHandler(this.loadDataButton_Click);
            // 
            // insertCustomerAddressGroupBox
            // 
            this.insertCustomerAddressGroupBox.Controls.Add(this.customerAddressesGroupBox);
            this.insertCustomerAddressGroupBox.Controls.Add(this.label1);
            this.insertCustomerAddressGroupBox.Controls.Add(this.addressTypeTextBox);
            this.insertCustomerAddressGroupBox.Controls.Add(this.label2);
            this.insertCustomerAddressGroupBox.Controls.Add(this.customerFilterComboBox);
            this.insertCustomerAddressGroupBox.Location = new System.Drawing.Point(12, 186);
            this.insertCustomerAddressGroupBox.Name = "insertCustomerAddressGroupBox";
            this.insertCustomerAddressGroupBox.Size = new System.Drawing.Size(756, 474);
            this.insertCustomerAddressGroupBox.TabIndex = 2;
            this.insertCustomerAddressGroupBox.TabStop = false;
            this.insertCustomerAddressGroupBox.Text = "Insert New Customer Address";
            // 
            // customerAddressesGroupBox
            // 
            this.customerAddressesGroupBox.Controls.Add(this.postalCodeLabel);
            this.customerAddressesGroupBox.Controls.Add(this.countryRegionLabel);
            this.customerAddressesGroupBox.Controls.Add(this.stateProvinceLabel);
            this.customerAddressesGroupBox.Controls.Add(this.cityLabel);
            this.customerAddressesGroupBox.Controls.Add(this.addressLine2Label);
            this.customerAddressesGroupBox.Controls.Add(this.addressLine1label);
            this.customerAddressesGroupBox.Controls.Add(this.postalCodeTextBox);
            this.customerAddressesGroupBox.Controls.Add(this.countryRegionTextBox);
            this.customerAddressesGroupBox.Controls.Add(this.stateProvinceTextBox);
            this.customerAddressesGroupBox.Controls.Add(this.cityTextBox);
            this.customerAddressesGroupBox.Controls.Add(this.addressLine2TextBox);
            this.customerAddressesGroupBox.Controls.Add(this.addressLine1TextBox);
            this.customerAddressesGroupBox.Controls.Add(this.customerAddressesDataGridView);
            this.customerAddressesGroupBox.Location = new System.Drawing.Point(9, 79);
            this.customerAddressesGroupBox.Name = "customerAddressesGroupBox";
            this.customerAddressesGroupBox.Size = new System.Drawing.Size(741, 387);
            this.customerAddressesGroupBox.TabIndex = 4;
            this.customerAddressesGroupBox.TabStop = false;
            this.customerAddressesGroupBox.Text = "Customer Addresses";
            // 
            // postalCodeLabel
            // 
            this.postalCodeLabel.AutoSize = true;
            this.postalCodeLabel.Location = new System.Drawing.Point(6, 152);
            this.postalCodeLabel.Name = "postalCodeLabel";
            this.postalCodeLabel.Size = new System.Drawing.Size(64, 13);
            this.postalCodeLabel.TabIndex = 12;
            this.postalCodeLabel.Text = "Postal Code";
            // 
            // countryRegionLabel
            // 
            this.countryRegionLabel.AutoSize = true;
            this.countryRegionLabel.Location = new System.Drawing.Point(6, 126);
            this.countryRegionLabel.Name = "countryRegionLabel";
            this.countryRegionLabel.Size = new System.Drawing.Size(80, 13);
            this.countryRegionLabel.TabIndex = 12;
            this.countryRegionLabel.Text = "Country Region";
            // 
            // stateProvinceLabel
            // 
            this.stateProvinceLabel.AutoSize = true;
            this.stateProvinceLabel.Location = new System.Drawing.Point(6, 100);
            this.stateProvinceLabel.Name = "stateProvinceLabel";
            this.stateProvinceLabel.Size = new System.Drawing.Size(77, 13);
            this.stateProvinceLabel.TabIndex = 12;
            this.stateProvinceLabel.Text = "State Province";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(6, 74);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(24, 13);
            this.cityLabel.TabIndex = 12;
            this.cityLabel.Text = "City";
            // 
            // addressLine2Label
            // 
            this.addressLine2Label.AutoSize = true;
            this.addressLine2Label.Location = new System.Drawing.Point(6, 48);
            this.addressLine2Label.Name = "addressLine2Label";
            this.addressLine2Label.Size = new System.Drawing.Size(74, 13);
            this.addressLine2Label.TabIndex = 12;
            this.addressLine2Label.Text = "Address Line2";
            // 
            // addressLine1label
            // 
            this.addressLine1label.AutoSize = true;
            this.addressLine1label.Location = new System.Drawing.Point(6, 22);
            this.addressLine1label.Name = "addressLine1label";
            this.addressLine1label.Size = new System.Drawing.Size(74, 13);
            this.addressLine1label.TabIndex = 12;
            this.addressLine1label.Text = "Address Line1";
            // 
            // postalCodeTextBox
            // 
            this.postalCodeTextBox.Location = new System.Drawing.Point(86, 149);
            this.postalCodeTextBox.Name = "postalCodeTextBox";
            this.postalCodeTextBox.Size = new System.Drawing.Size(649, 20);
            this.postalCodeTextBox.TabIndex = 11;
            // 
            // countryRegionTextBox
            // 
            this.countryRegionTextBox.Location = new System.Drawing.Point(86, 123);
            this.countryRegionTextBox.Name = "countryRegionTextBox";
            this.countryRegionTextBox.Size = new System.Drawing.Size(649, 20);
            this.countryRegionTextBox.TabIndex = 11;
            // 
            // stateProvinceTextBox
            // 
            this.stateProvinceTextBox.Location = new System.Drawing.Point(86, 97);
            this.stateProvinceTextBox.Name = "stateProvinceTextBox";
            this.stateProvinceTextBox.Size = new System.Drawing.Size(649, 20);
            this.stateProvinceTextBox.TabIndex = 11;
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(86, 71);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(649, 20);
            this.cityTextBox.TabIndex = 10;
            // 
            // addressLine2TextBox
            // 
            this.addressLine2TextBox.Location = new System.Drawing.Point(86, 45);
            this.addressLine2TextBox.Name = "addressLine2TextBox";
            this.addressLine2TextBox.Size = new System.Drawing.Size(649, 20);
            this.addressLine2TextBox.TabIndex = 9;
            // 
            // addressLine1TextBox
            // 
            this.addressLine1TextBox.Location = new System.Drawing.Point(86, 19);
            this.addressLine1TextBox.Name = "addressLine1TextBox";
            this.addressLine1TextBox.Size = new System.Drawing.Size(649, 20);
            this.addressLine1TextBox.TabIndex = 8;
            // 
            // customerAddressesDataGridView
            // 
            this.customerAddressesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerAddressesDataGridView.Location = new System.Drawing.Point(9, 175);
            this.customerAddressesDataGridView.Name = "customerAddressesDataGridView";
            this.customerAddressesDataGridView.Size = new System.Drawing.Size(729, 206);
            this.customerAddressesDataGridView.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Address Type";
            // 
            // addressTypeTextBox
            // 
            this.addressTypeTextBox.Location = new System.Drawing.Point(84, 19);
            this.addressTypeTextBox.Name = "addressTypeTextBox";
            this.addressTypeTextBox.Size = new System.Drawing.Size(666, 20);
            this.addressTypeTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Customer";
            // 
            // customerFilterComboBox
            // 
            this.customerFilterComboBox.DataSource = this.customerControllerBindingSource;
            this.customerFilterComboBox.DisplayMember = "FullName";
            this.customerFilterComboBox.FormattingEnabled = true;
            this.customerFilterComboBox.Location = new System.Drawing.Point(84, 46);
            this.customerFilterComboBox.Name = "customerFilterComboBox";
            this.customerFilterComboBox.Size = new System.Drawing.Size(666, 21);
            this.customerFilterComboBox.TabIndex = 6;
            this.customerFilterComboBox.ValueMember = "CustomerID";
            this.customerFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.customerFilterComboBox_SelectedIndexChanged);
            // 
            // saveCustomerAddressButton
            // 
            this.saveCustomerAddressButton.Location = new System.Drawing.Point(12, 666);
            this.saveCustomerAddressButton.Name = "saveCustomerAddressButton";
            this.saveCustomerAddressButton.Size = new System.Drawing.Size(132, 23);
            this.saveCustomerAddressButton.TabIndex = 3;
            this.saveCustomerAddressButton.Text = "Save New Address";
            this.saveCustomerAddressButton.UseVisualStyleBackColor = true;
            this.saveCustomerAddressButton.Click += new System.EventHandler(this.saveCustomerAddressButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 697);
            this.Controls.Add(this.saveCustomerAddressButton);
            this.Controls.Add(this.insertCustomerAddressGroupBox);
            this.Controls.Add(this.loadDataButton);
            this.Controls.Add(this.customersDataGridView);
            this.Name = "MainForm";
            this.Text = "Smart Customers Form";
            ((System.ComponentModel.ISupportInitialize)(this.customersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerControllerBindingSource)).EndInit();
            this.insertCustomerAddressGroupBox.ResumeLayout(false);
            this.insertCustomerAddressGroupBox.PerformLayout();
            this.customerAddressesGroupBox.ResumeLayout(false);
            this.customerAddressesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerAddressesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView customersDataGridView;
        private System.Windows.Forms.Button loadDataButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn nameStyleDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suffixDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesPersonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordHashDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordSaltDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowguidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isDeletedDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource customerControllerBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.GroupBox insertCustomerAddressGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addressTypeTextBox;
        private System.Windows.Forms.Button saveCustomerAddressButton;
        private System.Windows.Forms.GroupBox customerAddressesGroupBox;
        private System.Windows.Forms.DataGridView customerAddressesDataGridView;
        private System.Windows.Forms.ComboBox customerFilterComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stateProvinceTextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox addressLine2TextBox;
        private System.Windows.Forms.TextBox addressLine1TextBox;
        private System.Windows.Forms.Label stateProvinceLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label addressLine2Label;
        private System.Windows.Forms.Label addressLine1label;
        private System.Windows.Forms.Label postalCodeLabel;
        private System.Windows.Forms.Label countryRegionLabel;
        private System.Windows.Forms.TextBox postalCodeTextBox;
        private System.Windows.Forms.TextBox countryRegionTextBox;
    }
}

