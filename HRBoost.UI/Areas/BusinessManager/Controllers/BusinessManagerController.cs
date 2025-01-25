using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.BusinessManager.Controllers
{
    [Area("BusinessManager")]

    public class BusinessManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
