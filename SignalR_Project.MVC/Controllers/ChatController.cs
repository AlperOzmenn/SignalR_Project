using Microsoft.AspNetCore.Mvc;

namespace SignalR_Project.MVC.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
