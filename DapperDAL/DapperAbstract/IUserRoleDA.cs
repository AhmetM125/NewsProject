using BusinessLayer.DapperRepository;
using DataAccessLayer.Dapper;
using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface IUserRoleDA : IRepositoryDAP<UserRole>
    {
    }
}
