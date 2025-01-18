using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Entity
{
	public class Currency:BaseEntity
	{
        public string Symbol { get; set; }
        public string Code { get; set; }

        public string Name { get; set; }

        public decimal ExchangeRate { get; set; }


    }
}
