using HRBoost.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using HRBoost.UI.Areas.Personel.Models;
using HRBoost.Entity;
using Azure.Core;

namespace HRBoost.UI.Areas.BusinessManager.Controllers
{
    [Area("BusinessManager")]
    public class PermissionController : Controller
    {
        private readonly IPermissionRequestService _permissionRequestService;
        private readonly IUserService _userService;
        public PermissionController(IPermissionRequestService permissionRequestService, IUserService userService)
        {
            _permissionRequestService = permissionRequestService;
            _userService = userService;
        }


        public async Task<IActionResult> Index()
        {
            var VMs=new List<PermissionRequestVM>();
            var pendingRequests = await _permissionRequestService.GetAllPending();
            foreach (var pendingRequest in pendingRequests)
            {
                var requestVM = new PermissionRequestVM();
                requestVM.PermissionRequest = new PermissionRequest();
                requestVM.PermissionRequest.Id = pendingRequest.Id;
                requestVM.PermissionRequest.PermissionType = pendingRequest.PermissionType;
                requestVM.PermissionRequest.Description = pendingRequest.Description;
                requestVM.PermissionRequest.StartDate = pendingRequest.StartDate;
                requestVM.PermissionRequest.EndDate = pendingRequest.EndDate;
                requestVM.PermissionRequest.Status = pendingRequest.Status;
                var user = await _userService.GetUserById($"{pendingRequest.UserId}");
                requestVM.EmployeeName = user.UserName;
                VMs.Add(requestVM);
            }
            return View(VMs);

        }

       
        public async Task<IActionResult> Details(Guid id)
        {
            var request = await _permissionRequestService.GetById(x => x.Id ==id);
            if (request == null) return NotFound();
            return View(request);
        }

       
        [HttpPost]
        public async Task<IActionResult> Approve(Guid id)
        {
            var request = await _permissionRequestService.GetById(x => x.Id ==id);
            request.ApprovedBy = User.Identity.Name;
            
            var success = await _permissionRequestService.ApproveRequest(request);
            if (!success) return BadRequest();
            return RedirectToAction(nameof(Index));
        }

     
        [HttpPost]
        public async Task<IActionResult> Reject(Guid id)
        {
            var request = await _permissionRequestService.GetById(x => x.Id == id);
            request.ApprovedBy = User.Identity.Name;

            var success = await _permissionRequestService.RejectRequest(request);
            if (!success) return BadRequest();
            return RedirectToAction(nameof(Index));
        }
    }
}
