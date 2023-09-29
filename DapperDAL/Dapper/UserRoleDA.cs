using BusinessLayer.DapperRepository;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer;

namespace DataAccessLayer.Dapper
{
    public class UserRoleDA : GenericRepositoryDap<UserRole>, IUserRoleDA
    {
        public UserRoleDA(NEUContext context) : base(context)
        {
        }
    }
}
