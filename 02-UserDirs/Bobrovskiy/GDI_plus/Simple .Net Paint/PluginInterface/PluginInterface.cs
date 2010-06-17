using System.Drawing;

namespace PluginInterface
{
    public interface IPlugin
    {
        IPluginHost Host { get; set; }

        Image ToolBoxBitmapImage 
        { 
            get;
        }

        string MenuItemTextString
        { 
            get;
        }

        void Action(object param); 

        System.Windows.Forms.UserControl MainInterface { get; }

        void Initialize();
        void Dispose();  
    }

    public interface IPluginHost
    {
        void Draw(string param);
    }
}
