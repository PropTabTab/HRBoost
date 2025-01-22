using HRBoost.ContextDb.Abstract;
using HRBoost.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace HRBoost.ContextDb.Concrete
{
    public class PermissionTypeRepository : IPermissionTypeRepository
    {
        private readonly BaseContext _context;

        public PermissionTypeRepository(BaseContext context)
        {
            _context = context;
        }


        public List<PermissionType> GetAll()
        {
            var permissionTypes = _context.PermissionTypes;
            if (permissionTypes == null || !permissionTypes.Any())
            {
                throw new Exception("PermissionTypes tablosu boş veya veri bulunamadı.");
            }
            return permissionTypes.ToList();
        }

        
        public void Add(PermissionType permissionType)
        {
            _context.PermissionTypes.Add(permissionType);
            _context.SaveChanges();
        }

        
        public PermissionType GetById(Guid id)
        {
            return _context.PermissionTypes.FirstOrDefault(x => x.Id == id);
        }

        
        public void Delete(Guid id)
        {
            var permissionType = _context.PermissionTypes.FirstOrDefault(x => x.Id == id);
            if (permissionType != null)
            {
                _context.PermissionTypes.Remove(permissionType);
                _context.SaveChanges();
            }
        }

      
        public void Update(PermissionType permissionType)
        {
            _context.PermissionTypes.Update(permissionType);
            _context.SaveChanges();
        }
    }
}
