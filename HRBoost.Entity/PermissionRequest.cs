using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Entity
{
    public class PermissionRequest : BaseEntity
    {
        [Required]
        public string PermissionType { get; set; } 

        [Required]
        [MaxLength(500)]
        public string Description { get; set; } 

        [Required]
        public DateTime StartDate { get; set; } 

        [Required]
        public DateTime EndDate { get; set; } 

        public string Status { get; set; } = "Pending"; 

        public string? ApprovedBy { get; set; } 

        public DateTime? DecisionDate { get; set; } 
    }
}
