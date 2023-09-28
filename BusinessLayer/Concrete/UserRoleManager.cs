using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        private readonly IUserRoleDal _userRoleDal;
        public UserRoleManager(IUserRoleDal efUserRoleDal)
        {
            _userRoleDal = efUserRoleDal;
        }

        public List<UserRole> GetRolesOfUser(Guid U_Id)
        {

            List<UserRole> UserRoleList = _userRoleDal.List(x => x.UserId == U_Id);
            return UserRoleList;

        }

        public void DeleteRoleOfUser(Guid UserId, int roleId)
        {
            _userRoleDal.DeleteW(x => x.UserId == UserId && x.RoleId == roleId);
        }

        public void InsertNewRoleOfUser(UserRole role)
        {
            _userRoleDal.Insert(role);
        }
        public void DeleteRoleOfUser(UserRole role)
        {
            _userRoleDal.Delete(role);
        }

        public UserRole GetUserRoleById(Guid UserId, int RoleId)
        {
            return _userRoleDal.Get(x => x.RoleId == RoleId && x.UserId == UserId);
        }
    }
}
