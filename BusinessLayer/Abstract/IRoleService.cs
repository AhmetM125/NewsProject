using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IRoleService
    {
        Role GetRoleById(int roleId);
        List<Role> GetAllRoles();

        void UpdateRole(Role role);
        void DeleteRole(Role role);
        void NewRole(Role role);
    }
}
