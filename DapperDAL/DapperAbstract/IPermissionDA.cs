using BusinessLayer.DapperRepository;
using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface IPermissionDA : IRepositoryDAP<Permission>
    {
        
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task<Permission> GetPermissionsByIdAsync(int id);
        Task<bool> DeletePermissionsById(int id);
        Task<bool> UpdatePermission(Permission permission);
        Task<bool> CreatePermissionAsync(Permission permission);
    }
}
