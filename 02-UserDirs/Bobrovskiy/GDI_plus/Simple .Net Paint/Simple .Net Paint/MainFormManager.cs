using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using DrawingCanvas;
using DrawingCanvas.ImageManger;
using Host;

namespace Simple.Net_Paint
{
    public class PaintImageList
    { // store image name and full name with path
        private Hashtable imageList = new Hashtable();

        public void Add(string name, string fullName)
        {
            imageList.Add(name, fullName);
        }

        public string GetFullName(string name)
        {
            string fullName = string.Empty;
            if (imageList.Contains(name))
            {
                return (string)imageList[name];
            }

            return fullName;
        }

        public void RemoveByName(string name)
        {
            if (imageList.Contains(name))
            {
                imageList.Remove(name);
            }
        }

    }
    
    public partial class MainForm
    {
        const string defaultName = "first.bmp";
        private string pluginName;
        private string selectedImageName = defaultName;
        private Host.Types.AvailablePlugin selectedPlugin;
        private DrawCanvasManager canvasManager = new DrawCanvasManager();
        private PaintImageList paintImageList = new PaintImageList();

        private void LoadPluginFromPluginDirectoryToPanel()
        {
            Global.Plugins.FindPlugins(Application.StartupPath + @"\Plugins");

            foreach (Host.Types.AvailablePlugin pluginOn in Global.Plugins.AvailablePlugins)
            {
                pluginName = pluginOn.Instance.Name;
            }

            selectedPlugin =
              Global.Plugins.AvailablePlugins.Find(pluginName);

            if (selectedPlugin != null)
            {
                mainPanel.Controls.Clear();
                selectedPlugin.Instance.MainInterface.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(selectedPlugin.Instance.MainInterface);
            }
        }

        private void ShowOpenFileDialogAndAddImage()
        {
            ImageManager imageManager = new ImageManager();
            Image image = imageManager.Open();
            AddImageToCanvasToTabControl(imageManager.FileName, imageManager.FullFileName, image);
        }

        private void AddImageToCanvasToTabControl(string fileName, string fullFileName, Image image)
        {
            canvasManager.Add(fileName, drawingCanvas, image);
            paintImageList.Add(fileName, fullFileName);

            TabPage tabPage = new TabPage(fileName);
            mainTabControl.TabPages.Add(tabPage);
            mainTabControl.SelectTab(tabPage);
        }

        private void LoadImageByName(string fileName)
        {
            canvasManager.RefreshCanvas(drawingCanvas);
            canvasManager.LoadImageByName(fileName, drawingCanvas);
        }

        private void CloseCurrentTabPage()
        {
            if (mainTabControl.TabPages.Count > 1)
            {   // before remove tab remove image from imageList
                canvasManager.RemoveByName(selectedImageName);
                paintImageList.RemoveByName(selectedImageName);

                mainTabControl.TabPages.RemoveByKey(selectedImageName);
                mainTabControl.Invalidate(true);
                mainTabControl.TabPages.Remove(mainTabControl.SelectedTab);
            }
        }

        private void SaveCurrentImageByName(string selectedImageName)
        {
            ImageManager imageManager = new ImageManager();

            imageManager.Save(drawingCanvas.Contents);
        }

        private void ResizeCurrentImage(string imageName)
        {
            canvasManager.ResizeDrawingCanvas(drawingCanvas, imageName);
        }

    }
}
