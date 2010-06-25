using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using PluginInterface;
using Simple.Net_Paint.AdditionalDialogs;

namespace DrawingCanvas
{
    public class DrawCanvasManager
    {
        private Hashtable imageList = new Hashtable();

        private void Action(Point mousePosition,
                                    Host.Types.AvailablePlugin currentPlugin,
                                    ClassicPaint.DrawingCanvas drawingCanvas)
        {
            switch(currentPlugin.Instance.SelectedTool)
            {
                #region Color
                case Tool.BasicTools.BackGroundColorButton:
                    {
                        drawingCanvas.backGroundColor = currentPlugin.Instance.BackgroundColor;
                        drawingCanvas.mainColor = currentPlugin.Instance.BackgroundColor;
                        //currentPlugin.Instance.SetDefaultTool();
                    }break;

                case Tool.BasicTools.ForeGroundColorButton:
                    {
                        drawingCanvas.foregroundColor = currentPlugin.Instance.ForegroundColor;
                        //currentPlugin.Instance.SetDefaultTool();
                    } break;
                #endregion

                case Tool.BasicTools.Pencil: 
                    {
                        drawingCanvas.DrawingCanvasMouseDown(mousePosition, Tool.BasicTools.Pencil);
                    } break;
                case Tool.BasicTools.MouseCursor:
                    {
                        drawingCanvas.DrawingCanvasMouseDown(mousePosition, Tool.BasicTools.MouseCursor);
                    } break;
                case Tool.BasicTools.Text:
                    {
                        drawingCanvas.TextToDraw = "dsfasdfsadfdf";
                        drawingCanvas.DrawingCanvasMouseDown(mousePosition, Tool.BasicTools.Text);
                    } break;
            }
        }

        public void DrawingCanvasMouseDown(Point mousePosition,
                                    Host.Types.AvailablePlugin currentPlugin,
                                    ClassicPaint.DrawingCanvas drawingCanvas)
        {
          Action(mousePosition, currentPlugin, drawingCanvas);
        }

        public void OpenImage(ClassicPaint.DrawingCanvas drawingCanvas, Image currentImage)
        {
            drawingCanvas.DrawImage(currentImage);
        }

        public void SaveChanges(string fileName, ClassicPaint.DrawingCanvas drawingCanvas)
        {
            if (fileName != null)
            {
                imageList[fileName] = drawingCanvas.Contents;
            }
        }

        public void Add(string fileName, ClassicPaint.DrawingCanvas drawingCanvas, Image currentImage)
        {
            drawingCanvas.DrawImage(currentImage);
            imageList.Add(fileName, drawingCanvas.Contents);
        }

        public void LoadImageByName(string fileName, ClassicPaint.DrawingCanvas drawingCanvas)
        {
            Image image = (Image)imageList[fileName];
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

        public void DrawingCanvasMouseUp(Point mousePosition, ClassicPaint.DrawingCanvas drawingCanvas, string Name)
        {
            SaveChanges(Name, drawingCanvas);
            drawingCanvas.DrawingCanvasMouseUp(mousePosition);
        }

        public void DrawingCanvasMouseMove(Point mousePosition, ClassicPaint.DrawingCanvas drawingCanvas, Host.Types.AvailablePlugin currentPlugin)
        {
            drawingCanvas.DrawingCanvasMouseMove(mousePosition, currentPlugin.Instance.SelectedTool);
        }

        public void ClearDrawingCanvas(ClassicPaint.DrawingCanvas drawingCanvas)
        {
            drawingCanvas.ClearBitmap();
            RefreshCanvas(drawingCanvas);
        }

        public void ResizeDrawingCanvas(ClassicPaint.DrawingCanvas drawingCanvas, string imageName)
        {
            ResizeDialog resizeDialog =
                  new ResizeDialog(new Size(drawingCanvas.DrawWidth, drawingCanvas.DrawHeight));

            resizeDialog.ShowDialog();

            drawingCanvas.Contents = drawingCanvas.ResizeImage(drawingCanvas.Contents,
                                                               new Size(resizeDialog.imageWidth, resizeDialog.imageHeight));
            drawingCanvas.SetDrawSize(new Size(resizeDialog.imageWidth, resizeDialog.imageHeight));

            SaveChanges(imageName, drawingCanvas);
        }
    }
}
