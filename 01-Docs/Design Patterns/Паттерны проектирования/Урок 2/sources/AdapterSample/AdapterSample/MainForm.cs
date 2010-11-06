using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class MainForm : Form
    {
        public GraphicsView View { get; set; }
        BorderDecorator BorderDecor;
        ScrollDecorator ScrollDecor;
        public MainForm()
        {
            InitializeComponent();
            this.BackColor = mainPanel.BackColor = Color.White;
            View = new TextView("Hello world", mainPanel);
            this.KeyPress += (View as TextView).KeyPressEventHeandler;
            this.KeyDown += (View as TextView).KeyDownEventHandler;
            this.KeyPress += MainForm_KeyPress;
            BorderDecor = new BorderDecorator(View);
            ScrollDecor = new ScrollDecorator(BorderDecor);
            (View as TextArea).TextChanged += MainForm_TextChanged;
            ScrollDecor.SetScrollHandler(ScrollHandler);
        }
        void ScrollHandler(object sender, ScrollEventArgs e)
        {
            View.Offset = e.NewValue;
            Repaint(this, new PaintEventArgs(mainPanel.CreateGraphics(), mainPanel.ClientRectangle));
        }
        private void RecountScrollMaximum()
        {
            int max = (int)(View as TextView).GetBoundingRect(mainPanel.CreateGraphics()).Height;
            ScrollDecor.SetScrollRange(max);
            if (ScrollDecor.ScrollPosition > max)
                ScrollDecor.ScrollTo(max);
        }
        void MainForm_TextChanged(object sender, EventArgs e)
        {
            RecountScrollMaximum();
        }
        void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Repaint(mainPanel, new PaintEventArgs(mainPanel.CreateGraphics(), mainPanel.ClientRectangle));
        }
        public void Repaint(object sender, PaintEventArgs e)
        {
            Image img = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            Graphics DC = Graphics.FromImage(img);
            DC.Clear(BackColor);
            BorderDecor.Paint(DC, ClientRectangle);
            e.Graphics.DrawImage(img, 0,0);
            DC.Dispose();
            img.Dispose();
        }

        private void mainPanel_Resize(object sender, EventArgs e)
        {
            Repaint(mainPanel, new PaintEventArgs(mainPanel.CreateGraphics(), mainPanel.ClientRectangle));
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "Text files|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                (View as TextView).Text = System.IO.File.ReadAllText(dlg.FileName, Encoding.Default);
                RecountScrollMaximum();
                mainPanel.Invalidate();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
