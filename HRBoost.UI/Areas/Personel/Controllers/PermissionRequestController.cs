using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.UI.Areas.Personel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRBoost.UI.Areas.Personel.Controllers
{
    [Area("Personel")]
    public class PermissionRequestController : Controller
    {
        private readonly IPermissionRequestService _service;
        private readonly IPermissionTypeService _TypeService;

        public PermissionRequestController(IPermissionRequestService service,IPermissionTypeService typeService)
        
        {
            _service = service;
            _TypeService = typeService;
            
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var requests = await _service.GetAll();
                return View(requests);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Veriler yüklenirken hata oluştu: " + ex.Message;
                return View(new List<PermissionRequest>());
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model=new PermissionRequestVM();
            model.PermissionTypes = await _TypeService.GetAll();
            return View(model); 
            
        }

        [HttpPost]
        public async Task<IActionResult> Create(PermissionRequestVM request)
        {
            request.PermissionTypes = await _TypeService.GetAll();
            if (request==null)
            {
                TempData["ErrorMessage"] = "Form geçersiz! Lütfen tüm alanları doldurduğunuzdan emin olun.";
                return View(request);
            }

            await _service.AddAsync(request.PermissionRequest); 
           

            TempData["SuccessMessage"] = "İzin talebi başarıyla kaydedildi!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var request = await _service.GetById(x => x.Id == id);
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
        }
    }
}

//bundayım