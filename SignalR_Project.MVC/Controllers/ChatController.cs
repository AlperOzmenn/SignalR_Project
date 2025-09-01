using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR_Project.Core.Entities;
using SignalR_Project.Infrastructure.Concrates.Services;
using System.Security.Claims;

namespace SignalR_Project.MVC.Controllers
{
    public class ChatController : BaseController
    {
        private readonly UserMessageService _userMessageService;
        private readonly IMapper _mapper;

        public ChatController(UserMessageService userMessageService, IMapper mapper)
        {
            _userMessageService = userMessageService;
            _mapper = mapper;
        }

        // ✅ Giriş yapan kullanıcının Guid tipindeki ID'sini al
        private Guid GetCurrentUserId()
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Guid.TryParse(userIdStr, out Guid userId))
                return userId;

            throw new UnauthorizedAccessException("Kullanıcı ID'si alınamadı.");
        }


        public IActionResult Index()
        {
            return View();
        }
        // Mesaj Kaydetme GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Mesaj Kaydetme POST
        [HttpPost]
        public async Task<IActionResult> Create(UserMessage model)
        {
            if (ModelState.IsValid)
                return View(model);

            try
            {
                model.AppUserId = GetCurrentUserId();

                await _userMessageService.AddAsync(model);
                TempData["Success"] = "Mesajlar başarıyla kaydedildi";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Kullanıcı mesajları kaydedilemedi! {ex.Message}";
                return View(model);
            }
        }
    }
}
