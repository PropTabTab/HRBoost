using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Entity
{
    public class Business:BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public string BusinessName { get; set; }

        public string? BusinessComment { get; set; }

        public int? BusinessStar {  get; set; }

        public string? BusinessAdress {  get; set; }

        public string BusinessPhone { get; set; }

        public DateTime SubscriptionStartTime { get; set; }
        public DateTime SubscriptionFinishTime { get; set; }

        public byte[]? BusinessLogo { get; set; }

        public virtual Subscription Subscription { get; set; }
        public virtual List<User> Users { get; set; }

    }
}
