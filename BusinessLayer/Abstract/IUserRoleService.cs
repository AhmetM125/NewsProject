using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IUserRoleService
    {
        List<UserRole> GetRolesOfUser(Guid U_Id);
        void DeleteRoleOfUser(Guid UserId, int roleId);
        void InsertNewRoleOfUser(UserRole role);
        void DeleteRoleOfUser(UserRole role);
        UserRole GetUserRoleById(Guid UserId,int RoleId);


    }
}
