using HRBoost.Entity;

namespace HRBoost.UI.Areas.Personel.Models
{
    public class PermissionRequestVM
    {
        public PermissionRequest PermissionRequest { get; set; }
        public List<PermissionType> PermissionTypes { get; set; }
    }
}
