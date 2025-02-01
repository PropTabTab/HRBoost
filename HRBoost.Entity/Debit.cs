using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Entity
{
    public class Debit: BaseEntity
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public Guid UserId { get; set; }
        public string? Description { get; set; }
        public Guid BusinessId { get; set; }

        //Navi
        public virtual User User { get; set; }
        public virtual Business Business { get; set; }

    }
}
