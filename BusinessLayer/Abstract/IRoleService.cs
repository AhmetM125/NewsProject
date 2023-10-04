using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IRoleService
    {
        Task<Role> GetRoleById(int roleId);
        Task<List<Role>> GetAllRoles();
        Task UpdateRole(Role role);
        Task DeleteRole(Role role);
        Task NewRole(Role role);
    }
}
