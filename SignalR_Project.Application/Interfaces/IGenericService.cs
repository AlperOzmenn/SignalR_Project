using SignalR_Project.Core.Commons;

namespace SignalR_Project.Application.Interfaces
{
    public interface IGenericService<T> where T : IBaseEntity, new()
    {
        Task AddAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(Guid id);
        Task SoftDeleteAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync( bool ignoreFilters = false);
        Task<T?> GetByIdAsync(Guid id, bool ignoreFilters = false);
    }
}
