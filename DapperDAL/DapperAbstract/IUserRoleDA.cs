using BusinessLayer.DapperRepository;
using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface IUserRoleDA : IRepositoryDAP<UserRole>
    {
        Task<IEnumerable<UserRole>> GetAllUserRolesAsync();
        Task<UserRole> GetUserRoleByIdAsync(Guid Uid, int RoleId);
        Task<bool> DeleteUserRoleById(Guid Uid, int RoleId);
        Task<bool> UpdateUserRole(UserRole UserRole);
        Task<bool> CreateUserRoleAsync(UserRole UserRole);
    }
}
