 
namespace Dairy.MyDataInstance
{ 
    /// <summary>
    /// Instance of this class used to
    /// hold stored procedure parameter
    /// and used in Sync and Async dataProvider
    /// as parameter
    /// </summary>
    public class ParameterItem
    {
        public string ParameterName
        {
            get;
            set;
        }

        public object ParameterValue
        {
            get;
            set;
        }
    }
}
