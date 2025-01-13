using Microsoft.AspNetCore.Mvc;
using HRBoost.Services.Abstracts;
using HRBoost.Entity;
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

		[HttpPost]
		public async Task<IActionResult> Add(Role role)
		{
			if (await _roleService.Add(role.Name))
			{
				return RedirectToAction("Index");
			}
			return View(role);
		}

		[HttpGet]
		public async Task<IActionResult> Update(Guid id)
		{
			var role = await _roleService.FindById(id.ToString());

			return View(role);
		}

		[HttpPost]
		public async Task<IActionResult> Update(Role role)
		{
			var result = await _roleService.Update(role);
			if (result)
			{
				return RedirectToAction("Index");
			}
			return View(role);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _roleService.DeleteRole(id.ToString());

			return RedirectToAction("Index");
		}
	}
}
