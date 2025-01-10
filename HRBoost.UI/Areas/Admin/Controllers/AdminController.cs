using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.Admin.Controllers
{
	public class AdminController : Controller
	{
		[Area("Admin")]
		[Route("Admin")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
