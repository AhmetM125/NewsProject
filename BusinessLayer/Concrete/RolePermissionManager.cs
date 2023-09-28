using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class RolePermissionManager : IRolePermissionService
    {
        private readonly IRolePermissionDal roleDal;
        public RolePermissionManager(IRolePermissionDal rolePermissionDal)
        {
                roleDal = rolePermissionDal;
        }

        public void CreatePermission(RolePermission rolePermission)
        {
            roleDal.Insert(rolePermission);
        }

        public void DeleteRolePermission(RolePermission rolePermission)
        {
            roleDal.Delete(rolePermission);
        }

        public List<RolePermission> GetAllRolePermission()
        {
            return roleDal.List();
        }

        public ICollection<RolePermission> GetRolePermissionById(int RoleId)
        {
           return roleDal.List(x => x.RoleId == RoleId);
        }

        public RolePermission GetRolePermissionById(int RoleId, int PermissionId)
        {
           return roleDal.Get(x=>x.RoleId == RoleId &&  x.PermissionId == PermissionId);
        }
    }
}
