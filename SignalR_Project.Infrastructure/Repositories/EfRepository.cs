using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SignalR_Project.Core.Commons;
using SignalR_Project.Core.Interfaces;
using SignalR_Project.Infrastructure.Contexts;

namespace SignalR_Project.Infrastructure.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public EfRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public void Delete(T item)
        {
            _dbSet.Remove(item);
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool ignoreFilters = false)
        {
            IQueryable<T> query = _dbSet;

            if (ignoreFilters)
                query = query.IgnoreQueryFilters();

            return await query.ToListAsync();
        }

        public void SoftDelete(T item)
        {
            item.SoftDelete();
            _dbSet.Update(item);
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }

        public async Task<T?> GetByIdAsync(Guid id, bool ignoreFilters = false)
        {
            if (ignoreFilters)
                return await _dbSet.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == id);

            return await _dbSet.FindAsync(id); 
        }

        public async Task<IEnumerable<TResult>> GetFilteredListAsync<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null)
        {
            IQueryable<T> query = _dbSet;

            if (join != null)
                query = join(query);

            if (where != null)
                query = query.Where(where);

            if (orderBy != null)
                return await orderBy(query).Select(select).ToListAsync();
            else
                return await query.Select(select).ToListAsync();
        }
    }
}
