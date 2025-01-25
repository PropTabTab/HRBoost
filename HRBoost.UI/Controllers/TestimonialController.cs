using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.UI.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IBusinessService _businessService;
        private readonly IUserService _userService;

        public TestimonialController(IUserService userService, IBusinessService businessService)
        {
            _userService = userService;
            _businessService = businessService;
        }

        public async Task<IActionResult> Index(string UserMail)
        {
            YorumVM selectedYorum = null;
            var u = await _userService.GetUserByMail(UserMail);
            var b = (await _businessService.GetBy(x => x.BusinessComment != null && x.Id == u.BusinessId)).First();
            YorumVM yorum = new YorumVM
            {
                BusinessName = b.BusinessName,
                BusinessComment = b.BusinessComment,
                BusinessLogo = b.BusinessLogo,
                UserPhoto = u.UserPhoto,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Position = u.Position
            };

            selectedYorum = yorum;
            
            return View(new List<YorumVM> { selectedYorum });
        }
    }
}
