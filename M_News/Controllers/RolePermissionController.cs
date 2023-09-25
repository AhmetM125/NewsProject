using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace M_News.Controllers
{
    public class RolePermissionController : Controller
    {
        RolePermissionManager rolePermission = new RolePermissionManager(new EfRolePermissionDal());
        public IActionResult Index()
        {
            return View();
        }
    }
}
