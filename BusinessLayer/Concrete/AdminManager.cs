using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace BusinessLayer.Abstract
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal adminDal;
        private readonly IAdminDA _adminDapper;
        private readonly ILogger<AdminManager> _logger;
        public AdminManager(IAdminDal _adminDal, IAdminDA _adminDA, ILogger<AdminManager> logger)
        {
            adminDal = _adminDal;
            _adminDapper = _adminDA;
            _logger = logger;
        }
        public Admin? Login(string username, string password) //CancellationToken cancellationToken
        {



            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    _logger.LogError("Invalid username or password");
                    return null;
                }
                else
                {
                    username.GetHashCode();
                    var admin = adminDal.Get(x => x.Username == username && x.Password == password);
                    return admin;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, $"SQL Exception occurred in Login method for user: {username}");
                throw;
            }

        }
        public async Task<List<Admin>> GetAllAdmins()
        {
            try
            {
                var AdminList = await _adminDapper.GetAll();
                return AdminList.ToList();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Exception occurred while getting the list of users");
                throw;
            }

        }

        public async Task<int> DeleteAdmin(Guid id)
        {
            try
            {
                var affectedRow = await _adminDapper.Delete(id.ToString());
                return affectedRow;

            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Exception occurred while deleting the user");
                throw;
            }
        }

        public async Task<Admin?> GetAdmin(Guid Id)
        {
            try
            {
                var admin = await _adminDapper.GetById(Id.ToString());
                return admin;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Exception occurred while getting the admin");
                throw;
            }
        }

        public async Task<bool> EditAdmin(Admin admin)
        {
            try
            {
                var result = await _adminDapper.Update(admin);
                return result;

            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Exception occurred while updating the admin");
                throw;
            }

        }

        public async Task<int> NewAdmin(Admin admin)
        {
            try
            {
                admin.User_Id = Guid.NewGuid();
                var Result = await _adminDapper.Insert(admin);
                return Result;

            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Exception occurred while creating a new admin");
                throw;
            }

        }


    }
}
