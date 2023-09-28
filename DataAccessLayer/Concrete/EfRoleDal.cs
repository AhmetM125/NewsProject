using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer;

namespace DataAccessLayer.Concrete
{
    public class EfRoleDal : GenericRepository<Role>, IRoleDal
    {
        public EfRoleDal(NEUContext context) : base(context)
        {
        }
    }
}
