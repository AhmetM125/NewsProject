using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Abstract
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal adminDal;
        private readonly IAdminDA admintest;
        private readonly INewService _newService;

        public AdminManager(IAdminDal _adminDal, IAdminDA _adminDA, INewService newService)
        {
            adminDal = _adminDal;
            admintest = _adminDA;
            _newService = newService;

        }
        public Admin Login(string username, string password) => adminDal.Get(x => x.Username == username && x.Password == password);

        public List<Admin> GetAllAdmins()
        {
            var adminList = adminDal.List();
            return adminList;
        }

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
