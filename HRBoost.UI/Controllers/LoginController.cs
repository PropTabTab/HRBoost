using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.Services.Concretes;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace HRBoost.UI.Controllers
{
    public class LoginController : Controller
    {
        IUserService _userService;
        private IEmailService _emailService;

        public LoginController(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
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
                if (User.IsInRole("Personel")){
                    return RedirectToAction("Index", "Personel", new {area = "Personel"});
                }
                if (User.IsInRole("BusinessManager"))
                {
                    return RedirectToAction("Index", "BusinessManager", new {area = "BusinessManager"});
                }
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Admin", new {area = "Admin"});
                }
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
                
                var token = await _userService.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Login", new { token, email = user.Email },Request.Scheme);

                await _emailService.SendEmail(user.Email, "Email Confirmation", confirmationLink);
                return RedirectToAction("EmailSent", "Login");
            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var result = await _userService.ConfirmEmailAsync(email, token);
            if (result)
            {
                return View(nameof(ConfirmEmail));
            }
            return View();
        }

        [HttpGet]
        public IActionResult SuccessRegistration()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EmailSent()
        {
            return View();
        }
    }
}
