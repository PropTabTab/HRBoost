using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Controllers
{
    public class LoginController : Controller
    {
        IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Login")]
        public async Task<IActionResult> SignIn()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> SignIn(User user)
        {

            var cevap = await _userService.LoginAsync(user);

            if (cevap)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        [HttpGet("Register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(User user)
        {

            var cevap = await _userService.RegisterAsync(user);

            if (cevap)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }
    }
}
