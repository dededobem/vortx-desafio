using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vortx.Application.Interfaces.Base
{
    public interface IApplication<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Update(Guid id, T entity);
        Task Remove(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        
    }
}
