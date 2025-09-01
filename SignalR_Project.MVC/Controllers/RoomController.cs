using Microsoft.AspNetCore.Mvc;

namespace SignalR_Project.MVC.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
