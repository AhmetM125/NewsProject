using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace BusinessLayer.Concrete
{
    public class PermissionManager : IPermissionService
    {
        private readonly IPermissionDA PermissionDal;
        private readonly ILogger<PermissionManager> _logger;
        public PermissionManager(IPermissionDA permissionDal, ILogger<PermissionManager> logger)
        {
            PermissionDal = permissionDal;
            _logger = logger;
        }

        public async Task<ICollection<Permission>> GetAllPermission()
        {
            try
            {
                var result = await PermissionDal.GetAll();
                return result.ToList();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Exception GetAll");
                throw;
            }
        }

        public async Task<Permission?> GetPermission(int id)
        {
            try
            {
                return await PermissionDal.GetById(id.ToString());

            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Exception GetPermission");

                throw;
            }
        }
        public async Task DeletePermission(Permission permission)
        {
            try
            {
                await PermissionDal.Delete(permission.Id.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SQL Exception DeletePermission");
                throw;
            }
        }

        public async Task CreatePermission(Permission permission)
        {
            try
            {
                if (permission is not null)
                    await PermissionDal.Insert(permission);

            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Exception CreatePermission");
                throw;
            }
        }

        public async Task UpdatePermission(Permission permission)
        {
            try
            {
                if (permission is not null)
                    await PermissionDal.Update(permission);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SQL Exception UpdatePermission");
                throw;
            }
        }
    }
}
