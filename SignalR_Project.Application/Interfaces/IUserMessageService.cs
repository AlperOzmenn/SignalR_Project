using SignalR_Project.Application.DTOs;
using SignalR_Project.Core.Entities;

namespace SignalR_Project.Application.Interfaces
{
    public interface IUserMessageService : IGenericService<UserMessage>
    {
        Task<IEnumerable<UserMessage>> GetMessagesByRoomIdAsync(Guid roomId);
    }
}
