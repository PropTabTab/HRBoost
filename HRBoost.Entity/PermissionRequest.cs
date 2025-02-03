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
     

        [Required(ErrorMessage = "İzin türü boş olamaz!")]
        public  Guid PermissionTypeId { get; set; }


        [Required(ErrorMessage = "Açıklama boş olamaz!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Başlangıç tarihi boş olamaz!")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi boş olamaz!")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

       

        public string? ApprovedBy { get; set; } 

        public DateTime? DecisionDate { get; set; } 
        public virtual PermissionType? PermissionType { get; set; }
    }
}
