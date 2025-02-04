using HRBoost.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Entity
{
	public class User : IdentityUser<Guid>, IEntity
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
        public string? BusinessName { get; set; }
        public byte[]? UserPhoto { get; set; }
        public string? Position { get; set; }


        public Guid? BusinessId { get; set; }
        [NotMapped]
        public string? Password { get; set; }
        //public Guid Id { get; set; }

        public Status Status { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }

		//virtual

		public virtual Business Business { get; set; }

        public virtual List<Expense> Expenses { get; set; }
        public virtual List<Debit> Debits { get; set; }

        public virtual List<Document>   Documents { get; set; }

    }
}
