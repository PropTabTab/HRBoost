using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Entity
{
    public class PermissionTypeRecord
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        [Required] 
        public string Name { get; set; }

        [Required]
        public string PermissionType { get; set; } = string.Empty;

      
    }
   
}

