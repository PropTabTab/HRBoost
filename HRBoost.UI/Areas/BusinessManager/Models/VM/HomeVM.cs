using HRBoost.Entity;

namespace HRBoost.UI.Areas.BusinessManager.Models.VM
{
    public class HomeVM
    {
        public List<User> Personel { get; set; }
        public decimal MyProperty { get; set; }
        public decimal approvedExpense { get; set; }
        public decimal pendingExpense { get; set; }

        public int approvedPermission { get; set; }
        public int pendingPermission { get; set; }
    }
}
