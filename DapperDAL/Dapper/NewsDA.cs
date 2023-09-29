using BusinessLayer.DapperRepository;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer;

namespace DataAccessLayer.Dapper
{
    public class NewsDA : GenericRepositoryDap<News>, INewDA
    {
        public NewsDA(NEUContext context) : base(context)
        {
        }
    }
}
