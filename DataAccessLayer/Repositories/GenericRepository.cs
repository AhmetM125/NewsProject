using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly NEUContext _context;
        public GenericRepository(NEUContext context)
        {
            _context = context;
        }
        public void Delete(T p)
        {
            var deletedEntity = _context.Entry(p);
            deletedEntity.State = EntityState.Deleted;

            _context.SaveChanges();
        }
        public void Delete(Expression<Func<T, bool>> filter)
        {
            var ValuesToDelete = _context.Set<T>().Where(filter);
            foreach (var item in ValuesToDelete)
            {
                _context.Set<T>().Remove(item);
            }
        }

        public T? Get(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().FirstOrDefault(filter);
        }

        public void Insert(T p)
        {
            var addedEntity = _context.Entry(p);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public List<T> List()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedEntity = _context.Entry(p);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
