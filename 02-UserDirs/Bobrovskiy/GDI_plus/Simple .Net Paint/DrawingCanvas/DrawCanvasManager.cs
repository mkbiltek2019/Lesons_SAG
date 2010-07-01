using System.Collections;
using System.Windows.Forms;
using DialogManger.AdditionalDialogs;

namespace DrawingCanvas
{
    public class DrawCanvasManager
    {
        private Hashtable imageList = new Hashtable();

        public void DrawingCanvasMouseDown(System.Drawing.Point mousePosition,
                                    Host.Types.AvailablePlugin currentPlugin,
                                    ClassicPaint.DrawingCanvas drawingCanvas)
        {
            if (Host.Global.SlectedTool!=null)
            {
                if(!(Host.Global.SlectedTool.ColorPikerColor.IsEmpty))
                { //used for color picker
                   currentPlugin.Instance.BackgroundColor = Host.Global.SlectedTool.ColorPikerColor;
                }
            }

            drawingCanvas.mainColor = currentPlugin.Instance.BackgroundColor;

            drawingCanvas.DrawingCanvasMouseDown(mousePosition);
        }

        public void DrawingCanvasMouseUp(System.Drawing.Point mousePosition, Host.Types.AvailablePlugin currentPlugin, ClassicPaint.DrawingCanvas drawingCanvas, string Name)
        { 
            SaveChanges(Name, drawingCanvas);
            drawingCanvas.DrawingCanvasMouseUp(mousePosition);
        }

        public void DrawingCanvasMouseMove(System.Drawing.Point mousePosition, Host.Types.AvailablePlugin currentPlugin, ClassicPaint.DrawingCanvas drawingCanvas)
        { 
            drawingCanvas.DrawingCanvasMouseMove(mousePosition);
        }

        public void SaveChanges(string fileName, ClassicPaint.DrawingCanvas drawingCanvas)
        {
            if (fileName != null)
            {
                imageList[fileName] = drawingCanvas.Contents;
            }
        }

        public void AddImageToCanvasAndToOpenedImageList(string fileName, ClassicPaint.DrawingCanvas drawingCanvas, System.Drawing.Image currentImage)
        {
            if ((fileName != null) && (currentImage != null))
            {
                drawingCanvas.DrawImage(currentImage);
                imageList.Add(fileName, drawingCanvas.Contents);
            }
        }

        public void LoadImageByName(string fileName, ClassicPaint.DrawingCanvas drawingCanvas)
        {
            System.Drawing.Image image = (System.Drawing.Image)imageList[fileName];
            if (image != null)
            {
                drawingCanvas.DrawImage(image);
            }
        }

        public void RemoveByName(string fileName)
        {
            if (imageList.Contains(fileName))
            {
                imageList.Remove(fileName);
            }
        }

        public void RefreshCanvas(ClassicPaint.DrawingCanvas drawingCanvas)
        {
            drawingCanvas.Invalidate(true);
        }

        public void ZoomCanvas(MouseButtons button, ClassicPaint.DrawingCanvas drawingCanvas)
        {
            if (button == MouseButtons.Right)
            {
                drawingCanvas.DrawHeight += 10;
                drawingCanvas.DrawWidth += 10;
            }

            drawingCanvas.Refresh();
        }

        public void ClearDrawingCanvas(ClassicPaint.DrawingCanvas drawingCanvas)
        {
            drawingCanvas.ClearBitmap();
            RefreshCanvas(drawingCanvas);
        }

        public void ResizeDrawingCanvas(ClassicPaint.DrawingCanvas drawingCanvas, string imageName)
        {
            ResizeDialog resizeDialog =
                  new ResizeDialog(new System.Drawing.Size(drawingCanvas.DrawWidth, drawingCanvas.DrawHeight));

            resizeDialog.ShowDialog();

            drawingCanvas.Contents = drawingCanvas.ResizeImage(drawingCanvas.Contents,
                                                               new System.Drawing.Size(resizeDialog.imageWidth, resizeDialog.imageHeight));
            drawingCanvas.SetDrawSize(new System.Drawing.Size(resizeDialog.imageWidth, resizeDialog.imageHeight));

            SaveChanges(imageName, drawingCanvas);
        }
    }
}
