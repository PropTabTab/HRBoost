using HRBoost.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.ContextDb.Abstract
{
    public interface IPermissionTypeRepository
    {
        List<PermissionType> GetAll();
        PermissionType GetById(Guid id);
        void Add(PermissionType permissionType);
        void Delete(Guid id);
        void Update(PermissionType permissionType);
    }
}
