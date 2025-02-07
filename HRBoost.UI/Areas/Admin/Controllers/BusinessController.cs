﻿using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.Services.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Resources;

namespace HRBoost.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]

    [Area("Admin")]
    public class BusinessController : Controller
    {
        private readonly IBusinessService _businessService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public BusinessController(IBusinessService businessService, IUserService userService, IEmailService emailService)
        {
            _businessService = businessService;
            _userService = userService;
            _emailService = emailService;
        }
        public async Task<IActionResult> Index()
        {
            var bl = await _businessService.GetAllPending();
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
            var ul = (await _userService.GetAllUsersAsync()).Where(x => x.BusinessId == b.Id).ToList();
            var yonetici = new User();
            foreach (var user in ul)
            {
                user.Status = Shared.Enums.Status.DeActive;
                await _userService.UpdateUserAsync(user);
                if ((await _userService.GetUserRole(user)).ToLower() == "businessmanager")
                {
                    yonetici = user;
                }   
            }
           if (yonetici != null)
            {
                _emailService.SendEmail(yonetici.Email, "Abolenik süresi dolumu", "Abonelik süreniz dolduğu için hesabiniz dondurulmuştur. Daha fazla bilgi için müşteri hizmetleriyle iletişime geçin");
            }
           b.Status = Shared.Enums.Status.DeActive;
            await _businessService.UpdateAsync(b);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Unfreeze(Guid id)
        {
            var b = await _businessService.GetById(x => x.Id == id);
            var ul = (await _userService.GetAllUsersAsync()).Where(x => x.BusinessId == b.Id).ToList();
            var yonetici = new User();
            foreach (var user in ul)
            {
                user.Status = Shared.Enums.Status.Active;
                await _userService.UpdateUserAsync(user);
                if ((await _userService.GetUserRole(user)).ToLower() == "businessmanager")
                {
                    yonetici = user;
                }
            }
            if (yonetici != null)
            {
                _emailService.SendEmail(yonetici.Email, "Abonelik yenilendi. ", "Aboneliğiniz yeniden aktive edilmiştir. Daha fazla bilgi için müşteri hizmetleriyle iletişime geçin");
            }
            b.Status = Shared.Enums.Status.Active;
            await _businessService.UpdateAsync(b);
            return RedirectToAction("Index");
        }

    }
}
