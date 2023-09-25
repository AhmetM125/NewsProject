using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
