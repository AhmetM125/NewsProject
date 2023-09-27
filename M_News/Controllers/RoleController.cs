using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using M_News.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace M_News.Controllers
{
    [AuthorizeY(Permission = "Roles")]
    public class RoleController : Controller
    {

        RoleManager roleManager = new RoleManager(new EfRoleDal());
        RolePermissionManager RolePermission = new RolePermissionManager(new EfRolePermissionDal());
        PermissionManager PermissionManager = new PermissionManager(new EfPermissionDal());
        [HttpGet]
        public IActionResult Index()
        {
            var Roles = roleManager.GetAllRoles();
            return View(Roles);
        }
        [HttpGet]
        public IActionResult EditRole(int RoleId)
        {
            return View(roleManager.GetRoleById(RoleId));
        }
        [HttpPost]
        public IActionResult EditRole(Role p)
        {
            roleManager.UpdateRole(p);
            return RedirectToAction("Index", "Role");
        }
        public IActionResult DeleteRole(int RoleId)
        {
            var RoleValue = roleManager.GetRoleById(RoleId);
            roleManager.DeleteRole(RoleValue);
            return RedirectToAction("Index", "Role");
        }
        [HttpGet]
        public IActionResult NewRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewRole(Role p)
        {
            roleManager.NewRole(p);
            return RedirectToAction("Index", "Role");
        }


        //ROLEPERMISSION
        public IActionResult EditPermissions(int RoleId)
        {
            var Role = roleManager.GetRoleById(RoleId);
            var PermissionList = RolePermission.GetRolePermissionById(RoleId);
            foreach (var item in PermissionList)
            {
                item.Permission = PermissionManager.GetPermission(item.PermissionId);
                item.Role = roleManager.GetRoleById(item.RoleId);
            }
            ViewBag.RoleId = RoleId;
            return View(PermissionList);
        }
        [HttpGet]
        public IActionResult DeletePermissionOfRole(int RoleId, int PermissionId)
        {
            var RolePermissionValue = RolePermission.GetRolePermissionById(RoleId, PermissionId);
            RolePermission.DeleteRolePermission(RolePermissionValue);
            return RedirectToAction("Index", "RolePermission");
        }
        [HttpGet]
        public IActionResult NewPermissionForRole(int RoleId)
        {
            List<RolePermission> valuesToCheck = RolePermission.GetAllRolePermission().Where(x => x.RoleId != RoleId).ToList();

            IEnumerable<SelectListItem> Permissions_ListItem = (from x in PermissionManager.GetAllPermission()
                                                                select new SelectListItem

                                                                {
                                                                    Value = x.Id.ToString(),
                                                                    Text = x.Title
                                                                });

            ViewBag.Permissions = Permissions_ListItem;

            ViewBag.RoleId = RoleId;
            return View();
        }
        [HttpPost]
        public IActionResult NewPermissionForRole(RolePermission p)
        {
            var IsExist = RolePermission.GetRolePermissionById(p.RoleId, p.PermissionId);
            if (IsExist is null)
                RolePermission.CreatePermission(p);
            return RedirectToAction("Index", "Role");
        }



    }
}
