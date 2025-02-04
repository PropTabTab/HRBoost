using HRBoost.Entity;
using HRBoost.Services.Abstracts;
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

        public HomeController(IBusinessService businessService, IUserService userService)
        {
            _businessService = businessService;
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var yonetici = await _userService.GetUserByMail(User.Identity.Name);
            var business = (await _businessService.GetBy(x => x.Id == yonetici.BusinessId)).First();

            var workers = (await _userService.GetAllUsersAsync()).Where(x => x.BusinessId == business.Id).ToList();
            return View(workers);
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
