using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer;

namespace DataAccessLayer.Concrete
{
    public class EfPermissionDal : GenericRepository<Permission>, IPermissionDal
    {
        public EfPermissionDal(NEUContext context) : base(context)
        {
        }
    }
}
