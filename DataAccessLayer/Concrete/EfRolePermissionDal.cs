using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer;

namespace DataAccessLayer.Concrete
{
    public class EfRolePermissionDal : GenericRepository<RolePermission>, IRolePermissionDal
    {
        public EfRolePermissionDal(NEUContext context) : base(context)
        {
        }
    }
}
