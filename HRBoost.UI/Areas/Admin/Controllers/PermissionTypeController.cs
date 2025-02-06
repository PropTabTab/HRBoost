using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.Services.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("Admin")]
    public class PermissionTypeController : Controller
    {
        private readonly IPermissionTypeService _service;

        public PermissionTypeController(IPermissionTypeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var savedPermissions = await _service.GetAll();

            return View(savedPermissions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PermissionType permissionType)
        {
            if ((permissionType == null))
            {
                ModelState.AddModelError("", "Geçersiz izin türü ");
                return RedirectToAction("Index");
            }


            await _service.AddAsync(permissionType);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                ModelState.AddModelError("", "Geçersiz izin ID.");
                return RedirectToAction("Index");
            }
            var permissionType = await _service.GetById(x => x.Id == id);
            _service.DeleteAsync(permissionType);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var currency = await _service.GetById(x => x.Id == id);
            return View(currency);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PermissionType permission)
        {
            try
            {
                var permission2 = await _service.GetById(x => x.Id == permission.Id);
                permission2.Name = permission.Name;
                permission2.Description = permission.Description;
                await _service.UpdateAsync(permission2);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

            }

            return View(permission);
        }

        
    }
}