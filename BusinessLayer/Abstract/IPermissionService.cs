using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IPermissionService
    {
        Task<ICollection<Permission>> GetAllPermission();
        Task<Permission?> GetPermission(int id);
        Task DeletePermission(Permission permission);
        Task CreatePermission(Permission permission);
        Task UpdatePermission(Permission permission);
    }
}
