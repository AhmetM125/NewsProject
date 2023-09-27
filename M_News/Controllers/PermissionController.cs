using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using M_News.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace M_News.Controllers
{
    [AuthorizeY(Permission = "Permissions")]
    public class PermissionController : Controller
    {
        PermissionManager permissionManager = new PermissionManager(new EfPermissionDal());
        [HttpGet]
        public IActionResult Index()
        {
            ICollection<Permission> ListOfPermissions = permissionManager.GetAllPermission();
            return View(ListOfPermissions);
        }
        [HttpGet]
        public IActionResult EditPermission(int PermissionId)
        {
            Permission PermissionObj = permissionManager.GetPermission(PermissionId);
            return View(PermissionObj);
        }
        [HttpPost]
        public IActionResult EditPermission(Permission p)
        {
            permissionManager.UpdatePermission(p);
            return RedirectToAction("Index", "Permission");
        }

        [HttpGet]
        public IActionResult DeletePermission(int PermissionId)
        {
            permissionManager.DeletePermission(permissionManager.GetPermission(PermissionId));
            return RedirectToAction("Index","Permission");//
        }
        [HttpGet]
        public IActionResult CreatePermission()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePermission(Permission P)
        {
            permissionManager.CreatePermission(P);
            return RedirectToAction("Index","Permission");
            
        }
    }
}
