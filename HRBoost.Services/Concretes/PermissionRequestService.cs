using Azure.Core;
using HRBoost.ContextDb.Abstract;
using HRBoost.ContextDb.Concrete;
using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Services.Concretes
{
    public class PermissionRequestService : BaseServices<PermissionRequest>, IPermissionRequestService
    {
        public PermissionRequestService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<bool> ApproveRequest(PermissionRequest request)
        {
            request.Status = Shared.Enums.Status.Approved;
            await this.UpdateAsync(request);
            return true;
        }

        public async Task<bool> RejectRequest(PermissionRequest request)
        {
            request.Status = Shared.Enums.Status.Deleted;
            await this.UpdateAsync(request);
            return true;
        }
    }
}