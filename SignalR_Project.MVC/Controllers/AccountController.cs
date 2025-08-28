using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR_Project.Application.VMs;
using SignalR_Project.Core.Entities;

namespace SignalR_Project.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        // Kayıt Ol (GET)
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Kayıt Ol (POST)
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // AutoMapper ile RegisterVM'den AppUser oluştur
            var user = _mapper.Map<AppUser>(model);

            // Identity için UserName zorunlu.
            user.UserName = model.UserName;

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (loginResult.Succeeded)
                    return RedirectToAction("Index", "Home");

                return RedirectToAction("Login", "Account");
            }
            else
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }

            return View(model);  // model ile dön ki form verileri kalsın ve validasyonlar gözüksün
        }

    }
}
