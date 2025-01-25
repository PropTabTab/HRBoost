using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.BusinessManager.Controllers
{
    [Area("BusinessManager")]

    public class PersonelController : Controller
    {

        IUserService _userService;
        private IBusinessService _businessService;

        public PersonelController(IUserService userService, IBusinessService businessService)
        {
            _userService = userService;
            _businessService = businessService;
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
    }
}
