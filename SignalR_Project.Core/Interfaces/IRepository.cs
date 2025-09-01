using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using SignalR_Project.Core.Commons;

namespace SignalR_Project.Core.Interfaces
{
    public interface IRepository<T> where T : IBaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(bool ignoreFilters = false);
        Task<T?> GetByIdAsync(Guid id, bool ignoreFilters = false);
        Task<IEnumerable<TResult>> GetFilteredListAsync<TResult>(
            Expression<Func<T, TResult>> select,
            Expression<Func<T, bool>> where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void SoftDelete(T item);
    }
}
