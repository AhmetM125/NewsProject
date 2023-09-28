using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer;

namespace DataAccessLayer.Concrete
{
    public class EfUserRoleDal : GenericRepository<UserRole>, IUserRoleDal
    {
        public EfUserRoleDal(NEUContext context) : base(context)
        {
        }
    }
}
