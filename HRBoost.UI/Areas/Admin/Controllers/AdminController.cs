using HRBoost.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    public class AdminController : Controller
	{
		private readonly IBusinessService _businessService;
		private readonly IUserService _userService;

        public AdminController(IUserService userService, IBusinessService businessService)
        {
            _businessService = businessService;
            _userService = userService;
        }
        public async Task<IActionResult> Index()
		{
            var bl = await _businessService.GetAll();
			return View(bl);
		}
	}
}
