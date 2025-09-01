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

        // Room Listesi
        public async Task<IActionResult> Index()
        {
            return await ExecuteSafeAsync(async () =>
            {
                var rooms = await _roomService.GetAllAsync();
                return View(rooms);
            }, errorMessage: "Oda listesi yüklenirken hata oluştu!");
        }

        // Oda Oluştur (GET)
        [HttpGet]
        public IActionResult Create() => View();

        // Oda Oluştur (POST)
        [HttpPost]
        public async Task<IActionResult> Create(RoomDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return await ExecuteSafeAsync(async () =>
            {
                await _roomService.AddAsync(model);
                return RedirectToAction(nameof(Index));
            }, successMessage: "Oda başarılı bir şekilde oluşturuldu!", errorMessage: "Oda oluşturma işlemi sırasında hata oluştu!");
        }

        // Room Soft Delete
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                await _roomService.SoftDeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }, successMessage: "Oda başarıyla silindi!", errorMessage: "Oda işlemi sırasında hata oluştu!");
        }


    }
}
