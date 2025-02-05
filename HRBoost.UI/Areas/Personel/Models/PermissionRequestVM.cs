using HRBoost.Entity;

namespace HRBoost.UI.Areas.Personel.Models
{
    public class PermissionRequestVM
    {
      
        public string EmployeeName { get; set; } 
 
       
        public PermissionRequest PermissionRequest { get; set; }
        public List<PermissionType> PermissionTypes { get; set; }
    }
}
