using Microsoft.AspNetCore.SignalR;
namespace SignalR_Project.MVC.Hubs;

public class ChatHub : Hub
{
    private static readonly Dictionary<string, List<string>> RoomUsers = new();

    // Odaya katıl
    public async Task JoinRoom(string roomId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomId);

        var username = Context.User.Identity?.Name ?? "Anonim"; // Direkt username alıyoruz
        if (!RoomUsers.ContainsKey(roomId))
            RoomUsers[roomId] = new List<string>();

        if (!RoomUsers[roomId].Contains(username))
            RoomUsers[roomId].Add(username);

        await Clients.Group(roomId).SendAsync("UpdateUserList", RoomUsers[roomId]);
        await Clients.Group(roomId).SendAsync("UserJoined", $"{username} odaya katıldı.");
    }

    // Mesaj gönder
    public async Task SendMessage(string roomId, string message)
    {
        var username = Context.User.Identity?.Name ?? "Anonim";
        var time = DateTime.Now.ToString("HH:mm");

        await Clients.Group(roomId).SendAsync("ReceiveMessage", username, message, time);

        // İstersen DB kaydı buraya eklenebilir
    }
}
