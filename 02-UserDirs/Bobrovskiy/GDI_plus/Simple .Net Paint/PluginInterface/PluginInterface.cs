using System.Drawing;

namespace PluginInterface
{
    public interface IPlugin
    {
        IPluginHost Host
        {
            get; 
            set;
        }

        string Name
        {
            get;
        }

        Tool.BasicTools SelectedTool
        {
            get; 
            set;
        }

        Color ForegroundColor
        {
            get; 
            set; 
        }

        Color BackgroundColor
        {
            get; 
            set;
        }
        
        System.Windows.Forms.UserControl MainInterface { get; }

        void SetDefaultTool();
        void Initialize();
        void Dispose();

    }

    public interface IPluginHost
    {
        void Feedback(Tool.BasicTools Feedback, IPlugin Plugin);
    }
}
