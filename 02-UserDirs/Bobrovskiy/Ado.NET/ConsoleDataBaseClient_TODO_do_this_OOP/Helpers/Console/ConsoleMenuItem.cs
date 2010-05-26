namespace Helpers.Console
{
    #region ConsoleMenuItem definition
       
    public delegate MenuResult MenuFunctionHandler();

    public class ConsoleMenuItem
    {
        #region Properties

        public MenuFunctionHandler Action
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Key
        {
            get;
            set;
        }

        public bool Visible
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        public ConsoleMenuItem() :
            this(string.Empty, string.Empty, false)
        { }

        public ConsoleMenuItem(string description, string key, bool visible)
        {
            Description = description;
            Key = key;
            Visible = visible;
        }

        public ConsoleMenuItem(string description, string key, bool visible, MenuFunctionHandler action)
            : this(description, key, visible)
        {
            Action = action; 
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return string.Format("{0}. {1}", Key, Description);
        }

        #endregion
    }

    #endregion
}