using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace M_News.Controllers
{
    //will not use 
    public class RolePermissionController : Controller
    {
        /*RolePermissionManager rolePermission = new RolePermissionManager(new EfRolePermissionDal());
        RoleManager roleManager = new RoleManager(new EfRoleDal());
        PermissionManager PermissionManager = new PermissionManager(new EfPermissionDal());
        public IActionResult Index(int page = 1)
        {
            var RolePermissions = rolePermission.GetAllRolePermission();
            foreach (var item in RolePermissions)
            {
                item.Role = roleManager.GetRoleById(item.RoleId);
                item.Permission = PermissionManager.GetPermission(item.PermissionId);
            }

            return View(RolePermissions.ToPagedList(page, 10));
        }
        [HttpGet]
        public IActionResult DeletePermissionOfRole(int RoleId, int PermissionId)
        {
            var RolePermissionValue = rolePermission.GetRolePermissionById(RoleId, PermissionId);
            rolePermission.DeleteRolePermission(RolePermissionValue);
            return RedirectToAction("Index", "RolePermission");
        }
        [HttpPost]
        public IActionResult EditPermissions(int RoleId, int PermissionId)
        {
            return View();
        }*/
    }
}
