using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.Services.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentservice;
        public DocumentController(IDocumentService documentservice)
        {
            _documentservice = documentservice;

        }
        public async Task<IActionResult> Index()

        {
            return View(await _documentservice.GetAll());
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Document documentservice)
        {
            await _documentservice.AddAsync(documentservice);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var role = await _documentservice.GetById(x => x.Id == id);

            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Document document)
        {
            await _documentservice.UpdateAsync(document);

            return View(document);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _documentservice.GetById(x => x.Id == id);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Silmek istediğiniz dosya bulunamadı.";
                return View("Error");
            }

            return View(user);
        }



        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Document document = await _documentservice.GetById(x => x.Id == id);
            await _documentservice.DeleteAsync(document);

            return RedirectToAction("Index");
        }

    }

}

