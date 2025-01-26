using HRBoost.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.BusinessManager.Controllers
{
    [Area("BusinessManager")]
    [Route("BusinessManager")]
    public class BusinessManagerController : Controller
    {
        

        private readonly IBusinessService _businessService;
        private readonly IUserService _userService;

        public BusinessManagerController(IBusinessService businessService, IUserService userService)
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
    }
}
