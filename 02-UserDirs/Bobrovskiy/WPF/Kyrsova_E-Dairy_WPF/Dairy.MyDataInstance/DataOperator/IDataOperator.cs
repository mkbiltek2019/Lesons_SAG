using System.Collections.Generic;
using Model;

namespace Dairy.MyDataInstance.DataOperator
{
    public interface IDataOperator
    {
        List<DairyListItem> Select();
        void Insert();
        void Update();
        void Delete();
    }

}
