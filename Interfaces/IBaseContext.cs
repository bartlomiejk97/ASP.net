using System.Collections.Generic;

namespace LibApp_Gr3.Interfaces
{
    public interface IBaseContext<T>
    {
        IEnumerable<T> GetList();
        T GetItem(int id);
        void Insert(T item);
        void Update(int id, T item);
        void Remove(int id);
    }
}
