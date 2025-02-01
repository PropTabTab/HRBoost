  using HRBoost.ContextDb.Abstract;
using HRBoost.Entity;
using HRBoost.Shared.Enums;
using HRBoost.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HRBoost.ContextDb.Concrete
{
	public class BaseContext : IdentityDbContext<User, Role, Guid>, IEFContext
	{
		public DbSet<Currency> Currencies { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
		public DbSet<Business> Businesses { get; set; }
		public DbSet<Subscription> Subscriptions { get; set; }
		public DbSet<FileType> FileTypes { get; set; }

        public BaseContext(DbContextOptions options) : base(options)
		{

        }

		protected override void OnModelCreating(ModelBuilder builder)
		{

            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new CurrencyMap());
			builder.ApplyConfiguration(new FileTypeMap());
            builder.ApplyConfiguration(new PermissionTypeMap());
            builder.ApplyConfiguration(new BusinessMap());
            builder.ApplyConfiguration(new SubscriptionMap());
			builder.ApplyConfiguration(new DocumentMap());

            base.OnModelCreating(builder);
		}

        public override DbSet<TEntity> Set<TEntity>()
		{
			return base.Set<TEntity>();
		}

		EntityEntry IEFContext.Entry<TEntity>(TEntity entity)
		{
			return base.Entry<TEntity>(entity);
		}

		public async Task<int> SaveChanges(CancellationToken cancellationToken)
		{
			List<EntityEntry> entityEntries = new List<EntityEntry>();
			DateTime now = DateTime.Now;
			var entries = ChangeTracker.Entries();
			if (entries != null)
			{
				entries = entries.Where(x => typeof(BaseEntity).IsAssignableFrom(x.Entity.GetType())).ToList();
			}
			foreach (var entry in entries)
			{
				if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
				{
					if (entry.Entity is BaseEntity baseEntity)
					{
						baseEntity.ModifiedDate = now;
						baseEntity.ModifiedBy = "baseDefault";
						if (entry.State == EntityState.Added)
						{
							baseEntity.CreateDate = now;
							baseEntity.CreatedBy = "baseDefault";
							baseEntity.Status = Status.Active;
							entityEntries.Add(entry);
						}
					}
				}
			}
			int rowCount = 0;
			try
			{
               rowCount= await base.SaveChangesAsync(cancellationToken);
            }
			catch (Exception ex)
			{

				throw new Exception($"Veri Kaydetme İşleminde Bir Hata Oluştu =>{ex.Message}");
			}
			return rowCount;
		}

		public IEnumerable<TEntity> SqlQuery<TEntity>(FormattableString query)
		{
			return base.Database.SqlQuery<TEntity>(query);
		}

		public TResult SqlQuery<TResult>(string query, params object[] parameters)
		{
			return Database.SqlQueryRaw<TResult>(query, parameters).ToListAsync().Result.First();
		}
	

		
	}
}
