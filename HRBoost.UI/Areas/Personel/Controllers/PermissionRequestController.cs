using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.Personel.Controllers
{
    [Area("Personel")]
    public class PermissionRequestController : Controller
    {
        private readonly IPermissionRequestService _service;

        public PermissionRequestController(IPermissionRequestService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var requests = await _service.GetAllRequestsAsync();
                return View(requests);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Veriler yüklenirken hata oluştu: " + ex.Message;
                return View(new List<PermissionRequest>()); 
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(PermissionRequest request)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(request);
                return RedirectToAction("Index");
            }
            return View(request);
        }

        public IActionResult Details(Guid id) 
        {
            var request = _service.GetById(x => x.Id == id); 
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
        }
    }
}
