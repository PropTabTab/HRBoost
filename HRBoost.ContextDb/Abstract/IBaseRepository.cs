using HRBoost.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.ContextDb.Abstract
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		Task AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
		Task<List<T>> GetAll();
		Task<T> GetById(Expression<Func<T, bool>> exp);
		Task<List<T>> GetBy(Expression<Func<T, bool>> exp);
		Task<List<T>> GetAllActive();
        Task GetByIdAsync(Guid id);
    }
}
