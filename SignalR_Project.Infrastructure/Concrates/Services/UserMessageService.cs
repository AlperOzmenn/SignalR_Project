using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SignalR_Project.Application.DTOs;
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

        public async Task<IEnumerable<UserMessageDTO>> GetFilteredMessagesByRoomAsync(Guid roomId)
        {
            var messages = await _unitOfWork.GetRepository<UserMessage>()
                .GetFilteredListAsync(
                    select: m => m, // tüm entity'yi al
                    where: m => m.RoomId == roomId && !m.IsDeleted,
                    orderBy: q => q.OrderBy(x => x.CreatedDate),
                    join: q => q.Include(x => x.AppUser)
                );

            // AutoMapper ile entity → DTO
            return _mapper.Map<IEnumerable<UserMessageDTO>>(messages);
        }
    }
}
