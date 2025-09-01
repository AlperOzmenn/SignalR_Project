using SignalR_Project.Core.Commons;
using SignalR_Project.Core.Interfaces;

namespace SignalR_Project.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IAppUserRepository AppUserRepository { get; }
        IRepository<T> GetRepository<T>() where T : class, IBaseEntity;
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
