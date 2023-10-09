using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer;
using File = EntityLayer.File;

namespace DataAccessLayer.Concrete
{
    public class EfFilesDal : GenericRepository<File>, IFilesDal
    {
        public EfFilesDal(NEUContext context) : base(context)
        {
        }
    }
}
