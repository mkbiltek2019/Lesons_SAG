using System;
using System.Drawing;
using System.Windows.Forms;
using CSharpFilters;

namespace Simple.Net_Paint
{
    public partial class MainForm : Form
    {
        public double Zoom = 1;

        public MainForm()
        {
            InitializeComponent();
            AddImageToCanvasToTabControl(defaultName, null, null); //add default tab with empty region
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canvasManager.SaveChanges(selectedImageName, drawingCanvas);
            ShowOpenFileDialogAndAddImage();
            canvasManager.RefreshCanvas(drawingCanvas);
        }

        private void drawingCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            canvasManager.DrawingCanvasMouseDown(e.Location, selectedPlugin, drawingCanvas);
        }

        private void drawingCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            canvasManager.DrawingCanvasMouseUp(e.Location, selectedPlugin, drawingCanvas, selectedImageName);
        }

        private void drawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            canvasManager.DrawingCanvasMouseMove(e.Location, selectedPlugin, drawingCanvas);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadPluginFromPluginDirectoryToPanel();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseCurrentTabPage();
        }

        private void mainTabControl_Selected(object sender, TabControlEventArgs e)
        {
            selectedImageName = e.TabPage.Text;
            LoadImageByName(selectedImageName);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCurrentImageByName();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canvasManager.ClearDrawingCanvas(drawingCanvas);
        }

        private void setImageSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResizeCurrentImage(selectedImageName);
        }

        private void drawingCanvas_Click(object sender, EventArgs e)
        {
            canvasManager.ZoomCanvas(((MouseEventArgs)e).Button, drawingCanvas);
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom = 2;

            this.drawingCanvas.AutoScrollMinSize =
                new Size((int)(this.drawingCanvas.DrawHeight * Zoom) + 30,
                         (int)(this.drawingCanvas.DrawWidth * Zoom) + 30);

            drawingCanvas.DrawHeight = (int)(this.drawingCanvas.DrawHeight * Zoom);
            drawingCanvas.DrawWidth = (int)(this.drawingCanvas.DrawWidth * Zoom);

            drawingCanvas.Refresh();
            drawingCanvas.Invalidate();
            this.Invalidate();

        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom = 0.5;
            this.drawingCanvas.AutoScrollMinSize =
                new Size((int)(this.drawingCanvas.DrawHeight * Zoom) + 30,
                         (int)(this.drawingCanvas.DrawWidth * Zoom) + 30);

            drawingCanvas.DrawHeight = (int)(this.drawingCanvas.DrawHeight * Zoom);
            drawingCanvas.DrawWidth = (int)(this.drawingCanvas.DrawWidth * Zoom);

            drawingCanvas.Refresh();
            drawingCanvas.Invalidate();
            this.Invalidate();
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap currentBitmap = (Bitmap)drawingCanvas.Contents;
            if (BitmapFilter.Invert(currentBitmap))
            {
                drawingCanvas.Contents = currentBitmap;
                this.Invalidate();
            }  
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap currentBitmap = (Bitmap)drawingCanvas.Contents;
            if (BitmapFilter.GrayScale(currentBitmap))
            {
                drawingCanvas.Contents = currentBitmap;
                this.Invalidate();
            }  
        }



    }
}
