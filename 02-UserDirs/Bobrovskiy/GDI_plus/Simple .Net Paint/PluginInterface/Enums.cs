
namespace PluginInterface
{
    public static class Tool
    {
        private static Tool.BasicTools selectedTool;

        public static Tool.BasicTools SelectedTool
        {
            get
            {
                return selectedTool;
            }
            set
            {
                selectedTool = value;
            }
        }

        public enum BasicTools
        {
            MouseCursor,
            FreeHandSelection,
            RectangleSelection,
            Eraser,
            Bucket,
            ColorPick,
            Zoom,
            Pencil,
            Brush,
            Airbrush,
            Text,
            Line,
            Curve,
            Rectangle,
            Polygon,
            Ellipse,
            Squircle,
            ForeGroundColorButton,
            BackGroundColorButton
        };
    }

}