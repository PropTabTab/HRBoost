using Microsoft.AspNetCore.Mvc;
using HRBoost.Services.Abstracts;
namespace HRBoost.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _roleService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }



    }
}
