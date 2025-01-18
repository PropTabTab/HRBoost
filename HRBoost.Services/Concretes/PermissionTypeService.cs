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
    public class PermissionTypeService :BaseServices<PermissionType>,IPermissionTypeService
    {
        public PermissionTypeService(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            
        }
    }
}