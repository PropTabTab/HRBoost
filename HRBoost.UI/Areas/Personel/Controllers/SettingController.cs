using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.Shared.Enums;
using HRBoost.UI.Areas.Admin.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace HRBoost.UI.Areas.Personel.Controllers
{
    [Authorize(Roles = "personel, businessmanager,admin")]

    [Area("Personel")]
    public class SettingController : Controller
    {
        private readonly IUserService _userService;

        public SettingController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var users = await _userService.GetAllUsersAsync();


            if (!User.Identity.IsAuthenticated)
            {
                ViewBag.ErrorMessage = "Hiçbir kullanıcı bulunamadı. Lütfen bir kullanıcı girişi yapınız.";
                return RedirectToAction("Add");
            }


            var user = users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
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
        public async Task<IActionResult> Index(UserViewModel userModel)
        {
            if (userModel == null)
            {
                ViewBag.ErrorMessage = "Lütfen tüm alanları doğru şekilde doldurunuz.";
                return View(userModel);
            }
            var user = await _userService.GetUserById(userModel.Id.ToString());
            user.Id = userModel.Id;
            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.Email = userModel.Email;
            user.Password = userModel.Password;
            user.Status = Enum.Parse<Status>(userModel.Status);


            var result = await _userService.UpdateUserAsync(user);

            if (!result)
            {
                ViewBag.ErrorMessage = "Güncelleme sırasında bir hata oluştu.";
                return View(userModel);
            }

            ViewBag.SuccessMessage = "Bilgiler başarıyla güncellendi.";
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Deactivate(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Pasif hale getirmek istediğiniz kullanıcı bulunamadı.";
                return RedirectToAction("Index", "Home");
            }

            if ((await _userService.GetUserRole(user)).ToLower() == "businessmanager")
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
            return RedirectToAction("Index", "Home", new { area = "" });
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
