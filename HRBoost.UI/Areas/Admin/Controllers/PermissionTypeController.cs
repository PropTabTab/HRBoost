using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Controllers
{
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
        public async Task <IActionResult> Create(PermissionType permissionType)
        {
            if ((permissionType==null) )
            {
                ModelState.AddModelError("", "Geçersiz izin türü ");
                return RedirectToAction("Index");
            }

           
            

            

           await _service.AddAsync(permissionType);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task <IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                ModelState.AddModelError("", "Geçersiz izin ID.");
                return RedirectToAction("Index");
            }
            var permissionType= await _service.GetById(x=> x.Id==id);
            _service.DeleteAsync(permissionType);
            return RedirectToAction("Index");
        }
    }
}