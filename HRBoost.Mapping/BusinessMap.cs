using HRBoost.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Mapping
{
    public class BusinessMap : BaseMap<Business>
    {
        public override void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.Property(x => x.BusinessComment).HasMaxLength(300);
            base.Configure(builder);
        }
    }
}
