using HRBoost.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HRBoost.Mapping;


namespace HRBoost.ContextDb.Concrete
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