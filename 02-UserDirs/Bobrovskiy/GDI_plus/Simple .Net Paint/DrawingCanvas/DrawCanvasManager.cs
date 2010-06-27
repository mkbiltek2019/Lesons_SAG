using System;
using System.Collections;
using System.Windows.Forms;
using PluginInterface;
using Simple.Net_Paint.AdditionalDialogs;

namespace DrawingCanvas
{
    public class DrawCanvasManager
    {
        private Hashtable imageList = new Hashtable();

        private void Action(Host.Types.AvailablePlugin currentPlugin, ClassicPaint.DrawingCanvas drawingCanvas)
        {
            switch (currentPlugin.Instance.SelectedTool)
            {
                case Tool.BasicTools.BackGroundColorButton:
                    {
                        drawingCanvas.mainColor = currentPlugin.Instance.BackgroundColor;
                    } break;

                case Tool.BasicTools.ForeGroundColorButton:
                    {
                        drawingCanvas.mainColor = currentPlugin.Instance.ForegroundColor;
                    } break;

                case Tool.BasicTools.Pencil:
                    {
                        CreateTool(new MyTools.PencilTool());
                    } break;

                case Tool.BasicTools.MouseCursor:
                    {
                        CreateTool(null);
                    } break;

                case Tool.BasicTools.Text:
                    {
                        CreateTool(null);
                    } break;

                case Tool.BasicTools.Brush:
                    {
                        CreateTool(new MyTools.BrushTool());
                    } break;

                default:
                    {
                        CreateTool(null);
                    }
                    break;
            }
        }

        private void CreateTool(MyTools.BaseTool tool)
        {
            if (Host.Global.SlectedTool == null)
            {
                Host.Global.SlectedTool = tool;
            }
            else
            {
                string first = Host.Global.SlectedTool.ToString();
                string second = string.Empty;

                if (tool != null)
                {
                    second = tool.ToString();
                }

                if (first != second)
                {
                    Host.Global.SlectedTool = tool;
                }
            }
        }

        public void DrawingCanvasMouseDown(System.Drawing.Point mousePosition,
                                    Host.Types.AvailablePlugin currentPlugin,
                                    ClassicPaint.DrawingCanvas drawingCanvas)
        {
            Action(currentPlugin, drawingCanvas);
            drawingCanvas.DrawingCanvasMouseDown(mousePosition);
        }

        public void DrawingCanvasMouseUp(System.Drawing.Point mousePosition, Host.Types.AvailablePlugin currentPlugin, ClassicPaint.DrawingCanvas drawingCanvas, string Name)
        {
            Action(currentPlugin, drawingCanvas);
            SaveChanges(Name, drawingCanvas);
            drawingCanvas.DrawingCanvasMouseUp(mousePosition);
        }

        public void DrawingCanvasMouseMove(System.Drawing.Point mousePosition, Host.Types.AvailablePlugin currentPlugin, ClassicPaint.DrawingCanvas drawingCanvas)
        {
            Action(currentPlugin, drawingCanvas);
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
