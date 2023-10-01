using BusinessLayer.DapperRepository;
using DataAccessLayer.Dapper;
using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface IRoleDA : IRepositoryDAP<Role>
    {

        Task<IEnumerable<Role>> GetAllRoleAsync();
        Task<Role> GetRoleByIdAsync(int id);
        Task<bool> DeleteRoleById(int id);
        Task<bool> UpdateRole(Role role);
        Task<bool> CreateRoleAsync(Role role);
    }
}
