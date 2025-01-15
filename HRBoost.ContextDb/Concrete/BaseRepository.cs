using HRBoost.ContextDb.Abstract;
using HRBoost.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.ContextDb.Concrete
{
	public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
	{
		private readonly IEFContext _context;
		private readonly DbSet<T> _table;

		public BaseRepository(IEFContext context)
		{
			_context = context;
			_table = context.Set<T>();
		}

		public virtual async Task AddAsync(T entity)
		{
			try
			{
				await _table.AddAsync(entity);
			}
			catch (Exception ex)
			{

				throw new Exception("Ekleme işlemleri sırasında bir hata oluştu..." + "(" + ex.Message + ")");
			}
		}

		public async Task UpdateAsync(T entity)
		{
			try
			{
				_context.Entry(entity).State = EntityState.Modified;
			}
			catch (Exception ex)
			{

				throw new Exception("Güncelleme işlemleri sırasında bir hata oluştu... " + "(" + ex.Message + ")");
			}
		}

		public async Task DeleteAsync(T entity)
		{
			entity.Status = Shared.Enums.Status.Deleted;
			await UpdateAsync(entity);
		}

		public async Task<List<T>> GetAll()
		{
			return await _table.ToListAsync();
		}

		public async Task<List<T>> GetAllActive()
		{
			return await _table.Where(x => x.Status == Shared.Enums.Status.Active).ToListAsync();
		}

		public async Task<List<T>> GetBy(Expression<Func<T, bool>> exp)
		{
			return await _table.Where(exp).ToListAsync();
		}

		public async Task<T> GetById(Expression<Func<T, bool>> exp)
		{
			return await _table.Where(exp).FirstAsync();
		}


	}
}