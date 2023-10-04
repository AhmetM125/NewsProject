using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        private readonly IUserRoleDA _userRoleDal;
        public UserRoleManager(IUserRoleDA efUserRoleDal)
        {
            _userRoleDal = efUserRoleDal;
        }

        public async Task<List<UserRole>> GetRolesOfUser(Guid U_Id)
        {

            List<UserRole> UserRoleList = (List<UserRole>)await _userRoleDal.GetAll();
            UserRoleList = UserRoleList.Where(x => x.UserId == U_Id).ToList();
            return UserRoleList;

        }
        public async Task InsertNewRoleOfUser(UserRole role)
        {
            role.G_Id = Guid.NewGuid();
          await  _userRoleDal.Insert(role);
        }
        public async Task DeleteRoleOfUser(UserRole role)
        {
            await _userRoleDal.DeleteByEntity(role);
        }

        public async Task<UserRole> GetUserRoleById(Guid UserId, int RoleId)
        {
            var list = await _userRoleDal.GetAll();
            var obj = list.Where(x => x.UserId == UserId && x.RoleId == RoleId).FirstOrDefault();
            return obj;
        }
    }
}
