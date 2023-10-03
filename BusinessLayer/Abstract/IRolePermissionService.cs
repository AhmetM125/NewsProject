using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IRolePermissionService
    {
        Task<List<RolePermission>> GetAllRolePermission();
        Task<ICollection<RolePermission>> GetRolePermissionByIdList(int RoleId);
        Task DeleteRolePermission(RolePermission rolePermission);
        Task<RolePermission> GetRolePermissionById(int RoleId, int PermissionId);
        Task CreatePermission(RolePermission rolePermission);
    }
}
