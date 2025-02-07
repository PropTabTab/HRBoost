﻿using System;
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
using Microsoft.AspNetCore.Authorization;

namespace HRBoost.UI.Areas.Personel.Controllers
{
    [Authorize(Roles = "personel, businessmanager,admin")]
    [Area("Personel")]
    public class ExpensesController : Controller
    {
        private readonly IExpense _expenseService;
        private readonly IUserService _userService;

        public ExpensesController(IExpense expenseService,IUserService userService)
        {
            _expenseService = expenseService;
            _userService = userService;
        }

   
        public async Task<IActionResult> Index()
        {
            var expenses = await _expenseService.GetAllPending();
            var user = await _userService.GetUserByMail(User.Identity.Name);
            return View(expenses.Where(x=> x.UserID == user.Id).ToList());
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
                var personel = await _userService.GetUserByMail(User.Identity.Name);
                expense.UserID = personel.Id;
                expense.BusinessID = (Guid)personel.BusinessId;
                expense.Status=Shared.Enums.Status.Pending;
                expense.CreatedBy= personel.FirstName +" "+ personel.LastName;
                await _expenseService.AddAsync(expense);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {


            }

            return View(expense);
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var expense = await _expenseService.GetById(x => x.Id == id);
            return View(expense);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Expense expense)
        {
            try
            {
                var expense2 = await _expenseService.GetById(x => x.Id == expense.Id);
                expense2.Name = expense.Name;
                expense2.Quantity = expense.Quantity;
                await _expenseService.UpdateAsync(expense2);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

            }

            return View(expense);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var expense = await _expenseService.GetById(x => x.Id == id);
            await _expenseService.DeleteAsync(expense);
            return RedirectToAction("Index");
        }

    }
}
