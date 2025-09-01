using Microsoft.AspNetCore.Mvc;
using SignalR_Project.Core.UnitOfWorks;

namespace SignalR_Project.MVC.Controllers
{
    public class ChatController : BaseController
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
