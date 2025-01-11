using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Entity
{
    public class Business:BaseEntity
    {
        public Subscription Subscription { get; set; }
    }
}
