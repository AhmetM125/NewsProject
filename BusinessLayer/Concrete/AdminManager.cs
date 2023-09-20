using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public class AdminManager : IAdminService
    {
        IAdminDal AdminDal { get; set; }

        public AdminManager(IAdminDal _adminDal)
        {

            AdminDal = _adminDal;

        }
        public Admin Login(string username, string password) => AdminDal.Get(x => x.Username == username && x.Password == password);

        public List<Admin> GetAllAdmins() => AdminDal.List();

        public void DeleteAdmin(Guid Id)
        {
            AdminDal.Delete(AdminDal.Get(x => x.User_Id == Id));
        }

        public Admin GetAdmin(Guid Id)
        {
            return AdminDal.Get(x => x.User_Id == Id);
        }

        public void EditAdmin(Admin admin)
        {
            AdminDal.Update(admin);
        }

        public void NewAdmin(Admin admin)
        {
            admin.User_Id = Guid.NewGuid();
            admin.Role = "b";
            AdminDal.Insert(admin);
        }
    }
}
