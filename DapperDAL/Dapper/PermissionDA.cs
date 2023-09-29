using BusinessLayer.DapperRepository;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer;

namespace DataAccessLayer.Dapper
{
    public class PermissionDA : GenericRepositoryDap<Permission>, IPermissionDA
    {
        public PermissionDA(NEUContext context) : base(context)
        {
        }
    }
}
