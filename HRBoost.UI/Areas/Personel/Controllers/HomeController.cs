using HRBoost.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.Personel.Controllers
{
    [Authorize(Roles = "personel, businessmanager,admin")]

    [Area("Personel")]
    public class HomeController :Controller
    {
        IUserService _userService;
        private IBusinessService _businessService;
        private readonly IEmailService _emailService;

        public HomeController(IUserService userService, IBusinessService businessService, IEmailService emailService)
        {
            _userService = userService;
            _businessService = businessService;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            var yonetici = await _userService.GetUserByMail(User.Identity.Name);
            var business = (await _businessService.GetBy(x => x.Id == yonetici.BusinessId)).First();

            var workers = (await _userService.GetAllUsersAsync()).Where(x => x.BusinessId == business.Id).ToList();
            return View(workers);
        }

    }
}
