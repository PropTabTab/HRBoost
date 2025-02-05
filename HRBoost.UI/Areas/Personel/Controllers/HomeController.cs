using HRBoost.Services.Abstracts;
using HRBoost.UI.Areas.Personel.Models;
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
        private readonly IPermissionRequestService _permissionService;

        public HomeController(IUserService userService, IBusinessService businessService, IEmailService emailService, IHolidayService holidayService, IPermissionRequestService permissionService)
        {
            _userService = userService;
            _businessService = businessService;
            _emailService = emailService;
            _holidayService = holidayService;
            _permissionService = permissionService;
        }

        public async Task<IActionResult> Index()
        {
            PersonelVM vm = new PersonelVM();
            var user = await _userService.GetUserByMail(User.Identity.Name);
            vm.holidays = await _holidayService.getHolidays();
            var permissions = (await _permissionService.GetBy(x=> x.UserId==user.Id && x.Status== Shared.Enums.Status.Approved));
            foreach (var permission in permissions) {
                vm.permissionDuration += (permission.EndDate - permission.StartDate).Days;
            }
            return View(vm);
        }

    }
}
