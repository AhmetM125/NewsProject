using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IRolePermissionService
    {
        List<RolePermission> GetAllRolePermission();
        ICollection<RolePermission> GetRolePermissionById(int RoleId);
        void DeleteRolePermission(RolePermission rolePermission);
        RolePermission GetRolePermissionById(int RoleId, int PermissionId);
        void CreatePermission(RolePermission rolePermission);
    }
}
