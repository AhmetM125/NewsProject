using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IPermissionService
    {
        ICollection<Permission> GetAllPermission();
        Permission GetPermission(int id);
        void DeletePermission(Permission permission);
        void CreatePermission(Permission permission);
        void UpdatePermission(Permission permission);
    }
}
