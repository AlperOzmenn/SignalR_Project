using Microsoft.Extensions.DependencyInjection;
using SignalR_Project.Application.Interfaces;
using SignalR_Project.Application.Mapping;
using SignalR_Project.Core.Entities;
using SignalR_Project.Core.Interfaces;
using SignalR_Project.Core.UnitOfWorks;
using SignalR_Project.Infrastructure.Concrates.Services;
using SignalR_Project.Infrastructure.Repositories;
using SignalR_Project.Infrastructure.UnitOfWorks;

namespace SignalR_Project.Infrastructure.IoCs
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Registering the Services
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IUserMessageService, UserMessageService>();

            services.AddScoped<IGenericService<AppUser>, GenericService<AppUser>>();
            services.AddScoped<IGenericService<Room>, GenericService<Room>>();
            services.AddScoped<IGenericService<UserMessage>, GenericService<UserMessage>>();

            // Registering the Repositorys
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IUserMessageRepository, UserMessageRepository>();

            // IRepository
            services.AddScoped<IRepository<AppUser>, EfRepository<AppUser>>();
            services.AddScoped<IRepository<Room>, EfRepository<Room>>();
            services.AddScoped<IRepository<UserMessage>, EfRepository<UserMessage>>();
        }
    }
}
