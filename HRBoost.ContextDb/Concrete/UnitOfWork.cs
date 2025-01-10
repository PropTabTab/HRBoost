using HRBoost.ContextDb.Abstract;
using HRBoost.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.ContextDb.Concrete
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IEFContext _context;
		private readonly Dictionary<string, dynamic> _repositoryDictionary;

		public UnitOfWork(IEFContext context)
		{
			_context = context;
			_repositoryDictionary = new Dictionary<string, dynamic>();
		}

		public IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
		{
			var entityName = typeof(TEntity).Name;
			var repositoryCreated = _repositoryDictionary.ContainsKey(entityName);
			if (!repositoryCreated)
			{
				var newRepository = new BaseRepository<TEntity>(_context);
				_repositoryDictionary.Add(entityName, newRepository);
			}

			return _repositoryDictionary[entityName];
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChanges(new CancellationToken());
		}
	}
}
