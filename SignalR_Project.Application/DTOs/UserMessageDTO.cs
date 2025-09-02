namespace SignalR_Project.Application.DTOs
{
    public class UserMessageDTO
    {
        public string Text { get; set; } = string.Empty;
        public Guid AppUserId { get; set; } = default!;
        public string UserName { get; set; } = string.Empty;
        public Guid RoomId { get; set; }
        public DateTime CreatedDate { get; set; }

        // Odaya ait eski mesajlar
        public List<UserMessageDTO> Messages { get; set; } = new();
    }
}
