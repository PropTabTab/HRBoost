using HRBoost.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Entity
{
	public interface IEntity
	{
		Guid Id { get; set; }
		Status Status { get; set; }
		DateTime CreateDate { get; set; }
		DateTime ModifiedDate { get; set; }
		string CreatedBy { get; set; }
		string ModifiedBy { get; set; }
	}
}
