using BusinessLayer.DapperRepository;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer;

namespace DataAccessLayer.Dapper
{
    public class RoleDA : GenericRepositoryDap<Role>, IRoleDA
    {
        public RoleDA(NEUContext context) : base(context)
        {
        }
    }
}
