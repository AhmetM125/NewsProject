using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Concrete
{
    public class RolePermissionManager : IRolePermissionService
    {
        IRolePermissionDal roleDal;
        public RolePermissionManager(IRolePermissionDal _roleDal)
        {
                roleDal = _roleDal;
        }
    }
}
