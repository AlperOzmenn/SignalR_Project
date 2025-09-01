using SignalR_Project.Core.Commons;
using SignalR_Project.Core.Enum;

namespace SignalR_Project.Core.Entities
{
    public class UserMessage : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public MessageStatus MessageStatus { get; set; }
        public Guid ToUser { get; set; }

        //Navigation properties
        public virtual Guid AppUserId { get; set; } = default!;
        public virtual AppUser AppUser { get; set; }
        public virtual Guid RoomId { get; set; } = default!;
        public virtual Room Room { get; set; }
    }
}
