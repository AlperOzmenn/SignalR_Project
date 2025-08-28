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
        public Guid UserId { get; set; } = default!;
        public AppUser AppUser { get; set; }
    }
}
