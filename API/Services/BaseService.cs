using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected DataContext _dataContext;
        protected HttpContext _httpContext;

        public BaseService(
            DataContext dataContext,
            HttpContext context
            )
        {
            _dataContext = dataContext;
            _httpContext = context;
        }

        public async Task<T> AddAsync(T obj)
        {
            var x = await _dataContext.AddAsync(obj);
            return (T)x.Entity;
        }

        public async Task<T> FindAsync(long id)
        {
            return await _dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id && x.StatusCode != (int)StatusCode.Terminated);
        }

        public IEnumerable<T> GetEnumerable()
        {
            return _dataContext.Set<T>().Where(x => x.StatusCode != (int)StatusCode.Terminated).AsEnumerable();
        }

        public async Task<IList<T>> GetListAsync()
        {
            return await _dataContext.Set<T>().Where(x => x.StatusCode != (int)StatusCode.Terminated).ToListAsync();
        }

        public Task<T> UpdateAsync(T initialObj, T newObj)
        {
            throw new NotImplementedException();
        }

        public T Delete(T obj)
        {
            var x = _dataContext.Remove(obj);
            return (T)x.Entity;
        }

        public async Task Complete()
        {
            await _dataContext.SaveChangesAsync();
        }

        private string ipAddress()
        {
            if (_httpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
                return _httpContext.Request.Headers["X-Forwarded-For"];
            else
                return _httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
