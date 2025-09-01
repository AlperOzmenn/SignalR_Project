using SignalR_Project.Core.Commons;
using SignalR_Project.Core.Interfaces;
using SignalR_Project.Core.UnitOfWorks;
using SignalR_Project.Infrastructure.Contexts;
using SignalR_Project.Infrastructure.Repositories;

namespace SignalR_Project.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public int SaveChanges()
        {
            var result = _context.SaveChanges();

            if (result > 0)
                return result;
            else
                throw new Exception("Değişiklikler işlenemedi");
        }

        public async Task<int> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return result;
            else
                throw new Exception("Değişiklikler işlenemdi");
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new EfRepository<T>(_context);
        }
    }
}
