using SignalR_Project.Core.Commons;

namespace SignalR_Project.Core.Interfaces
{
    public interface IRepository<T> where T : IBaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(bool ignoreFilters = false);
        Task<T?> GetByIdAsync(Guid id, bool ignoreFilters = false);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void SoftDelete(T item);
    }
}
