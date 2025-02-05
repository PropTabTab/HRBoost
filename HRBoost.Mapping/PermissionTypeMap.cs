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
            builder.HasData(new PermissionType
            {
                Name = "Yıllık İzin",
                Description = "",
                CreateDate =
               DateTime.Now,
                CreatedBy = "Basedefault",
                Id = Guid.NewGuid(),
                ModifiedBy = "Basedefault",
                Status = Shared.Enums.Status.Active,
                ModifiedDate = DateTime.Now
            });
            builder.HasData(new PermissionType
            {
                Name = "Sağlık İzin",
                Description = "",
                CreateDate =
                DateTime.Now,
                CreatedBy = "Basedefault",
                Id = Guid.NewGuid(),
                ModifiedBy = "Basedefault",
                Status = Shared.Enums.Status.Active,
                ModifiedDate = DateTime.Now
            }); builder.HasData(new PermissionType
            {
                Name = "Kişisel İzin",
                Description = "",
                CreateDate =
                DateTime.Now,
                CreatedBy = "Basedefault",
                Id = Guid.NewGuid(),
                ModifiedBy = "Basedefault",
                Status = Shared.Enums.Status.Active,
                ModifiedDate = DateTime.Now
            }); builder.HasData(new PermissionType
            {
                Name = "Ebeveyn İzin",
                Description = "",
                CreateDate =
                DateTime.Now,
                CreatedBy = "Basedefault",
                Id = Guid.NewGuid(),
                ModifiedBy = "Basedefault",
                Status = Shared.Enums.Status.Active,
                ModifiedDate = DateTime.Now
            }); builder.HasData(new PermissionType
            {
                Name = "Eğitim İzin",
                Description = "",
                CreateDate =
                DateTime.Now,
                CreatedBy = "Basedefault",
                Id = Guid.NewGuid(),
                ModifiedBy = "Basedefault",
                Status = Shared.Enums.Status.Active,
                ModifiedDate = DateTime.Now
            }); builder.HasData(new PermissionType
            {
                Name = "Doğum İzin",
                Description = "",
                CreateDate =
                DateTime.Now,
                CreatedBy = "Basedefault",
                Id = Guid.NewGuid(),
                ModifiedBy = "Basedefault",
                Status = Shared.Enums.Status.Active,
                ModifiedDate = DateTime.Now
            });

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Description)
                   .HasMaxLength(255); 
        }
    }
}