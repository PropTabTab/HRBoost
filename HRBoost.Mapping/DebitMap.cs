using HRBoost.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Mapping
{
    public class DebitMap:BaseMap<Debit>
    {
        public override void Configure(EntityTypeBuilder<Debit> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            base.Configure(builder);
        }
    }
}
