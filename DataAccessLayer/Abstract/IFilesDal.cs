using DataAccessLayer.Repositories;
using EntityLayer;
using File = EntityLayer.File;

namespace DataAccessLayer.Abstract
{
    public interface IFilesDal : IRepository<File>
    {

    }
}
