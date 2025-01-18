using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRBoost.ContextDb.Concrete;
using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.Services.Concretes;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace HRBoost.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CurrenciesController : Controller
    {
        private readonly ICurrencyService _currencyService;

        public CurrenciesController(ICurrencyService currencyService)
        {
			_currencyService = currencyService;
        }
		public async Task<IActionResult> Index()
		{
			return View(_currencyService.GetCurrencies());
		}
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var currency = new Currency(); 
			return View(currency); 
		}


		[HttpPost]
		public async Task<IActionResult> Add(Currency currency)
		{
			if (ModelState.IsValid)
			{
				
				currency.CreatedBy = User.Identity.Name;  
				currency.ModifiedBy = User.Identity.Name; 
				

	

				bool result = await _currencyService.Add(currency);

				if (result)
				{
					return RedirectToAction("Index");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Currency already exists.");
				}
			}

			return View(currency);
		}




	}
}
