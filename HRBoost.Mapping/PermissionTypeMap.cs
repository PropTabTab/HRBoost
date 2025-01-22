using HRBoost.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Mapping
{
    public class PermissionTypeMap : BaseMap<PermissionType>
    {
        public override void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            base.Configure(builder);

           
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Description)
                   .HasMaxLength(255); 
        }
    }
}