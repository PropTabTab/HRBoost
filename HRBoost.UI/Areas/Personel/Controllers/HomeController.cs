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
        private readonly IHolidayService _holidayService;

        public HomeController(IUserService userService, IBusinessService businessService, IEmailService emailService, IHolidayService holidayService)
        {
            _userService = userService;
            _businessService = businessService;
            _emailService = emailService;
            _holidayService = holidayService;
        }

        public async Task<IActionResult> Index()
        {
            var holidays = await _holidayService.getHolidays();
            return View(holidays);
        }

    }
}
