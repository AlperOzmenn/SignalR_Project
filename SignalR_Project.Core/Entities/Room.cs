using SignalR_Project.Core.Commons;

namespace SignalR_Project.Core.Entities
{
    public class Room : BaseEntity
    {
        public string RoomName { get; set; }
        public string NumberOfPeople { get; set; }
        public bool IsPrivate { get; set; }
        public string? Password { get; set; }

        //Navigation properties
        public Guid UserId { get; set; } = default!;
        public AppUser AppUser { get; set; }
        public ICollection<UserMessage> UserMessages { get; set; }
        public UserMessage UserMessage { get; set; }
    }
}
