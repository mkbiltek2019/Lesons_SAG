using System;
using System.Windows.Forms;
using DrawingCanvas.AdditionalDialogs;

namespace Simple.Net_Paint
{
    public partial class MainForm : Form
    {  
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
            Text = selectedPlugin.Instance.SelectedTool.ToString();
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
            SaveCurrentImageByName(selectedImageName);
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
        
        private void setSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // set pen Size
            PenDialog dialog = new PenDialog(Host.Global.SlectedTool.PenStrength,
                   Host.Global.SlectedTool.PenEndLineStyle);
            dialog.ShowDialog();
            Host.Global.SlectedTool.PenStrength = dialog.PenSize;
            Host.Global.SlectedTool.PenEndLineStyle = dialog.PenEndLineStyle;
        }      

        
    }
}
