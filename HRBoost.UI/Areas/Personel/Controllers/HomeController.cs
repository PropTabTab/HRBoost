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
        private readonly IExpense _expenseService;

        public HomeController(IUserService userService, IBusinessService businessService, IEmailService emailService, IHolidayService holidayService, IPermissionRequestService permissionService, IExpense expenseService)
        {
            _userService = userService;
            _businessService = businessService;
            _emailService = emailService;
            _holidayService = holidayService;
            _permissionService = permissionService;
            _expenseService = expenseService;
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

            var approvedExpenses = (await _expenseService.GetBy(x => x.UserID == user.Id && x.Status == Shared.Enums.Status.Approved));
            foreach (var expense in approvedExpenses)
            {
                vm.approvedExpense += expense.Quantity;
            }

            var pendingExpenses = (await _expenseService.GetBy(x => x.UserID == user.Id && x.Status == Shared.Enums.Status.Pending));
            foreach (var expense in pendingExpenses)
            {
                vm.pendingExpense += expense.Quantity;
            }
            return View(vm);
        }

    }
}
