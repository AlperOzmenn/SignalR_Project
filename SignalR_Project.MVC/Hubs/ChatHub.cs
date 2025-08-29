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

    }
}
