using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleDA _roleDal;
        public RoleManager(IRoleDA roleDal)
        {
            _roleDal = roleDal;
        }

        public async Task DeleteRole(Role role)
        {
            await _roleDal.DeleteByEntity(role);
        }

        public async Task<List<Role>> GetAllRoles()
        {
            var list = await _roleDal.GetAll();
            return list.ToList();
        }
        public async Task<Role> GetRoleById(int roleId)
        {
            var role = await _roleDal.GetById(roleId.ToString());
            return role;
        }

        public async Task NewRole(Role role)
        {
            await _roleDal.Insert(role);
        }

        public async Task UpdateRole(Role role)
        {
           await _roleDal.Update(role);
        }
    }
}
