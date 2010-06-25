using System;
using System.Windows.Forms;
using BasicToolEnumerator;
using PluginInterface;

namespace ToolBarControlPlugin
{
    /// <summary>
    /// Summary description for ctlMain.
    /// </summary>
    public class ToolBarControl : UserControl, IPlugin
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public ToolBarControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            Application.EnableVisualStyles();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        
        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ToolBarControl
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Name = "ToolBarControl";
            this.Size = new System.Drawing.Size(407, 367);
            this.ResumeLayout(false);

        }
        #endregion


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

        public void Initialize()
        {
            ///empty
        }

        private BasicTool selectedTool;

        public BasicTool SelectedTool
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

        private void button2_Click(object sender, EventArgs e)
        {
            selectedTool = BasicTool.Brush;
            // this.Host.Feedback(selectedTool, this);
        }

        private void textButton_Click(object sender, EventArgs e)
        {
            selectedTool = BasicTool.Text;
        }

        private void penButton_Click(object sender, EventArgs e)
        {
            selectedTool = BasicTool.Pencil;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            selectedTool = BasicTool.RectangleSelection;
        }
    }
}
