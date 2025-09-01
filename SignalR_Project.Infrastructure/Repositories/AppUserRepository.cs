using SignalR_Project.Core.Entities;
using SignalR_Project.Core.Interfaces;
using SignalR_Project.Infrastructure.Contexts;

namespace SignalR_Project.Infrastructure.Repositories
{
    public class AppUserRepository : EfRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
