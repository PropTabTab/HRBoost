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
			return View(await _currencyService.GetAll());
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
			try
			{
				await _currencyService.AddAsync(currency);
				return RedirectToAction("Index");
			}
			catch (Exception)
			{
				
				
			}

			return View(currency);
		}


		[HttpGet]
		public async Task<IActionResult> Update(Guid id)
		{
			var currency = await _currencyService.GetById(x => x.Id == id); 
			return View(currency);
		}

		[HttpPost]
		public async Task<IActionResult> Update(Currency currency)
		{
			try
			{
                var currency2 = await _currencyService.GetById(x => x.Id == currency.Id);
				currency2.Name = currency.Name;
				currency2.Symbol = currency.Symbol;
                await _currencyService.UpdateAsync(currency2);
				return RedirectToAction("Index");
			}
			catch (Exception)
			{

			}

			return View(currency);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			var currency = await _currencyService.GetById(x => x.Id == id);
			await _currencyService.DeleteAsync(currency);
			return RedirectToAction("Index");
		}




	}
}
