using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
	public class GenericRepository<T> : IRepository<T> where T : class
	{
		private NEUContext _NeuContext = new NEUContext();
		private readonly DbSet<T> _Object;

		public GenericRepository(/*NEUContext context*/)
		{
			/*_NeuContext.Configuration.LazyLoadingEnabled = true;
			_NeuContext.Configuration.ProxyCreationEnabled = true;*/

			/*_NeuContext = context;*/
			_Object = _NeuContext.Set<T>();
		}
		public void Delete(T p)
		{
			var deletedEntity = _NeuContext.Entry(p);
			deletedEntity.State = EntityState.Deleted;

			_NeuContext.SaveChanges();
		}

		public T Get(Expression<Func<T, bool>> filter)
		{
			return _Object.SingleOrDefault(filter);
		}

		public void Insert(T p)
		{
			var addedEntity = _NeuContext.Entry(p);
			addedEntity.State = EntityState.Added;
			_NeuContext.SaveChanges();
		}

		public List<T> List()
		{
			return _Object.ToList();
		}

		public List<T> List(Expression<Func<T, bool>> filter)
		{
			return _Object.Where(filter).ToList();
		}

		public void Update(T p)
		{
			var updatedEntity = _NeuContext.Entry(p);
			updatedEntity.State = EntityState.Modified;
			_NeuContext.SaveChanges();
		}
	}
}
