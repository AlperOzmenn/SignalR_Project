using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<UserMessage>> GetMessagesByRoomIdAsync(Guid roomId)
        {
            return await _unitOfWork.GetRepository<UserMessage>()
                .GetFilteredListAsync(
                    select: m => m, // tüm entity'yi almak için
                    where: m => m.RoomId == roomId,
                    orderBy: q => q.OrderBy(m => m.CreatedDate),
                    join: q => q.Include(x => x.AppUser)
                );
        }








    }
}
