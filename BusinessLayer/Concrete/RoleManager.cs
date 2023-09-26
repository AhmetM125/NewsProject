using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public void DeleteRole(Role role)
        {
            _roleDal.Delete(role);
        }

        public List<Role> GetAllRoles()
        {
            return _roleDal.List();
        }
        public Role GetRoleById(int roleId)
        {
            return _roleDal.Get(x=>x.Id == roleId);
        }

        

        public void NewRole(Role role)
        {
           _roleDal.Insert(role);
        }

        public void UpdateRole(Role role)
        {
            _roleDal.Update(role);
        }
    }
}
