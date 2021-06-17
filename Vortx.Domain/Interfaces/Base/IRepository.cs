using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vortx.Domain.Entities;

namespace Vortx.Domain.Interfaces.Base
{
    public interface IRepository<T> where T : EntityBase
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
    }
}
