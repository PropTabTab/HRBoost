using HRBoost.Entity;

namespace HRBoost.UI.Areas.Personel.Models
{
    public class PersonelVM
    {
        public List<Holiday> holidays { get; set; }
        public int permissionDuration { get; set; }

        public decimal approvedExpense {  get; set; }
        public decimal pendingExpense { get; set; }
    }
}
