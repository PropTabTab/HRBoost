using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.Services.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _subscriptionService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Subscription sub)
        {
            await _subscriptionService.AddAsync(sub);
            
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            Subscription sub = await _subscriptionService.GetById(x=> x.Id == id);
            await _subscriptionService.DeleteAsync(sub);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            Subscription sub = await _subscriptionService.GetById(x => x.Id == id);
            return View(sub);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Subscription sub)
        {
            Subscription oldSub = await _subscriptionService.GetById(x => x.Id == sub.Id);
            oldSub.SubscriptionType = sub.SubscriptionType;
            oldSub.Price = sub.Price;
            oldSub.Duration = sub.Duration;
            await _subscriptionService.UpdateAsync(oldSub);
            return RedirectToAction("Index");
        }
    }
}
