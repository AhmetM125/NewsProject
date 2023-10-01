using BusinessLayer.DapperRepository;
using DataAccessLayer.Dapper;
using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface IAdminDA : IRepositoryDAP<Admin>
    {
        Task<IEnumerable<Admin>> GetAllAdmins();
        Task<Admin> GetAdminById(Guid id);
        Task<bool> DeleteAdmin(Guid id);
        Task<bool> InsertAdmin(Admin admin);
        Task<bool> UpdateAdmin(Admin admin);

    }
}
