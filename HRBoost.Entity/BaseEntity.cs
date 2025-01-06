using HRBoost.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Entity
{
	public class BaseEntity:IEntity
	{
		public Guid Id { get; set; }
		public Status Status { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
	}
}
