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
    public class SubscriptionMap : BaseMap<Subscription>
    {
        public override void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.Property(x => x.Price).HasColumnType("Money");
            builder.HasData(new Subscription { SubscriptionType = "Free", Price = 0, CreateDate = DateTime.Now, CreatedBy = "Basedefault", Duration = 0, Id = Guid.NewGuid(), ModifiedBy = "Basedefault", Status = Shared.Enums.Status.Active, ModifiedDate = DateTime.Now });
            builder.HasData(new Subscription { SubscriptionType = "Monthly", Price = 149.90m, CreateDate = DateTime.Now, CreatedBy = "Basedefault", Duration = 1, Id = Guid.NewGuid(), ModifiedBy = "Basedefault", Status = Shared.Enums.Status.Active, ModifiedDate = DateTime.Now });
            builder.HasData(new Subscription { SubscriptionType = "Yearly", Price = 1499.90m, CreateDate = DateTime.Now, CreatedBy = "Basedefault", Duration = 12, Id = Guid.NewGuid(), ModifiedBy = "Basedefault", Status = Shared.Enums.Status.Active, ModifiedDate = DateTime.Now });
            builder.HasData(new Subscription { SubscriptionType = "Premium", Price = 12999.90m, CreateDate = DateTime.Now, CreatedBy = "Basedefault", Duration = 100, Id = Guid.NewGuid(), ModifiedBy = "Basedefault", Status = Shared.Enums.Status.Active, ModifiedDate = DateTime.Now });


            base.Configure(builder);

        }
    }
}
