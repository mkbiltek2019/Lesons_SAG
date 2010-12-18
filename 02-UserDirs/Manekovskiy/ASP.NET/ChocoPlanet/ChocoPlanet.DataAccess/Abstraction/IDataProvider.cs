using System.Collections.Generic;

namespace ChocoPlanet.DataAccess.Abstraction
{
    public interface IDataProvider<T>
        where T : new()
    {
        IEnumerable<T> GetAll();
        T GetById(int categoryId);
    }
}