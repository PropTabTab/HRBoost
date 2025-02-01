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

namespace HRBoost.UI.Areas.Personel.Controllers
{
    [Area("Personel")]
    public class ExpensesController : Controller
    {
        private readonly IExpense _expenseService;

        public ExpensesController(IExpense expenseService)
        {
            _expenseService = expenseService;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var baseContext = _expenseService.Expenses.Include(e => e.Business);
        //    return View(await baseContext.ToListAsync());
        //}

        public async Task<IActionResult> Index()
        {
            return View(await _expenseService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var expense = new Expense();
            return View(expense);
        }


        [HttpPost]
        public async Task<IActionResult> Add(Expense expense)
        {
            try
            {
                await _expenseService.AddAsync(expense);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {


            }

            return View(expense);
        }


        //[HttpGet]
        //public async Task<IActionResult> Update(Guid id)
        //{
        //    var currency = await _currencyService.GetById(x => x.Id == id);
        //    return View(currency);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Update(Currency currency)
        //{
        //    try
        //    {
        //        var currency2 = await _currencyService.GetById(x => x.Id == currency.Id);
        //        currency2.Name = currency.Name;
        //        currency2.Symbol = currency.Symbol;
        //        await _currencyService.UpdateAsync(currency2);
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception)
        //    {

        //    }

        //    return View(currency);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var currency = await _currencyService.GetById(x => x.Id == id);
        //    await _currencyService.DeleteAsync(currency);
        //    return RedirectToAction("Index");
        //}

    }
}
