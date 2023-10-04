using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IUserRoleService
    {
        Task<List<UserRole>> GetRolesOfUser(Guid U_Id);
        Task InsertNewRoleOfUser(UserRole role);
        Task DeleteRoleOfUser(UserRole role);
        Task<UserRole> GetUserRoleById(Guid UserId, int RoleId);


    }
}
