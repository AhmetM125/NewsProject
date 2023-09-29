using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer;

namespace DataAccessLayer.Concrete
{
    public class EfFilesDal : GenericRepository<Files>, IFilesDal
    {
        public EfFilesDal(NEUContext context) : base(context)
        {
        }
    }
}
