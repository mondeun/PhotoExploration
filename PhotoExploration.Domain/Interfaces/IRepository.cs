using System;
using System.Collections.Generic;

namespace PhotoExploration.Domain.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Edit(T item);
        void Remove(Guid id);
        IEnumerable<T> GetItems();
        T FindById(Guid id);

    }
}
