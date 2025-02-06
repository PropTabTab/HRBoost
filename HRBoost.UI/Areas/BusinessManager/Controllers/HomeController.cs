using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.UI.Areas.BusinessManager.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.BusinessManager.Controllers
{
    [Authorize(Roles = "businessmanager,admin")]
    [Area("BusinessManager")]
    public class HomeController : Controller
    {


        private readonly IBusinessService _businessService;
        private readonly IUserService _userService;
        private readonly IPermissionRequestService _permissionService;
        private readonly IExpense _expenseService;

        public HomeController(IBusinessService businessService, IUserService userService, IPermissionRequestService permissionRequest, IExpense expenseService)
        {
            _businessService = businessService;
            _userService = userService;
            _permissionService = permissionRequest;
            _expenseService = expenseService;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM();
            var yonetici = await _userService.GetUserByMail(User.Identity.Name);
            var business = (await _businessService.GetBy(x => x.Id == yonetici.BusinessId)).First();

            var approvedPermissions = (await _permissionService.GetBy(x => x.User.BusinessId == yonetici.BusinessId && x.Status == Shared.Enums.Status.Approved));
            vm.approvedPermission = approvedPermissions.Count();

            var pendingPermissions = (await _permissionService.GetBy(x => x.User.BusinessId == yonetici.BusinessId && x.Status == Shared.Enums.Status.Pending));
            vm.pendingPermission = pendingPermissions.Count();

            var approvedExpenses = (await _expenseService.GetBy(x => x.BusinessID == business.Id && x.Status == Shared.Enums.Status.Approved));
            foreach (var expense in approvedExpenses)
            {
                vm.approvedExpense += expense.Quantity;
            }

            var pendingExpenses = (await _expenseService.GetBy(x => x.BusinessID == business.Id && x.Status == Shared.Enums.Status.Pending));
            foreach (var expense in pendingExpenses)
            {
                vm.pendingExpense += expense.Quantity;
            }


            vm.Personel = (await _userService.GetAllUsersAsync()).Where(x => x.BusinessId == business.Id).ToList();
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> AddComment(string empty)
        {
            var yonetici = await _userService.GetUserByMail(User.Identity.Name);
            var business = (await _businessService.GetBy(x => x.Id == yonetici.BusinessId)).First();
            return View(business);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Business b)
        {
            var yonetici = await _userService.GetUserByMail(User.Identity.Name);
            var business = (await _businessService.GetBy(x => x.Id == yonetici.BusinessId)).First();
            business.BusinessComment = b.BusinessComment;
            await _businessService.UpdateAsync(business);
            return RedirectToAction("Index");
        }

    }
}
