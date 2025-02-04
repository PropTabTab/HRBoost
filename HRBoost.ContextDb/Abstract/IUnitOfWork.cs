using HRBoost.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.ContextDb.Abstract
{
	public interface IUnitOfWork
	{
        object GetRepository<T>();
        IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        void SaveChanges();
        Task<int> SaveChangesAsync();
	}
}
