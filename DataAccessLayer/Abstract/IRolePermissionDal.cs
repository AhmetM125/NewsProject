using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IRolePermissionDal : IRepository<RolePermission>
    {
    }
}
