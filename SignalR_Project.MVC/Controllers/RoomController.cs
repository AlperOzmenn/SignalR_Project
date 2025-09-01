using Microsoft.AspNetCore.Mvc;
using SignalR_Project.Application.Interfaces;
using SignalR_Project.Core.UnitOfWorks;

namespace SignalR_Project.MVC.Controllers
{
    public class RoomController : BaseController
    {
        private readonly IRoomService _roomService;
        private readonly IUnitOfWork _unitOfWork;

        public RoomController(IRoomService categoryService, IUnitOfWork unitOfWork)
        {
            _roomService = categoryService;
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
