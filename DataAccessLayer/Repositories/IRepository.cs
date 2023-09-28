using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public interface IRepository<T>
    {
        void Delete(Expression<Func<T, bool>> predicate);
        List<T> List();

        void Insert(T p);

        void Update(T p);

        void Delete(T p);

        List<T> List(Expression<Func<T, bool>> filter);

        T Get(Expression<Func<T, bool>> filter);

    }
}
