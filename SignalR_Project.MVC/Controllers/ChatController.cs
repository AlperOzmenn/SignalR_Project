//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using SignalR_Project.Application.DTOs;
//using SignalR_Project.Application.Interfaces;
//using SignalR_Project.Core.Entities;
//using System.Security.Claims;

//namespace SignalR_Project.MVC.Controllers
//{
//    public class ChatController : BaseController
//    {
//        private readonly IUserMessageService _userMessageService;
//        private readonly IMapper _mapper;

//        public ChatController(IUserMessageService userMessageService, IMapper mapper)
//        {
//            _userMessageService = userMessageService;
//            _mapper = mapper;
//        }

//        private Guid GetCurrentUserId()
//        {
//            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//            if (Guid.TryParse(userIdStr, out Guid userId))
//                return userId;

//            throw new UnauthorizedAccessException("Kullanıcı ID'si alınamadı.");
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpGet]
//        public IActionResult Create(Guid roomId)
//        {
//            var model = new UserMessageDTO
//            {
//                RoomId = roomId
//            };
//            return View(model);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(UserMessageDTO model, Guid roomId)
//        {
//            if (!ModelState.IsValid)
//                return View(model);

//            try
//            {
//                model.AppUserId = GetCurrentUserId();
//                model.RoomId = roomId;

//                UserMessage entity = _mapper.Map<UserMessage>(model);
//                await _userMessageService.AddAsync(entity);

//                TempData["Success"] = "Mesajlar başarıyla kaydedildi";
//                return RedirectToAction(nameof(Room), new { roomId });
//            }
//            catch (Exception ex)
//            {
//                TempData["Error"] = $"Kullanıcı mesajları kaydedilemedi! {ex.Message}";
//                return View(model);
//            }
//        }
//    }
//}













using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR_Project.Application.DTOs;
using SignalR_Project.Application.Interfaces;
using SignalR_Project.Core.Entities;
using SignalR_Project.Core.UnitOfWorks;
using System.Security.Claims;

namespace SignalR_Project.MVC.Controllers
{
    public class ChatController : BaseController
    {
        private readonly IUserMessageService _userMessageService;
        private readonly IMapper _mapper;

        public ChatController(IUserMessageService userMessageService, IMapper mapper)
        {
            _userMessageService = userMessageService;
            _mapper = mapper;
        }

        private Guid GetCurrentUserId()
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(userIdStr, out Guid userId))
                return userId;

            throw new UnauthorizedAccessException("Kullanıcı ID'si alınamadı.");
        }

        // Chat sayfasını aç
        [HttpGet]
        public async Task<IActionResult> Index(Guid roomId)
        {
            // Geçmiş mesajları çek
            var messages = await _userMessageService.GetMessagesByRoomIdAsync(roomId);

            var model = messages
                .Select(m => new UserMessageDTO
                {
                    RoomId = m.RoomId,
                    AppUserId = m.AppUserId,
                    UserName = m.AppUser.UserName,
                    Text = m.Text,
                    CreatedDate = m.CreatedDate
                })
                .ToList();

            ViewData["RoomId"] = roomId;
            return View(model);
        }
    }
}
