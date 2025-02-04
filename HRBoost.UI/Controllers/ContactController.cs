using HRBoost.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailService _emailService;
        public ContactController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> Mail(string name, string email, string subject, string text)
        {
            await _emailService.SendEmail(email, "Mesajınız İletilmiştir..." , $"Sayın {name}, \nMesajınız iletilmiştir.");
            await _emailService.SendEmail("hrboost2@gmail.com", $"{email} Tarafından: {subject}", text);

            return RedirectToAction("Index","Home");
        }
    }
}
