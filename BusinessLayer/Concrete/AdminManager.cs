using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Abstract
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal adminDal;
        private readonly IAdminDA admintest;

        public AdminManager(IAdminDal _adminDal, IAdminDA _adminDA)
        {
            adminDal = _adminDal;
            admintest = _adminDA;
        }
        public Admin Login(string username, string password) => adminDal.Get(x => x.Username == username && x.Password == password);

        public async Task<List<Admin>> GetAllAdmins()
        {
            //list
            var listest = await admintest.GetAll();

            //delete
            var target = adminDal.Get(x => x.Name == "m");
            await admintest.Delete(target.User_Id);


            
            return adminDal.List();
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
