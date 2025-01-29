using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Entity
{
    public class Expense:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Quantity { get; set; }

        public Guid PersonelID { get; set; }

        public Guid BusinessID { get; set; }





    }
}
