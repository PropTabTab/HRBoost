using HRBoost.ContextDb.Abstract;
using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Services.Concretes
{
	public class BaseServices<T> : IService<T> where T : BaseEntity
	{
		protected readonly IUnitOfWork _unitOfWork;
		private readonly IBaseRepository<T> _baseRepository;

		public BaseServices(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
            _baseRepository = _unitOfWork.Repository<T>();
		}

		public virtual async Task AddAsync(T entity)
		{
			try
			{
				await _baseRepository.AddAsync(entity);
				await _unitOfWork.SaveChangesAsync();
			}
			catch (Exception ex)
			{

				throw new Exception("Ekleme işlemleri sırasında bir hata oluştu..." + "(" + ex.Message + ")");
			}
		}

		public virtual async Task UpdateAsync(T entity)
		{
			try
			{
				await _baseRepository.UpdateAsync(entity);
				await _unitOfWork.SaveChangesAsync();
			}
			catch (Exception ex)
			{

				throw new Exception("Güncelleme işlemleri sırasında bir hata oluştu..." + "(" + ex.Message + ")");
			}
		}

		public virtual async Task DeleteAsync(T entity)
		{
			try
			{
				await _baseRepository.DeleteAsync(entity);
				await _unitOfWork.SaveChangesAsync();
			}
			catch (Exception ex)
			{

				throw new Exception("Silme işlemleri sırasında bir hata oluştu..." + "(" + ex.Message + ")");
			}
		}

		public virtual async Task<List<T>> GetAll()
		{
			return await _baseRepository.GetAllActive();
		}

        public virtual async Task<List<T>> GetAllPending()
        {
            return await _baseRepository.GetBy(x=>x.Status!=Shared.Enums.Status.Deleted);
        }

        public virtual async Task<List<T>> GetBy(Expression<Func<T, bool>> exp)
		{
			return await _baseRepository.GetBy(exp);
		}

		public async virtual Task<T> GetById(Expression<Func<T, bool>> exp)
		{
			return await _baseRepository.GetById(exp);
		}
	}
}