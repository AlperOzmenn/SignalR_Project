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
        public virtual ICollection<AppUser> AppUsers { get; set; } = new HashSet<AppUser>();
        public virtual ICollection<UserMessage> UserMessages { get; set; } = new HashSet<UserMessage>();

    }
}
