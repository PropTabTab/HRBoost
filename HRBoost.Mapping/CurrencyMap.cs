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
	public class CurrencyMap:BaseMap<Currency>
	{
        public override void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.Property(X => X.ExchangeRate).HasColumnType("money");
            base.Configure(builder);
        }

    }
}
