using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Entity
{
    public class Document : BaseEntity
    {

        public Guid UserId { get; set; }
        public string FileName { get; set; }
        public byte[] File {  get; set; }
        public DateTime UploadDate { get; set; }

        public virtual User User { get; set; }
    }
}
