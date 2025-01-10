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
	public class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
	{

		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.HasKey(x => x.Id);


			builder.Property(x => x.Status)
				.IsRequired();

			builder.Property(x => x.CreatedBy)
				.HasMaxLength(50)
				.HasColumnType("varchar")
				.IsRequired();
			builder.Property(x => x.CreateDate)
				.IsRequired();
			builder.Property(x => x.ModifiedBy)
				.HasMaxLength(50)
				.HasColumnType("varchar")
				.IsRequired();
			builder.Property(x => x.ModifiedDate)
				.IsRequired();
		}
	}
}