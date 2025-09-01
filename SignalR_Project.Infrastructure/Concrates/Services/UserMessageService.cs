using AutoMapper;
using SignalR_Project.Application.Interfaces;
using SignalR_Project.Core.Entities;
using SignalR_Project.Core.Interfaces;
using SignalR_Project.Core.UnitOfWorks;

namespace SignalR_Project.Infrastructure.Concrates.Services
{
    public class UserMessageService : GenericService<UserMessage>, IUserMessageService
    {
        public UserMessageService(IRepository<UserMessage> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}
