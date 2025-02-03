using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Entity
{
    public class PermissionType : BaseEntity
    {
        public string Name { get; set; } 
        public string Description { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public int? Days { get; set; }
        public virtual List<PermissionRequest> PermissionRequests { get; set; }
    }
}