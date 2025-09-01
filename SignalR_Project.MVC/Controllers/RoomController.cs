using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR_Project.Application.DTOs;
using SignalR_Project.Application.Interfaces;
using SignalR_Project.Core.Entities;
using SignalR_Project.Core.UnitOfWorks;

namespace SignalR_Project.MVC.Controllers
{
    public class RoomController : BaseController
    {
        private readonly IRoomService _roomService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomController(IRoomService categoryService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _roomService = categoryService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Room Listesi
        public async Task<IActionResult> Index()
        {
            return await ExecuteSafeAsync(async () =>
            {
                IEnumerable<Room> rooms = await _roomService.GetAllAsync();
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
            
            Room entity = _mapper.Map<Room>(model);

            return await ExecuteSafeAsync(async () =>
            {
                await _roomService.AddAsync(entity);
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


        public async Task<IActionResult> GetAppUserByRoom(Guid id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                if (id == Guid.Empty)
                {
                    TempData["Error"] = "Geçersiz oda ID'si!";
                    return RedirectToAction(nameof(Index));
                }

                var appUsers = await _unitOfWork.GetRepository<AppUser>().GetFilteredListAsync(
                    select: p => new ProductListDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        UnitPrice = p.UnitPrice,
                        CategoryName = p.Category.Name,
                        Brand = p.Brand,
                        Discount = p.Discount,
                        FinalPrice = p.FinalPrice,
                        ImagePath = p.ImageUrl,
                        Stock = p.Stock,
                        Description = p.Description,
                    },
                    where: p => p.CategoryId == id && !p.IsDeleted,
                    join: p => p.Include(x => x.Category)
                );

                if (!products.Any())
                {
                    TempData["Info"] = "Bu kategoriye ait ürün bulunamadı!";
                }

                return View(products);
            }, errorMessage: "Ürünler yüklenirken hata oluştu!");
        }


    }
}
