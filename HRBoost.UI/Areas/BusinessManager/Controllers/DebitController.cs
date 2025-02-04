using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.UI.Areas.BusinessManager.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.BusinessManager.Controllers
{
    [Authorize(Roles = "businessmanager,admin")]
    [Area("BusinessManager")]
    public class DebitController : Controller
    {
        IUserService _userService;
        private IBusinessService _businessService;
        private readonly IDebitService _debitService;

        public DebitController(IUserService userService, IBusinessService businessService, IDebitService debitService)
        {
            _userService = userService;
            _businessService = businessService;
            _debitService = debitService;
        }


        public async Task<IActionResult> Index(Guid id)
        {
            var user = await _userService.GetUserByMail(User.Identity.Name);
            var debits = await _debitService.GetBy(x => x.UserId == user.Id && x.Status==Shared.Enums.Status.Active);
            DebitListVM VM = new DebitListVM();
            VM.UserId = user.Id;
            VM.Debits = debits;

            return View(VM);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid id)
        {
            var user = await _userService.GetUserById(id.ToString());
            var debit = new Debit();
            debit.UserId = user.Id;
            debit.BusinessId = (Guid)user.BusinessId;

            return View(debit);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Debit model)
        {

            if (model != null)
            {
                model.Id =Guid.NewGuid();
                await _debitService.AddAsync(model);


                TempData["Message"] = "Zimmet bilgileri başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Güncelleme sırasında bir hata oluştu. Lütfen bilgileri kontrol edin.";
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var debit = await _debitService.GetById(x=>x.Id==id);
            if (debit == null) return NotFound();

            return View(debit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Debit model)
        {
            if (model != null)
            {
                var debit = await _debitService.GetById(x => x.Id == model.Id);
                debit.Name = model.Name;
                debit.Description = model.Description;
                debit.Amount = model.Amount;
                await _debitService.UpdateAsync(debit);
                TempData["Message"] = "Zimmet bilgileri başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var debit = await _debitService.GetById(x=>x.Id==id);
            await _debitService.DeleteAsync(debit);
            return RedirectToAction("Index");
        }

        

        
    }
}
