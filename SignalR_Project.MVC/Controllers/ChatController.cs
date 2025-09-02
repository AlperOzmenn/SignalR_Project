using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR_Project.Application.DTOs;
using SignalR_Project.Application.Interfaces;
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
