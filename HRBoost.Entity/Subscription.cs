using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Entity
{
    public class Subscription : BaseEntity
    {
        public string SubscriptionType { get; set; }
        public DateTime SubscriptionStartTime { get; set; }
        public DateTime SubscriptionFinishTime { get; set; }
        public decimal Price { get; set; }

        //Navi
        public virtual List<Business> Businesses { get; set; }
    }
}
