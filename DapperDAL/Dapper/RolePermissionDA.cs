using BusinessLayer.DapperRepository;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer;

namespace DataAccessLayer.Dapper
{
    public class RolePermissionDA : GenericRepositoryDap<RolePermission>, IRolePermissionDa
    {
        public RolePermissionDA(NEUContext context) : base(context)
        {
        }

        public Task<bool> CreateRolePermissionAsync(RolePermission RolePermission)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRolePermissionById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RolePermission>> GetAllRolePermissionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RolePermission> GetRolePermissionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRolePermission(RolePermission RolePermission)
        {
            throw new NotImplementedException();
        }
    }
}
