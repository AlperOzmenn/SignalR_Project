using Microsoft.AspNetCore.SignalR;

namespace SignalR_Project.MVC.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            var userName = Context.User.Identity.Name;

            await Clients.All.SendAsync("ReceiveMessage", userName, message);
        }

        //public async Task SendMessage(string userName, string message, string roomId)
        //{
        //    var createdDate = DateTime.Now;

        //    // Mesajı sadece o odadaki kullanıcılara gönder
        //    await Clients.Group(roomId).SendAsync("ReceiveMessage", userName, message, roomId, createdDate);
        //}

        public async Task JoinRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }

    }
}
