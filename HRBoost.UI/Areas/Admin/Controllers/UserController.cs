using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.Shared.Enums;
using HRBoost.UI.Areas.Admin.Models.VM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRBoost.UI.Areas.Admin.Controllers
{
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
            return View(userModel);
        }

       
        [HttpPost]
        public async Task<IActionResult> Add(UserViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen tüm alanları doldurunuz.";
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

            var result = await _userService.RegisterAsync(user,"BusinessManager");

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

       
        [HttpPost]
        public async Task<IActionResult> Deactivate(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Pasif hale getirmek istediğiniz kullanıcı bulunamadı.";
                return RedirectToAction("List");
            }

            user.Status = Status.DeActive; 
            var result = await _userService.UpdateUserAsync(user);

            if (!result)
            {
                ViewBag.ErrorMessage = "Kullanıcı pasif hale getirilemedi.";
                return RedirectToAction("List");
            }

            return RedirectToAction("List");
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
        public async Task<IActionResult> RejectList()
        {
            var users = await _userService.GetAllUsersAsync();
            var pendingUsers = users.Where(x => x.Status == Status.Pending).ToList();
            return View(pendingUsers);
        }

        [HttpGet]
        public async Task<IActionResult> Reject(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Hesap bulunamadı.";
                return RedirectToAction("RejectList");
            }

            await _emailService.SendEmail(user.Email, "Hesap başvurunuz reddedildi.",
                "Hesap başvurunuz reddedilmiştir. Daha detaylı bilgi için iletişime geçiniz.");
            user.Status = Status.Deleted; 
            await _userService.UpdateUserAsync(user);

            return RedirectToAction("RejectList");
        }
    }
}