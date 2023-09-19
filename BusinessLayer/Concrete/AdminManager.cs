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








    }
}
