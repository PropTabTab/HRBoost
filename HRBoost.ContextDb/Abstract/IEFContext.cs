using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.ContextDb.Abstract
{
	public interface IEFContext
	{
		EntityEntry Entry(object entry);
		EntityEntry Entry<TEntity>(TEntity entity) where TEntity : class;

		int SaveChanges();

		Task<int> SaveChanges(CancellationToken cancellationToken);
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		IEnumerable<TEntity> SqlQuery<TEntity>(FormattableString query);
		TResult SqlQuery<TResult>(string query, params object[] parameters);
	}
}
