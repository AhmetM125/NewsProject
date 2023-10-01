using BusinessLayer.DapperRepository;
using DataAccessLayer.Dapper;
using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface IRolePermissionDa : IRepositoryDAP<RolePermission>
    {
        Task<IEnumerable<RolePermission>> GetAllRolePermissionsAsync();
        Task<RolePermission> GetRolePermissionByIdAsync(int RoleId, int PermissionId);
        Task<bool> DeleteRolePermissionById(int RoleId, int PermissionId);
        Task<bool> UpdateRolePermission(RolePermission RolePermission);
        Task<bool> CreateRolePermissionAsync(RolePermission RolePermission);
    }
}
