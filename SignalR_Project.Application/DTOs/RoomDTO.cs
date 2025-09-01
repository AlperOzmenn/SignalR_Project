namespace SignalR_Project.Application.DTOs
{
    public class RoomDTO
    {
        public Guid Id { get; set; }
        public string RoomName { get; set; }
        public bool IsPrivate { get; set; }
        public int NumberOfPeople { get; set; }
    }
}
