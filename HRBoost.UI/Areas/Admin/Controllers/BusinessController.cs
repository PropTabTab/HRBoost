using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.Services.Concretes;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Resources;

namespace HRBoost.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BusinessController : Controller
    {
        private readonly IBusinessService _businessService;
        private readonly IUserService _userService;

        public BusinessController(IBusinessService businessService, IUserService userService)
        {
            _businessService = businessService;
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var bl = await _businessService.GetAll();
            return View(bl);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var b = await _businessService.GetById(x => x.Id == id);
            if (b == null) return NotFound();

            return View(b);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Business b)
        {
            if (b != null)
            {
                var oldB = await _businessService.GetById(x => x.Id == b.Id);
                oldB.BusinessAdress = b.BusinessAdress;
                oldB.BusinessPhone = b.BusinessPhone;
                oldB.BusinessName = b.BusinessName;
                oldB.BusinessLogo = b.BusinessLogo;
                await _businessService.UpdateAsync(oldB);
                TempData["Message"] = "Personel bilgileri başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            return View(b);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var b = await _businessService.GetById(x => x.Id == id);
            await _businessService.DeleteAsync(b);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Freeze(Guid id)
        {
            var b = await _businessService.GetById(x => x.Id == id);
            var ul = (await _userService.GetAllUsersAsync()).Where(x => x.BusinessId == b.Id);
            foreach (var user in ul)
            {
                user.Status = Shared.Enums.Status.Pending;
                await _userService.UpdateUserAsync(user);
            }
            return RedirectToAction("Index");
        }





    }
}
