using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete
{
    public class EfRoleDal : GenericRepository<Role>, IRoleDal
    {
    }
}
