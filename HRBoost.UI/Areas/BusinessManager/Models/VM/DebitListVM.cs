using HRBoost.Entity;

namespace HRBoost.UI.Areas.BusinessManager.Models.VM
{
    public class DebitListVM
    {
        public Guid UserId { get; set; }
        public List<Debit> Debits { get; set; }
    }
}
