using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.Personel.Controllers
{
    public class PersonelController : Controller
    {

        [Area("Personel")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
