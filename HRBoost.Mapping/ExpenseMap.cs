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
    public class ExpenseMap : BaseMap<Expense>
    {
        public override void Configure(EntityTypeBuilder<Expense> builder) 
        {
            builder.Property(x => x.Quantity).HasColumnType("Money");
            base.Configure(builder);
        }
        
        
    }
}
