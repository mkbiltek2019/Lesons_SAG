using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DrawCanvas;

namespace Simple.Net_Paint
{
    public partial class mainForm : Form
    {
        private int thick = 1;

        public mainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image currentImage = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Filter = @"All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            Image loadedImage = null;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadedImage = Image.FromFile(openFileDialog1.FileName);

                currentImage = (Image)loadedImage.Clone();
            }

            if (loadedImage != null)
            {
                loadedImage.Dispose();
            }

            drawingCanvas.DrawImage(currentImage);
            
        }

        private void drawingCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            drawingCanvas.DrawingCanvasMouseDown(e.X, e.Y, thick);
        }

        private void drawingCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            drawingCanvas.DrawingCanvasMouseUp(e.X, e.Y);
        }

        private void drawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            drawingCanvas.DrawingCanvasMouseMove(e.X, e.Y, thick); 
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }




       
    }
}
