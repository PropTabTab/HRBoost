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

        public Task<string?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetAllRequestsAsync()
        {
            throw new NotImplementedException();
        }
    }
}