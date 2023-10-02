using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        Admin Login(string username, string password);
        List<Admin> GetAllAdmins();

        void DeleteAdmin(Guid? Id);
        Admin GetAdmin(Guid? Id);

        void EditAdmin(Admin admin);
        void NewAdmin(Admin admin);

    }
}
