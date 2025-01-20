using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.BusinessManager.Controllers
{
    public class BusinessManagerController : Controller
    {
        [Area("BusinessManager")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
