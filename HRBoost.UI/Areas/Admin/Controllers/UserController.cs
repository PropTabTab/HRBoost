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
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await _userService.GetAllUsersAsync(); 
            return View(users); 
        }


        [HttpGet]
        public IActionResult Add()
        {
            var userModel = new User(); 
            return View(userModel); 
        }

        [HttpPost]
        public async Task<IActionResult> Add(User userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterAsync(userModel);
                if (result)
                {
                    return RedirectToAction("List");
                }
            }
            return View(userModel);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id); 
            if (user == null)
            {
               
                return NotFound("Silmek istediğiniz kullanıcı bulunamadı.");
            }

            return View(user); 
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var result = await _userService.DeleteUserAsync(id); 
            if (!result)
            {
                
                return View("Error", "Kullanıcı silinirken bir hata oluştu veya kullanıcı bulunamadı.");
            }

            return RedirectToAction("List"); 
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id); 
            if (user == null)
            {
                return NotFound("Güncellemek istediğiniz kullanıcı bulunamadı."); 
            }

            return View(user); 
        }

        [HttpPost]
        public async Task<IActionResult> Update(User userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UpdateUserAsync(userModel);
                if (result)
                {
                    return RedirectToAction("List");
                }
            }
            return View(userModel);
        }
    }
}
