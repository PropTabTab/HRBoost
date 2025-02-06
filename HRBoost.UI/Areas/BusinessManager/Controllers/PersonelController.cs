using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.BusinessManager.Controllers
{
    [Authorize(Roles = "businessmanager,admin")]
    [Area("BusinessManager")]
    public class PersonelController : Controller
    {

        IUserService _userService;
        private IBusinessService _businessService;
        private readonly IEmailService _emailService;

        public PersonelController(IUserService userService, IBusinessService businessService, IEmailService emailService)
        {
            _userService = userService;
            _businessService = businessService;
            _emailService = emailService;
        }


        public async Task<IActionResult> Index()
        {
            var yonetici = await _userService.GetUserByMail(User.Identity.Name);
            var business = (await _businessService.GetBy(x => x.Id == yonetici.BusinessId)).First();

            var workers = (await _userService.GetAllUsersAsync()).Where(x => x.BusinessId == business.Id).ToList();
            return View(workers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new User());
        }

        [HttpPost]
        public async Task<IActionResult> Create(User model)
        {
            if (model != null)
            {
                var yonetici = await _userService.GetUserByMail(User.Identity.Name);
                var business = (await _businessService.GetBy(x => x.Id == yonetici.BusinessId)).First();

                model.BusinessId = business.Id;
                model.BusinessName = business.BusinessName;   
                model.Password = "123456789";
                model.EmailConfirmed = true;
                await _userService.RegisterAsync(model, "Personel");
                TempData["Message"] = "Personel başarıyla eklendi.";
                return RedirectToAction("Index");
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User model)
        {
            if (model != null)
            {
                await _userService.UpdateUserAsync(model);
                TempData["Message"] = "Personel bilgileri başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
           
            await _userService.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Unfreeze(Guid id)
        {
           
            var model = await _userService.GetUserByIdAsync(id);
            if (model != null)
            {
                
                model.Status = Shared.Enums.Status.Active;

                await _userService.UpdateUserAsync(model);

                _emailService.SendEmail
                    (
                    model.Email,
                    "Hesabınız tekrar aktif hale getirildi",
                    "Şirket yöneticinizin onayıyla hesabınız yeniden aktif hale getirildi. Daha fazla bilgi için şirket yöneticinizle iletişime geçebilirsiniz."
                );

                // İşlemden sonra liste sayfasına yönlendir
                return RedirectToAction("Index");
            }

            // Eğer kullanıcı bulunamazsa aynı sayfayı hata mesajıyla döndür
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Freeze(Guid id)
        {
            var model = await _userService.GetUserByIdAsync(id);
            if (model != null)
            {
                model.Status = Shared.Enums.Status.DeActive;
                await _userService.UpdateUserAsync(model);
                _emailService.SendEmail(model.Email, "Hesabınız şirket yöneticisi tarafından askıya alındı", "Ayrıntılı bilgi için şirket yöeticinizle iletişime geçin");
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
