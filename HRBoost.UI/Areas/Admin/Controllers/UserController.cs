using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.Shared.Enums;
using HRBoost.UI.Areas.Admin.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public UserController(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var userModel = new UserViewModel();
            ViewBag.Roles = new List<string> { "admin", "personel", "businessmanager" };
            return View(userModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen tüm alanları doldurunuz.";
                ViewBag.Roles = new List<string> { "admin", "personel", "businessmanager" };
                return View(userModel);
            }

            var user = new User
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                Password = userModel.Password,
                Status = Status.Active
            };
            user.EmailConfirmed = true;
            var result = await _userService.RegisterAsync(user, userModel.Role);

            if (!result)
            {
                ViewBag.ErrorMessage = "Kullanıcı eklenirken bir hata oluştu.";
                return View(userModel);
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Güncellemek istediğiniz kullanıcı bulunamadı.";
                return RedirectToAction("List");
            }

            var userModel = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Status = user.Status.ToString()
            };

            return View(userModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen tüm alanları doğru şekilde doldurunuz.";
                return View(userModel);
            }

            var user = new User
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                Status = Enum.Parse<Status>(userModel.Status)
            };

            var result = await _userService.UpdateUserAsync(user);

            if (!result)
            {
                ViewBag.ErrorMessage = "Güncelleme sırasında bir hata oluştu.";
                return View(userModel);
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Settings()
        {

            var users = await _userService.GetAllUsersAsync();


            if (!User.Identity.IsAuthenticated)
            {
                ViewBag.ErrorMessage = "Hiçbir kullanıcı bulunamadı. Lütfen bir kullanıcı girişi yapınız.";
                return RedirectToAction("Add");
            }


            var user = users.Where(x=>x.UserName==User.Identity.Name).FirstOrDefault();
            var userModel = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Status = user.Status.ToString()
            };

            return View(userModel);
        }

        [HttpPost]
        public async Task<IActionResult> Settings(UserViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen tüm alanları doğru şekilde doldurunuz.";
                return View(userModel);
            }

            var user = new User
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                Status = Enum.Parse<Status>(userModel.Status)
            };

            var result = await _userService.UpdateUserAsync(user);

            if (!result)
            {
                ViewBag.ErrorMessage = "Güncelleme sırasında bir hata oluştu.";
                return View(userModel);
            }

            ViewBag.SuccessMessage = "Bilgiler başarıyla güncellendi.";
            return RedirectToAction("Settings");
        }

        
        public async Task<IActionResult> Deactivate(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Pasif hale getirmek istediğiniz kullanıcı bulunamadı.";
                return RedirectToAction("Index","Home");
            }

            if ((await _userService.GetUserRole(user)).ToLower()=="businessmanager")
            {
                var users = _userService.GetUsersByBusiness((Guid)user.BusinessId);
                foreach (var u in users)
                {
                    u.Status = Status.DeActive;
                    var res = await _userService.UpdateUserAsync(u);
                }
                return RedirectToAction("Index", "Home", new { area = "" });

            }
            user.Status = Status.DeActive;
            var result = await _userService.UpdateUserAsync(user);

            if (!result)
            {
                ViewBag.ErrorMessage = "Kullanıcı pasif hale getirilemedi.";
                return RedirectToAction("Settings");
            }

            await _userService.Logout();
            return RedirectToAction("Index","Home", new {area ="" });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Silmek istediğiniz kullanıcı bulunamadı.";
                return RedirectToAction("List");
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
            {
                ViewBag.ErrorMessage = "Kullanıcı silinirken bir hata oluştu.";
                return View("Error");
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}