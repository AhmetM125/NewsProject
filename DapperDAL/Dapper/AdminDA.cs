using BusinessLayer.DapperRepository;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer;

namespace DataAccessLayer.Dapper
{
    public class AdminDA : GenericRepositoryDap<Admin>, IAdminDA
    {
        public AdminDA(NEUContext context) : base(context)
        {
        }
    }
}
