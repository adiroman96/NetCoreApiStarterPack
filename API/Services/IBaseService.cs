using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IBaseService<T>
    {
        Task<T> AddAsync(T obj);
        T Delete(T obj);
        Task<T> FindAsync(long id);
        IEnumerable<T> GetEnumerable();
        Task<IList<T>> GetListAsync();
        Task<T> UpdateAsync(T initialObj, T newObj);
        Task Complete();
    }
}
