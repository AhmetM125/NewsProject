using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        Admin? Login(string username, string password);
        Task<List<Admin>> GetAllAdmins();

        Task<int> DeleteAdmin(Guid id);
        Task<Admin?> GetAdmin(Guid Id);

        Task<bool> EditAdmin(Admin admin);
        Task<int> NewAdmin(Admin admin);

    }
}
