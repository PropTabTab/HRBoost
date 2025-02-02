using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.BusinessManager.Controllers
{
	[Area("BusinessManager")]
	public class ExpenseController :Controller
	{
		private readonly IExpense _expenseService;
		private readonly IUserService _userService;

		public ExpenseController(IExpense expenseService, IUserService userService)
		{
			_expenseService = expenseService;
			_userService = userService;
		}

	

		public async Task<IActionResult> Index()
		{
            var personel = await _userService.GetUserByMail(User.Identity.Name);
			var expenses = await _expenseService.GetAllPending();
            return View(expenses.Where(x=>x.BusinessID==personel.BusinessId));
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
				expense.Status = Status.Active;

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
				expense2.Status = Status.Active;

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