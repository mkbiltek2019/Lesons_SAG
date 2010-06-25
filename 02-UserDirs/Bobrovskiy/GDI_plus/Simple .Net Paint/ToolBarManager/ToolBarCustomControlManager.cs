using System.Drawing;
using System.Windows.Forms;

namespace ToolBarCustomControlManager
{
    public class ToolBarManager
    {
        #region Get background and fore ground Color from ColorDialog

        private Color backgGroundColor;
        private Color foreGroundColor;

        public Color BackGroundColor
        {
            get
            {
                backgGroundColor = GetColorFromColorDialog();
                return backgGroundColor;
            }
        }

        public Color ForeGroundColor
        {
            get
            {
                foreGroundColor = GetColorFromColorDialog();
                return foreGroundColor;
            }
        }

        private Color GetColorFromColorDialog()
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            return colorDialog.Color;
        }

        #endregion               
    
    }
}
