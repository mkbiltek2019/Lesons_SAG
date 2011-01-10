using System.Collections.Generic;

namespace ChocoPlanet.DataAccess.Abstraction
{
    public interface IDataProvider<T>
        where T : new()
    {
        IEnumerable<T> GetAll();
        T GetById(int itemId);
        void Add(T newData);
        void Remove(T dataToRemove);
        void Modify(T dataToModify);
        IEnumerable<T> SelectByForeignKey(int foreignKeyId);
    }
}