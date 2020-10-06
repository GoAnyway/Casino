using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repository
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> Get(Guid id);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
        void Save();
    }
}