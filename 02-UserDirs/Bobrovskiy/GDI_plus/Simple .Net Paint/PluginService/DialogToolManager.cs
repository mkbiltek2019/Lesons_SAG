using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DialogManger.AdditionalDialogs;

namespace DialogManger
{
   public class DialogToolManager
    {
       public void Show()
       {
           ShowDiallogToSetPencilParameter();
           ShowDialogToSetTextParameter();
           ShowDialogToSetBrushParameter();
       }

       #region Tool Dailogs Show

       private void ShowDiallogToSetPencilParameter()
       {
           if (Host.Global.SlectedTool != null)
           {
               if (Host.Global.SlectedTool.Compare((new MyTools.PencilTool()).ToString()))
               {
                   PenDialog dialog =
                       new PenDialog(Host.Global.SlectedTool.PenStrength,
                                     Host.Global.SlectedTool.PenLength,
                                     Host.Global.SlectedTool.PenStartLineStyle,
                                     Host.Global.SlectedTool.PenEndLineStyle,
                                     Host.Global.SlectedTool.MainColor,
                                     Host.Global.SlectedTool.Solid);
                   dialog.ShowDialog();
                   Host.Global.SlectedTool.PenStrength = dialog.PenStrength;
                   Host.Global.SlectedTool.PenEndLineStyle = dialog.PenEndLineStyle;
                   Host.Global.SlectedTool.PenStartLineStyle = dialog.PenStartLineStyle;
                   Host.Global.SlectedTool.PenLength = dialog.PenLength;
                   Host.Global.SlectedTool.Solid = dialog.SolidPen;
               }
           }
       }

       private void ShowDialogToSetTextParameter()
       {
           if (Host.Global.SlectedTool != null)
           {
               if (Host.Global.SlectedTool.Compare((new MyTools.TextTool()).ToString()))
               {
                   TextToolDialog dialog =
                       new TextToolDialog(Host.Global.SlectedTool.TextToDraw);
                   dialog.ShowDialog();

                   Host.Global.SlectedTool.TextToDraw = dialog.TextToDraw;
                   Host.Global.SlectedTool.TextResultImage = dialog.ResultImage;
               }
           }
       }

       private void ShowDialogToSetBrushParameter()
       {
           if (Host.Global.SlectedTool != null)
           {
               if (Host.Global.SlectedTool.Compare((new MyTools.BrushTool()).ToString()))
               {
                   BrushDialog dialog = new BrushDialog();
                   dialog.ShowDialog();
                   Host.Global.SlectedTool.CustomBrush = dialog.CustomBrush;
                   Host.Global.SlectedTool.CustomBrushHeight = dialog.BrushHeight;
                   Host.Global.SlectedTool.CustomBrushWidth = dialog.BrushWidth;
               }
           }

       }

       #endregion
    }
}
