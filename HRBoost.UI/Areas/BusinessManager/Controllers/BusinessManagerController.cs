using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.BusinessManager.Controllers
{
    public class BusinessManagerController : Controller
    {
        [Area("BusinessManager")]
        [Route("BusinessManager")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
