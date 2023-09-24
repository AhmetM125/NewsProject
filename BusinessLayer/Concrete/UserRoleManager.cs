using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        EfUserRoleDal _UserRoleDal { get; set; }
        public UserRoleManager(EfUserRoleDal efUserRoleDal)
        {
            _UserRoleDal = efUserRoleDal;
        }

        public List<UserRole> GetRolesOfUser(Guid U_Id)
        {
            List<UserRole> UserRoleList = _UserRoleDal.List(x => x.UserId == U_Id);
            return UserRoleList;
            
        }

        public void DeleteRoleOfUser(Guid UserId, int roleId)
        {
            _UserRoleDal.DeleteW(x=>x.UserId == UserId &&  x.RoleId == roleId);
        }
    }
}
