using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.UI.Areas.Admin.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult List()
        {

            var users = _userService.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Email = userModel.Email,
                    Status = Enum.Parse<HRBoost.Shared.Enums.Status>(userModel.Status)
                };
                _userService.RegisterAsync(user);
                return RedirectToAction("List");
            }
            return View("List");
        }
    }
}
