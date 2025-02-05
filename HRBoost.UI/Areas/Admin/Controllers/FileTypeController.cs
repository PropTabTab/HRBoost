using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.Services.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("Admin")]
    public class FileTypeController : Controller
    {
        private readonly IFileTypeService _fileTypeService;
        public FileTypeController(IFileTypeService fileTypeService)
        {
            _fileTypeService = fileTypeService;

        }
        public async Task<IActionResult> Index()

        {
            return View(await _fileTypeService.GetAll());
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(FileType fileType)
        {
            await _fileTypeService.AddAsync(fileType);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var role = await _fileTypeService.GetById(x => x.Id == id);

            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FileType fileType)
        {
            await _fileTypeService.UpdateAsync(fileType);

            return View(fileType);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _fileTypeService.GetById(x => x.Id == id);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Silmek istediğiniz kullanıcı bulunamadı.";
                return View("Error");
            }

            return View(user);
        }



        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            FileType fileType = await _fileTypeService.GetById(x => x.Id == id);
            await _fileTypeService.DeleteAsync(fileType);

            return RedirectToAction("Index");
        }


    }
}
