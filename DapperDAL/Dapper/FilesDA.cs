using BusinessLayer.DapperRepository;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer;

namespace DataAccessLayer.Dapper
{
    public class FilesDA : GenericRepositoryDap<Files>, IFilesDA
    {
        public FilesDA(NEUContext context) : base(context)
        {
        }
    }
}
