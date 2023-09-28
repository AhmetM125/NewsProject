using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal adminDal;

        public AdminManager(IAdminDal _adminDal)
        {
            adminDal = _adminDal;
        }
        public Admin Login(string username, string password) => adminDal.Get(x => x.Username == username && x.Password == password);

        public List<Admin> GetAllAdmins() => adminDal.List();

        public void DeleteAdmin(Guid id)
        {
            var obj = GetAdmin(id);
            adminDal.Delete(obj);
        }

        public Admin GetAdmin(Guid Id)
        {
            return adminDal.Get(x => x.User_Id == Id);
        }

        public void EditAdmin(Admin admin)
        {
            adminDal.Update(admin);
        }

        public void NewAdmin(Admin admin)
        {
            admin.User_Id = Guid.NewGuid();
            adminDal.Insert(admin);
        }

    }
}
