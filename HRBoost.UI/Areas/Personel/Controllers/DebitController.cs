﻿using HRBoost.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.Personel.Controllers
{
    [Area ("Personel")]
    public class DebitController : Controller
    {
        private readonly IDebitService _debitService;

        public DebitController(IDebitService debitService)
        {
            _debitService = debitService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var debits = await _debitService.GetAll();
            return View(debits);
        }
    }
}
