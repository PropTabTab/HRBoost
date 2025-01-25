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

    public async Task<IActionResult> Index()
    {
        YorumVM selectedYorum = null; 
        var ul = await _userService.GetAllUsersAsync();
        var bs = await _businessService.GetBy(x => x.BusinessComment != null);
        foreach (var b in bs)
        {
            foreach (var user in ul)
            {
                if (await _userService.GetUserRole(user) == "BusinessManager")
                {
                    if (user.BusinessId == b.Id)
                    {
                        YorumVM yorum = new YorumVM
                        {
                            BusinessName = b.BusinessName,
                            BusinessComment = b.BusinessComment,
                            BusinessLogo = b.BusinessLogo,
                            UserPhoto = user.UserPhoto,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Position = user.Position
                        };

                        selectedYorum = yorum; 
                        break;
                    }
                }
            }
            if (selectedYorum != null)
            {
                break; 
            }
        }

        return View(new List<YorumVM> { selectedYorum }); 
    }
}
}
