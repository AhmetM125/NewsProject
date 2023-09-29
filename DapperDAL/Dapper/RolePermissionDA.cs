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
    }
}
