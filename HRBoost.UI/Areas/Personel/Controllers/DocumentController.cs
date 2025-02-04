using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.UI.Areas.Admin.Models.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HRBoost.UI.Areas.Personel.Controllers
{
    [Area("Personel")]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentservice;
        private readonly IUserService _userservice;

        public DocumentController(IDocumentService documentservice, IUserService userService)
        {
            _documentservice = documentservice;
            _userservice = userService;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userservice.GetUserByMail(User.Identity.Name);
            var documents = await _documentservice.GetBy(x => x.UserId == user.Id);
            DocumentVM vm = new DocumentVM();
            return View(documents);

        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var users = await _userservice.GetAllUsersAsync();
            ViewBag.UserList = new SelectList(users, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Document document, IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                   
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        document.File = memoryStream.ToArray(); 
                    }

                    document.FileName = file.FileName;
                    document.UploadDate = DateTime.Now; 
                }

               
                var user = await _userservice.GetUserByMail(User.Identity.Name);
                if (user == null)
                {
                    ViewBag.ErrorMessage = "Kullanıcı bilgisi alınamadı.";
                    return View(document);
                }

                document.UserId = user.Id;

                await _documentservice.AddAsync(document);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Dosya yüklenirken bir hata oluştu: {ex.Message}";
                return View(document);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var document = await _documentservice.GetById(x => x.Id == id);
            return View(document);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Document document)
        {
            await _documentservice.UpdateAsync(document);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var document = await _documentservice.GetById(x => x.Id == id);
            if (document == null)
            {
                ViewBag.ErrorMessage = "Silmek istediğiniz dosya bulunamadı.";
                return View("Error");
            }
         
            return View(document);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var document = await _documentservice.GetById(x => x.Id == id);
            await _documentservice.DeleteAsync(document);

            return RedirectToAction("Index");
        }

    }
}
