using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.Services.Concretes;
using HRBoost.UI.Models.VM;
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
        private IBusinessService _businessService;
        private ISubscriptionService _subscriptionService;

        public LoginController(IUserService userService, IEmailService emailService, IBusinessService businessService, ISubscriptionService subscriptionService)
        {
            _userService = userService;
            _emailService = emailService;
            _businessService = businessService;
            _subscriptionService = subscriptionService;
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
                if (User.IsInRole("personel"))
                {
                    return RedirectToAction("Index", "Personel", new { area = "Personel" });
                }
                if (User.IsInRole("businessmanager"))
                {
                    return RedirectToAction("Index","Home", new { area = "BusinessManager" });
                }
                if (User.IsInRole("admin"))
                {
                    return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }
            }
            return View(user);
        }

        [HttpGet("Register")]
        public async Task<IActionResult> Register(string SubscriptionType)
        {
            RegisterVM vm = new RegisterVM();
            vm.SubscriptionName = SubscriptionType;
            return View(vm);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            Subscription s = (await _subscriptionService.GetBy(x => x.SubscriptionType == registerVM.SubscriptionName)).FirstOrDefault();
            Business business = new Business();
            business.BusinessName = registerVM.BusinessName;
            business.SubscriptionId = s.Id;
            Business b = await _businessService.RegisterBusiness(business,s.Duration);

            User user = new User();
            user.FirstName = registerVM.FirstName;
            user.LastName = registerVM.LastName;
            user.Email = registerVM.Email;
            user.Password = registerVM.Password;
            user.PhoneNumber = registerVM.PhoneNumber;
            user.BusinessId = b.Id;
            user.BusinessName = registerVM.BusinessName;

            var cevap = await _userService.RegisterAsync(user, "BusinessManager");

            if (cevap)
            {

                var token = await _userService.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Login", new { token, email = user.Email }, Request.Scheme);

                await _emailService.SendEmail(user.Email, "Email Confirmation", confirmationLink);
                return RedirectToAction("EmailSent", "Login");
            }
            return View(registerVM);
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
