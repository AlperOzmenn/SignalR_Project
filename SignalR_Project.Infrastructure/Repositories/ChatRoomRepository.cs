using SignalR_Project.Core.Entities;
using SignalR_Project.Core.Interfaces;
using SignalR_Project.Infrastructure.Contexts;

namespace SignalR_Project.Infrastructure.Repositories
{
    public class ChatRoomRepository : EfRepository<ChatRoom>, IChatRoomRepository
    {
        public ChatRoomRepository(AppDbContext context) : base(context)
        {
        }
    }
}
