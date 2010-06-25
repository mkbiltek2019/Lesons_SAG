using System;
using System.Drawing;
using System.Windows.Forms;
using PluginInterface;

namespace MyToolBar
{
    public partial class ToolBarControl : UserControl, IPlugin
    {
        IPluginHost myPluginHost = null;
        public string Name = "Name";

        public IPluginHost Host
        {
            get { return myPluginHost; }
            set { myPluginHost = value; }
        }

        public UserControl MainInterface
        {
            get { return this; }
        }

        public void SetDefaultTool()
        {
            selectedTool = Tool.BasicTools.MouseCursor;
        }

        public void Initialize()
        {
            ///empty
        }

        private Tool.BasicTools selectedTool;

        public Tool.BasicTools SelectedTool
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

        private Color foregroundColor;
        private Color backgroundColor;

        public Color ForegroundColor
        {
            get
            {
                return foregroundColor;
            }
            set
            {
                foregroundColor = value;
            }
        }

        public Color BackgroundColor
        {
            get
            {
                return backgroundColor;
            }
            set
            {
                backgroundColor = value;
            }
        }

        public ToolBarControl()
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            Application.EnableVisualStyles();
            backGroundButton.BackColor = Color.White;
            foreGroundButton.BackColor = Color.Black;
        }

        private void backGroundButton_Click(object sender, EventArgs e)
        {
            selectedTool = Tool.BasicTools.BackGroundColorButton;
            myPluginHost.Feedback(selectedTool, this);
            backGroundButton.BackColor = backgroundColor;
        }

        private void foreGroundButton_Click(object sender, EventArgs e)
        {
            selectedTool = Tool.BasicTools.ForeGroundColorButton;
            myPluginHost.Feedback(selectedTool, this);
            foreGroundButton.BackColor = foregroundColor;
        }

        private void penToolButton_Click(object sender, EventArgs e)
        {
            selectedTool = Tool.BasicTools.Pencil;
        }

        private void brushToolButton_Click(object sender, EventArgs e)
        {
            selectedTool = Tool.BasicTools.Brush;
        }

        private void textToolButton_Click(object sender, EventArgs e)
        {
            selectedTool = Tool.BasicTools.Text;
        }

        private void colorPikerToolButton_Click(object sender, EventArgs e)
        {
            selectedTool = Tool.BasicTools.ColorPick;
        }

        private void zoomToolButton_Click(object sender, EventArgs e)
        {
            selectedTool = Tool.BasicTools.Zoom;
        }

        private void EraseToolButton_Click(object sender, EventArgs e)
        {
            selectedTool = Tool.BasicTools.Eraser;
        }

        private void fillToolButton_Click(object sender, EventArgs e)
        {
            selectedTool = Tool.BasicTools.Bucket;
        }

        private void selectToolButton_Click(object sender, EventArgs e)
        {
            selectedTool = Tool.BasicTools.RectangleSelection;
        }

        private void defaultButton_Click(object sender, EventArgs e)
        {
            selectedTool = Tool.BasicTools.MouseCursor;
        }   
         
    }

}
