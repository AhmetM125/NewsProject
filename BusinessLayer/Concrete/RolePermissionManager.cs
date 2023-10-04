using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class RolePermissionManager : IRolePermissionService
    {
        private readonly IRolePermissionDA roleDal;
        public RolePermissionManager(IRolePermissionDA rolePermissionDal)
        {
            roleDal = rolePermissionDal;
        }

        public async Task CreatePermission(RolePermission rolePermission)
        {
            rolePermission.G_Id = Guid.NewGuid();
            await roleDal.Insert(rolePermission);
        }

        public async Task DeleteRolePermission(RolePermission rolePermission)
        {
            await roleDal.DeleteByEntity(rolePermission);
        }

        public async Task<List<RolePermission>> GetAllRolePermission()
        {
            var list = await roleDal.GetAll();
            return list.ToList();
        }

        public async Task<ICollection<RolePermission>> GetRolePermissionByIdList(int RoleId)
        {
            var list = await roleDal.GetAll();
            list = list.Where(x => x.RoleId == RoleId).ToList();
            return (ICollection<RolePermission>)list;
        }

        public async Task<RolePermission> GetRolePermissionById(int RoleId, int PermissionId)
        {
            var list = await roleDal.GetAll();
            var RolePermission = list.Where(x => x.RoleId == RoleId && x.PermissionId == PermissionId).FirstOrDefault();
            return RolePermission;
        }
    }
}
