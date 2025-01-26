using HRBoost.Services.Abstracts;
using HRBoost.UI.Models;
using HRBoost.UI.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HRBoost.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBusinessService _businessService;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService,IBusinessService businessService)
        {
            _logger = logger;
            _userService = userService;
            _businessService = businessService;
        }

        public async Task<IActionResult> Index()
        {
            List<YorumVM> yorums = new List<YorumVM>();
            var ul = await _userService.GetAllUsersAsync();
            var bs = await _businessService.GetBy(x=>x.BusinessComment != null);
            foreach (var b in bs)
            {
                foreach (var user in ul)
                {
                    if ((await _userService.GetUserRole(user)).ToLower() == "businessmanager")
                    {
                        if (user.BusinessId == b.Id)
                        {
                            YorumVM yorum = new YorumVM();
                            yorum.BusinessName=b.BusinessName;
                            yorum.BusinessComment=b.BusinessComment;
                            yorum.BusinessLogo=b.BusinessLogo;
                            yorum.UserPhoto=user.UserPhoto;
                            yorum.FirstName = user.FirstName;
                            yorum.LastName=user.LastName;
                            yorum.Position=user.Position;
                            yorum.UserMail=user.Email;

                            yorums.Add(yorum);
                        }
                    }
                    
                }
            }
            
            return View(yorums);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
