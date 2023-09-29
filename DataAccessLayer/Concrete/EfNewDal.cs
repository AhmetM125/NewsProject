using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer;

namespace DataAccessLayer.Concrete
{
    public class EfNewDal : GenericRepository<News>, INewDal
    {
        public EfNewDal(NEUContext context) : base(context)
        {
        }
    }
}
