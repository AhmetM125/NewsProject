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
            _UserRoleDal.DeleteW(x => x.UserId == UserId && x.RoleId == roleId);
        }

        public void InsertNewRoleOfUser(UserRole role)
        {
            _UserRoleDal.Insert(role);
        }
        public void DeleteRoleOfUser(UserRole role)
        {
            _UserRoleDal.Delete(role);
        }

        public UserRole GetUserRoleById(Guid UserId, int RoleId)
        {
            return _UserRoleDal.Get(x => x.RoleId == RoleId && x.UserId == UserId);
        }
    }
}
