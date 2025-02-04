using HRBoost.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Mapping
{
    public class PermissionRequestMap : BaseMap<PermissionRequest>
    {
        public override void Configure(EntityTypeBuilder<PermissionRequest> builder)
        {
            base.Configure(builder); 

            builder.ToTable("PermissionRequests");

            builder.Property(p => p.PermissionType)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Description)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(p => p.StartDate)
                   .IsRequired();

            builder.Property(p => p.EndDate)
                   .IsRequired();

            builder.Property(p => p.Status)
                   .HasDefaultValue("Pending")
                   .HasMaxLength(50);

            builder.Property(p => p.ApprovedBy)
                   .HasMaxLength(100);

            builder.Property(p => p.DecisionDate)
                   .IsRequired(false);
        }
    }
}
