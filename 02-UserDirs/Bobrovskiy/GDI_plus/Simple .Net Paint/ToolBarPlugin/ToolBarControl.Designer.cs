
namespace MyToolBar
{
    partial class ToolBarControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.GroupBox colorSetterGroupBox;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolBarControl));
            this.foreGroundButton = new System.Windows.Forms.Button();
            this.backGroundButton = new System.Windows.Forms.Button();
            this.defaultButton = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.textToolButton = new System.Windows.Forms.Button();
            this.brushToolButton = new System.Windows.Forms.Button();
            this.penToolButton = new System.Windows.Forms.Button();
            this.zoomToolButton = new System.Windows.Forms.Button();
            this.colorPikerToolButton = new System.Windows.Forms.Button();
            this.fillToolButton = new System.Windows.Forms.Button();
            this.EraseToolButton = new System.Windows.Forms.Button();
            this.selectToolButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            colorSetterGroupBox = new System.Windows.Forms.GroupBox();
            colorSetterGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorSetterGroupBox
            // 
            colorSetterGroupBox.BackColor = System.Drawing.SystemColors.Control;
            colorSetterGroupBox.Controls.Add(this.foreGroundButton);
            colorSetterGroupBox.Controls.Add(this.backGroundButton);
            colorSetterGroupBox.Location = new System.Drawing.Point(1, 245);
            colorSetterGroupBox.Name = "colorSetterGroupBox";
            colorSetterGroupBox.Size = new System.Drawing.Size(61, 68);
            colorSetterGroupBox.TabIndex = 27;
            colorSetterGroupBox.TabStop = false;
            // 
            // foreGroundButton
            // 
            this.foreGroundButton.BackColor = System.Drawing.Color.White;
            this.foreGroundButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.foreGroundButton.ForeColor = System.Drawing.Color.Transparent;
            this.foreGroundButton.Location = new System.Drawing.Point(25, 32);
            this.foreGroundButton.Name = "foreGroundButton";
            this.foreGroundButton.Size = new System.Drawing.Size(30, 30);
            this.foreGroundButton.TabIndex = 29;
            this.toolTip.SetToolTip(this.foreGroundButton, "Foreground color");
            this.foreGroundButton.UseVisualStyleBackColor = false;
            this.foreGroundButton.Click += new System.EventHandler(this.foreGroundButton_Click);
            // 
            // backGroundButton
            // 
            this.backGroundButton.BackColor = System.Drawing.Color.Black;
            this.backGroundButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backGroundButton.ForeColor = System.Drawing.Color.Transparent;
            this.backGroundButton.Location = new System.Drawing.Point(5, 8);
            this.backGroundButton.Name = "backGroundButton";
            this.backGroundButton.Size = new System.Drawing.Size(30, 30);
            this.backGroundButton.TabIndex = 28;
            this.toolTip.SetToolTip(this.backGroundButton, "Background color");
            this.backGroundButton.UseVisualStyleBackColor = false;
            this.backGroundButton.Click += new System.EventHandler(this.backGroundButton_Click);
            // 
            // defaultButton
            // 
            this.defaultButton.BackColor = System.Drawing.Color.Transparent;
            this.defaultButton.BackgroundImage = global::ToolPlugin.Resources.Cursor;
            this.defaultButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.defaultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.defaultButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.defaultButton.Location = new System.Drawing.Point(1, 0);
            this.defaultButton.Name = "defaultButton";
            this.defaultButton.Size = new System.Drawing.Size(30, 30);
            this.defaultButton.TabIndex = 2;
            this.defaultButton.UseVisualStyleBackColor = false;
            this.defaultButton.Click += new System.EventHandler(this.defaultButton_Click);
            // 
            // button9
            // 
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.ForeColor = System.Drawing.Color.Transparent;
            this.button9.Location = new System.Drawing.Point(32, 215);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(30, 30);
            this.button9.TabIndex = 26;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.ForeColor = System.Drawing.Color.Transparent;
            this.button10.Location = new System.Drawing.Point(1, 215);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(30, 30);
            this.button10.TabIndex = 25;
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.ForeColor = System.Drawing.Color.Transparent;
            this.button11.Location = new System.Drawing.Point(32, 185);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(30, 30);
            this.button11.TabIndex = 24;
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.ForeColor = System.Drawing.Color.Transparent;
            this.button12.Location = new System.Drawing.Point(1, 185);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(30, 30);
            this.button12.TabIndex = 23;
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.ForeColor = System.Drawing.Color.Transparent;
            this.button13.Location = new System.Drawing.Point(32, 154);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(30, 30);
            this.button13.TabIndex = 22;
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.ForeColor = System.Drawing.Color.Transparent;
            this.button14.Location = new System.Drawing.Point(1, 154);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(30, 30);
            this.button14.TabIndex = 21;
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.ForeColor = System.Drawing.Color.Transparent;
            this.button15.Location = new System.Drawing.Point(32, 123);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(30, 30);
            this.button15.TabIndex = 20;
            this.button15.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pen_tool.png");
            this.imageList1.Images.SetKeyName(1, "text_letter.png");
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Location = new System.Drawing.Point(2, 319);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(59, 146);
            this.listView1.TabIndex = 28;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // textToolButton
            // 
            this.textToolButton.BackColor = System.Drawing.Color.Transparent;
            this.textToolButton.BackgroundImage = global::ToolPlugin.Resources.text_letter;
            this.textToolButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.textToolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textToolButton.ForeColor = System.Drawing.Color.Transparent;
            this.textToolButton.Location = new System.Drawing.Point(1, 123);
            this.textToolButton.Name = "textToolButton";
            this.textToolButton.Size = new System.Drawing.Size(30, 30);
            this.textToolButton.TabIndex = 19;
            this.toolTip.SetToolTip(this.textToolButton, "Text");
            this.textToolButton.UseVisualStyleBackColor = false;
            this.textToolButton.Click += new System.EventHandler(this.textToolButton_Click);
            // 
            // brushToolButton
            // 
            this.brushToolButton.BackColor = System.Drawing.Color.Transparent;
            this.brushToolButton.BackgroundImage = global::ToolPlugin.Resources.Brush_tool;
            this.brushToolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brushToolButton.ForeColor = System.Drawing.Color.Transparent;
            this.brushToolButton.Location = new System.Drawing.Point(32, 92);
            this.brushToolButton.Name = "brushToolButton";
            this.brushToolButton.Size = new System.Drawing.Size(30, 30);
            this.brushToolButton.TabIndex = 9;
            this.toolTip.SetToolTip(this.brushToolButton, "Brush");
            this.brushToolButton.UseVisualStyleBackColor = false;
            this.brushToolButton.Click += new System.EventHandler(this.brushToolButton_Click);
            // 
            // penToolButton
            // 
            this.penToolButton.AutoEllipsis = true;
            this.penToolButton.BackColor = System.Drawing.Color.Transparent;
            this.penToolButton.BackgroundImage = global::ToolPlugin.Resources.pen_tool;
            this.penToolButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.penToolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.penToolButton.ForeColor = System.Drawing.Color.Transparent;
            this.penToolButton.Location = new System.Drawing.Point(1, 92);
            this.penToolButton.Name = "penToolButton";
            this.penToolButton.Size = new System.Drawing.Size(30, 30);
            this.penToolButton.TabIndex = 8;
            this.toolTip.SetToolTip(this.penToolButton, "Pen");
            this.penToolButton.UseVisualStyleBackColor = false;
            this.penToolButton.Click += new System.EventHandler(this.penToolButton_Click);
            // 
            // zoomToolButton
            // 
            this.zoomToolButton.BackColor = System.Drawing.Color.Transparent;
            this.zoomToolButton.BackgroundImage = global::ToolPlugin.Resources.lens_zoom_tool;
            this.zoomToolButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.zoomToolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoomToolButton.ForeColor = System.Drawing.Color.Transparent;
            this.zoomToolButton.Location = new System.Drawing.Point(32, 62);
            this.zoomToolButton.Name = "zoomToolButton";
            this.zoomToolButton.Size = new System.Drawing.Size(30, 30);
            this.zoomToolButton.TabIndex = 7;
            this.toolTip.SetToolTip(this.zoomToolButton, "Zoom Tool");
            this.zoomToolButton.UseVisualStyleBackColor = false;
            this.zoomToolButton.Click += new System.EventHandler(this.zoomToolButton_Click);
            // 
            // colorPikerToolButton
            // 
            this.colorPikerToolButton.BackColor = System.Drawing.Color.Transparent;
            this.colorPikerToolButton.BackgroundImage = global::ToolPlugin.Resources.color_picker;
            this.colorPikerToolButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.colorPikerToolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorPikerToolButton.ForeColor = System.Drawing.Color.Transparent;
            this.colorPikerToolButton.Location = new System.Drawing.Point(1, 62);
            this.colorPikerToolButton.Name = "colorPikerToolButton";
            this.colorPikerToolButton.Size = new System.Drawing.Size(30, 30);
            this.colorPikerToolButton.TabIndex = 6;
            this.toolTip.SetToolTip(this.colorPikerToolButton, "Color piker");
            this.colorPikerToolButton.UseVisualStyleBackColor = false;
            this.colorPikerToolButton.Click += new System.EventHandler(this.colorPikerToolButton_Click);
            // 
            // fillToolButton
            // 
            this.fillToolButton.BackColor = System.Drawing.Color.Transparent;
            this.fillToolButton.BackgroundImage = global::ToolPlugin.Resources.paintbucket;
            this.fillToolButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.fillToolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fillToolButton.ForeColor = System.Drawing.Color.Transparent;
            this.fillToolButton.Location = new System.Drawing.Point(32, 31);
            this.fillToolButton.Name = "fillToolButton";
            this.fillToolButton.Size = new System.Drawing.Size(30, 30);
            this.fillToolButton.TabIndex = 5;
            this.toolTip.SetToolTip(this.fillToolButton, "Fill bucket");
            this.fillToolButton.UseVisualStyleBackColor = false;
            this.fillToolButton.Click += new System.EventHandler(this.fillToolButton_Click);
            // 
            // EraseToolButton
            // 
            this.EraseToolButton.BackColor = System.Drawing.Color.Transparent;
            this.EraseToolButton.BackgroundImage = global::ToolPlugin.Resources.eraser;
            this.EraseToolButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.EraseToolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EraseToolButton.ForeColor = System.Drawing.Color.Transparent;
            this.EraseToolButton.Location = new System.Drawing.Point(1, 31);
            this.EraseToolButton.Name = "EraseToolButton";
            this.EraseToolButton.Size = new System.Drawing.Size(30, 30);
            this.EraseToolButton.TabIndex = 4;
            this.EraseToolButton.Tag = "Erace tool";
            this.toolTip.SetToolTip(this.EraseToolButton, "Eracer");
            this.EraseToolButton.UseVisualStyleBackColor = false;
            this.EraseToolButton.Click += new System.EventHandler(this.EraseToolButton_Click);
            // 
            // selectToolButton
            // 
            this.selectToolButton.BackColor = System.Drawing.Color.Transparent;
            this.selectToolButton.BackgroundImage = global::ToolPlugin.Resources.select_tool1;
            this.selectToolButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.selectToolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectToolButton.ForeColor = System.Drawing.Color.Transparent;
            this.selectToolButton.Location = new System.Drawing.Point(32, 0);
            this.selectToolButton.Name = "selectToolButton";
            this.selectToolButton.Size = new System.Drawing.Size(30, 30);
            this.selectToolButton.TabIndex = 3;
            this.toolTip.SetToolTip(this.selectToolButton, "Select tool");
            this.selectToolButton.UseVisualStyleBackColor = false;
            this.selectToolButton.Click += new System.EventHandler(this.selectToolButton_Click);
            // 
            // ToolBarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Controls.Add(colorSetterGroupBox);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.textToolButton);
            this.Controls.Add(this.brushToolButton);
            this.Controls.Add(this.penToolButton);
            this.Controls.Add(this.zoomToolButton);
            this.Controls.Add(this.colorPikerToolButton);
            this.Controls.Add(this.fillToolButton);
            this.Controls.Add(this.EraseToolButton);
            this.Controls.Add(this.selectToolButton);
            this.Controls.Add(this.defaultButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ToolBarControl";
            this.Size = new System.Drawing.Size(63, 470);
            colorSetterGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button defaultButton;
        private System.Windows.Forms.Button selectToolButton;
        private System.Windows.Forms.Button fillToolButton;
        private System.Windows.Forms.Button EraseToolButton;
        private System.Windows.Forms.Button brushToolButton;
        private System.Windows.Forms.Button penToolButton;
        private System.Windows.Forms.Button zoomToolButton;
        private System.Windows.Forms.Button colorPikerToolButton;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button textToolButton;
        private System.Windows.Forms.Button backGroundButton;
        private System.Windows.Forms.Button foreGroundButton;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolTip toolTip;

    }
}
