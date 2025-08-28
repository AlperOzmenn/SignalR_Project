using Microsoft.Extensions.DependencyInjection;
using SignalR_Project.Application.Mapping;

namespace SignalR_Project.Infrastructure.IoCs
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
        }
    }
}
