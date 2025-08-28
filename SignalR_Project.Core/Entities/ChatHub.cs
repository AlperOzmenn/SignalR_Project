using Microsoft.AspNetCore.SignalR;

namespace SignalR_Project.Core.Entities
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)

        {

            var time = DateTime.Now.ToString("HH:mm");

            await Clients.All.SendAsync("ReceiveMessage", user, message, time);

        }
    }
}