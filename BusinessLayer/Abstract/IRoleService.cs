using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IRoleService
    {
        Role GetRoleById(int roleId);
        
    }
}
