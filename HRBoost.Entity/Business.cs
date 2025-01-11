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

        public virtual Subscription Subscription { get; set; }
    }
}
